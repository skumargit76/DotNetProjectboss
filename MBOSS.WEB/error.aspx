<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="Mboss.Web.error" MasterPageFile="~/Site.Master" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server" ID="errorpage_content">
    <main class="middle">
      <div class="container3">
		<table id="Table_01" width="80%" border="0" cellpadding="0" cellspacing="0">
            <tr><td>&nbsp;</td></tr>
		    <tr>
				<td> <div>
   <asp:Label runat="server" ID="errorMessage" Text="" ForeColor="Red"></asp:Label> 
                     - Please conatct Admin abcd@mizuho.com 
    </div></td>
			</tr>		
		</table>	
		<br> <br> <br>
        </div>	
    </main>
    </asp:Content>