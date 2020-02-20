using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Mboss.DataAccessObject;

namespace Mboss.DataAccess.Task
{
   public class MST_Business_Process_TargetDta:Base
    {
       public List<Mboss.DataAccessObject.Task.MST_Business_Process_TargetDTO> Select_Business_Process_Target_By_BPCODE_By_ConfigCode(string BPCODE, int ConfigId)
       {
           var reader = ExecuteReader("USP_GET_BP_TARGET_BY_BPCODE_BPConfig_CODE"
               , new SqlParameter("@BP_CODE", BPCODE)
               , new SqlParameter("@BP_Config_ID", ConfigId));
             List<Mboss.DataAccessObject.Task.MST_Business_Process_TargetDTO> BusinessProcessTargetDetailList
              = new List<DataAccessObject.Task.MST_Business_Process_TargetDTO>();

           while (reader.Read())
           {
               Mboss.DataAccessObject.Task.MST_Business_Process_TargetDTO BusinessProcessTargetDetailItem
                        = new DataAccessObject.Task.MST_Business_Process_TargetDTO();
               BusinessProcessTargetDetailItem.ID = reader.GetDecimal("ID");
               BusinessProcessTargetDetailItem.BUSINESS_PROCESS_CODE = reader.GetString("BUSINESS_PROCESS_CODE");
               BusinessProcessTargetDetailItem.BUSINESS_PROCESS_CONFIG_ID = reader.GetDecimal("BUSINESS_PROCESS_CONFIG_ID");
               BusinessProcessTargetDetailItem.RESULT_SEQ = reader.GetDecimal("RESULT_SEQ");
               BusinessProcessTargetDetailItem.TARGET_TRN_STATUS_CODE = reader.GetString("TARGET_TRN_STATUS_CODE");
               BusinessProcessTargetDetailItem.CREATE_TASK = reader.GetDecimal("CREATE_TASK");
               BusinessProcessTargetDetailItem.TASK_TARGET_GROUP_ID = reader.GetDecimal("TASK_TARGET_GROUP_ID");
               BusinessProcessTargetDetailItem.TASK_TARGET_TYPE_CODE = reader.GetString("TASK_TARGET_TYPE_CODE");
               BusinessProcessTargetDetailItem.CREATED_BY = reader.GetString("CREATED_BY");
               BusinessProcessTargetDetailItem.CREATED_DATE = reader.GetDateTime("CREATED_DATE");
               BusinessProcessTargetDetailItem.UPDATED_BY = reader.GetString("UPDATED_BY");
               BusinessProcessTargetDetailItem.UPDATED_DATE = reader.GetDateTime("UPDATED_DATE");
               BusinessProcessTargetDetailList.Add(BusinessProcessTargetDetailItem);
           }
           reader.Close();
           return BusinessProcessTargetDetailList;
       }
    }
}
