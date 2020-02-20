using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Mboss.Common;

namespace Mboss.Web
{
    public partial class MainPage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

       public void handleError(Mboss.Common.Exception exp)
        {
             string errorPagePath = Request.Url.ToString();

             ErrorLogger.WriteException(exp, errorPagePath,
                    ExtensionMethods.ErrorLogPath);

            Response.Redirect("/error.aspx?msg=" + exp.Message);
        }

        public void handleError(string erroCode)
        {
            string errorPagePath = Request.Url.ToString();

            ErrorLogger.WriteError(erroCode, errorPagePath,
                    ExtensionMethods.ErrorLogPath);

            Response.Redirect("/error.aspx?errCode=" + erroCode);
        }

    }
}