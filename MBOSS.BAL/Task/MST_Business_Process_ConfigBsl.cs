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
    public class MST_Business_Process_ConfigBsl
    {
        public List<Mboss.DataAccessObject.Task.MST_Business_Process_ConfigDTO> Get_Business_Process_Config_ByTxn_Code_ByConfigCode(string TxnCode, int TaskTrigger)
        {
            DataAccess.Task.MST_Business_Process_ConfigDta Mboss = new DataAccess.Task.MST_Business_Process_ConfigDta();
            List<Mboss.DataAccessObject.Task.MST_Business_Process_ConfigDTO> BusinessProcess_ConfigDetails = Mboss.Select_Business_Process_Config_ByTxn_Code_By_ConfigCode(TxnCode, TaskTrigger);
            return BusinessProcess_ConfigDetails;
        }
    }
}
