using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mboss.DataAccessObject
{
    public class EnquireResponseCollection
    {
        public string transactionRef {get; set;}
        public string hdr {get;set;}
        public string txnType {get; set;}
        public string debitAccount {get; set;}
        public string debitCcy {get; set;}
        public double debitAmount {get; set;}
        public string creditAccount {get; set;}
        public string creditCcy {get; set;}
        public double creditAmount {get; set;}
        public string status {get; set;}
        public string inputter {get; set;}
    }
}
