using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mboss.DataAccessObject.FileUpload
{
    public class FileDetailsDTO
    {
        public string recordSequenceNo { get; set; }
        public decimal debitAccountNumber { get; set; }
        public string debitCurrency { get; set; }
        public double debitAmount { get; set; }
        public string debitValueDate { get; set; }
        public string debitNarrative { get; set; }
        public string orderedBy1 { get; set; }
        public string creditAccountNumber { get; set; }
        public string creditCurrency { get; set; }
        public double creditAmount { get; set; }
        public string creditValueDate { get; set; }
        public string creditNarrative { get; set; }
        public string chequeNumber { get; set; }
        public string customerRate { get; set; }
        public string paymentDetails1 { get; set; }
        public string paymentDetails2 { get; set; }
        public string paymentDetails3 { get; set; }
        public string headerID { get; set; }
        public string recordStatus { get; set; }
        public string transactionType { get; set; }
        //fileId = Header ID
    }
}
