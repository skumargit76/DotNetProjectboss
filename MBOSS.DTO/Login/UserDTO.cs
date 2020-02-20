using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mboss.DataAccessObject
{
    public class UserDTO
    {
        public string userName { get; set; }
        public string ldapID { get; set; }
        public string email { get; set; }
        public decimal ID { get; set; }
        public string createdBy { get; set; }
        public decimal recordStatus { get; set; }
        public DateTime createdDate { get; set; }
        public string updatedBy {get; set;}
        public DateTime updatedDate { get; set; }
        public decimal role { get; set; }
        public string errroCode { get; set; }
        public string roleCode { get; set; }
    }
}
