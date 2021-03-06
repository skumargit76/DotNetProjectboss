﻿using System;
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


namespace Mboss.Web.FTUpload
{
    public partial class FileUpload : MainPage
    {
       
      
        /// <summary>
        /// page load function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {       
            try
            {
                    if (!(Page.IsPostBack))
                    {
                    LoadChargeTypes();
                }
            }
            catch(System.Exception ex)
            {
                string errorCode = Mboss.Common.Properties.Resources.
                    MBS01LOG10001;
                handleError(errorCode);
            }
            finally { }
        }


        /// <summary>
        /// 
        /// </summary>
        protected void LoadChargeTypes()
        {
            List<Mboss.DataAccessObject.FileUpload.ChargeTypesDTO> chargeTypes
                = new List<DataAccessObject.FileUpload.ChargeTypesDTO>();
            Mboss.BusinessLogic.FileUpload.ChargeTypesBsl fileUploadChargeTypes
                = new BusinessLogic.FileUpload.ChargeTypesBsl();
            chargeTypes = fileUploadChargeTypes.GetChargeTypes();
            foreach (var item in chargeTypes)
            {
                ListItem lItem = new ListItem();
                lItem.Value = item.chargeTypeCode;
                lItem.Text = item.chargeTypeName;
                listChargeType.Items.Add(lItem);
            }

        }


       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpload_Click(object sender, EventArgs e)
        {
          
            try
            {
                //declarations
               
               string fileName = fUpload.FileName.Substring(0,
                    fUpload.FileName.Length - 4);

               ViewState["file"] = fUpload.FileName;

              // file = fUpload;
                //end of declarations
               string tempFileSavedFilePath = ExtensionMethods.FileServerPath +
           listChargeType.SelectedItem.Value + "_" + fileName +
           "_" + "temp" +
           Path.GetExtension(fUpload.FileName);

               ViewState["tempFileSavedFilePath"] = tempFileSavedFilePath;

               if (listChargeType.SelectedItem.Value != "1")
               {
                   if (UploadFile(tempFileSavedFilePath))
                   {
                       string fileStatus = null;

                       if (!FileExists(ref fileStatus))
                       {
                           FileHandling(fileName, false,
                               tempFileSavedFilePath);
                       }
                       else
                       {
                           if (fileStatus == "UPLOADED")
                           {
                               ScriptManager.RegisterStartupScript(this, this.GetType(), "ChangePaint", "launchmodal();", true);
                           }
                           else if (fileStatus == "SUBMITTED")
                           {
                               btnSubmit.Enabled = false;
                               tableR.Visible = false;
                               uploadedDataRepeater.DataSource = null;
                               uploadedDataRepeater.DataBind();
                               ScriptManager.RegisterStartupScript(this, this.GetType(), "ChangePaint", "alreadySubmit();", true);
                           }
                       }
                   }
               }
               else
               {
                   ScriptManager.RegisterStartupScript(this, this.GetType(), "ChangePaint", "charge();", true);
               }
            }
            catch(System.Exception ex)
            {
                string errorCode = Mboss.Common.Properties.Resources.
                    MBS01LOG10001;
                handleError(errorCode);
            }
            finally { }
        }


        /// <summary>
        /// Saving Uploaded File
        /// </summary>
        /// <returns></returns>
        protected bool UploadFile(string savedFilePath)
        {
            string fileName = ViewState["file"].ToString();
            String fileExtension = Path.GetExtension(fileName);
            Mboss.BusinessLogic.FileUpload.FileExtensionsBsl fileExtenstion = new 
                BusinessLogic.FileUpload.FileExtensionsBsl();
            if (fUpload.HasFile)
            {
                if (fileExtenstion.validate(fileExtension))
                {
                    string fileServerPath = ExtensionMethods.FileServerPath;
                    fUpload.SaveAs(Server.MapPath(savedFilePath));
                    return true;
                }
                else
                {
                    //better grap error help text from resource file
                    helpText.InnerText = "Invalid .csv or .txt file";
                    helpText.Attributes.CssStyle.Add("color", "Red");
                }
            }
            return false;
        }


