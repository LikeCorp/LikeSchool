<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/mainpage.Master" AutoEventWireup="true"
    CodeBehind="leave.aspx.cs" Inherits="LikeSchool.leave" %>
<%@ Register Src="~/Controls/breadcrumb.ascx" TagPrefix="bc1" TagName="BreadCrumb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
         <bc1:BreadCrumb runat="server" ID="BreadCrumb" />
        <div class="row-fluid">
            <div class="span2">
               <div class="well sidebar-nav">
                    <ul class="nav nav-list prof">
                        <li class="nav-header">Course Menu</li>
                        <li class="active"><a href="#" id="manageCourse" hint="first"><i class="icon-search icon-black"></i>&nbsp;Manage Course</a></li>
                        <li><a href="#" id="manageSubject" hint="second"><i class="icon-th icon-black"></i>&nbsp;Manage Subject</a></li>
                        <li><a href="#" hint="third"><i class="icon-list-alt icon-black"></i>&nbsp;Report</a>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="span10">
                <!--Body content-->
            </div>
        </div>
    </div>
</asp:Content>
