using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mboss.Web
{
    public partial class error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //assign error message to 
          //  errorMessage.Text = getErrorMessage();
        }

        /// <summary>
        /// Retrieves the error message passed to this page
        /// </summary>
        /// <returns></returns>
        public String getErrorMessage()
        {
            return Request.QueryString["msg"];
        }
    }
}