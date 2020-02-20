using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mboss.DataAccessObject
{
   public class MenuDTO
    {
        public string moduleName { get; set; }
        public string formName { get; set; }
        public string formUrl { get; set; }
        public decimal formSequence { get; set; }
        public decimal moduleSequence { get; set; }
    }
}
