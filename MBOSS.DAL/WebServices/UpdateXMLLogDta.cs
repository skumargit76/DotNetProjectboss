using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Mboss.DataAccessObject;
using System.Data;

namespace Mboss.DataAccess.WebServices
{
    public class UpdateXMLLogDta: Base
    {
        public void UpdateXMLLog(int recordStatus, decimal logId, Tmp_XML_Response_WSFEEUPLOADAUTHORISE_DTO responseObj)
        { 
            string response = "";
            ExecuteNonQuery(""
                , new SqlParameter("@logID", logId)
                , new SqlParameter("@responseXML", response)
                , new SqlParameter("@recordStatus", recordStatus));
        }
    }
}
