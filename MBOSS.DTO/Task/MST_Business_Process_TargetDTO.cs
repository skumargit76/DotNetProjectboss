using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mboss.DataAccessObject.Task
{
    public class MST_Business_Process_TargetDTO
    {
        public decimal ID { get; set; }
        public string BUSINESS_PROCESS_CODE { get; set; }
        public decimal BUSINESS_PROCESS_CONFIG_ID { get; set; }
        public decimal RESULT_SEQ { get; set; }
        public string TARGET_TRN_STATUS_CODE { get; set; }
        public decimal CREATE_TASK { get; set; }
        public decimal TASK_TARGET_GROUP_ID { get; set; }
        public string TASK_TARGET_TYPE_CODE { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_DATE { get; set; }
    }
}
