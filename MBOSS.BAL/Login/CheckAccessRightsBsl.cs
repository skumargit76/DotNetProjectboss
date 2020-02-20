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

namespace Mboss.BusinessLogic.Login
{
    public class CheckAccessRightsBsl
    {
        /// <summary>
        /// Checks Access Rights based on RoleId and FormUrl
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool CheckUserAscessRights(decimal roleID, string formUrl)
        {
            bool existsStatus = false;
            DataAccess.Login.CheckAccessRightsDta fileExists = new DataAccess.Login.CheckAccessRightsDta();
            existsStatus=fileExists.UserAscessRightcheck(roleID, formUrl);
            return existsStatus;
        }
    }
}
