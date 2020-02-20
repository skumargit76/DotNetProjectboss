using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mboss.DataAccessObject
{
    public class Tmp_XML_Request_WSFEEUPLOADINPUT_DTO
    {
        public RequestLoginDetails_DTO authoriseInfo = new RequestLoginDetails_DTO();
        public string gtsControl { get; set; }
        public string noOfAuth { get; set; }
        public string replace {get; set;}
        public double transactionRate { get; set; }
        public TRN_T24FtTransaction_DTO transactiondDetails = new TRN_T24FtTransaction_DTO();
        public string customerSpread {get; set;}
        public List<string> signatory = new List<string>();
        public string benCountry {get; set;}           
    }
}
