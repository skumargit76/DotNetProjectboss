using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mboss.DataAccessObject.FileUpload
{
    public class UploadedFileEnquiryDetailsDTO
    {
        public decimal DEBIT_ACCOUNT { get; set; }
        public string DEBIT_CURRENCY { get; set; }
        public decimal DEBIT_AMOUNT { get; set; }
        public decimal CREDIT_ACCOUNT { get; set; }
        public string CREDIT_CURRENCY { get; set; }
        public decimal CREDIT_AMOUNT { get; set; }
        public decimal CUSTOMER_RATE { get; set; }
        public string TRANSACTION_TYPE { get; set; }
        public DateTime DEBIT_VALUE_DATE { get; set; }
        public string PAYMENT_DETAILS_1 { get; set; }
        public string PAYMENT_DETAILS_2 { get; set; }
        public string PAYMENT_DETAILS_3 { get; set; }
        
    }
}
