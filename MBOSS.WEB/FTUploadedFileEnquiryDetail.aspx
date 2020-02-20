<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FTUploadedFileEnquiryDetail.aspx.cs" Inherits="Mboss.Web.FTUploadedFileEnquiryDetail" %>

<%@ Register Src="~/User_Controls/Header.ascx" TagPrefix="headers" TagName="Header" %>
<%@ Register Src="~/User_Controls/Logo.ascx" TagPrefix="logo" TagName="Logo" %>
<%@ Register Src="~/User_Controls/Scripts.ascx" TagPrefix="scripts" TagName="Scripts" %>
<%@ Register Src="~/User_Controls/Footer.ascx" TagPrefix="footer" TagName="Footer" %>


<!DOCTYPE html>
<html lang="en">
  <head runat="server" id="mainHeader">
         <headers:Header runat="server" id="Header" />
    </head>
<body style="background-color:white;" class="container-fluid">
    <form id="mainForm" runat="server">
        <scripts:Scripts runat="server" id="Scripts" />
         <logo:Logo runat="server" id="Logo" />

        <div class="container-fluid">
            <div class="row-fluid">
                <asp:Panel ID="mainContent" runat="server" Visible="true">

             <div class="span12">
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Label runat="server" ID="lblFileStatus"  Text="File Status :"></asp:Label>
                    <asp:Label runat="server" ID="lblFileStatusResult"></asp:Label>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label runat="server" ID="lblFileType" Text="File Type :"></asp:Label>
                    <asp:Label runat="server" ID="lblFileTypeResult"></asp:Label>
             </div>
                     <hr />

                    <asp:UpdatePanel ID="tableContent" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                        <div class="span12">
                        <div class="span12" runat="server" id="tableR" visible="true" style="height:400px; overflow:scroll;" >
                    
                     <table id="UploadedFileDataTable" class="table table-striped table-bordered" tabindex="4">
                         <thead style="background-color:#000080; color:white;">
                                <tr>
                                    <th>Debit Account Number</th>
                                    <th>Debit Currency</th>
                                    <th>Debit Amount</th>
                                    <th>Credit Account Number</th>
                                    <th>Credit Currency</th>
                                    <th>Credit Amount</th>
                                    <th>Customer Rate</th>
                                    <th>Transaction Type</th>
                                    <th>Value Date</th>
                                    <th>Payment Details 1</th>
                                    <th>Payment Details 2</th>
                                    <th>Payment Details 3</th>
                                </tr>
                         </thead>
                        <tbody>   
                    <asp:Repeater ID="uploadedFileEnquiryDetailsDataRepeater" runat="server">
                        <ItemTemplate>
                            <tr>
                            <td><%# Eval("DEBIT_ACCOUNT") %></td>
                            <td><%# Eval("DEBIT_CURRENCY") %></td>
                            <td><%# Eval("DEBIT_AMOUNT") %></td>
                            <td><%# Eval("CREDIT_ACCOUNT") %></td>
                            <td><%# Eval("CREDIT_CURRENCY") %></td>
                            <td><%# Eval("CREDIT_AMOUNT") %></td>
                            <td><%# Eval("CUSTOMER_RATE") %></td>
                            <td><%# Eval("TRANSACTION_TYPE") %></td>
                            <td><%# Eval("DEBIT_VALUE_DATE") %></td>    
                            <td><%# Eval("PAYMENT_DETAILS_1") %></td>
                            <td><%# Eval("PAYMENT_DETAILS_2") %></td>
                            <td><%# Eval("PAYMENT_DETAILS_3") %></td>
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
       
            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnCancel" runat="server" Text="Close" OnClick="btnCancel_Click" />
           <asp:Button ID="btnSubmit" runat="server" Visible="false" Text="Submit" OnClick="btnSubmit_Click" />
        <footer:Footer runat="server" id="Footer" />
    </form>
</body>
</html>
