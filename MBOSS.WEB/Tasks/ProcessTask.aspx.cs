using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mboss.BusinessLogic;
using Mboss.Common;
using System.IO;
using System.Configuration;
using Mboss.DataAccessObject;
using Mboss.Web.User_Controls;
using System.Net;
using System.Text;

namespace Mboss.Web.Tasks
{
    public partial class ProcessTask : MainPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                int TRANSACTION_ID = 0;
                try
                {
                    
                    TRANSACTION_ID = (int)Session["TRANSACTION_ID"];
                    GetProcessURL(TRANSACTION_ID);
                }
                catch
                {
                    if (TRANSACTION_ID == 0)
                    {
                        Response.Redirect("Default.aspx");
                    }
                    string errorCode = Mboss.Common.Properties.Resources.
                        MBS01LOG10001;
                    handleError(errorCode);
                }
                finally { }
            }
        }
        /// <summary>
        /// Retriving Transaction Status based on transaction ID
        /// </summary>
        protected void GetProcessURL(int TRANSACTION_ID)
        {
            Mboss.BusinessLogic.Task.TRN_T24FtTransactionBsl TransactionStatus = new BusinessLogic.Task.TRN_T24FtTransactionBsl();
            string TrnStatus = TransactionStatus.GetTransactionStatus(TRANSACTION_ID);
            Mboss.BusinessLogic.Task.TRN_T24FtTransactionBsl BusinessProcessCode = new BusinessLogic.Task.TRN_T24FtTransactionBsl();
            int Trigger_Value = 1;
            string BPCode = BusinessProcessCode.GetBusinessProcessCode(TrnStatus, Trigger_Value);
            Mboss.BusinessLogic.Task.TRN_T24FtTransactionBsl TargetURL = new BusinessLogic.Task.TRN_T24FtTransactionBsl();
            string URL = null;
            string URL_PARAMETER = null;
            TargetURL.GetTargetURL(BPCode, ref URL, ref URL_PARAMETER);
        }
    }
}