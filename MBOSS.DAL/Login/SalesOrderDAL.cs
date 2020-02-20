using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Model.SalesOrder.Response;

namespace Data.SalesOrder
{
    public class SalesOrderDAL : Base
    {
        public List<Model.ResponseMessage> getProductValidation(string ItemListXML)
        {
            List<Model.ResponseMessage> errList = new List<Model.ResponseMessage>();


            var reader = ExecuteReader("CMN_GET_PRODUCT_VALIDATION_BY_XML"
                     , new SqlParameter("@xmlstring", ItemListXML)
                     );
            if (reader.Read())
            {
                do
                {
                    Model.ResponseMessage err = new Model.ResponseMessage();
                    err.MessageCode = reader.GetString("ERRORCODE");
                    err.MessageDescription = reader.GetString("ErrorDesc");
                    err.MessageType = "Error";
                    errList.Add(err);
                } while (reader.Read());
            }
            reader.Close();


            return errList;

        }

        


       

       
    }
}
