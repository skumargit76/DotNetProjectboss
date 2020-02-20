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
    public class UploadedFileEnquiryBsl
    {
        public List<Mboss.DataAccessObject.FileUpload.UploadedFileEnquiryDTO> GetUploadedFiles(string FromDate, string ToDate, string FileType, string FileStatus)
        {
            DataAccess.FileUpload.UploadedFileEnquiryDta Mboss = new DataAccess.FileUpload.UploadedFileEnquiryDta();
            List<Mboss.DataAccessObject.FileUpload.UploadedFileEnquiryDTO> UploadedFilesList = Mboss.SelectUploadedFiles(FromDate,ToDate,FileType,FileStatus);
            return UploadedFilesList;
        }
    }
}
