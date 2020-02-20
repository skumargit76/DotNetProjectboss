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

namespace Mboss.Web.Tasks
{
    public partial class TaskList : MainPage
    {
       protected void Page_Load(object sender, EventArgs e)
        {
            string roleCode = Session["roleCode"].ToString();
            if (!IsPostBack)
            {
                string userID = null;
                try
                {
                    userID = Session["userID"].ToString();
                    LoadTransactionTypes();
                    LoadTaskType(roleCode);
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
        /// Binding Data to Transaction Type Dropdownlist
        /// </summary>
        protected void LoadTransactionTypes()
        {
            List<Mboss.DataAccessObject.FileUpload.ChargeTypesDTO> chargeTypes
                = new List<DataAccessObject.FileUpload.ChargeTypesDTO>();
            Mboss.BusinessLogic.FileUpload.ChargeTypesBsl fileUploadChargeTypes = new BusinessLogic.FileUpload.ChargeTypesBsl();
            chargeTypes = fileUploadChargeTypes.GetChargeTypes();
            ddllistTransactionType.Items.Add(new ListItem("ALL", "", true));
            foreach (var item in chargeTypes)
            {
                ListItem lItem = new ListItem();
                lItem.Value = item.chargeTypeCode;
                lItem.Text = item.chargeTypeName;
                ddllistTransactionType.Items.Add(lItem);
            }
        }

        /// <summary>
        /// Binding Data to Load Task Type Dropdownlist
        /// </summary>
        protected void LoadTaskType(string roleCode)
        {
            List<Mboss.DataAccessObject.Task.TaskTypeByGroupid> TaskTypesList
                   = new List<DataAccessObject.Task.TaskTypeByGroupid>();
            Mboss.BusinessLogic.Task.TaskTypesBsl TaskTypes = new BusinessLogic.Task.TaskTypesBsl();
            TaskTypesList = TaskTypes.GetTaskTypes(roleCode);
            ddllistTaskType.Items.Add(new ListItem("ALL", "", true));
            foreach (var item in TaskTypesList)
            {
                ListItem lItem = new ListItem();
                lItem.Value = item.TASK_TYPE_CODE;
                lItem.Text = item.TASK_TYPE_NAME;
                ddllistTaskType.Items.Add(lItem);
            }
        }


          //Once user clicks on Filter button it will reterive records
        //and shows them in User Interface Side
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                string FromDate = Request.Form[txtFromDate.UniqueID];
                string ToDate = Request.Form[txtToDate.UniqueID];
                string TransactionType = ddllistTransactionType.SelectedValue.ToString();
                string TaskType = ddllistTaskType.SelectedValue.ToString();
                string roleCode = Session["roleCode"].ToString();
                Mboss.BusinessLogic.Task.TaskListsBsl UploadedfileEnquiry = new BusinessLogic.Task.TaskListsBsl();
                List<Mboss.DataAccessObject.Task.TaskListsDTO> UploadedFilesList = UploadedfileEnquiry.GetUploadedFiles(FromDate, ToDate, TransactionType, TaskType, roleCode);
                uploadedDataRepeater.DataSource = UploadedFilesList;
                uploadedDataRepeater.DataBind();
                tableR.Visible = true;
            }
            catch
            {
                string errorCode = Mboss.Common.Properties.Resources.
                 MBS01DEF10006;
                handleError(errorCode);
            }
            finally
            {
                txtFromDate.Text = null;
                txtToDate.Text = null;
            }
        }
    }
}