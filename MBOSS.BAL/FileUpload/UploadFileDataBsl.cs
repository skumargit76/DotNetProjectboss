using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mboss.BusinessLogic.FileUpload
{
    public class UploadFileDataBsl
    {
        public Mboss.DataAccessObject.FileUpload.FileDetailsDTO addRow(string[] rowData, decimal fileID, string status, string chargeType)
        {
            Mboss.DataAccessObject.FileUpload.FileDetailsDTO FileDataRow = new DataAccessObject.FileUpload.FileDetailsDTO();

            FileDataRow.recordSequenceNo = rowData[0];
            FileDataRow.debitAccountNumber = Convert.ToDecimal(rowData[1]);
            FileDataRow.debitCurrency = rowData[2];
            if (rowData[3] != "")
            {
                FileDataRow.debitAmount = Convert.ToDouble(rowData[3]);
            }
            else
            {
                FileDataRow.debitAmount = 0;
            }
            FileDataRow.debitValueDate = rowData[4];
            FileDataRow.debitNarrative = rowData[5];
            FileDataRow.orderedBy1 = rowData[6];
            FileDataRow.creditAccountNumber = rowData[7];
            FileDataRow.creditCurrency = rowData[8];
            if (rowData[9] != "")
            {
                FileDataRow.creditAmount = Convert.ToDouble(rowData[9]);
            }
            else
            {
                FileDataRow.creditAmount = 0;
            }
            FileDataRow.creditValueDate = rowData[10];
            FileDataRow.creditNarrative = rowData[11];
            FileDataRow.chequeNumber = rowData[12];
            FileDataRow.customerRate = rowData[13];
            FileDataRow.paymentDetails1 = rowData[14];
            FileDataRow.paymentDetails2 = rowData[15];
            FileDataRow.paymentDetails3 = rowData[16];
            FileDataRow.recordStatus = status;
            FileDataRow.transactionType = chargeType;
            FileDataRow.headerID = Convert.ToString(fileID);

            return FileDataRow;
        }
    }
}
