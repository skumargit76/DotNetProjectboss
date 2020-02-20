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

namespace Mboss.BusinessLogic.Task
{
    public class TaskTypesBsl : Base
    {
        public List<Mboss.DataAccessObject.Task.TaskTypeByGroupid> GetTaskTypes(string RoleCode)
        {
            Mboss.DataAccess.Task.TaskTypesDta mboss =
                new DataAccess.Task.TaskTypesDta();
            return mboss.TaskTypes(RoleCode);
        }
    }
}
