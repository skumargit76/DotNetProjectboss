using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Mboss.DataAccessObject;

namespace Mboss.DataAccess.Login
{
    public class MenuDta: Base
    {
        /// <summary>
        /// Executes procedure "MENU_ITEMS" gets menu list to be displayed
        /// as per the rights of logged in user and returns cretaed menu items
        /// and returns menu items to business logic calling function
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<MenuDTO> CreateMenu(decimal roleID)
        {
            List<MenuDTO> menuList = new List<MenuDTO>();
            var reader = ExecuteReader("getMenuItems"
                , new SqlParameter("@roleID", roleID));
            
            while(reader.Read())
                {
                    MenuDTO menu = new MenuDTO();
                    menu.moduleName = reader.GetString("moduleName");
                    menu.formName = reader.GetString("formName");
                    menu.formUrl = reader.GetString("formUrl");
                    menu.formSequence = reader.GetDecimal("formSequence");
                    menu.moduleSequence = reader.GetDecimal("moduleSequence");
                    menuList.Add(menu);
                }
            reader.Close();
            return menuList;
        }

    }
}
