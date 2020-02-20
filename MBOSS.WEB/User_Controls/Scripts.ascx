<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Scripts.ascx.cs" Inherits="Mboss.Web.User_Controls.Scripts" %>
 <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Scripts>
            <%--Framework Scripts--%>
            <asp:ScriptReference Name="MsAjaxBundle" />
            <asp:ScriptReference Name="jquery" />
            <asp:ScriptReference Name="jquery.ui.combined" />
            <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
            <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
            <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
            <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
            <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
            <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
            <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
            <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
            <asp:ScriptReference Name="WebFormsBundle" />
            <%--Site Scripts--%>
        </Scripts>
    </asp:ScriptManager>
<script src="../Scripts/jquery-1.11.3.min.js" type="text/javascript"></script>
<script src="../Scripts/DataTable/jquery.dataTables.min.js" type="text/javascript"></script>
<script src="../Scripts/DataTable/dataTables.bootstrap.min.js" type="text/javascript"></script>
<script src="../Scripts/pulgins/bootstrap.js" type="text/javascript"></script>
<script src="../Scripts/pulgins/bootstrap.min.js" type="text/javascript"></script>
<script src="../Scripts/jquery-ui.js" type="text/javascript"></script>
<script src="../Scripts/jquery-ui-1.11.4.js" type="text/javascript"></script>
<script src="../Scripts/jquery-ui-1.11.4.min.js" type="text/javascript"></script>
<script src="../Scripts/jquery.validate.js" type="text/javascript"></script>
<script src="../Scripts/jquery.validate.min.js" type="text/javascript"></script>
<script type="text/javascript">
    function popupwindow(url, title, w, h) {
        var left = (screen.width / 2) - (w / 2);
        var top = (screen.height / 2) - (h / 2);
        return window.open(url, title, 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
    }
</script>

<%--Script for File upload page--%>
<script type="text/javascript">
    $(document).ready(function () {

        //$('#uploadedDataTable').dataTable({
        //    "pageLength": 10
        //});

      //  $("#alertInfo").dialog();

        $(".mainmenu").hover(function () {
            $(".submenu").show();

        }, function () {
            $(".submenu").hide();
        }
            );


        $("#fUpload").click(function () {
            $("#helpText").html("<span class='glyphicon glyphicon-search'></span>Can upload only .csv or .txt files");
            $("#helpText").css("color", "Gray");
        });

        $("#fUpload").change(function () {
            
            $("#btnUpload").click(function () {
               
            });

            if ($("#fUpload").length > 0) {
                        
                    $("#btnUpload").prop('disabled', false);
                }
            
            else {
                $("#btnUpload").prop('disbaled', true);
            }
        });

    });
</script>
