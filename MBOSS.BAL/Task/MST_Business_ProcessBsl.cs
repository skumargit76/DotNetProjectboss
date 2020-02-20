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
   public class MST_Business_ProcessBsl
    {
       public List<Mboss.DataAccessObject.Task.MST_Business_ProcessDTO> Get_Business_Process_By_BPCODE(string BPCODE)
       {
           DataAccess.Task.MST_Business_ProcessDta Mboss = new DataAccess.Task.MST_Business_ProcessDta();
           List<Mboss.DataAccessObject.Task.MST_Business_ProcessDTO> BusinessProcessDetails = Mboss.Select_Business_Process_By_BPCODE(BPCODE);
           return BusinessProcessDetails;
       }
    }
}
