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
    public class MST_Business_Process_ConfigDta:Base
    {
        public List<Mboss.DataAccessObject.Task.MST_Business_Process_ConfigDTO> Select_Business_Process_Config_ByTxn_Code_By_ConfigCode(string TxnCode, int TaskTrigger)
        {
            var reader = ExecuteReader("USP_GET_BP_Config_by_Txn_Status_FROM_Task"
                , new SqlParameter("@TXN_CODE", TxnCode)
                , new SqlParameter("@Task_Trigger", TaskTrigger));
            List<Mboss.DataAccessObject.Task.MST_Business_Process_ConfigDTO> BusinessProcessConfigDetailList
             = new List<DataAccessObject.Task.MST_Business_Process_ConfigDTO>();

            while (reader.Read())
            {
                Mboss.DataAccessObject.Task.MST_Business_Process_ConfigDTO BusinessProcessConfigDetailItem
                         = new DataAccessObject.Task.MST_Business_Process_ConfigDTO();
                BusinessProcessConfigDetailItem.ID = reader.GetDecimal("ID");
                BusinessProcessConfigDetailItem.BUSINESS_PROCESS_CODE = reader.GetString("BUSINESS_PROCESS_CODE");
                BusinessProcessConfigDetailItem.TASK_TRIGGER = reader.GetDecimal("TASK_TRIGGER");
                BusinessProcessConfigDetailItem.TRN_STATUS_CODE_FROM = reader.GetString("TRN_STATUS_CODE_FROM");
                BusinessProcessConfigDetailItem.ENABLED = reader.GetDecimal("ENABLED");
                BusinessProcessConfigDetailItem.CREATED_BY = reader.GetString("CREATED_BY");
                BusinessProcessConfigDetailItem.CREATED_DATE = reader.GetDateTime("CREATED_DATE");
                BusinessProcessConfigDetailItem.UPDATED_BY = reader.GetString("UPDATED_BY");
                BusinessProcessConfigDetailItem.UPDATED_DATE = reader.GetDateTime("UPDATED_DATE");
                BusinessProcessConfigDetailList.Add(BusinessProcessConfigDetailItem);
            }
            reader.Close();
            return BusinessProcessConfigDetailList;
        }
    }
}
