using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Mboss.DataAccessObject;

namespace Mboss.DataAccess.Login
{
   public class CheckAccessRightsDta : Base
    {
        public bool UserAscessRightcheck(decimal roleID, string formUrl)
        {
            bool result = false;
            var reader = ExecuteReader("Check_AscessRights"
               , new SqlParameter("@RoleId", roleID)
               , new SqlParameter("@formUrl", formUrl));
            if (reader.Read())
            {
                result = true;
            }
            reader.Close();
            return result;
        }
    }
}
