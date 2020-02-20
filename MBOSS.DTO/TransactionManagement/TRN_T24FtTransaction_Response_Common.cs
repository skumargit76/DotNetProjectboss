using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mboss.DataAccessObject
{
    public class TRN_T24FtTransaction_Response_Common
    {
        public string chargeComDisplay { get; set; }
        public string chargeCode { get; set; }
        public long profitCentreCust { get; set; }
        public string returnToDept { get; set; }
        public string fedFunds { get; set; }
        public string positionType { get; set; }
        public string amountDebited { get; set; }
        public string amountCredited { get; set; }
        public string creditCompCode { get; set; }
        public string debitCompCode { get; set; }
        public double locCamtDebited { get; set; }
        public double loCamtCredited { get; set; }
        public long custGroupLevel { get; set; }
        public long debitCustomer { get; set; }
        public string drAdviceReqdYN { get; set; }
        public string crAdviceReqdYN { get; set; }
        public long chargedCustomer { get; set; }
        public long toTrecComm { get; set; }
        public long recCommLcl { get; set; }
        public long totRecChg { get; set; }
        public long totRecChgLcl { get; set; }
        public string rateFixing { get; set; }
        public long totRecChgCrccy { get; set; }
        public long totSndChgCrccy { get; set; }
        public long roundType { get; set; }
        public string authDate { get; set; }
        public string[] stmtnos { get; set; }
        public string[] gOverride { get; set; }
        public string recordStatus { get; set; }
        public string inputter { get; set; }
        public string datetime { get; set; }
        public string coCode { get; set; }
        public long deptCode { get; set; }  
    }
}
