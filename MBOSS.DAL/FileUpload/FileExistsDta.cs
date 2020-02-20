using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Mboss.DataAccessObject;

namespace Mboss.DataAccess.FileUpload
{
    public class FileExistsDta: Base
    {
        public void Check(string fileName, ref bool exists, ref decimal fileID, ref string fileStatus)
        {
            var reader = ExecuteReader("FileCheck",
                new SqlParameter("@fileName", fileName));
            if (reader.Read())
            {
                fileID = reader.GetDecimal("fileID");
                fileStatus = reader.GetString("fileStatus");
                exists = true;
            }
            else
            {        
                exists = false;
            }
            reader.Close();
        }
    }
}
