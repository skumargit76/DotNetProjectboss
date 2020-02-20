using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mboss.DataAccessObject
{
    public class TRN_T24FtTransaction_DTO
    {
        public int headerID { get; set; }
        public int detailID { get; set; }
        public string T24TransactionID {get; set;}
        public string productTypeCode { get; set; }
        public int TRNTaskID { get; set; }
        public int recordStatus { get; set; }
        public string transactionStatus { get; set; }
        public string transactionType { get; set; }
        public string currencyMkTdr { get; set; }
        public string currencyMkTcr { get; set; }
        public string processingDate { get; set; }
        public long debitAccount { get; set; }
        public string debitCurrency { get; set; }
        public double debitAmount { get; set; }
        public string debitValueDate { get; set; }
        public string debitNarrative { get; set; }
        public List<string> orderedBy = new List<string>();
        public string creditAccount { get; set; }
        public string creditCurrency { get; set; }
        public double creditAmount { get; set; }
        public string creditValueDate { get; set; }
        public string creditNarrative { get; set; }
        public long chequeNumber { get; set; }
        public long customerRate { get; set; }
        public List<string> paymentDetails = new List<string>();
        public string errorFlag { get; set; }
        public int T24RequestID { get; set; }
        public string createdBy { get; set; }
        public string createdDate { get; set; }
        public string updatedBy { get; set; }
        public string updatedDate { get; set; }
        public string chargeComDisplay { get; set; }
        public string commissionCode { get; set; } 
        public string chargeCode { get; set; }
        public string profitCentreCust { get; set; }
        public string returnToDept { get; set; }
        public string fedFunds { get; set; }
        public string positionType { get; set; }
        public string amountDebited { get; set; }
        public string amountCredited { get; set; }
        public string creditCompCode { get; set; }
        public string debitCompCode { get; set; }
        public double locAmtDebited { get; set; }
        public double locAmtCredited { get; set; }
        public long custGroupLevel { get; set; }
        public long debitCustomer { get; set; }
        public List<string> deliveryOutRef = new List<string>();
        public string drAdviceReqdYN { get; set; }
        public string crAdviceReqdYN { get; set; }
        public long chargedCustomer { get; set; }
        public long toTrecComm { get; set; }
        public long toRecCommLcl { get; set; }
        public long totRecChg { get; set; }
        public long totRecChgLcl { get; set; }
        public string rateFixing { get; set; }
        public long totRecChgCrccy { get; set; }
        public long totSndChgCrccy { get; set; }
        public long roundType { get; set; }
        public string authDate { get; set; }
        public List<string> stmtnos = new List<string>();
        public List<string> gOverride = new List<string>();
        public string recordStatusByName { get; set; }
        public string currNo { get; set; }
        public List<string> inputter = new List<string>();
        public List<string> dateTime = new List<string>();
        public string coCode { get; set; }
        public long deptCode { get; set; }
        public string authoriser { get; set; }
        public string debitTheirRef { get; set; }
        public string creditTheirRef { get; set; }
        public string gOderingCustAttribute { get; set; }
        public string gPaymentDetailsAttribute { get; set; }
        public string gDeliveryOutRefAttribute { get; set; }
        public string gSignatoryAttribute { get; set; }
        public string fundTransferMhcbmyactrfthpTypeAttribute {get; set;}
    }
}
