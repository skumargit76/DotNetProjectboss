<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Mboss.Web.User_Controls.Header" %>

<meta charset="utf-8" />
<title><%: Page.Title %> Mizuho MBOSS</title>
<meta name="viewport" content="width=device-width, initial-scale=1.0" />
<asp:PlaceHolder ID="PlaceHolder1" runat="server">
    <%: Scripts.Render("~/bundles/modernizr") %>
</asp:PlaceHolder>
<webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/css" />
<link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
<link href="../Content/css/sitemaster.css" rel="stylesheet" />
<%--<link href="../Scripts/pulgins/bootstrap.css" rel="stylesheet" />--%>
<%--<link href="../Content/css/bootstrap.css" rel="stylesheet" />--%>
<link href="../Scripts/pulgins/bootstrap.css" rel="stylesheet" />
<link href="../Scripts/pulgins/bootstrap-responsive.css" rel="stylesheet" />
<link href="../Content/css/bootstrap-modal.css" rel="stylesheet" />
<link href="../Content/css/bootstrap.min.css" rel="stylesheet" />
<link href="../Content/css/dataTables.bootstrap.min.css" rel="stylesheet" />
<link href="../Content/themes/base/jquery-ui.css" rel="stylesheet" />
<link href="../Content/themes/base/jquery.ui.dialog.css" rel="stylesheet" />
<link href="../Content/css/jquery-ui-1.10.1.custom.css" rel="stylesheet" />

