using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Mboss.DataAccessObject;
using System.Data;

namespace Mboss.DataAccess.FileUpload
{
    public class CreateTaskDta :Base
    {
        public bool createTRN(string status, string taskName, string fileID, string loginUser)
        {
           
            var reader = ExecuteReader("CreateTRNTask"
                , new SqlParameter("@fileID", fileID)
                , new SqlParameter("@loginUSer", loginUser)
                , new SqlParameter("@Status", status)
                , new SqlParameter("@taskName", taskName));

            if (reader.Read())
            {
                reader.Close();
                return true;

            }
            else
            {
                reader.Close();
                return false;
            }
            
        }
    }
}
