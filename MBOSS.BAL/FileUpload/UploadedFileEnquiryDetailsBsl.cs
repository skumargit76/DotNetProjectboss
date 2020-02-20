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
   public class UploadedFileEnquiryDetailsBsl
    {
       public List<Mboss.DataAccessObject.FileUpload.UploadedFileEnquiryDetailsDTO> GetUploadedFilesDetails(int FileId)
        {
            DataAccess.FileUpload.UploadedFileEnquiryDetailsDta Mboss = new DataAccess.FileUpload.UploadedFileEnquiryDetailsDta();
            List<Mboss.DataAccessObject.FileUpload.UploadedFileEnquiryDetailsDTO> UploadedFilesDetailList = Mboss.SelectUploadedFilesDetails(FileId);
            return UploadedFilesDetailList;
        }
    }
}
