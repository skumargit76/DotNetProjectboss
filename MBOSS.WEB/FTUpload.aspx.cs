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
using Mboss.DataAccess;

namespace Mboss.Web
{
    public partial class FTUpload : MainPage
    {
        //private variables visible to whole class
        string userID = null;
        bool invalid = true;

      
        /// <summary>
        /// page load function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //login user name
            try
            {
                //Mboss.DataAccess.WebServices.ReadXMLDta wb = new DataAccess.WebServices.ReadXMLDta();
                //wb.readxml();
                
                PrepareMenu();
                    if (!(Page.IsPostBack))
                    {
                LoadChargeTypes();
            }
            }
            catch(System.Exception ex)
            {
                if (userID.IsNullOrEmpty())
                {
                    invalid = false;
                    Response.Redirect("Default.aspx");  
                }

                string errorCode = Mboss.Common.Properties.Resources.
                    MBS01LOG10001;
                handleError(errorCode);
            }
            finally {
                if (invalid)
                {
                    Response.Redirect("error.aspx");
                }
            }
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
        /// display menu based on the user rights
        /// </summary>
        protected void PrepareMenu()
        {
            List<MenuDTO> menuItem = new List<MenuDTO>();
            string userID = Session["userID"].ToString();
            string currentUrl = HttpContext.Current.Request.Url.AbsolutePath;
          
            char spartor = '/';
            string[] array = currentUrl.Split(spartor);
            currentUrl = array.Last();
           currentUrl = currentUrl.TrimStart('/');
    
            if (userID.IsNullOrEmpty())
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                decimal roleID = Convert.ToDecimal(Session["roleID"].ToString());
                Control ul = Menu.FindControl("Ul1");
                Control ul2 = Menu.FindControl("Ul2");
                GenerateMenu genMenu = new GenerateMenu();
                menuItem = genMenu.MenuItems(roleID);

                var result = from modules in menuItem select new { moduleName = modules.moduleName};
                result = result.Distinct();

                foreach (var mods in result)
                {
                    var forms = from urls in menuItem where urls.moduleName == mods.moduleName orderby urls.formSequence select new { formnames = urls.formName, url = urls.formUrl };
                    if (forms.Count() > 1)
                    {
                        ul.Controls.Add(new Literal()
                        {
                            Text = "<li class='mainmenu'><a  href='" + forms.Last().url +
                            "'style='width:auto;'>" + mods.moduleName + "</a><ul class='submenu' runat='server' style='background-color: #000080;list-style:none;display:none; text-align:left;'>"
                        });

                        foreach (var item in forms)
                        {
                            if (currentUrl == item.url)
                            {
                                invalid = false;
                            }
                            ul.Controls.Add(new Literal()
                            {
                                Text = "<li><a style='background-color:#000080;' href='" + item.url +
                                "'style='width:auto;'>" + item.formnames + "</a></li>"
                            });
                        }
                        ul.Controls.Add(new Literal()
                        {
                            Text = "</li></ul>"
                        });
                    }
                    else
                    {
                        if (currentUrl == forms.First().url)
                        {
                            invalid = false;
                        }
                        ul.Controls.Add(new Literal()
                        {
                            Text = "<li><a  href='" + forms.Last().url +
                            "'style='width:auto;'>" + mods.moduleName + "</a></li>"
                        });
                    }
                }             

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
                           //popup do you want to override file
                           // ScriptManager.RegisterStartupScript(this, this.GetType(), "alertInfo", "$(alertInfo).dialog();", true);

                           if (fileStatus == "UPLOADED")
                           {
                               ScriptManager.RegisterStartupScript(this, this.GetType(), "ChangePaint", "launchmodal();", true);
                           }
                           else if (fileStatus == "SUBMITTED")
                           {
                               ScriptManager.RegisterStartupScript(this, this.GetType(), "ChangePaint", "alreadySubmit();", true);
                           }
                           }
                       }
                   }
               else
               {
                   ScriptManager.RegisterStartupScript(this, this.GetType(), "ChangePaint", "charge();", true);
               }
               else
               {
                   ScriptManager.RegisterStartupScript(this, this.GetType(), "ChangePaint", "charge();", true);
            }
            }
            catch
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
            Mboss.BusinessLogic.FileUpload.FileExtensions fileExtenstion = new 
                BusinessLogic.FileUpload.FileExtensions();
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
            bool uploaded = false;
            try
            {
                string fileID = ViewState["fileID"].ToString();

                Mboss.BusinessLogic.FileUpload.CreateTRNTaskBsl createTRNTask 
                    = new BusinessLogic.FileUpload.CreateTRNTaskBsl();

                createTRNTask.Create("Pending", "FT Upload Submission", 
                    fileID);

                uploaded = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ChangePaint", "submit();", true);
     
            }
            catch
            {
                string errorCode = Mboss.Common.Properties.Resources.
                    MBS01LOG10001;
                handleError(errorCode);
            }
            finally {
                if (uploaded)
                {
                    Response.Redirect("~/FTUpload.aspx");
                }
            }

        }


        /// <summary>
        /// File Overwrite Action 'yes'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void overwiteYes_Click(object sender, EventArgs e)
        {
            overwrite.Visible = false;
            mainContent.Visible = true;
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