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
    public class StoreFileDetailsBsl
    {
        public void SaveFileData(List<Mboss.DataAccessObject.FileUpload.FileDetailsDTO> fileData)
        {
            Mboss.DataAccess.FileUpload.FileDetailDta mboss = new DataAccess.FileUpload.FileDetailDta();
            foreach (var row in fileData)
            {
                mboss.SaveFileDetails(row);
            }
        }
    }
}
