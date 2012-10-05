<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/mainpage.Master" AutoEventWireup="true" CodeBehind="course.aspx.cs" Inherits="LikeSchool.course" %>

<%@ Register Src="~/Controls/breadcrumb.ascx" TagPrefix="bc1" TagName="BreadCrumb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/layout.css" rel="stylesheet" />
    <link href="../css/bootstrap-datatables.css" rel="stylesheet" />
    <link href="../css/jquery.dataTables.css" rel="stylesheet" />
    <link href="../css/chosen.css" rel="stylesheet" />
    <script type="text/javascript" src="../js/layoutnavigator.js"></script>
    <script src="../js/jquery.dataTables.js"></script>    
    <script src="../js/bootstrap-alert.js"></script>
    <script type="text/javascript" src="../js/bootstrap-tab.js"></script>
    <script src="../js/chosen.jquery.js"></script>    
    <script type="text/javascript"  src="../js/coursemanager.js"></script>
    <script src="../js/bootstrap-datatables.js"></script>

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
        <div class="page-header">
            <h2>Course Manager</h2>
        </div>
        <div class="row-fluid">
            <div class="span3">
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
            <div class="span8">
                <div id="first" class="profs" style="display: none;">
                    <div class="tabbable tabs-right">
                        <ul id="myTab" class="nav nav-tabs">
                            <li class="active">                                
                                <a href="#viewTab" id="viewCourse" data-toggle="tab">View Courses</a>
                            </li>
                            <li class=""><a href="#addTab" id="addCourse" data-toggle="tab">Add Course</a></li>
                        </ul>
                        <div id="myTabContent" class="tab-content">
                            <div class="tab-pane fade active in" id="viewTab">
                            </div>
                            <div class="tab-pane fade" id="addTab">
                                <form class="form-horizontal">
                                    <legend>Add New Course</legend>
                                    <div class="control-group">
                                        <label class="control-label" for="inputCourse">Course Name</label>
                                        <div class="controls">
                                            <input type="text" class="input-xxlarge" id="inputCourse" placeholder="Course Name [eg: I,II]." />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label" for="inputNoStudents">No of Students</label>
                                        <div class="controls">
                                            <input type="text" class="input-xxlarge" id="inputNoStudents" placeholder="No of Students alloted for this course." />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label" for="inputNoStudents">Subjects</label>
                                        <div class="controls">
                                            <select data-placeholder="Assign Subjects" id="assignSubject" multiple style="width: 350px;">
                                                <%foreach (LikeSchool.Modals.SubjectModal modal in SubjectCollection)
                                                  { %>
                                                <option value="1"><%=modal.SubjectName %></option>
                                                <%} %>
                                            </select>
                                        </div>
                                        <div class="controls">
                                            <span class="help-block">Press [Ctrl button] to select more than one subject.</span>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <div class="controls">
                                            <button type="button" class="btn btn-info" id="addCoursebtn"><i class="icon-plus icon-black"></i>&nbsp;Add Course</button>
                                            <button type="button" class="btn" id="clearbtn"><i class="icon-trash icon-black"></i>&nbsp;Clear</button>
                                            <div class="loading" id='courseloading'>
                                                <span class='loadingText'>Loading...</span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <div class="alert fade in">
                                            <button type="button" class="close" data-dismiss="alert">×</button>
                                            <strong>Course has been included successfully!</strong>
                                        </div>
                                        <div class="alert alert-block alert-error fade in">
                                            <button type="button" class="close" data-dismiss="alert">×</button>
                                            <strong>Unexpected error occurred!</strong>
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="second" class="profs" style="display: none;">
                    <div class="tabbable tabs-right">
                        <ul id="subjectHead" class="nav nav-tabs">
                            <li class="active"><a href="#viewSTab" id="viewSubject" data-toggle="tab">View Subjects</a></li>
                            <%-- <a href="#viewSTab" data-toggle="tab">View Subjects</a></li>--%>
                            <li class=""><a href="#addSTab" id="addSubject" data-toggle="tab">Add Subject</a></li>
                        </ul>
                        <div id="subjectTab" class="tab-content">
                            <div class="tab-pane fade active in" id="viewSTab">
                            </div>
                            <div class="tab-pane fade" id="addSTab">
                                <form class="form-horizontal">
                                    <legend>Add New Subject</legend>
                                    <div class="control-group">
                                        <label class="control-label" for="inputSubject">Subject Name</label>
                                        <div class="controls">
                                            <input type="text" class="input-xxlarge" id="inputSubject" placeholder="Subject Name [eg: Hindi,English].">
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <div class="controls">
                                            <button type="button" class="btn btn-info" id="addSub"><i class="icon-plus icon-black"></i>&nbsp;Add Subject</button>
                                            <button type="button" class="btn" id="clearSub"><i class=" icon-trash icon-black"></i>&nbsp;Clear</button>
                                            <div class="loading" id='subjectloading'>
                                                <span class='loadingText'>Loading...</span>
                                            </div>
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="third" class="profs" style="display: none;">
                </div>
            </div>
        </div>
    </div>
    <form runat="server">
    <asp:HiddenField ID="LoginIdField" runat="server" />
    <asp:HiddenField ID="LoginNameField" runat="server" />
    <asp:HiddenField ID="RoleNameField" runat="server" />
    </form>
</asp:Content>
