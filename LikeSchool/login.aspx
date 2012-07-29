<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/Login.Master" AutoEventWireup="true"
    CodeBehind="login.aspx.cs" Inherits="LikeSchool.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div id="right" style="width: 350px; float: right; margin: 0;">
            <div id="span5 offset5">
                <form class="form-horizontal">
                <fieldset>
                    <legend>Login</legend>
                    
                    <div class="control-group">
                        <label class="control-label" for="user">Username or UserId</label>
                        <div class="controls">
                            <input type="text" class="input-xlarge" id="user" runat="server" onfocus="javascript:fnHideMessage()">
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="pass">Password</label>
                        <div class="controls">
                            <input type="password" class="input-xlarge" id="pass" runat="server">
                        </div>
                    </div>
                    <div class="controls">
                        <label class="checkbox">
                            <input type="checkbox" id="rememberCheckbox" value="rememberMe" runat="server">
                            Remember Me
                        </label>
                    </div>
                    <div class="form-actions">
                        <button type="submit" class="btn btn-info" id="loginBtn" runat="server">Login</button>
                        <button class="btn">Forgot Password ?</button>
                    </div>
                    <span class="error" id="errorid">Invalid Username and Password</span>
                </fieldset>
                </form>
            </div>
        </div>
        <div id="left" style="margin: 0 360px 0 30px">
            <h1>Like School</h1>
            <br />
            <p style="line-height: 35px;">
                Like School is a School Management Application Software, Which is unparallel and
                comprehensive School Software that covers each and every entity of school. It is
                an interactive platform for all the entities of School like Teachers, Management,Financial
                Department, Students, Parents and Librarian etc.
            </p>
            <br />
            <p>
               <strong> Like School </strong>is suitable for Educational Institutions:
            </p>
            <ul id="features">
                <li>Schools</li>
                <li>Degree/Professional Colleges </li>
                <li>Coaching/Other Institutes</li>
            </ul>
        </div>
    </div>
</asp:Content>
