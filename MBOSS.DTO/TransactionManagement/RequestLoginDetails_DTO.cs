using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mboss.DataAccessObject
{
    public class RequestLoginDetails_DTO
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string company { get; set; }
        public string transactionId { get; set; }
        public string loginUser { get; set; }
        public string messageId { get; set; }
        public string message { get; set; }
        public string successIndicator { get; set; }
        public string application { get; set; }
    }
}
