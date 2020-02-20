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

namespace Mboss.Web
{
    public partial class _Default : MainPage
    {
        /// <summary>
        /// Page load function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //validate user before redirecting user to login page
                UserValidation();
            }
            catch (Mboss.Common.Exception exp)
            {
                handleError(exp);
            }
            finally
            {}
        }

        /// <summary>
        /// Gets the User name from windows and validates it with Active directory.
        /// After Active directory validation, validates user with MBOSS database
        /// and if user exits then shows login page. If user dosen't exits in 
        /// MBOSS Database creates a new user in MBOSS Database
        /// </summary>
        private void UserValidation()
        {
            //Get User ID from Windows and authenticatein AD & MBOSS
            LoginBsl loginBsl = new LoginBsl();
            UserDTO userDTO = new UserDTO();
            userDTO = loginBsl.AuthenticateUserinMBOSS();
            if (userDTO.errroCode.IsNullOrEmpty())
            {
                Session["userID"] = userDTO.ID.ToString();
                Session["roleID"] = userDTO.role.ToString();
                Session["roleCode"] = userDTO.roleCode.ToString();
                //Response.Redirect("FTUpload.aspx");
                //Response.Redirect("FTUploadedFileEnquiry.aspx");
                //Response.Redirect("/Tasks/TaskList.aspx");
                Response.Redirect("login.aspx", false );
            }
            else
            {
                handleError(userDTO.errroCode);
            }
        }

    }
}