using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mboss.DataAccessObject;
using MBOSS.WebService;

namespace Mboss.Web
{
    public partial class TestWebService : MainPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Upload Input Webservice
                Mboss.DataAccessObject.Tmp_XML_Response_WSFEEUPLOADINPUT_DTO response;
                Mboss.DataAccessObject.Tmp_XML_Request_WSFEEUPLOADINPUT_DTO request = new Tmp_XML_Request_WSFEEUPLOADINPUT_DTO();
                MBOSS.WebService.WSFEEUPLOADINPUT temp = new MBOSS.WebService.WSFEEUPLOADINPUT();

                request.authoriseInfo.userName = "mmMBOSSMAK";
                request.authoriseInfo.password = "@6Yhn7ujm";
                request.authoriseInfo.company = "MY0012101";

                request.transactiondDetails.transactionType = "GST";
                request.transactiondDetails.debitAccount = 8880009142;
                request.transactiondDetails.debitCurrency = "MYR";
                request.transactiondDetails.debitAmount = 13.5;
                request.transactiondDetails.debitValueDate = "20150815";
                request.transactiondDetails.debitNarrative = "CHGS CHQ ISSUE";
                //request.transactiondDetails.orderedBy.Add("");
                request.transactiondDetails.creditAccount = "PL52003 ";
                request.transactiondDetails.creditCurrency = "MYR";
                request.transactiondDetails.creditAmount = 0;
                request.transactiondDetails.creditValueDate = "20150414";
                request.transactiondDetails.creditNarrative = "CHGS CHQ ISSUE";
                string str = "BEING CHGS CHQ ISSUE FVG ";
                request.transactiondDetails.paymentDetails.Add(str);
                request.transactiondDetails.paymentDetails.Add("CUSTOMER NAME 1");
                request.transactiondDetails.paymentDetails.Add("CUSTOMER NAME 2 - Reddy");

                response = temp.DoWsFeeUploadInput(request);               
            }
            catch (Exception ex)
            {
                handleError("MBOSS Error");
            }
            finally { }
        }
    }
}