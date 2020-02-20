using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Mboss.Common;
using Mboss.DataAccess;
using Mboss.DataAccessObject;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.Protocols;

namespace Mboss.BusinessLogic.FileUpload
{
    public class ChargeTypesBsl
    {
        public List<Mboss.DataAccessObject.FileUpload.ChargeTypesDTO>GetChargeTypes()
        {
            Mboss.DataAccess.FileUpload.ChargeTypesDta mboss = 
                new DataAccess.FileUpload.ChargeTypesDta();
            return mboss.ChargeTypes();
        }
    }
}
