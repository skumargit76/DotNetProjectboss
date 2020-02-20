using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Mboss.Common;
using Mboss.DataAccess;
using Mboss.DataAccessObject;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.Protocols;

namespace Mboss.BusinessLogic
{
    public class LoginBsl
    {
       /// <summary>
       /// Verifies user name in active directory and retrieves user information
       /// </summary>
       /// <param name="SystemLoginName"></param>
       /// <returns></returns>
        private ActiveDirectoryDTO GetDataFromActiveDirectory(string SystemLoginName)
        {
            // Logic of active directiry connectivity
            bool error = false;
            
            ActiveDirectoryDTO AdDTO = new ActiveDirectoryDTO();
            AdDTO.systemLoginName = SystemLoginName;

            PrincipalContext principalContext = new PrincipalContext
                (ContextType.Domain, "MHCBMY.local", "DC=MHCBMY,DC = LOCAL");

            UserPrincipal userPrincipal = UserPrincipal.FindByIdentity
                (principalContext, IdentityType.SamAccountName, SystemLoginName);

            PrincipalSearchResult<Principal> result = userPrincipal.
                   GetAuthorizationGroups();
            List<Principal> groupNames = result.ToList();

            if (userPrincipal != null)
            {
                //Principal PcMaker = groupNames.FirstOrDefault
                //    (group => (group.Name == "MBOSS_MAKER"));

               string group = groupNames.FirstOrDefault().Name.ToString();

               if (group == "MBOSS_MAKER" || 
                   group == "MBOSS_APPROVER" || 
                   group == "MBOSS_ADMIN")
               {
                   AdDTO.role = group;
                   AdDTO.groupName = group;
                   error = false;
               }
                else
                {
                   // error user dosent belong to any group
                    error = true;
                    AdDTO.errroCode = Mboss.Common.Properties.Resources.
                        MBS01DEF40000;
                }
            }
            else
            {
                //invalid user or connection error
                AdDTO.errroCode = Mboss.Common.Properties.Resources.
                    MBS01LOG10001;      
            }

            if (!error)
            {
                AdDTO.displayName = userPrincipal.DisplayName;
                AdDTO.email = userPrincipal.EmailAddress;
                //temp fix
                AdDTO.email = "abc@email.com";
                AdDTO.groupName = groupNames[0].ToString();
                AdDTO.role = groupNames[0].ToString();

                //all the fields for the AD entry are mandatory -
                //MBOSS Database can't take nulls
                if (AdDTO.email.IsNullOrEmpty() || 
                    AdDTO.displayName.IsNullOrEmpty() 
                    || AdDTO.role.IsNullOrEmpty() || 
                    AdDTO.groupName.IsNullOrEmpty())
                {
                    AdDTO.errroCode = Mboss.Common.Properties.Resources.
                        MBS01DEF10003;
                }

            }
            return AdDTO;
        }

        /// <summary>
        /// Gets username/LDAP_ID from the machine, checks/gets info of user 
        /// from AD. Then checks the user details in MBOSS database. If user 
        /// dosen't exist in MBOSS database creates new entry in MBOSS database
        /// </summary>
        /// <returns></returns>
        public UserDTO AuthenticateUserinMBOSS()
        {
            // get user name from system
            var name = System.Security.Principal.WindowsIdentity.
                GetCurrent().Name;
            char spartor = '\\';
            string[] array = name.Split(spartor);
            name = array[1].ToString();
            // check user in active directiory
            ActiveDirectoryDTO AdDTO = this.GetDataFromActiveDirectory(name);

            UserDTO userDTO = new UserDTO();
            if (AdDTO.errroCode.IsNullOrEmpty())
            {
                DataAccess.Login.LoginDta Mboss = new DataAccess.Login.LoginDta();
                userDTO = Mboss.AuthticatUser(AdDTO.systemLoginName, 
                    AdDTO.displayName, AdDTO.email, "System", AdDTO.role, 
                    AdDTO.groupName);
            }
            else
            {
                userDTO.errroCode = AdDTO.errroCode;
            }
            return userDTO;
        }
    }
}
