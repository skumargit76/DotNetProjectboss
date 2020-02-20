using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Mboss.DataAccessObject;

namespace Mboss.DataAccess.FileUpload
{
    public class UploadedFileEnquiryDta:Base
    {
        public List<Mboss.DataAccessObject.FileUpload.UploadedFileEnquiryDTO> SelectUploadedFiles(string FromDate, string ToDate, string FileType, string FileStatus)
        {
            var reader = ExecuteReader("Get_UploadedFilesEnquiry"
                , new SqlParameter("@FromDate", FromDate)
                , new SqlParameter("@ToDate", ToDate)
                , new SqlParameter("@FileType", FileType)
                , new SqlParameter("@FileStatus", FileStatus));
            List<Mboss.DataAccessObject.FileUpload.UploadedFileEnquiryDTO> UploadedFilesList
               = new List<DataAccessObject.FileUpload.UploadedFileEnquiryDTO>();

            while (reader.Read())
            {
                Mboss.DataAccessObject.FileUpload.UploadedFileEnquiryDTO UploadedFileItem
                         = new DataAccessObject.FileUpload.UploadedFileEnquiryDTO();
                UploadedFileItem.FileType = reader.GetString("FILE_TYPE");
                UploadedFileItem.FileName = reader.GetString("FILE_NAME");
                UploadedFileItem.FileStatus = reader.GetString("FILE_STATUS");
                UploadedFileItem.UploadedDate = reader.GetDateTime("UPLOAD_DATE");
                UploadedFileItem.UploadedBy = reader.GetString("UPLOADED_BY");
                UploadedFileItem.FileId = reader.GetDecimal("FILE_ID");
                UploadedFileItem.TYPE_CODE = reader.GetString("TYPE_CODE");
                UploadedFilesList.Add(UploadedFileItem);
            }
            reader.Close();
            return UploadedFilesList;
        }
    }
}
