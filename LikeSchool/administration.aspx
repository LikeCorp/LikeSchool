<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/mainpage.Master" AutoEventWireup="true" CodeBehind="administration.aspx.cs" Inherits="LikeSchool.administration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class="span20">
            <h2>Administration Dashboard</h2>
        </div>
    </div>
    <hr class="container" />
    
    <div class="container">
        <% foreach(LikeSchool.Configuration.MenuElement element in submenus){ %>
        <div class="span2">
            <a href="<%=element.NavigateUrl %>">
                <img src="<%=element.ImageUrl %>" /></a>
            <h3 class="dash"><%=element.DisplayText %></h3>
        </div>
        <%} %>        
    </div>
   
</asp:Content>
