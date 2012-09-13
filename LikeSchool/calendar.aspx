<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Masterpages/mainpage.Master"
    CodeBehind="calendar.aspx.cs" Inherits="LikeSchool.calendar" %>

<%@ Register Src="~/Controls/calendar.ascx" TagPrefix="uc1" TagName="Calendar" %>
<%@ Register Src="~/Controls/breadcrumb.ascx" TagPrefix="bc1" TagName="BreadCrumb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function GetLoginId() {
            return $("#<%= LoginIdField.ClientID%>").val();
        }

        function GetLoginName() {
            return $("#<%= LoginNameField.ClientID%>").val();
        }

        function GetRoleName() {
            return $("#<%= RoleNameField.ClientID%>").val();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <bc1:BreadCrumb runat="server" ID="BreadCrumb" />
    </div>
    <uc1:Calendar runat="server" ID="Calendar" />
    <form id="Form1" runat="server">
        <asp:HiddenField ID="LoginIdField" runat="server" />
        <asp:HiddenField ID="LoginNameField" runat="server" />
        <asp:HiddenField ID="RoleNameField" runat="server" />
    </form>
</asp:Content>
