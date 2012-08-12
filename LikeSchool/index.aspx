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
    <hr class="container"/>
    <div class="container">        
        <div class="span2">
            <a href="studentdetail.aspx">
                <img src="img/dashboard/profile.png" /></a>
            <h3 class="dash">Student Details</h3>
        </div>
        <div class="span2">
            <a href="attendance.aspx">
                <img src="img/dashboard/attendance.png" /></a>
            <h3 class="dash">Attendance</h3>
        </div>
        <div class="span2">
            <a href="leave.aspx">
                <img src="img/dashboard/leave.png" /></a>
            <h3 class="dash">Leave</h3>
        </div>
        <div class="span2">
            <a href="timetable.aspx">
                <img src="img/dashboard/timetable.png" /></a>
            <h3 class="dash">TimeTable</h3>
        </div>
        <div class="span2">
            <a href="calendar.aspx">
                <img src="img/dashboard/calendar.png" /></a>
            <h3 class="dash">Calendar</h3>
        </div>        
        <div class="span2">
            <a href="#">
                <img src="img/dashboard/support.png" /></a>
            <h3 class="dash">Support</h3>
        </div>
        <div class="span2">
            <a href="#">
                <img src="img/dashboard/settings.png" /></a>
            <h3 class="dash">Settings</h3>
        </div>
    </div>
</asp:Content>
