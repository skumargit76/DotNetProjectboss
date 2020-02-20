using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mboss.DataAccessObject
{
    public class ActiveDirectoryDTO
    {
        public string displayName { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public string systemLoginName { get; set; }
        public string groupName { get; set; }
        public string errroCode { get; set; }

    }
}
