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
using Mboss.DataAccessObject;
using System.Xml;
using System.Net;
using System.IO;
using Mboss.Common;
using Mboss.DataAccess;

namespace MBOSS.WebService
{
    /// <summary>
    /// Summary description for WSFEEUPLOADREVERSE
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WSFEEUPLOADREVERSE : System.Web.Services.WebService
    {

        [WebMethod]
        public Tmp_XML_Response_WSFEEUPLOADREVERSE_DTO DoWsFeeUploadInput(Tmp_XML_Request_WSFEEUPLOADREVERSE_DTO xmlReqObj)
        {
            string TWSEE_WS_WSFEEUPLOADREVERSE_URL = ExtensionMethods.JBOSSServerPath;
            string xmlRequestTmpPath = ExtensionMethods.XMLTemplateReverseRequestPath;

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(TWSEE_WS_WSFEEUPLOADREVERSE_URL);
            webRequest.ContentType = "text/xml; encoding= 'utf-8'";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            XmlDocument xmlRequest = new XmlDocument();
            xmlRequest.Load(xmlRequestTmpPath);
            XmlElement xmlRoot = xmlRequest.DocumentElement;
            XmlNodeList nodes = xmlRoot.SelectNodes("/soapenv:Envelope/soapenv:Body/t24:WSFEEUPLOADREVERSE/WebRequestCommon");

            foreach (XmlNode node in nodes)
            {
                node["userName"].InnerText = xmlReqObj.authoriseInfo.userName;
                node["password"].InnerText = xmlReqObj.authoriseInfo.password;
                node["company"].InnerText = xmlReqObj.authoriseInfo.company;
            }


            nodes = xmlRoot.SelectNodes("/soapenv:Envelope/soapenv:Body/t24:WSFEEUPLOADREVERSE/FUNDSTRANSFERAUTHType");
            foreach (XmlNode node in nodes)
            {
                node["transactionId"].InnerText = xmlReqObj.authoriseInfo.transactionId;
            }

            //insert log in MBOSS Database
            Mboss.DataAccess.WebServices.InsertXMLLogDta logData = new Mboss.DataAccess.WebServices.InsertXMLLogDta();
            //decimal logId = logData.LogXMLRequest(xmlReqObj);

            decimal logId = 0;
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


            //read the response
            Tmp_XML_Response_WSFEEUPLOADREVERSE_DTO ResObj = new Tmp_XML_Response_WSFEEUPLOADREVERSE_DTO();
            XmlNode root = soapResponseXml.SelectSingleNode("/S:Envelope/S:Body/ns2:WSFEEUPLOADREVERSEResponse/Status");
            ResObj.authoriseInfo.transactionId = root.SelectSingleNode("transactionId").InnerText;
            ResObj.authoriseInfo.successIndicator = root.SelectSingleNode("successIndicator").InnerText;
            ResObj.authoriseInfo.application = root.SelectSingleNode("application").InnerText;

            //if T24 Sucess then only read rest of data
            if (ResObj.authoriseInfo.successIndicator == "Success")
            {
               
                XmlNode subroot = soapResponseXml.SelectSingleNode("/S:Envelope/S:Body/ns2:WSFEEUPLOADREVERSEResponse/FUNDSTRANSFERType");
                ResObj.transactionDetails.recordStatusByName = root.SelectSingleNode("RECORDSTATUS").InnerText;
            }

            //store response in database and update log
            Mboss.DataAccess.WebServices.UpdateXMLLogDta updateLog = new Mboss.DataAccess.WebServices.UpdateXMLLogDta();
            //updateLog.UpdateXMLLog(1, logId, ResObj);
            
            return ResObj;
        }
    }
}
