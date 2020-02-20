using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mboss.BusinessLogic.FileUpload
{
    public class FileExistsBsl
    {
        public bool Check(string fileName, ref decimal fileID, ref string fileStatus)
        {
            bool existsStatus = false;
            Mboss.DataAccess.FileUpload.FileExistsDta fileExists = new DataAccess.FileUpload.FileExistsDta();

            fileExists.Check(fileName, ref existsStatus, ref fileID, ref fileStatus);

            return existsStatus;
        }
    }
}
