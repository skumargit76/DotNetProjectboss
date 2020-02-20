using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mboss.DataAccessObject.Task
{
   public class TRN_Transaction_StatusDTO
    {
        public decimal ID { get; set; }
        public string TRN_STATUS_CODE { get; set; }
        public string TRN_STATUS_NAME { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_DATE { get; set; }
    }
}
