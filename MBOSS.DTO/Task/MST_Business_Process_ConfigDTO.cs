using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mboss.DataAccessObject.Task
{
    public class MST_Business_Process_ConfigDTO
    {
        public decimal ID { get; set; }
        public string BUSINESS_PROCESS_CODE { get; set; }
        public decimal TASK_TRIGGER { get; set; }
        public string TRN_STATUS_CODE_FROM { get; set; }
        public decimal ENABLED { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_DATE { get; set; }
    }
}
