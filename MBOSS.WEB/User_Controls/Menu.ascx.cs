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
using System.Data;

namespace Mboss.Web.User_Controls
{
    public partial class Menu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userID = null;
             try
            {
              
                 userID = Session["userID"].ToString();
                    PrepareMenu(userID);
          
            if (!CheckAscessRights())
            {
                Response.Redirect("error.aspx");
                //Response.Redirect("/Tasks/TaskList.aspx");
            }
            }
             catch (System.Exception ex)
             {
                 if (userID.IsNullOrEmpty())
                 {
                   
                     Response.Redirect("/Default.aspx");
                 }

                 string errorCode = Mboss.Common.Properties.Resources.
                     MBS01LOG10001;
                 MainPage mainPage = new MainPage();
                 mainPage.handleError(errorCode);
             }
             finally
             {
                 
             }
        }
        /// <summary>
        /// display menu based on the user rights
        /// </summary>
        protected void PrepareMenu(string userID)
        {
           
            //login user name
           
           
            List<MenuDTO> menuItem = new List<MenuDTO>();

            string currentUrl = HttpContext.Current.Request.Url.AbsolutePath;

            char spartor = '/';
            string[] array = currentUrl.Split(spartor);
            currentUrl = array.Last();
            currentUrl = currentUrl.TrimStart('/');

            if (userID.IsNullOrEmpty())
            {
                Response.Redirect("/Default.aspx");
            }
            else
            {
                decimal roleID = Convert.ToDecimal(Session["roleID"].ToString());
                Control ul = this.FindControl("Ul1");

                GenerateMenu genMenu = new GenerateMenu();
                menuItem = genMenu.MenuItems(roleID);

                var result = from modules in menuItem select new { moduleName = modules.moduleName };
                result = result.Distinct();

                foreach (var mods in result)
                {
                    var forms = from urls in menuItem where urls.moduleName == mods.moduleName orderby urls.formSequence select new { formnames = urls.formName, url = urls.formUrl };
                    if (forms.Count() > 1)
                    {
                        ul.Controls.Add(new Literal()
                        {
                            Text = "<li class='mainmenu'><a  href='" + forms.Last().url +
                            "'style='width:auto;'>" + mods.moduleName + "</a><ul class='submenu' runat='server' style='background-color: #000080;list-style:none;display:none; text-align:left;'>"
                        });

                        foreach (var item in forms)
                        {
                            if (currentUrl == item.url)
                            {
                               // invalid = false;
                            }
                            ul.Controls.Add(new Literal()
                            {
                                Text = "<li><a style='background-color:#000080;' href='" + item.url +
                                "'style='width:auto;'>" + item.formnames + "</a></li>"
                            });
                        }
                        ul.Controls.Add(new Literal()
                        {
                            Text = "</li></ul>"
                        });
                    }
                    else
                    {
                        if (currentUrl == forms.First().url)
                        {
                           // invalid = false;
                        }
                        ul.Controls.Add(new Literal()
                        {
                            Text = "<li><a  href='" + forms.Last().url +
                            "'style='width:auto;'>" + mods.moduleName + "</a></li>"
                        });
                    }
                }

            }
        }

        protected bool CheckAscessRights()
        {
            decimal roleID = Convert.ToDecimal(Session["roleID"].ToString());
            string currentUrl = HttpContext.Current.Request.Url.AbsolutePath;
            char spartor = '/';
            string[] array = currentUrl.Split(spartor);
            currentUrl = array.Last();
            string formUrl = currentUrl.TrimStart('/');
            Mboss.BusinessLogic.Login.CheckAccessRightsBsl CheckAscessRightsbsl = new BusinessLogic.Login.CheckAccessRightsBsl();
            return CheckAscessRightsbsl.CheckUserAscessRights(roleID, formUrl);
        }
        
    }
}