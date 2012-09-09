<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/mainpage.Master" AutoEventWireup="true"
    CodeBehind="searchstudent.aspx.cs" Inherits="LikeSchool.SearchStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/bootstrap-datatables.css" />
    <link rel="stylesheet" type="text/css" href="css/jquery.dataTables.css" />
    <script type="text/javascript" src="js/jquery.dataTables.js"></script>
    <script type="text/javascript" src="js/bootstrap-typeahead.js"></script>
    <script type="text/javascript" src="../js/searchstudent.js"></script>
    <script type="text/javascript" src="js/bootstrap-datatables.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="search" autocomplete="off">
    <div class="container">
        <h2>Search Student</h2>
    </div>
    <hr class="container" />
    <div class="container">
        <div class="control-group">
            <label class="control-label" for="inputEmail">
                <h4>Search By:</h4>
            </label>
            <div class="controls searchRadio">
                <label class="radio inline">
                    <input type="radio" name="optionsRadios" id="adno" value="admission" checked="checked" />
                    Admission No
                </label>
                <label class="radio inline">
                    <input type="radio" name="optionsRadios" id="classid" value="class" />
                    Class-Section
                </label>
            </div>
        </div>
        ,
        <br />
        <div class="control-group">
            <div class="controls">
                <input type="text" class="span7" id="searchtext" style="height: 30px" placeholder=""
                    data-provide="typeahead" data-source="" data-items="4" />
                <button class="btn btn-info" type="button" style="height: 40px; margin-top: -7px;
                    width: 100px;" id="searchSubmit">
                    <i class="icon-search icon-black"></i>&nbsp;Search
                </button>
                <span class="help-block">Type your search text and select the system suggested text.
                </span>
            </div>
        </div>
    </div>
    <hr class="container" />
    <div class="container" id="resultSpan" style="display: none">
        <h4>Search Result:</h4>
    </div>
    <br />
    <div class="container" id="searchResult">
        <div class="loading" id='searchloading'>
            <span class='loadingText'>Loading...</span>
        </div>
    </div>
    </form>
</asp:Content>
