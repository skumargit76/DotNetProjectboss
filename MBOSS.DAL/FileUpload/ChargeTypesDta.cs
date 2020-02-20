using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Mboss.DataAccessObject;

namespace Mboss.DataAccess.FileUpload
{
    public class ChargeTypesDta: Base
    {
        public List<Mboss.DataAccessObject.FileUpload.ChargeTypesDTO>ChargeTypes()
        {
            var reader = ExecuteReader("USP_Get_Charge_Type");
            List<Mboss.DataAccessObject.FileUpload.ChargeTypesDTO> chargesTypes
                = new List<DataAccessObject.FileUpload.ChargeTypesDTO>();
            while(reader.Read())
            {
                Mboss.DataAccessObject.FileUpload.ChargeTypesDTO chargetypeItem
                    = new DataAccessObject.FileUpload.ChargeTypesDTO();
                chargetypeItem.chargeTypeCode = reader.GetString("TYPE_CODE");
                chargetypeItem.chargeTypeName = reader.GetString("TYPE_NAME");
                chargesTypes.Add(chargetypeItem);
            }
            reader.Close();
            return chargesTypes;
        }
    } 
}
