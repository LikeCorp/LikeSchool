<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/mainpage.Master" AutoEventWireup="true"
    CodeBehind="index.aspx.cs" Inherits="LikeSchool.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="span20">
            <h2>Like school Dashboard</h2>
        </div>
    </div>
    <hr class="container" />
    <!--Todo: the dashboard need to be called based on the roles -->
    <div class="container">
        <% foreach(LikeSchool.Configuration.MenuElement element in Elements){ %>
        <div class="span2">
            <a href="<%=element.NavigateUrl %>" onclick="<%=element.ClientClickEvent %>">
                <img src="<%=element.ImageUrl %>" /></a>
            <h3 class="dash"><%=element.DisplayText %></h3>
        </div>
        <%} %>        
    </div>
    <br />
    <br />
    <hr class="container" />
    <div class="container">
        <div class="span20">
           <h3>Events of this Month</h3>
        </div>
    </div>
    <hr class="container" />
</asp:Content>
