<%@ Page Language="C#" AutoEventWireup="true" Title="File Upload" CodeBehind="FTUpload.aspx.cs" Inherits="Mboss.Web.FTUpload" EnableViewState="true" %>
<%@ Register Src="~/User_Controls/Header.ascx" TagPrefix="headers" TagName="Header" %>
<%@ Register Src="~/User_Controls/Menu.ascx" TagPrefix="menu" TagName="Menu" %>
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
        <div class="container-fluid">
            <div class="row-fluid">
         <menu:Menu runat="server" id="Menu" />
             <asp:Panel ID="mainContent" runat="server" Visible="true">
            <div class="span12">
                <div class="span4">
                <table class="table" style="border:none;">
                    <tr style="border:none;">
                        <td><asp:Label runat="server" ID="lblChargeType" Text="Charge Type:"></asp:Label></td>
                        <td><asp:DropDownList runat="server" ID="listChargeType" TabIndex="1" height="50%">
                        <asp:ListItem Value="1" Text="Select Option" Enabled="true"></asp:ListItem>
                    </asp:DropDownList></td>
                    </tr>
                    <tr style="border:none;">
                        <td><asp:Label runat="server" ID="lblFileUpload" Text="File to be uploaded:"></asp:Label></td>
                        <td>
                                                    
                                <asp:FileUpload ID="fUpload" runat="server" EnableViewState="true"  /> 
                                <p class="help-block" id="helpText" runat="server"><span class="glyphicon glyphicon-search"></span>Can upload only .csv or .txt files</p>
                            
                        </td>
                    </tr>
                    <tr style="border:none;">
                        <td> <asp:Button CssClass="btn btn-info span6" ID="btnUpload" Text="&#8679; Upload" TabIndex="3" runat="server" Enabled="false" OnClick="btnUpload_Click" BorderStyle="None" ForeColor="White" BackColor="#000066" />
                           
                        </td>
                    </tr>
                </table>
                    </div>
            </div>
                 <hr />
           <asp:UpdatePanel ID="tableContent" runat="server" UpdateMode="Conditional">
               <ContentTemplate>
            <div class="span12">
                <div class="span12" runat="server" id="tableR" visible="false" style="height:400px; overflow:scroll;" >
                     <table id="uploadedDataTable" class="table table-striped table-bordered" tabindex="4">
                         <thead style="background-color:#000080; color:white;">
                                <tr>
                                    <th>Transaction Type</th>
                                    <th>Debit Account</th>
                                    <th>Debit Currency</th>
                                    <th>Debit Amount</th>
                                    <th>Debit Value Date</th>
                                    <th>Debit Narrative</th>
                                    <th>Ordered by 1</th>
                                    <th>Credit Account</th>
                                    <th>Credit Currency</th>
                                    <th>Credit Amount</th>
                                    <th>Credit Value Date</th>
                                    <th>Credit Narrative</th>
                                    <th>Cheque Number</th>
                                    <th>Customer Rate</th>
                                    <th>Payment Details 1</th>
                                    <th>Payment Details 2</th>
                                    <th>Payment Details 3</th>
                                </tr>
                                </thead>
                         <tfoot>
                            <tr>
                                <th colspan="17" style="text-align:right;"><asp:Button ID="btnSubmit" CssClass="btn purple" Text="Submit" TabIndex="5" runat="server" Enabled="false" OnClick="btnSubmit_Click" /></th>
                            </tr>   
                             </tfoot>
                            <tbody>
                            
                           <asp:Repeater ID="uploadedDataRepeater" runat="server">
                                 <ItemTemplate>
                                     <tr>
                                <td><%# Eval("transactionType") %></td>
                                <td><%# Eval("debitAccountNumber") %></td>
                                <td><%# Eval("debitCurrency") %> </td>
                                <td><%# Eval("debitAmount") %> </td>
                                <td><%# Eval("debitValueDate", "{0: dd MMM yyyy}") %> </td>
                                <td><%# Eval("debitNarrative") %> </td>
                                <td><%# Eval("orderedBy1") %> </td>
                                <td><%# Eval("creditAccountNumber") %> </td>
                                <td><%# Eval("creditCurrency") %> </td>
                                <td><%# Eval("creditAmount") %> </td>
                                <td><%# Eval("creditValueDate") %> </td>
                                <td><%# Eval("creditNarrative") %> </td>
                                <td><%# Eval("chequeNumber") %> </td>
                                <td><%# Eval("customerRate") %> </td>
                                <td><%# Eval("paymentDetails1") %> </td>
                                <td><%# Eval("paymentDetails2") %> </td>
                                <td><%# Eval("paymentDetails3") %> </td>
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


        <asp:Panel runat="server" id="submittedFile" >
        <div id="submittedWin" >
            <div id="submittedDialog" class="modal" tabindex="-1">
               <div class="modal-header" style="text-align:center;" >
						<h5>File already submitted</h5>
					                    </div>
                                        <div class="modal-body" style="text-align:center">
                                            <div class ="controls">            
                                                <span>
                                                     <asp:Button ID="btnalreadySubmittedOk" Text="&#10004; Ok" CssClass="btn btn-primary" runat="server"  OnClick="btnalreadySubmittedOk_Click" />
                                                </span>
                                               
                                            </div>
		                         </div>
            </div>
        </div>
            </asp:Panel>   

            <asp:Panel runat="server" id="overwrite">
        <div id="alertInfo">
            <div id="alertInfoForm" class="modal" runat="server">
                <div class="modal-header" style="text-align:center;" >
						<h5>File already exists - do you want to overwrite</h5>
					                    </div>
                                        <div class="modal-body" style="text-align:center">
                                            <div class ="controls">            
                                                <span>
                                                     <asp:Button ID="overwiteYes" Text="&#10004; Yes" CssClass="btn btn-primary" runat="server" OnClick="overwiteYes_Click" />
                                                </span>
                                                <span>&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                                <span>
                                                     <asp:Button ID="overwriteNo" Text="&#10008; No" CssClass="btn btn-primary" runat="server" OnClick="overwriteNo_Click" />
                                                </span>
                                            </div>
		                         </div>
            </div>
        </div>
            </asp:Panel>     

          <asp:Panel runat="server" id="chargetypePanel">
        <div id="chargetypeWin" >
            <div id="chargetypeDialog" class="modal">
               <div class="modal-header" style="text-align:center;" >
						<h5>Please select the charge type</h5>
					                    </div>
                                        <div class="modal-body" style="text-align:center">
                                            <div class ="controls">            
                                                <span>
                                                     <asp:Button ID="btnchargetypeOk" Text="&#10004; Ok" CssClass="btn btn-primary" runat="server"  OnClick="btnchargetypeOk_Click" />
                                                </span>
                                               
                                            </div>
		                         </div>
            </div>
        </div>
            </asp:Panel>   

         <asp:Panel runat="server" id="submitsuccessPanel">
        <div id="submitsuccessWin" >
            <div id="submitsuccessDialog" class="modal" tabindex="-1">
               <div class="modal-header" style="text-align:center;" >
						<h5>Submitted Successfully</h5>
					                    </div>
                                        <div class="modal-body" style="text-align:center">
                                            <div class ="controls">            
                                                <span>
                                                     <asp:Button ID="btnSubmitSuccessOk" Text="&#10004; Ok" CssClass="btn btn-primary" runat="server"  OnClick="btnSubmitSuccessOk_Click" />
                                                </span>
                                               
                                            </div>
		                         </div>
            </div>
        </div>
            </asp:Panel>   
        <script type="text/javascript">
           // var launch = false;
            function launchmodal() {
                $("#alertInfoForm").dialog({
                    autoOpen: true,
                    appendTo: "form",
                    modal: true,
                    width: 600,
                    show: 'fade'

                }).parent().css('z-index', '1005');
                
                $(".ui-dialog-title").text("MBOSS Alert");
                $("#overwiteYes.btn").css('background-color', '#000080');
                $("#overwriteNo.btn").css('background-color', '#000080');
            }


            function submit() {
                $("#submitsuccessDialog").dialog({
                    autoOpen: true,
                    appendTo: "form",
                    modal: true,
                    width: 600,
                    show: 'fade'

                }).parent().css('z-index', '1005');

                $(".ui-dialog-title").text("MBOSS Alert");
                $("#btnSubmitSuccessOk.btn").css('background-color', '#000080');
            }

            function alreadySubmit() {
                $("#submittedDialog").dialog({
                    autoOpen: true,
                    appendTo: "form",
                    modal: true,
                    width: 600,
                    show: 'fade'

                }).parent().css('z-index', '1005');

                $(".ui-dialog-title").text("MBOSS Alert");
                $("#btnalreadySubmittedOk.btn").css('background-color', '#000080');
            }

            function charge() {
                $("#chargetypeDialog").dialog({
                    autoOpen: true,
                    appendTo: "form",
                    modal: true,
                    width: 600,
                    show: 'fade'

                }).parent().css('z-index', '1005');

                $(".ui-dialog-title").text("MBOSS Alert");
                $("#btnchargetypeOk.btn").css('background-color', '#000080');
            }
            function hid() {
             //  $(".ui-dialog").hide('fade');
            }

        </script>
    </form>
</body>
</html>

