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
    public class InsertXMLLogDta: Base
    {
        public decimal LogXMLRequest(Object reqObj)
           // public decimal LogXMLRequest(Tmp_XML_Request_WSFEEUPLOADAUTHORISEDTO reqObj)
        {
            /*
            string requestXML = "";
            decimal logID = 0;
            var reader = ExecuteReader("USP_LOG_T24RequestResponse"
                , new SqlParameter("@RequestXML", requestXML)
                , new SqlParameter("@loginUser", reqObj.loginUser));
            
            if(reader.Read())
            {
                logID = reader.GetDecimal("logID");
            }
            reader.Close();
            return logID;*/
            return 0;
        }
    }
}
