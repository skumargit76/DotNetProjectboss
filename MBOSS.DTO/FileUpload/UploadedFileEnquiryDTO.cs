using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mboss.DataAccessObject.FileUpload
{
    public class UploadedFileEnquiryDTO
    {
        
        public string FileType { get; set; }
        public string FileName { get; set; }
        public string FileStatus { get; set; }
        public DateTime UploadedDate { get; set; }
        public string UploadedBy { get; set; }
        public decimal FileId { get; set; }
        public string TYPE_CODE { get; set; }
    }
}
