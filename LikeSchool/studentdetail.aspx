<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/mainpage.Master" AutoEventWireup="true"
    CodeBehind="studentdetail.aspx.cs" Inherits="LikeSchool.StudentDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="js/bootstrap-tab.js"></script>
    <script type="text/javascript" src="js/student.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="page-header">
            <h2>Student Details<span id="subheading"></span></h2>
        </div>
        <div class="row-fluid">
            <div class="span3">
                <div class="well sidebar-nav">
                    <ul class="nav nav-list prof">
                        <li class="nav-header">Student Menu</li>
                        <li class="active"><a href="#" hint="search"><i class="icon-search icon-black"></i>&nbsp;Search
                            Student</a></li>
                        <li><a href="#" hint="profile"><i class="icon-user icon-black"></i>&nbsp;View Profile
                        </a></li>
                        <li><a href="#" hint="sendemail"><i class="icon-envelope icon-black"></i>&nbsp;Send
                            Email</a></li>
                        <li><a href="#" hint="report"><i class="icon-list-alt icon-black"></i>&nbsp;Report</a>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="span8">
                <div id="profile" class="profs" style="display: none;">
                    <ul id="myTab" class="nav nav-tabs">
                        <li class="active"><a href="#profileTab" data-toggle="tab">Profile</a></li>
                        <li class=""><a href="#communicationTab" data-toggle="tab">Contact Details</a></li>
                        <li class=""><a href="#parentTab" data-toggle="tab">Parent/Guardian</a></li>
                        <li class=""><a href="#otherTab" data-toggle="tab">More Details</a></li>
                        <li style="float: right">
                            <form style="margin: 0 0 7px" class="form-search">
                            <input type="text" class="search-query" />
                            <button type="submit" class="btn">
                                <i class="icon-search icon-black"></i>&nbsp;Search
                            </button>
                            </form>
                        </li>
                    </ul>
                    <div id="myTabContent" class="tab-content">
                        <div class="tab-pane fade active in" id="profileTab">
                            <img src="img/dashboard/profile.png" class="span2" />
                            <table class="table table-striped table-bordered">
                                <tbody>
                                    <tr>
                                        <th>Admission No</th>
                                        <td>Mark</td>
                                    </tr>
                                    <tr>
                                        <th>Admission Date</th>
                                        <td>Jacob</td>
                                    </tr>
                                    <tr>
                                        <th>First Name</th>
                                        <td>Larry</td>
                                    </tr>
                                    <tr>
                                        <th>Middle Name</th>
                                        <td>Larry</td>
                                    </tr>
                                    <tr>
                                        <th>Last Name</th>
                                        <td>Larry</td>
                                    </tr>
                                    <tr>
                                        <th>Class</th>
                                        <td>Larry</td>
                                    </tr>
                                    <tr>
                                        <th>Section</th>
                                        <td>Larry</td>
                                    </tr>
                                    <tr>
                                        <th>Batch</th>
                                        <td>Larry</td>
                                    </tr>
                                </tbody>
                            </table>
                            <div class="form-actions">
                                <button type="button" class="btn btn-primary"><i class="icon-pencil icon-white"></i>
                                    &nbsp;Edit</button>
                                <button type="button" class="btn btn-danger"><i class="icon-trash icon-white"></i>&nbsp;Delete
                                </button>
                            </div>
                        </div>
                        <div class="tab-pane fade" id="communicationTab">
                            <table class="table table-striped table-bordered">
                                <tbody>
                                    <tr>
                                        <th>Address1</th>
                                        <td>Mark</td>
                                    </tr>
                                    <tr>
                                        <th>Address2</th>
                                        <td>Jacob</td>
                                    </tr>
                                    <tr>
                                        <th>City</th>
                                        <td>Larry</td>
                                    </tr>
                                    <tr>
                                        <th>State</th>
                                        <td>Larry</td>
                                    </tr>
                                    <tr>
                                        <th>Country</th>
                                        <td>Larry</td>
                                    </tr>
                                    <tr>
                                        <th>Pincode</th>
                                        <td>Larry</td>
                                    </tr>
                                    <tr>
                                        <th>Phone1</th>
                                        <td>Larry</td>
                                    </tr>
                                    <tr>
                                        <th>Phone2</th>
                                        <td>Larry</td>
                                    </tr>
                                     <tr>
                                        <th>Mobile No</th>
                                        <td>Larry</td>
                                    </tr>
                                     <tr>
                                        <th>Email</th>
                                        <td>Larry</td>
                                    </tr>
                                </tbody>
                            </table>
                            <div class="form-actions">
                                <button type="button" class="btn btn-primary"><i class="icon-pencil icon-white"></i>
                                    &nbsp;Edit</button>
                                <button type="button" class="btn btn-danger"><i class="icon-trash icon-white"></i>&nbsp;Delete
                                </button>
                            </div>
                        </div>
                        <div class="tab-pane fade" id="otherTab">
                            <table class="table table-striped table-bordered">
                                <tbody>
                                    <tr>
                                        <th>Date of Birth</th>
                                        <td>Mark</td>
                                    </tr>
                                    <tr>
                                        <th>Blood Group</th>
                                        <td>Jacob</td>
                                    </tr>
                                    <tr>
                                        <th>Gender</th>
                                        <td>Larry</td>
                                    </tr>
                                    <tr>
                                        <th>Nationality</th>
                                        <td>Larry</td>
                                    </tr>
                                    <tr>
                                        <th>Language</th>
                                        <td>Larry</td>
                                    </tr>
                                    <tr>
                                        <th>Category</th>
                                        <td>Larry</td>
                                    </tr>
                                    <tr>
                                        <th>Religion</th>
                                        <td>Larry</td>
                                    </tr>                                   
                                </tbody>
                            </table>
                            <div class="form-actions">
                                <button type="button" class="btn btn-primary"><i class="icon-pencil icon-white"></i>
                                    &nbsp;Edit</button>
                                <button type="button" class="btn btn-danger"><i class="icon-trash icon-white"></i>&nbsp;Delete
                                </button>
                            </div>
                        </div>
                        <div class="tab-pane fade" id="parentTab">
                            <table class="table table-striped table-bordered">
                                <tbody>
                                    <tr>
                                        <th>Address1</th>
                                        <td>Mark</td>
                                    </tr>
                                    <tr>
                                        <th>Address2</th>
                                        <td>Jacob</td>
                                    </tr>
                                    <tr>
                                        <th>City</th>
                                        <td>Larry</td>
                                    </tr>
                                    <tr>
                                        <th>State</th>
                                        <td>Larry</td>
                                    </tr>
                                    <tr>
                                        <th>Country</th>
                                        <td>Larry</td>
                                    </tr>
                                    <tr>
                                        <th>Pincode</th>
                                        <td>Larry</td>
                                    </tr>
                                    <tr>
                                        <th>Phone1</th>
                                        <td>Larry</td>
                                    </tr>
                                    <tr>
                                        <th>Phone2</th>
                                        <td>Larry</td>
                                    </tr>
                                     <tr>
                                        <th>Mobile No</th>
                                        <td>Larry</td>
                                    </tr>
                                     <tr>
                                        <th>Email</th>
                                        <td>Larry</td>
                                    </tr>
                                </tbody>
                            </table>
                            <div class="form-actions">
                                <button type="button" class="btn btn-primary"><i class="icon-pencil icon-white"></i>
                                    &nbsp;Edit</button>
                                <button type="button" class="btn btn-danger"><i class="icon-trash icon-white"></i>&nbsp;Delete
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="search" class="profs" style="display: none;">
                </div>
                <div id="sendemail" class="profs" style="display: none;">
                </div>
                <div id="report" class="profs" style="display: none;">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