        /// <summary>
        /// Check whether already existis in MBOSS Database
        /// </summary>
        /// <returns></returns>
        protected bool FileExists(ref string fileStatus)
        {
            Mboss.BusinessLogic.FileUpload.FileExistsBsl fileExists =
                new BusinessLogic.FileUpload.FileExistsBsl();

            decimal oldFileID = 0;
            string fileName = ViewState["file"].ToString();
            bool result = fileExists.Check(fileName, ref oldFileID, ref fileStatus);

            ViewState["oldFileID"] = oldFileID.ToString();
            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        protected void FileHandling(string fileName, bool overwrite,
            string tempFileSavedFilePath)
        {
            //declarations
            String file = ViewState["file"].ToString();
            string savedFilePath = ExtensionMethods.FileServerPath +
              listChargeType.SelectedItem.Value + "_" + fileName +
              "_" + System.DateTime.Now.ToString("yyyyMMddhhmmss") +
              Path.GetExtension(file);

            Mboss.BusinessLogic.FileUpload.FileEntryBsl fileEntry =
                new BusinessLogic.FileUpload.FileEntryBsl();

                      List<Mboss.DataAccessObject.FileUpload.FileDetailsDTO>
                uploadedFileData = new
                List<DataAccessObject.FileUpload.FileDetailsDTO>();

            Mboss.BusinessLogic.FileUpload.UploadFileDataBsl
                uploadRow = new
                Mboss.BusinessLogic.FileUpload.UploadFileDataBsl();

            Mboss.DataAccessObject.FileUpload.FileDetailsDTO row =
                new DataAccessObject.FileUpload.FileDetailsDTO();

            Mboss.BusinessLogic.FileUpload.StoreFileDetailsBsl 
                storeData = new 
                    BusinessLogic.FileUpload.StoreFileDetailsBsl();
            //end of declarations

          
                //mboss file header entry 
                decimal oldFileID = 0;
                oldFileID = Convert.ToDecimal(ViewState["oldFileID"]);
                decimal fileID = fileEntry.CreateFileEntry(
                    file,
                    listChargeType.SelectedItem.Value,
                    savedFilePath, "UPLOADED", overwrite, oldFileID);

            //reading file content
                string[] fileContent = File.ReadAllLines
                    (Server.MapPath(tempFileSavedFilePath));
              
            //creating actual file in file server for saving
                File.Copy(Server.MapPath(tempFileSavedFilePath), 
                    Server.MapPath(savedFilePath), true);

            //deleting temporary textfile
                File.Delete(Server.MapPath(tempFileSavedFilePath));
                
            //looping and reading each row/record from file
                foreach (string readLine in fileContent)
                {
                    char spartor = ';';
                    string[] dataRow = readLine.Split(spartor);

                    //add retrieved row from file to list<filedataObj>
                    row = uploadRow.addRow(dataRow, fileID, "1",
                        listChargeType.SelectedItem.Value);

                    //adding filedata object to list
                    uploadedFileData.Add(row);
                }
               
               
                //write file details to MBOSS database
                storeData.SaveFileData(uploadedFileData);

                //display file contents in repeater
                uploadedDataRepeater.DataSource = uploadedFileData;
                uploadedDataRepeater.DataBind();
                btnSubmit.Enabled = true;
                tableR.Visible = true;

                ViewState["fileID"] = fileID.ToString();
           
        }


        /// <summary>
        /// Creating task upon submit click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           
            try
            {
                string fileID = ViewState["fileID"].ToString();

                Mboss.BusinessLogic.FileUpload.CreateTRNTaskBsl createTRNTask 
                    = new BusinessLogic.FileUpload.CreateTRNTaskBsl();

                createTRNTask.Create("0", "Pending Submission", 
                    fileID);   
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ChangePaint", "submit();", true);
                btnSubmit.Enabled = false;
                tableR.Visible = false;
                uploadedDataRepeater.DataSource = null;
                uploadedDataRepeater.DataBind();
     
            }
            catch
            {
                string errorCode = Mboss.Common.Properties.Resources.
                    MBS01LOG10001;
                handleError(errorCode);
            }
            finally {
                
            }

        }


        /// <summary>
        /// File Overwrite Action 'yes'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void overwiteYes_Click(object sender, EventArgs e)
        {
           
            string file = ViewState["file"].ToString();
            string fileName = file.Substring(0,
                     file.Length - 4);
            string tempFileSavedFilePath = ViewState["tempFileSavedFilePath"].ToString();
            FileHandling(fileName, true, tempFileSavedFilePath);
        }

        /// <summary>
        /// File Overwrite Action 'No'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void overwriteNo_Click(object sender, EventArgs e)
        {
            string tempFileSavedFilePath = ViewState["tempFileSavedFilePath"].ToString();
            File.Delete(Server.MapPath(tempFileSavedFilePath));

            btnSubmit.Enabled = false;
            tableR.Visible = false;
            uploadedDataRepeater.DataSource = null;
            uploadedDataRepeater.DataBind();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "ChangePaint", "hid();", true);
        }
          
        protected void btnalreadySubmittedOk_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ChangePaint", "hid();", true);
        }

        protected void btnchargetypeOk_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ChangePaint", "hid();", true);
        }

        protected void btnSubmitSuccessOk_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ChangePaint", "hid();", true);
        }

    }
}