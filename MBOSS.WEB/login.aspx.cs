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
    public partial class content : MainPage
    {
        // globla variable with in class for storing userID
        string userID = null;

        /// <summary>
        /// Page load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //login user name
            try
            {
                PrepareMenu();
            }
            catch
            {
                if (userID.IsNullOrEmpty())
                {
                    Response.Redirect("/Default.aspx");
                }
                string errorCode = Mboss.Common.Properties.Resources.
                    MBS01LOG10001;
                handleError(errorCode);
            }
            finally { }
        }

        /// <summary>
        /// display menu based on the user rights
        /// </summary>
        protected void PrepareMenu()
        {
            List<MenuDTO> menuItem = new List<MenuDTO>();
            string userID = Session["userID"].ToString();
            if (userID.IsNullOrEmpty())
            {
                Response.Redirect("/Default.aspx");
            }
            else
            {
                decimal roleID = Convert.ToDecimal(Session["roleID"].ToString());
                userName.Text = userID;
                GenerateMenu genMenu = new GenerateMenu();
                menuItem = genMenu.MenuItems(roleID);
                TableRow tr = new TableRow();
                foreach (var item in menuItem)
                {
                    MenuItem mItem = new MenuItem();
                    mItem.Text = item.formName;
                    decimal moduleSequence = item.moduleSequence;
                    mItem.NavigateUrl = item.formUrl;
                    loginMenu.Items.Add(mItem);
                }
            }
        }

    }
}