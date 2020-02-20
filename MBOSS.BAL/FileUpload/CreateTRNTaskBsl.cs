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

namespace Mboss.BusinessLogic.FileUpload
{
    public class CreateTRNTaskBsl
    {
        public void Create(string status, string taskName, string fileID)
        {
            Mboss.DataAccess.FileUpload.CreateTaskDta createTRNTask = new DataAccess.FileUpload.CreateTaskDta();
             var loginUser = System.Security.Principal.WindowsIdentity.
                GetCurrent().Name;
            char spartor = '\\';
            string[] array = loginUser.Split(spartor);
            loginUser = array[1].ToString();

            createTRNTask.createTRN(status, taskName, fileID, loginUser);
        }
    }
}
