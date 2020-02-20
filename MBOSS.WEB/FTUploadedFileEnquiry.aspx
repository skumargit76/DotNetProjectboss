<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FTUploadedFileEnquiry.aspx.cs" Inherits="Mboss.Web.FTUploadedFileEnquiry" %>

<%@ Register Src="~/User_Controls/Header.ascx" TagPrefix="headers" TagName="Header" %>
<%@ Register Src="~/User_Controls/Menu.ascx" TagPrefix="menu" TagName="Menu" %>
<%@ Register Src="~/User_Controls/Scripts.ascx" TagPrefix="scripts" TagName="Scripts" %>
<%@ Register Src="~/User_Controls/Footer.ascx" TagPrefix="footer" TagName="Footer" %>

<link type="text/css" href="~/Content/css/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
<script type="text/javascript" src="~/Scripts/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="~/Scripts/jquery-ui-1.8.20.min.js"></script>


<!DOCTYPE html>
<html lang="en">
    <head runat="server" id="mainHeader">
         <headers:Header runat="server" id="Header" />
    <style type="text/css">.ui-datepicker { font-size:8pt !important}</style>
    </head>
<body style="background-color:white;" class="container-fluid">
    <form id="mainForm" runat="server">
        <scripts:Scripts runat="server" id="Scripts" />
        <div class="container-fluid">
           <div class="row-fluid">
         <menu:Menu runat="server" id="Menu" />
               <asp:Panel ID="mainContent" runat="server" Visible="true">
    
         <div class="span12">
                 <asp:Label runat="server" ID="lblFromDate" Text="Date From : "></asp:Label>
                    <asp:TextBox ID="txtFromDate" runat="server" ReadOnly="true" Width="108px"></asp:TextBox>
                 &nbsp;<asp:Label runat="server" ID="lblRndDate" Text="Date To : "></asp:Label>
                    <asp:TextBox ID="txtToDate" runat="server" ReadOnly="true"  Width="108px"></asp:TextBox>
                 &nbsp;<asp:Label runat="server" ID="Label1" Text="File Type : "></asp:Label>
                    <asp:DropDownList runat="server" ID="ddllistFileType" TabIndex="1" Height="50%" Width="190px">
                    </asp:DropDownList>
                 &nbsp;<asp:Label runat="server" ID="Label2" Text="File Status : "></asp:Label>
                    <asp:DropDownList runat="server" ID="ddllistFileStatus" TabIndex="2" Height="50%" Width="155px">
                    </asp:DropDownList>
                 &nbsp;
                 <asp:Button ID="btnFilter" runat="server" CssClass="btn btn-primary" Text="Filter"  OnClick="btnFilter_Click" Height="33px" Width="74px" />
         </div>
            <hr />
  
           <asp:UpdatePanel ID="tableContent" runat="server" UpdateMode="Conditional">
               <ContentTemplate>
            <div class="span12">
               <div class="span12" runat="server" id="tableR" visible="false" style="height:400px; overflow:scroll;" >
                     <table id="UploadedFileFilterDataTable" class="table table-striped table-bordered" tabindex="4">
                         <thead style="background-color:#000080; color:white;">
                                <tr>
                                    <th>File Type</th>
                                    <th>File Name</th>
                                    <th>File Status</th>
                                    <th>Upload / Submitted Date & Time</th>
                                    <th>Uploaded / Submitted By</th>
                                    <th>View Details</th>
                                </tr>
                         </thead>
                         <tbody>
                        <asp:Repeater ID="uploadedDataRepeater" runat="server">
                        <ItemTemplate>
                            <tr>
                            <td><%# Eval("FileType") %></td>
                            <td><%# Eval("FileName") %></td>
                            <td><%# Eval("FileStatus") %></td>
                            <td><%# Eval("UploadedDate") %></td>
                            <td><%# Eval("UploadedBy") %></td>
                            <td>
                               <asp:button ID="btnView" runat="server" Text="View" onclick="btnView_Click" TypeCode='<%# Eval("TYPE_CODE") %>'  FileStatus='<%# Eval("FileStatus") %>' CommandArgument='<%# Eval("FileId") %>'/>
                            </td>
                            </tr>
                       </ItemTemplate>
                      </asp:Repeater>
                     </tbody>
                    </table>
                   </div>
                  </div>
                </ContentTemplate>
               </asp:UpdatePanel>
              </asp:Panel>
             </div>
            </div>
        <footer:Footer runat="server" id="Footer" />
        
     <script type="text/javascript">
            $(function () {
                var dates = $("#txtFromDate, #txtToDate").datepicker({
                    minDate: '-30D',
                    maxDate: '0',
                    onSelect: function (selectedDate) {
                        var option = this.id == "txtFromDate" ? "minDate" : "maxDate",
        instance = $(this).data("datepicker"),
        date = $.datepicker.parseDate(
        instance.settings.dateFormat ||
        $.datepicker._defaults.dateFormat,
        selectedDate, instance.settings);
                        dates.not(this).datepicker("option", option, date);
                    }
                });
            });
    </script>
 
    </form>
</body>
</html>
