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
    public class MST_Business_ProcessDta:Base
    {
        public List<Mboss.DataAccessObject.Task.MST_Business_ProcessDTO> Select_Business_Process_By_BPCODE(string BPCODE)
        {
            var reader = ExecuteReader("USP_GET_BP_By_BPCODE"
                , new SqlParameter("@BP_CODE", BPCODE));
            List<Mboss.DataAccessObject.Task.MST_Business_ProcessDTO> BusinessProcessDetailList
               = new List<DataAccessObject.Task.MST_Business_ProcessDTO>();

            while (reader.Read())
            {
                Mboss.DataAccessObject.Task.MST_Business_ProcessDTO BusinessProcesseDetailItem
                         = new DataAccessObject.Task.MST_Business_ProcessDTO();
                BusinessProcesseDetailItem.ID = reader.GetDecimal("ID");
                BusinessProcesseDetailItem.BUSINESS_PROCESS_CODE = reader.GetString("BUSINESS_PROCESS_CODE");
                BusinessProcesseDetailItem.BUSINESS_PROCESS_NAME = reader.GetString("BUSINESS_PROCESS_NAME");
                BusinessProcesseDetailItem.CREATED_BY = reader.GetString("CREATED_BY");
                BusinessProcesseDetailItem.CREATED_DATE = reader.GetDateTime("CREATED_DATE");
                BusinessProcesseDetailItem.UPDATED_BY = reader.GetString("UPDATED_BY");
                BusinessProcesseDetailItem.UPDATED_DATE = reader.GetDateTime("UPDATED_DATE");
                BusinessProcessDetailList.Add(BusinessProcesseDetailItem);
            }
            reader.Close();
            return BusinessProcessDetailList;
        }
    }
}
