using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Mboss.DataAccessObject;


namespace Mboss.DataAccess.FileUpload
{
    public class FileUploadDta :Base
    {
        public decimal FileUpload(string fileName, string fileServerPath, 
            string authenticatedBy, string status, string chargeTypeCode)
        {
            decimal fileID = 0;
                         
                var reader = ExecuteReader("FileUploadHeader"
                , new SqlParameter("@FileName", fileName)
                , new SqlParameter("@FileServerPath", fileServerPath)
                , new SqlParameter("@LoginUser", authenticatedBy)
                , new SqlParameter("@Status", status)
                , new SqlParameter("@ChargeTypeCode", chargeTypeCode));
         
            if (reader.Read())
            {
                fileID = reader.GetDecimal("fileID");
            }
            
            reader.Close();         
            return fileID;
        }
    }
}
