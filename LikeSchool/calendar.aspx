<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Masterpages/mainpage.Master"
    CodeBehind="calendar.aspx.cs" Inherits="LikeSchool.calendar" %>

<%@ Register Src="~/Controls/Calendar.ascx" TagPrefix="uc1" TagName="Calendar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:calendar runat="server" id="Calendar" />
    
</asp:Content>
