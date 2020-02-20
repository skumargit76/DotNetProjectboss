<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskList.aspx.cs" Inherits="Mboss.Web.Tasks.TaskList" %>

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
    </head>
<body style="background-color:white;" class="container-fluid">
    <form id="mainForm" runat="server">
        <scripts:Scripts runat="server" id="Scripts" />
        <div class="container-fluid">
           <div class="row-fluid">
         <menu:Menu runat="server" id="Menu" />
               <asp:Panel ID="mainContent" runat="server" Visible="true">
    
         <div class="span12">
                    <asp:Label runat="server" ID="lblTransactionType" Text="Transaction Type : "></asp:Label>
                    <asp:DropDownList runat="server" ID="ddllistTransactionType" TabIndex="1" Height="50%" Width="190px">
                    </asp:DropDownList>
                 &nbsp;<asp:Label runat="server" ID="lblTaskType" Text="Task Type : "></asp:Label>
                    <asp:DropDownList runat="server" ID="ddllistTaskType" TabIndex="2" Height="50%" Width="280px">
                    </asp:DropDownList>
                 &nbsp;<asp:Label runat="server" ID="lblFromDate" Text="Date From : "></asp:Label>
                    <asp:TextBox ID="txtFromDate" runat="server" ReadOnly="true"  Width="108px"></asp:TextBox>
                 &nbsp;<asp:Label runat="server" ID="Label3" Text="Date To : "></asp:Label>
                    <asp:TextBox ID="txtToDate" runat="server" ReadOnly="true"  Width="108px"></asp:TextBox>
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
                                    <th>Transactin Type</th>
                                    <th>Task Type</th>
                                    <th>M-BOSS Task ID</th>
                                    <th>T24 Task ID</th>
                                    <th>Override/Error Message ?</th>
                                    <th>Created Date & Time</th>
                                    <th>Created By</th>
                                    <th>View / Process Task</th>
                                </tr>
                         </thead>
                         <tbody>
                        <asp:Repeater ID="uploadedDataRepeater" runat="server">
                        <ItemTemplate>
                            <tr>
                            <td><%# Eval("TRANSACTION_TYPE") %></td>
                            <td><%# Eval("TASK_TYPE") %></td>
                            <td><%# Eval("M_BOSS_TASK_ID") %></td>
                            <td><%# Eval("T24_TASK_ID") %></td>
                            <td><%# Eval("OVERRIDE_ERROR_MESSAGE") %></td>
                            <td><%# Eval("CREATED_DATE") %></td>
                            <td><%# Eval("CREATED_BY") %></td>
                            <td>
                               <asp:button ID="btnView" runat="server" Text="View" />
                               <asp:button ID="btnProcess" runat="server" Text="Process Task"/>

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
    <style type="text/css">.ui-datepicker { font-size:8pt !important}</style>
    </form>
</body>
</html>
