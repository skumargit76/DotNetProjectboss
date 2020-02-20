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
    /// Summary description for WSFEEUPLOADINPUT
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WSFEEUPLOADINPUT : System.Web.Services.WebService
    {

        [WebMethod]
        public Tmp_XML_Response_WSFEEUPLOADINPUT_DTO DoWsFeeUploadInput(Tmp_XML_Request_WSFEEUPLOADINPUT_DTO xmlReqObj)
        {
            string TWSEE_WS_WSFEEUPLOADINPUT_URL = ExtensionMethods.JBOSSServerPath;
            string xmlRequestTmpPath = ExtensionMethods.XMLTemplateInputRequestPath;
           
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(TWSEE_WS_WSFEEUPLOADINPUT_URL);
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml; encoding= 'utf-8'";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            XmlDocument xmlRequest = new XmlDocument();
            xmlRequest.Load(Server.MapPath(xmlRequestTmpPath));
            XmlElement xmlRoot = xmlRequest.DocumentElement;
            XmlNamespaceManager requestManager = new XmlNamespaceManager(xmlRequest.NameTable);
            requestManager.AddNamespace("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
            requestManager.AddNamespace("t24", "T24WebServicesImpl");

            XmlNodeList nodes = xmlRoot.SelectNodes("/soapenv:Envelope/soapenv:Body/t24:WSFEEUPLOADINPUT/WebRequestCommon", requestManager);
            foreach (XmlNode node in nodes)
            {
                node["userName"].InnerText = xmlReqObj.authoriseInfo.userName;
                node["password"].InnerText = xmlReqObj.authoriseInfo.password;
                node["company"].InnerText = xmlReqObj.authoriseInfo.company;
            }

            XmlNode fundTransferNode = xmlRoot.SelectSingleNode("/soapenv:Envelope/soapenv:Body/t24:WSFEEUPLOADINPUT/FUNDSTRANSFERMHCBMYACTRFTHPType", requestManager);
            fundTransferNode.Attributes[0].Value = xmlReqObj.transactiondDetails.fundTransferMhcbmyactrfthpTypeAttribute;

            nodes = xmlRoot.SelectNodes("/soapenv:Envelope/soapenv:Body/t24:WSFEEUPLOADINPUT/FUNDSTRANSFERMHCBMYACTRFTHPType", requestManager);
            foreach (XmlNode node in nodes)
            {
                node["gORDERINGCUST"].Attributes[0].Value = xmlReqObj.transactiondDetails.gOderingCustAttribute;
                node["gPAYMENTDETAILS"].Attributes[0].Value = xmlReqObj.transactiondDetails.gPaymentDetailsAttribute;
                node["gDELIVERYOUTREF"].Attributes[0].Value = xmlReqObj.transactiondDetails.gDeliveryOutRefAttribute;
                node["gSIGNATORY"].Attributes[0].Value = xmlReqObj.transactiondDetails.gSignatoryAttribute;
                node["TransactionType"].InnerText = xmlReqObj.transactiondDetails.transactionType;
                node["DebitAccount"].InnerText = Convert.ToString(xmlReqObj.transactiondDetails.debitAccount);
                node["DebitCurrency"].InnerText = xmlReqObj.transactiondDetails.debitCurrency;
                node["DebitAmount"].InnerText = Convert.ToString(xmlReqObj.transactiondDetails.debitAmount);
                node["DebitValueDate"].InnerText = xmlReqObj.transactiondDetails.debitValueDate;
                node["DebitNarrative"].InnerText = xmlReqObj.transactiondDetails.debitNarrative;
                node["CreditNarrative"].InnerText = xmlReqObj.transactiondDetails.creditNarrative;
                node["CreditAccount"].InnerText = xmlReqObj.transactiondDetails.creditAccount;
                node["CreditCurrency"].InnerText = xmlReqObj.transactiondDetails.creditCurrency;
                node["CreditAmount"].InnerText = Convert.ToString(xmlReqObj.transactiondDetails.creditAmount);
                node["CreditValueDate"].InnerText = xmlReqObj.transactiondDetails.creditValueDate;

                XmlNodeList subRoot = node.SelectNodes("/soapenv:Envelope/soapenv:Body/t24:WSFEEUPLOADINPUT/FUNDSTRANSFERMHCBMYACTRFTHPType/gORDERINGCUST", requestManager);
                int i = 0;
                foreach (XmlNode subNode in subRoot)
                {
                    if (xmlReqObj.transactiondDetails.orderedBy.Count > 0)
                    {
                        subNode["OrderedBy"].InnerText = xmlReqObj.transactiondDetails.orderedBy[i];
                        i++;
                    }
                }

                subRoot = node.SelectNodes("/soapenv:Envelope/soapenv:Body/t24:WSFEEUPLOADINPUT/FUNDSTRANSFERMHCBMYACTRFTHPType/gPAYMENTDETAILS", requestManager);
                i = 0;
                foreach (XmlNode subNode in subRoot)
                {
                    if (xmlReqObj.transactiondDetails.paymentDetails.Count > 0)
                    {

                        subNode["PaymentDetails"].InnerText = xmlReqObj.transactiondDetails.paymentDetails[i];
                        i++;
                    }
                }

                subRoot = node.SelectNodes("/soapenv:Envelope/soapenv:Body/t24:WSFEEUPLOADINPUT/FUNDSTRANSFERMHCBMYACTRFTHPType/gDELIVERYOUTREF", requestManager);
                i = 0;
                foreach (XmlNode subNode in subRoot)
                {
                    if (xmlReqObj.transactiondDetails.deliveryOutRef.Count > 0)
                    {                 
                            subNode["DeliveryReference"].InnerText = xmlReqObj.transactiondDetails.deliveryOutRef[i];
                            i++;
                    }
                }

                subRoot = node.SelectNodes("/soapenv:Envelope/soapenv:Body/t24:WSFEEUPLOADINPUT/FUNDSTRANSFERMHCBMYACTRFTHPType/gSIGNATORY", requestManager);
                i = 0;
                foreach (XmlNode subNode in subRoot)
                {
                    if (xmlReqObj.signatory.Count > 0)
                    {
                        subNode["Signatory"].InnerText = xmlReqObj.signatory[i];
                    i++;
                    }
                }
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

            XmlNamespaceManager responseManager = new XmlNamespaceManager(soapResponseXml.NameTable);
            responseManager.AddNamespace("S", "http://schemas.xmlsoap.org/soap/envelope/");
            responseManager.AddNamespace("ns2", "T24WebServicesImpl");

            Tmp_XML_Response_WSFEEUPLOADINPUT_DTO ResObj = new Tmp_XML_Response_WSFEEUPLOADINPUT_DTO();
            XmlNode root = soapResponseXml.SelectSingleNode("/S:Envelope/S:Body/ns2:WSFEEUPLOADINPUTResponse/Status", responseManager);
            ResObj.authoriseInfo.transactionId = root.SelectSingleNode("transactionId").InnerText;
            ResObj.authoriseInfo.successIndicator = root.SelectSingleNode("successIndicator").InnerText;
            ResObj.authoriseInfo.application = root.SelectSingleNode("application").InnerText;

            //if T24 Sucess then only read rest of data
            if (ResObj.authoriseInfo.successIndicator == "Success")
            {

                XmlNode subroot = soapResponseXml.SelectSingleNode("/S:Envelope/S:Body/ns2:WSFEEUPLOADINPUTResponse/FUNDSTRANSFERType", responseManager);
                ResObj.transactionDetails.fundTransferMhcbmyactrfthpTypeAttribute = soapResponseXml.Attributes[0].InnerText;
                XmlNodeList nodelist = subroot.ChildNodes;
                ResObj.transactionDetails.transactionType = nodelist[0].InnerText;
                ResObj.transactionDetails.debitAccount = Convert.ToInt64(nodelist[1].InnerText);
                ResObj.transactionDetails.currencyMkTdr = nodelist[2].InnerText;
                ResObj.transactionDetails.debitCurrency = nodelist[3].InnerText;
                ResObj.transactionDetails.debitAmount = Convert.ToDouble(nodelist[4].InnerText);
                ResObj.transactionDetails.debitValueDate = nodelist[5].InnerText;
                ResObj.transactionDetails.debitTheirRef = nodelist[6].InnerText;
                ResObj.transactionDetails.creditTheirRef = nodelist[7].InnerText;
                ResObj.transactionDetails.creditAccount = nodelist[8].InnerText;
                ResObj.transactionDetails.currencyMkTcr = nodelist[9].InnerText;
                ResObj.transactionDetails.creditCurrency = nodelist[10].InnerText;
                ResObj.transactionDetails.creditValueDate = nodelist[11].InnerText;
                ResObj.transactionDetails.processingDate = nodelist[12].InnerText;
                XmlNodeList subnodes = nodelist[13].ChildNodes;
                foreach (XmlNode subNode in subnodes)
                {
                    ResObj.transactionDetails.paymentDetails.Add(subNode.InnerText);
                }
                ResObj.transactionDetails.chargeComDisplay = nodelist[14].InnerText;
                ResObj.transactionDetails.commissionCode = nodelist[15].InnerText;
                ResObj.transactionDetails.chargeCode = nodelist[16].InnerText;
                ResObj.transactionDetails.profitCentreCust = nodelist[17].InnerText;
                ResObj.transactionDetails.returnToDept = nodelist[18].InnerText;
                ResObj.transactionDetails.fedFunds = nodelist[19].InnerText;
                ResObj.transactionDetails.positionType = nodelist[20].InnerText;
                ResObj.transactionDetails.amountDebited = nodelist[21].InnerText;
                ResObj.transactionDetails.amountCredited = nodelist[22].InnerText;
                ResObj.transactionDetails.creditCompCode = nodelist[23].InnerText;
                ResObj.transactionDetails.locAmtDebited = Convert.ToDouble(nodelist[24].InnerText);
                ResObj.transactionDetails.locAmtCredited = Convert.ToDouble(nodelist[24].InnerText);
                ResObj.transactionDetails.custGroupLevel = Convert.ToInt32(nodelist[25].InnerText);
                ResObj.transactionDetails.debitCustomer = Convert.ToInt32(nodelist[26].InnerText);
                ResObj.transactionDetails.drAdviceReqdYN = nodelist[27].InnerText;
                ResObj.transactionDetails.crAdviceReqdYN = nodelist[28].InnerText;
                ResObj.transactionDetails.chargedCustomer = Convert.ToInt32(nodelist[29].InnerText);
                ResObj.transactionDetails.toTrecComm= Convert.ToInt32(nodelist[30].InnerText);
                ResObj.transactionDetails.toRecCommLcl= Convert.ToInt32(nodelist[31].InnerText);
                  ResObj.transactionDetails.totRecChg= Convert.ToInt32(nodelist[32].InnerText);
                  ResObj.transactionDetails.totRecChgLcl= Convert.ToInt32(nodelist[33].InnerText);
                  ResObj.transactionDetails.rateFixing= nodelist[34].InnerText;
                  ResObj.transactionDetails.totRecChgCrccy= Convert.ToInt32(nodelist[35].InnerText);
                  ResObj.transactionDetails.totSndChgCrccy= Convert.ToInt32(nodelist[36].InnerText);
                  ResObj.transactionDetails.roundType= Convert.ToInt32(nodelist[37].InnerText);
                              subnodes = nodelist[38].ChildNodes;
                                foreach (XmlNode subNode in subnodes)
                                {
                                    ResObj.transactionDetails.stmtnos.Add(subNode.InnerText);
                                }

                                 subnodes = nodelist[39].ChildNodes;
                                foreach (XmlNode subNode in subnodes)
                                {
                                    ResObj.transactionDetails.gOverride.Add(subNode.InnerText);
                                }

                  ResObj.transactionDetails.recordStatusByName = nodelist[40].InnerText;
                  ResObj.transactionDetails.currNo = nodelist[41].InnerText; 
                             subnodes = nodelist[42].ChildNodes;
                                foreach (XmlNode subNode in subnodes)
                                {
                                    ResObj.transactionDetails.inputter.Add(subNode.InnerText);
                                }

                                subnodes = nodelist[43].ChildNodes;
                                foreach (XmlNode subNode in subnodes)
                                {
                                    ResObj.transactionDetails.dateTime.Add(subNode.InnerText);
                                }
                  ResObj.transactionDetails.coCode = nodelist[44].InnerText;
                  ResObj.transactionDetails.deptCode = Convert.ToInt32(nodelist[45].InnerText);
                            }

            //store response in database and update log
            Mboss.DataAccess.WebServices.UpdateXMLLogDta updateLog = new Mboss.DataAccess.WebServices.UpdateXMLLogDta();
            //updateLog.UpdateXMLLog(1, logId, ResObj);

            return ResObj;
        }
    }
}
