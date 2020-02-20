<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Mboss.Web.content" MasterPageFile="~/Site.Master" %>

<asp:Content ContentPlaceHolderID="headerContent" ID="dynamic_header" runat="server">
    <div align="center">
        <nav class="header2" >
            <asp:Menu Orientation="Horizontal" runat="server" ID="loginMenu" Height="25px" BackColor="Black" ForeColor="white" BorderColor="White">
                <DynamicHoverStyle BackColor="Red" ForeColor="WhiteSmoke" />
            </asp:Menu>
        </nav>
            </div>
</asp:Content>
 <asp:content runat="server" ContentPlaceHolderID="MainContent"> 
      <div class="container3">
		<table id="Table_01" width="80%" border="0" cellpadding="0" cellspacing="0">
            <tr><td>&nbsp;</td></tr>
		    <tr>
				<td> Welcome <asp:Label runat="server" ID="userName" Text="" ForeColor="Red"></asp:Label></td>
			</tr>
			<tr>
                <td>&nbsp;</td>
			</tr>
			<tr>
				<td>Please choose what action you wanted from the menu button on top</td>
			</tr>
		</table>
		<br> <br> <br>
		<a href="../Mizuho/enquiry_file_upload.html">File Upload Enquiry </a>
		<br> <br> <br>
        </div>   
      </asp:content>