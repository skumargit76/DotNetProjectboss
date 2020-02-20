using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mboss.DataAccess;
using Mboss.DataAccessObject;
using System.Web;
using Mboss.Common;
using Mboss.DataAccess.Login;

namespace Mboss.BusinessLogic
{
    public class GenerateMenu
    {
       /// <summary>
       /// Creates Data Access object and calls the funaction to create menu
       /// </summary>
       /// <param name="userID"></param>
       /// <returns></returns>
        public List<MenuDTO> MenuItems(decimal roleID)
        {
            Mboss.DataAccess.Login.MenuDta menu = new DataAccess.Login.MenuDta();
            List<MenuDTO> menuItems = new List<MenuDTO>();
            menuItems = menu.CreateMenu(roleID);
            return menuItems;
        }
       }
}
