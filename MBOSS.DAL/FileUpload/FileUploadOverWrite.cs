using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Mboss.DataAccessObject;

namespace Mboss.DataAccess.FileUpload
{
    public class FileUploadOverWrite: Base
    {
        public void FileUpload(decimal fileID, decimal oldFileID)
        {
              ExecuteNonQuery("FileUploadHeader_Overwrite"
               , new SqlParameter("@fileID", fileID)
               , new SqlParameter("@oldFileID", oldFileID));    
          
        }
    }
}
