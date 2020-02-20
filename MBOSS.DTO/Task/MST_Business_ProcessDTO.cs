using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mboss.DataAccessObject.Task
{
   public class MST_Business_ProcessDTO
   {
        public decimal ID { get; set; }
        public string BUSINESS_PROCESS_CODE { get; set; }
        public string BUSINESS_PROCESS_NAME { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_DATE { get; set; }
    }
}
