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
    public partial class FTUploadedFileEnquiry : MainPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string userID = null;
                try
                {
                    userID = Session["userID"].ToString();
                    LoadFileTypes();
                    LoadFileStatus();
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
        }

        /// <summary>
        /// Binding Data to FileType Dropdownlist
        /// </summary>
        protected void LoadFileTypes()
        {
            List<Mboss.DataAccessObject.FileUpload.ChargeTypesDTO> chargeTypes
                = new List<DataAccessObject.FileUpload.ChargeTypesDTO>();
            Mboss.BusinessLogic.FileUpload.ChargeTypesBsl fileUploadChargeTypes = new BusinessLogic.FileUpload.ChargeTypesBsl();
            chargeTypes = fileUploadChargeTypes.GetChargeTypes();
            ddllistFileType.Items.Add(new ListItem("ALL", "", true));
            foreach (var item in chargeTypes)
            {
                ListItem lItem = new ListItem();
                lItem.Value = item.chargeTypeCode;
                lItem.Text = item.chargeTypeName;
                ddllistFileType.Items.Add(lItem);
            }
        }

        /// <summary>
        /// Manually Adding List Items to FileStatus Dropdownlist
        /// </summary>
        protected void LoadFileStatus()
        {
            ddllistFileStatus.Items.Add(new ListItem("Uploaded", "Uploaded", true));
            ddllistFileStatus.Items.Add(new ListItem("Submitted", "Submitted", true));
        }


        //Once user clicks on Filter button it will reterive records
        //and shows them in User Interface Side
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                string FromDate = txtFromDate.Text.ToString();
                string ToDate = txtToDate.Text.ToString();
                string FileType = ddllistFileType.SelectedValue.ToString();
                string FileStatus = ddllistFileStatus.SelectedValue.ToString();
                Mboss.BusinessLogic.FileUpload.UploadedFileEnquiryBsl UploadedfileEnquiry = new BusinessLogic.FileUpload.UploadedFileEnquiryBsl();
                List<Mboss.DataAccessObject.FileUpload.UploadedFileEnquiryDTO> UploadedFilesList = UploadedfileEnquiry.GetUploadedFiles(FromDate, ToDate, FileType, FileStatus);
                uploadedDataRepeater.DataSource = UploadedFilesList;
                uploadedDataRepeater.DataBind();
            }
            catch
            {
            }
            finally
            {
                txtFromDate.Text = null;
                txtToDate.Text = null;
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Button btn = (Button)(sender);
            Session["UserSelectedFileId"] = btn.CommandArgument;
            Session["UserSelectedFileStatus"] = btn.Attributes["FileStatus"].ToString();
            Session["UserSelectedFileTypeCode"] = btn.Attributes["TypeCode"].ToString();
            Response.Redirect("FTUploadedFileEnquiryDetail.aspx");
        }
    }
}