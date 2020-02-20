using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MBOSS.DAL;

namespace MBOSS.WEB
{
    public partial class validation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            user_name.Text = Request.QueryString["name"];
        }

        protected void user_ok_Click(object sender, EventArgs e)
        {
            MBOSS.DAL.VerifyUser verify = new VerifyUser();
            bool result = verify.authenticate(Request.QueryString["name"]);
            if (result)
            {
                Response.Redirect("login.aspx?name=" + Request.QueryString["name"]);
            }
            else
            {

            }
        }

        protected void user_false_Click(object sender, EventArgs e)
        {
            Response.Redirect("error.aspx?name=" + Request.QueryString["name"]);
        }
    }
}