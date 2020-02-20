using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Mboss.DataAccessObject;
using System.Data;

namespace Mboss.DataAccess.FileUpload
{
   public class FileDetailDta : Base
    {
       public void SaveFileDetails(Mboss.DataAccessObject.FileUpload.FileDetailsDTO row)
       {
               

            var reader = ExecuteReader("SaveFileData"
                , new SqlParameter("@HEADER_ID", row.headerID)
                ,new SqlParameter("@RECORD_STATUS", row.recordStatus)
                , new SqlParameter("@SEQUENCE_NO", row.recordSequenceNo)
                ,new SqlParameter("@TRANSACTION_TYPE", row.transactionType)
                , new SqlParameter("@DEBIT_ACCOUNT", row.debitAccountNumber)
                ,new SqlParameter("@DEBIT_CURRENCY", row.debitCurrency)
                , new SqlParameter("@DEBIT_AMOUNT", row.debitAmount)
                , new SqlParameter("@DEBIT_VALUE_DATE", row.debitValueDate)
                ,new SqlParameter("@DEBIT_NARRATIVE", row.debitNarrative)
                ,new SqlParameter("@ORDEREDBY_1", row.orderedBy1)
                , new SqlParameter("@CREDIT_ACCOUNT", row.creditAccountNumber)
                ,new SqlParameter("@CREDIT_CURRENCY",  row.creditCurrency)
                , new SqlParameter("@CREDIT_AMOUNT", row.creditAmount)
                ,new SqlParameter("@CREDIT_VALUE_DATE", row.creditValueDate)
                ,new SqlParameter("@CREDIT_NARRATIVE", row.creditNarrative)
                , new SqlParameter("@CHEQUE_NUMBER", row.chequeNumber)
                , new SqlParameter("@CUSTOMER_RATE", row.customerRate)
                ,new SqlParameter("@PAYMENT_DETAILS_1", row.paymentDetails1)
                ,new SqlParameter("@PAYMENT_DETAILS_2", row.paymentDetails2)
                ,new SqlParameter("@PAYMENT_DETAILS_3", row.paymentDetails3)
                ,new SqlParameter("@ERROR_FLG", 'N')
                ,new SqlParameter("@ERROR_DESCRIPTION", "NULL")
                ,new SqlParameter("@CREATED_BY", "System")
                ,new SqlParameter("@UPDATED_BY", "System")
                    );

          reader.Close();
       }
    }
}
