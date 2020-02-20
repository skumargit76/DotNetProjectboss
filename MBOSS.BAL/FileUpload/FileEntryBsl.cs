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

namespace Mboss.BusinessLogic.FileUpload
{
   public class FileEntryBsl
    {
       public decimal CreateFileEntry(string fileName, string chargeTypeCode, 
           string savedFilePath, string status, bool overwrite, decimal oldFileID)
       {
           decimal fileID = 0;

               DataAccess.FileUpload.FileUploadDta mbossFileUpload 
                   = new DataAccess.FileUpload.FileUploadDta();
               fileID = mbossFileUpload.FileUpload(fileName, savedFilePath, 
                   "System", status, chargeTypeCode);

               if (overwrite)
               {
               DataAccess.FileUpload.FileUploadOverWrite mbossFileOverwrite 
                   = new DataAccess.FileUpload.FileUploadOverWrite();
               mbossFileOverwrite.FileUpload(fileID, oldFileID);
               }

          return fileID;
          
       }
    }
}
