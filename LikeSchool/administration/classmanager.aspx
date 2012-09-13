<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/mainpage.Master" AutoEventWireup="true" CodeBehind="classmanager.aspx.cs" Inherits="LikeSchool.classmanager" %>
<%@ Register Src="~/Controls/breadcrumb.ascx" TagPrefix="bc1" TagName="BreadCrumb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <bc1:BreadCrumb runat="server" ID="BreadCrumb" />
        <div class="row-fluid">
            <div class="span2">
                <!--Sidebar content-->
            </div>
            <div class="span10">
                <!--Body content-->
            </div>
        </div>
    </div>
</asp:Content>
