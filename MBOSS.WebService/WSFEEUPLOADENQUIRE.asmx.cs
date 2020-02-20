using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Mboss.DataAccessObject;
using System.Xml;
using System.Net;
using System.IO;
using Mboss.Common;
using Mboss.DataAccess;

namespace MBOSS.WebService
{
    /// <summary>
    /// Summary description for WSFEEUPLOADENQUIRE
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WSFEEUPLOADENQUIRE : System.Web.Services.WebService
    {

        [WebMethod]
        public Tmp_XML_Response_WSFEEUPLOADENQUIRE_DTO DoWsFeeUploadAuthorise(Tmp_XML_Request_WSFEEUPLOADENQUIRE_DTO xmlReqObj)
        {
            string TWSEE_WS_WSFEEUPLOADENQUIRE_URL = ExtensionMethods.JBOSSServerPath;
            string xmlRequestTmpPath = ExtensionMethods.XMLTemplateEnquireRequestPath;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(TWSEE_WS_WSFEEUPLOADENQUIRE_URL);
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml; encoding= 'utf-8'";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            XmlDocument xmlRequest = new XmlDocument();
            xmlRequest.Load(xmlRequestTmpPath);
            XmlElement xmlRoot = xmlRequest.DocumentElement;
            XmlNamespaceManager requestManager = new XmlNamespaceManager(xmlRequest.NameTable);
            requestManager.AddNamespace("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
            requestManager.AddNamespace("t24", "T24WebServicesImpl");
            XmlNodeList nodes = xmlRoot.SelectNodes("/soapenv:Envelope/soapenv:Body/t24:WSFEEUPLOADENQUIRE/WebRequestCommon");
            foreach (XmlNode node in nodes)
            {
                node["userName"].InnerText = xmlReqObj.authorisationInfo.userName;
                node["password"].InnerText = xmlReqObj.authorisationInfo.password;
                node["company"].InnerText = xmlReqObj.authorisationInfo.company;              
            }

            //insert log in MBOSS Database
            Mboss.DataAccess.WebServices.InsertXMLLogDta logData = new Mboss.DataAccess.WebServices.InsertXMLLogDta();
            decimal logId = logData.LogXMLRequest(xmlReqObj);

            //Call the web service
            XmlDocument soapResponseXml = new XmlDocument();
            using (Stream stream = webRequest.GetRequestStream())
            {
                byte[] bytes;
                bytes = System.Text.Encoding.ASCII.GetBytes(xmlRequest.InnerXml);
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();
            }


            using (WebResponse response = webRequest.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    string soapResult = rd.ReadToEnd();
                    soapResponseXml.LoadXml(soapResult);
                }
            }

            XmlNamespaceManager responseManager = new XmlNamespaceManager(soapResponseXml.NameTable);
            responseManager.AddNamespace("S", "http://schemas.xmlsoap.org/soap/envelope/");
            responseManager.AddNamespace("ns2", "T24WebServicesImpl");
            //read the response
            Tmp_XML_Response_WSFEEUPLOADENQUIRE_DTO ResObj = new Tmp_XML_Response_WSFEEUPLOADENQUIRE_DTO();
            XmlNode root = soapResponseXml.SelectSingleNode("/S:Envelope/S:Body/ns2:WSFEEUPLOADENQUIREResponse/Status");
            ResObj.authorisationInfo.transactionId = root.SelectSingleNode("transactionId").InnerText;
            ResObj.authorisationInfo.successIndicator = root.SelectSingleNode("successIndicator").InnerText;
            ResObj.authorisationInfo.application = root.SelectSingleNode("application").InnerText;

            if (ResObj.authorisationInfo.successIndicator == "Success")
            {
                XmlNode subroot = soapResponseXml.SelectSingleNode("/S:Envelope/S:Body/ns2:WSFEEUPLOADENQUIREResponse/FUNDSTRANSFERType");             
                ResObj.transactionDetails.recordStatusByName = subroot.SelectSingleNode("RECORDSTATUS").InnerText;
            }

            //store response in database and update log
            Mboss.DataAccess.WebServices.UpdateXMLLogDta updateLog = new Mboss.DataAccess.WebServices.UpdateXMLLogDta();
            //updateLog.UpdateXMLLog(1, logId, ResObj);  
            return ResObj;
        }
    }
}
