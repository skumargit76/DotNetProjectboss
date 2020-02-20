using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mboss.DataAccessObject;

namespace Mboss.Common
{
    public class MbossValidation
    {
        public static bool ValidateFeeUploadTRN(object trnObj, ref List<string> errFieldName)
        {
            //Get Class name
            string objClassType = trnObj.GetType().Name.ToString();

            bool resultFlag = false; // If all mandatory field pass/valid then make it true else false
            //Get the values here
            switch (objClassType)
            {
                case "Tmp_XML_Request_WSFEEUPLOADINPUT_DTO":
                    Tmp_XML_Request_WSFEEUPLOADINPUT_DTO reqObjInput = new Tmp_XML_Request_WSFEEUPLOADINPUT_DTO();
                    reqObjInput = trnObj as Tmp_XML_Request_WSFEEUPLOADINPUT_DTO;
                    //Make Result flag true
                    resultFlag = true;
                    //Check Mandatory fields
                    if (reqObjInput.authoriseInfo.userName.IsNullOrEmpty())
                    {
                        resultFlag = false;
                        errFieldName.Add("UserName");
                    }
                    if (reqObjInput.authoriseInfo.password.IsNullOrEmpty())
                    {
                        resultFlag = false;
                        errFieldName.Add("Password");
                    }
                    if (reqObjInput.authoriseInfo.company.IsNullOrEmpty())
                    {
                        resultFlag = false;
                        errFieldName.Add("Company");
                    }
                    //fundTransferMhcbmyactrfthpTypeAttribute (optional if txn = 'new', mandatory if txn='modify'
                    //if (!reqObjInput.transactiondDetails.T24TransactionID.IsNullOrEmpty())
                    if (!reqObjInput.authoriseInfo.transactionId.IsNullOrEmpty())
                    {
                        if (reqObjInput.transactiondDetails.fundTransferMhcbmyactrfthpTypeAttribute.IsNullOrEmpty())
                        {
                            resultFlag = false;
                            errFieldName.Add("fundTransferMhcbmyactrfthpTypeAttribute");
                        }
                    }
                    // Starts txn = 'new' T24TransactionID is empty
                    //if (reqObjInput.transactiondDetails.T24TransactionID.IsNullOrEmpty())
                    if (reqObjInput.authoriseInfo.transactionId.IsNullOrEmpty())
                    {
                        //TransactionType
                        if (reqObjInput.transactiondDetails.transactionType.IsNullOrEmpty())
                        {
                            resultFlag = false;
                            errFieldName.Add("transactionType");
                        }
                        //need to confirm with barton weather it is INT or String
                        if (reqObjInput.transactiondDetails.debitAccount <= 0)
                        {
                            resultFlag = false;
                            errFieldName.Add("debitAccount");
                        }
                        if (reqObjInput.transactiondDetails.debitCurrency.IsNullOrEmpty())
                        {
                            resultFlag = false;
                            errFieldName.Add("debitCurrency");
                        }
                        if (reqObjInput.transactiondDetails.debitAmount <= 0)
                        {
                            resultFlag = false;
                            errFieldName.Add("debitAmount");
                        }
                        if (reqObjInput.transactiondDetails.debitValueDate.IsNullOrEmpty())
                        {
                            resultFlag = false;
                            errFieldName.Add("debitValueDate");
                        }
                        if (reqObjInput.transactiondDetails.debitNarrative.IsNullOrEmpty())
                        {
                            resultFlag = false;
                            errFieldName.Add("debitNarrative");
                        }
                        if (reqObjInput.transactiondDetails.creditNarrative.IsNullOrEmpty())
                        {
                            resultFlag = false;
                            errFieldName.Add("creditNarrative");
                        }

                        if (reqObjInput.transactiondDetails.creditAccount.IsNullOrEmpty())
                        {
                            resultFlag = false;
                            errFieldName.Add("creditAccount");
                        }
                        if (reqObjInput.transactiondDetails.creditCurrency.IsNullOrEmpty())
                        {
                            resultFlag = false;
                            errFieldName.Add("creditCurrency");
                        }
                        if (reqObjInput.transactiondDetails.creditAmount <= 0)
                        {
                            resultFlag = false;
                            errFieldName.Add("creditAmount");
                        }
                        if (reqObjInput.transactiondDetails.creditValueDate.IsNullOrEmpty())
                        {
                            resultFlag = false;
                            errFieldName.Add("creditValueDate");
                        }

                    }
                    // End txn = 'new' T24TransactionID is empty
                    if (reqObjInput.transactiondDetails.gOderingCustAttribute.IsNullOrEmpty())
                    {
                        resultFlag = false;
                        errFieldName.Add("gOderingCustAttribute");
                    }
                    if (reqObjInput.transactiondDetails.gPaymentDetailsAttribute.IsNullOrEmpty())
                    {
                        resultFlag = false;
                        errFieldName.Add("gPaymentDetailsAttribute");
                    }
                    if (reqObjInput.transactiondDetails.gDeliveryOutRefAttribute.IsNullOrEmpty())
                    {
                        resultFlag = false;
                        errFieldName.Add("gDeliveryOutRefAttribute");
                    }
                    if (reqObjInput.transactiondDetails.gSignatoryAttribute.IsNullOrEmpty())
                    {
                        resultFlag = false;
                        errFieldName.Add("gSignatoryAttribute");
                    }
                    //Check Mandatory fields - End
                    break;
                case "Tmp_XML_Response_WSFEEUPLOADINPUT_DTO":
                    Tmp_XML_Response_WSFEEUPLOADINPUT_DTO resObjInput = new Tmp_XML_Response_WSFEEUPLOADINPUT_DTO();
                    //convert type
                    resObjInput = trnObj as Tmp_XML_Response_WSFEEUPLOADINPUT_DTO;
                    //Make Result flag true
                    resultFlag = true;
                    //Check Mandatory fields - Starts
                    if (resObjInput.transactionDetails.T24TransactionID.IsNullOrEmpty())
                    {
                        resultFlag = false;
                        errFieldName.Add("T24TransactionID");
                    }
                    if (resObjInput.authoriseInfo.successIndicator.IsNullOrEmpty())
                    {
                        resultFlag = false;
                        errFieldName.Add("successIndicator");
                    }
                    if (resObjInput.authoriseInfo.message.IsNullOrEmpty())
                    {
                        resultFlag = false;
                        errFieldName.Add("message");
                    }
                    // need to confirm - fundTransferType or fundTransferMhcbmyactrfthpType
                    if (resObjInput.transactionDetails.fundTransferMhcbmyactrfthpTypeAttribute.IsNullOrEmpty())
                    {
                        resultFlag = false;
                        errFieldName.Add("fundTransferMhcbmyactrfthpTypeAttribute");
                    }
                    if (resObjInput.transactionDetails.gOverride == null)
                    {
                        resultFlag = false;
                        errFieldName.Add("gOverride");
                    }
                    if (resObjInput.transactionDetails.recordStatusByName.IsNullOrEmpty())
                    {
                        resultFlag = false;
                        errFieldName.Add("recordStatusByName");
                    }

                    //Check Mandatory fields - End

                    break;
                case "Tmp_XML_Request_WSFEEUPLOADDELETE_DTO":
                    Tmp_XML_Request_WSFEEUPLOADDELETE_DTO reqObjDel = new Tmp_XML_Request_WSFEEUPLOADDELETE_DTO();
                    //convert type
                    reqObjDel = trnObj as Tmp_XML_Request_WSFEEUPLOADDELETE_DTO;
                    //Make Result flag true
                    resultFlag = true;
                    //Check Mandatory fields - Starts
                    if (reqObjDel.authorisationInfo.userName.IsNullOrEmpty())
                    {
                        resultFlag = false;
                        errFieldName.Add("userName");
                    }
                    if (reqObjDel.authorisationInfo.password.IsNullOrEmpty())
                    {
                        resultFlag = false;
                        errFieldName.Add("password");
                    }
                    if (reqObjDel.authorisationInfo.company.IsNullOrEmpty())
                    {
                        resultFlag = false;
                        errFieldName.Add("company");
                    }
                    if (reqObjDel.authorisationInfo.transactionId.IsNullOrEmpty())
                    {
                        resultFlag = false;
                        errFieldName.Add("transactionId");
                    }

                    //Check Mandatory fields - End

                    break;
                case "Tmp_XML_Response_WSFEEUPLOADDELETE_DTO":
                    Tmp_XML_Response_WSFEEUPLOADDELETE_DTO resObjDel = new Tmp_XML_Response_WSFEEUPLOADDELETE_DTO();
                    //convert type
                    resObjDel = trnObj as Tmp_XML_Response_WSFEEUPLOADDELETE_DTO;
                    //Make Result flag true
                    resultFlag = true;
                    //Check Mandatory fields - Starts
                    if (resObjDel.authorisationInfo.transactionId.IsNullOrEmpty())
                    {
                        resultFlag = false;
                        errFieldName.Add("transactionId");
                    }

                    if (resObjDel.authorisationInfo.successIndicator.IsNullOrEmpty())
                    {
                        resultFlag = false;
                        errFieldName.Add("successIndicator");
                    }
                    if (resObjDel.authorisationInfo.message.IsNullOrEmpty())
                    {
                        resultFlag = false;
                        errFieldName.Add("message");
                    }
                    // need to confirm the field is correct or not
                    if (resObjDel.transactionDetails.fundTransferMhcbmyactrfthpTypeAttribute.IsNullOrEmpty ())
                    {
                        resultFlag = false;
                        errFieldName.Add("fundTransferMhcbmyactrfthpTypeAttribute");
                    }


                    //Check Mandatory fields - End

                    break;


                case "Tmp_XML_Request_WSFEEUPLOADAUTHORISE_DTO":
                    Tmp_XML_Request_WSFEEUPLOADAUTHORISE_DTO reqObjAuth = new Tmp_XML_Request_WSFEEUPLOADAUTHORISE_DTO();
                    //convert type
                    reqObjAuth = trnObj as Tmp_XML_Request_WSFEEUPLOADAUTHORISE_DTO;
                    //Make Result flag true
                    resultFlag = true;
                    //Check Mandatory fields - Starts
                    if (reqObjAuth.authoriseInfo.userName.IsNullOrEmpty ())
                    {
                        resultFlag = false;
                        errFieldName.Add("userName");
                    }
                    if (reqObjAuth.authoriseInfo.password.IsNullOrEmpty ())
                    {
                        resultFlag = false;
                        errFieldName.Add("password");
                    }
                    if (reqObjAuth.authoriseInfo.company.IsNullOrEmpty())
                    {
                        resultFlag = false;
                        errFieldName.Add("company");
                    }
                    if (reqObjAuth.authoriseInfo.transactionId.IsNullOrEmpty())
                    {
                        resultFlag = false;
                        errFieldName.Add("transactionId");
                    }

                    //Check Mandatory fields - End

                    break;

                case "Tmp_XML_Response_WSFEEUPLOADAUTHORISE_DTO":
                    Tmp_XML_Response_WSFEEUPLOADAUTHORISE_DTO resObjAuth = new Tmp_XML_Response_WSFEEUPLOADAUTHORISE_DTO();
                    //convert type
                    resObjAuth = trnObj as Tmp_XML_Response_WSFEEUPLOADAUTHORISE_DTO;
                    //Make Result flag true
                    resultFlag = true;
                    //Check Mandatory fields - Starts
          
                    if (resObjAuth.authoriseInfo.transactionId.IsNullOrEmpty())
                    {
                        resultFlag = false;
                        errFieldName.Add("transactionId");
                    }
                    if (resObjAuth.authoriseInfo.successIndicator.IsNullOrEmpty())
                    {
                        resultFlag = false;
                        errFieldName.Add("successIndicator");
                    }
                    if (resObjAuth.authoriseInfo.message.IsNullOrEmpty())
                    {
                        resultFlag = false;
                        errFieldName.Add("message");
                    }
                    //need crarification on fundTransfer
                    if (resObjAuth.transactionDetails.fundTransferMhcbmyactrfthpTypeAttribute.IsNullOrEmpty())
                    {
                        resultFlag = false;
                        errFieldName.Add("fundTransferMhcbmyactrfthpTypeAttribute");
                    
                    }

                    //Check Mandatory fields - End

                    break;
                case "Tmp_XML_Request_WSFEEUPLOADENQUIRE_DTO":
                    Tmp_XML_Request_WSFEEUPLOADENQUIRE_DTO reqObjEnquiry = new Tmp_XML_Request_WSFEEUPLOADENQUIRE_DTO();
                    //convert object to perticular class type
                    reqObjEnquiry = trnObj as Tmp_XML_Request_WSFEEUPLOADENQUIRE_DTO;
                    //Make Result flag true
                    resultFlag = true;
                    //Check Mandatory fields - Starts

                    if (reqObjEnquiry.authorisationInfo.userName.IsNullOrEmpty())
                    {
                        resultFlag = false;
                        errFieldName.Add("userName");
                    }
                    if (reqObjEnquiry.authorisationInfo.password.IsNullOrEmpty())
                    {
                        resultFlag = false;
                        errFieldName.Add("password");
                    }
                    if (reqObjEnquiry.authorisationInfo.company.IsNullOrEmpty ())
                    {
                        resultFlag = false;
                        errFieldName.Add("company");
                    }
                    break;
                case "Tmp_XML_Response_WSFEEUPLOADENQUIRE_DTO":
                    Tmp_XML_Response_WSFEEUPLOADENQUIRE_DTO resObjEnquiry = new Tmp_XML_Response_WSFEEUPLOADENQUIRE_DTO();
                    resObjEnquiry = trnObj as Tmp_XML_Response_WSFEEUPLOADENQUIRE_DTO;
                    //convert object to perticular class type
                    resObjEnquiry = trnObj as Tmp_XML_Response_WSFEEUPLOADENQUIRE_DTO;
                    //Make Result flag true
                    resultFlag = true;
                    //Check Mandatory fields - Starts

                    if (resObjEnquiry.authorisationInfo.transactionId.IsNullOrEmpty())
                    {
                        resultFlag = false;
                        errFieldName.Add("transactionId");
                    }
                    if (resObjEnquiry.authorisationInfo.successIndicator.IsNullOrEmpty())
                    {
                        resultFlag = false;
                        errFieldName.Add("successIndicator");
                    }
                    if (resObjEnquiry.authorisationInfo.message.IsNullOrEmpty())
                    {
                        resultFlag = false;
                        errFieldName.Add("message");
                    }
                    if (resObjEnquiry.transactionDetails.fundTransferMhcbmyactrfthpTypeAttribute.IsNullOrEmpty())
                    {
                        resultFlag = false;
                        errFieldName.Add("fundTransferMhcbmyactrfthpTypeAttribute");
                    }
                    break;
            }


            //Return result : False = mandatory field missing ; True =  TrnObj have all mandatory field.
            return resultFlag;
        }

    }
}
