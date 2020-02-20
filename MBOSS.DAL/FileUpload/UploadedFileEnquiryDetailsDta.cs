using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Mboss.DataAccessObject;


namespace Mboss.DataAccess.FileUpload
{
    public class UploadedFileEnquiryDetailsDta:Base
    {
        public List<Mboss.DataAccessObject.FileUpload.UploadedFileEnquiryDetailsDTO>SelectUploadedFilesDetails(int FileId)
        {
            var reader = ExecuteReader("Get_UploadedFilesEnquiryDetails"
                , new SqlParameter("@FileId", FileId));
            List<Mboss.DataAccessObject.FileUpload.UploadedFileEnquiryDetailsDTO> UploadedFilesDetailList
               = new List<DataAccessObject.FileUpload.UploadedFileEnquiryDetailsDTO>();

            while (reader.Read())
            {
                Mboss.DataAccessObject.FileUpload.UploadedFileEnquiryDetailsDTO UploadedFileDetailItem
                         = new DataAccessObject.FileUpload.UploadedFileEnquiryDetailsDTO();
                UploadedFileDetailItem.DEBIT_ACCOUNT = reader.GetDecimal("DEBIT_ACCOUNT");
                UploadedFileDetailItem.DEBIT_CURRENCY = reader.GetString("DEBIT_CURRENCY");
                UploadedFileDetailItem.DEBIT_AMOUNT = reader.GetDecimal("DEBIT_AMOUNT");
                UploadedFileDetailItem.CREDIT_ACCOUNT = reader.GetDecimal("CREDIT_ACCOUNT");
                UploadedFileDetailItem.CREDIT_CURRENCY = reader.GetString("CREDIT_CURRENCY");
                UploadedFileDetailItem.CREDIT_AMOUNT = reader.GetDecimal("CREDIT_AMOUNT");
                UploadedFileDetailItem.CUSTOMER_RATE = reader.GetDecimal("CUSTOMER_RATE");
                UploadedFileDetailItem.TRANSACTION_TYPE = reader.GetString("TRANSACTION_TYPE");
                UploadedFileDetailItem.DEBIT_VALUE_DATE = reader.GetDateTime("DEBIT_VALUE_DATE");
                UploadedFileDetailItem.PAYMENT_DETAILS_1 = reader.GetString("PAYMENT_DETAILS_1");
                UploadedFileDetailItem.PAYMENT_DETAILS_2 = reader.GetString("PAYMENT_DETAILS_2");
                UploadedFileDetailItem.PAYMENT_DETAILS_3 = reader.GetString("PAYMENT_DETAILS_3");
                UploadedFilesDetailList.Add(UploadedFileDetailItem);
            }
            reader.Close();
            return UploadedFilesDetailList;
        }
    }
}
