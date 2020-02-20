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
   public class MSTBusinessProcess_TargetBsl
    {
       public List<Mboss.DataAccessObject.Task.MST_Business_Process_TargetDTO> Get_Business_Process_Target_By_BPCODE_By_ConfigCode(string BPCODE, int ConfigId)
       {
           DataAccess.Task.MST_Business_Process_TargetDta Mboss = new DataAccess.Task.MST_Business_Process_TargetDta();
           List<Mboss.DataAccessObject.Task.MST_Business_Process_TargetDTO> BusinessProcess_TargetDetails = Mboss.Select_Business_Process_Target_By_BPCODE_By_ConfigCode(BPCODE, ConfigId);
           return BusinessProcess_TargetDetails;
       }
    }
}
