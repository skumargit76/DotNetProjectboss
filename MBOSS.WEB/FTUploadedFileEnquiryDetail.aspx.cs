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
using System.Data;

namespace Mboss.Web
{
    public partial class FTUploadedFileEnquiryDetail : MainPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userID = null;
            try
            {
                userID = Session["userID"].ToString();
                lblFileStatusResult.Text = Session["UserSelectedFileStatus"].ToString();
                lblFileTypeResult.Text = Session["UserSelectedFileTypeCode"].ToString();
                string FileStatus =Session["UserSelectedFileStatus"].ToString();
                string status = "UPLOADED";
                if (FileStatus == status)
                {
                    btnSubmit.Visible = true;
                }
                else
                {
                    btnSubmit.Visible = false;
                }
                BindDataRepeater();
             
            }
            catch
            {
                if (userID.IsNullOrEmpty())
                {
                    Response.Redirect("Default.aspx");
                }
                string errorCode = Mboss.Common.Properties.Resources.
                    MBS01LOG10001;
                handleError(errorCode);
            }
            finally { }
        }

        protected void BindDataRepeater()
        {
            int FileId = Int32.Parse(Session["UserSelectedFileId"].ToString()); 
            Mboss.BusinessLogic.FileUpload.UploadedFileEnquiryDetailsBsl UploadedfileEnquiryDetail = new BusinessLogic.FileUpload.UploadedFileEnquiryDetailsBsl();
            List<Mboss.DataAccessObject.FileUpload.UploadedFileEnquiryDetailsDTO> UploadedFilesDetailsList = UploadedfileEnquiryDetail.GetUploadedFilesDetails(FileId);
            uploadedFileEnquiryDetailsDataRepeater.DataSource = UploadedFilesDetailsList;
            uploadedFileEnquiryDetailsDataRepeater.DataBind();
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("FTUploadedFileEnquiry.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string fileID = Session["UserSelectedFileId"].ToString(); 
                Mboss.BusinessLogic.FileUpload.CreateTRNTaskBsl createTRNTask = new BusinessLogic.FileUpload.CreateTRNTaskBsl();
                createTRNTask.Create("Pending", "FT Upload Submission", fileID);
                
            }
            catch
            {
                string errorCode = Mboss.Common.Properties.Resources.
                    MBS01LOG10001;
                handleError(errorCode);
            }
            finally { }
            Response.Redirect("FTUploadedFileEnquiry.aspx");
        }
    }
}