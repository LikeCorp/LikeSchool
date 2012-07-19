<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/Login.Master" AutoEventWireup="true"
    CodeBehind="login.aspx.cs" Inherits="LikeSchool.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="span 5">
        <form class="form-horizontal">
        <fieldset>
            <legend>Login</legend>
            <div class="control-group">
                <label class="control-label" for="input01">Username or UserId</label>
                <div class="controls">
                    <input type="text" class="input-xlarge" id="input01">
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="input01">Password</label>
                <div class="controls">
                    <input type="password" class="input-xlarge" id="Text1">
                </div>
            </div>
            <div class="form-actions">
            <button type="submit" class="btn btn-info">Login</button>
            <button class="btn">Forgot Password ?</button>
          </div>
        </fieldset>
        </form>
    </div>
</asp:Content>
