﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mboss.DataAccessObject
{
    public class Tmp_XML_Response_WSFEEUPLOADENQUIRE_DTO
    {
        public RequestLoginDetails_DTO authorisationInfo;
        public List<EnquireResponseCollection> ftAuthAuType { get; set; }
        public TRN_T24FtTransaction_DTO transactionDetails;
    }
}
