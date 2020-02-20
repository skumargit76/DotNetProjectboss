using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mboss.BusinessLogic;
using Mboss.Common;
using System.IO;
using System.Configuration;
using Mboss.DataAccessObject;
using Mboss.Web.User_Controls;
using System.Net;
using System.Text;

namespace Mboss.Web.FTUpload
{
    public partial class FTUploadedFileEnquiryDetail : MainPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int FileId = Int16.Parse(Session["UserSelectedFileId"].ToString());
                lblFileStatusResult.Text = Session["UserSelectedFileStatus"].ToString();
                lblFileTypeResult.Text = Session["UserSelectedFileTypeCode"].ToString();
                string FileStatus = Session["UserSelectedFileStatus"].ToString();
                string status = "UPLOADED";
                if (FileStatus == status)
                {
                    btnSubmit.Visible = true;
                }
                else
                {
                    btnSubmit.Visible = false;
                }

                Mboss.BusinessLogic.FileUpload.UploadedFileEnquiryDetailsBsl UploadedfileEnquiryDetail = new BusinessLogic.FileUpload.UploadedFileEnquiryDetailsBsl();
                List<Mboss.DataAccessObject.FileUpload.UploadedFileEnquiryDetailsDTO> UploadedFilesDetailsList = UploadedfileEnquiryDetail.GetUploadedFilesDetails(FileId);
                uploadedFileEnquiryDetailsDataRepeater.DataSource = UploadedFilesDetailsList;
                uploadedFileEnquiryDetailsDataRepeater.DataBind();

            }
            catch
            {

            }
            finally { }


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("FTUploadedFileEnquiry.aspx");
        }

    }
}