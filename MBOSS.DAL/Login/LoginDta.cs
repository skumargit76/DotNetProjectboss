using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Mboss.DataAccessObject;

namespace Mboss.DataAccess.Login
{
    public class LoginDta : Base
    {

        public  UserDTO AuthticatUser(string systemLoginName,string userName, 
            string email, string authenticateBy, string role, string groupName)
        {
           UserDTO userDTO = new UserDTO();
             var reader = ExecuteReader("AuthticatUser"
                     , new SqlParameter("@LDAP_ID", systemLoginName)
                      , new SqlParameter("@UserName", userName)
                       , new SqlParameter("@EMAIL", email)
                        , new SqlParameter("@LoginUser", authenticateBy)
                        , new SqlParameter("@LDAP_Role", role)
                        , new SqlParameter("@LDAP_GroupName", groupName)
                     );
            if (reader.Read())
            {
                userDTO.ID = reader.GetDecimal("ID");
                userDTO.ldapID = reader.GetString("LDAP_ID");
                userDTO.userName = reader.GetString("USER_NAME");
                userDTO.createdBy = reader.GetString("CREATED_BY");
                userDTO.createdDate = reader.GetDateTime("CREATED_DATE");
                userDTO.updatedBy = reader.GetString("UPDATED_BY");
                userDTO.updatedDate = reader.GetDateTime("UPDATED_DATE");
                userDTO.recordStatus = reader.GetDecimal("RECORD_STATUS");
                userDTO.email = reader.GetString("EMAIL");
                userDTO.role = reader.GetDecimal("roleID");
                userDTO.roleCode = reader.GetString("roleCode");
            }
            else
            {
                userDTO.errroCode = Mboss.Common.Properties.Resources.
                    MBS01DEF10004;
            }
            reader.Close();
            return userDTO;
        }
    }
}
