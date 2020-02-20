using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mboss.BusinessLogic.FileUpload
{
    public class FileExtensionsBsl
    {
        public bool validate(string fileExtension)
        {
            if (fileExtension.ToLower() == ".csv" ||
                    fileExtension.ToLower() == ".txt")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
