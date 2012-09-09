<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/mainpage.Master" AutoEventWireup="true"
    CodeBehind="studentdetail.aspx.cs" Inherits="LikeSchool.StudentDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="js/bootstrap-tab.js"></script>
    <script type="text/javascript" src="js/student.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
    <div class="container-fluid">
        <div class="page-header">
            <h2>Student Details<span id="subheading"></span></h2>
        </div>
        <div class="row-fluid">
            <div class="span3">
                <div class="well sidebar-nav">
                    <ul class="nav nav-list prof">
                        <li class="nav-header">Student Menu</li>
                        <li><a href="searchstudent.aspx"><i class="icon-search icon-black"></i>&nbsp;Search
                            Student</a></li>
                        <li class="active"><a href="#" hint="profile"><i class=" icon-user icon-black"></i>&nbsp;View
                            Profile</a></li>
                        <li><a href="#" hint="sendemail"><i class="icon-envelope icon-black"></i>&nbsp;Send
                            Email</a></li>
                        <li><a href="#" hint="report"><i class="icon-list-alt icon-black"></i>&nbsp;Report</a>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="span8">
                <div id="profile" class="profs" style="display: none;">
                    <ul id="myTab" class="nav nav-pills">
                        <li class="active"><a href="#profileTab" data-toggle="tab">Profile</a></li>
                        <li class=""><a href="#communicationTab" data-toggle="tab">Contact Details</a></li>
                        <li class=""><a href="#otherTab" data-toggle="tab">More Details</a></li>
                        <li class=""><a href="#parentTab" data-toggle="tab">Parent/Guardian</a></li>
                    </ul>
                    <div id="myTabContent" class="tab-content">
                        <div class="tab-pane fade active in" id="profileTab">
                            <% if (StudentModal.Image == null)
                               { %>
                            <img src="img/dashboard/profile.png" class="span2" />
                            <%}
                               else
                               { %>
                            <%} %>
                            <table class="table  table-bordered">
                                <tbody>
                                    <tr>
                                        <th style="width: 20%;">Admission No</th>
                                        <td>
                                            <%= StudentModal.AdmissionNo %></td>
                                    </tr>
                                    <tr>
                                        <th>Admission Date</th>
                                        <td>
                                            <%= StudentModal.AdmissionDate %></td>
                                    </tr>
                                    <tr>
                                        <th>First Name</th>
                                        <td>
                                            <%= StudentModal.FirstName %></td>
                                    </tr>
                                    <tr>
                                        <th>Middle Name</th>
                                        <td>
                                            <%= StudentModal.MiddelName==null ? LikeSchool.Helpers.Constants.Defaulter : StudentModal.MiddelName %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Last Name</th>
                                        <td>
                                            <%= StudentModal.LastName %></td>
                                    </tr>
                                    <tr>
                                        <th>Class</th>
                                        <td>
                                            <%= StudentModal.ClassModal.ClassName %></td>
                                    </tr>
                                    <tr>
                                        <th>Section</th>
                                        <td>
                                            <%= StudentModal.ClassModal.Section %></td>
                                    </tr>
                                    <tr>
                                        <th>Batch</th>
                                        <td>
                                            <%= string.Format("{0}-{1}",StudentModal.BatchModal.From,StudentModal.BatchModal.To) %>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <% if (IsAdmin)
                               { %>
                            <div class="form-actions">
                                <button type="button" class="btn btn-primary">
                                    <i class="icon-pencil icon-white"></i>&nbsp;Edit
                                </button>
                                <button type="button" class="btn btn-danger">
                                    <i class="icon-trash icon-white"></i>&nbsp;Delete
                                </button>
                            </div>
                            <%} %>
                            <div class="pre updater">
                                <ul>
                                    <li>Created by
                                        <%=StudentModal.UpdateModal.CreatedBy %>
                                        at
                                        <%=StudentModal.UpdateModal.CreatedTime %></li>
                                    <li>Last Modified by
                                        <%= StudentModal.UpdateModal.LastModifiedBy %>
                                        at
                                        <%=StudentModal.UpdateModal.LastModifiedTime %>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div class="tab-pane fade" id="communicationTab">
                            <%if (StudentModal.ContactModal == null)
                              { %>
                            <span>Oops!.No entries of contact details.</span>
                            <%if (IsAdmin)
                              { %>
                            <div class="form-actions">
                                <button type="button" class="btn btn-info">
                                    <i class="icon-plus icon-black"></i>&nbsp;Add Contact details
                                </button>
                            </div>
                            <%} %>
                            <%}
                              else
                              { %>
                            <table class="table  table-bordered">
                                <tbody>
                                    <tr>
                                        <th style="width: 20%;">Address1</th>
                                        <td>
                                            <%= StudentModal.ContactModal.Address1 %></td>
                                    </tr>
                                    <tr>
                                        <th>Address2</th>
                                        <td>
                                            <%= StudentModal.ContactModal.Address2 == null ? LikeSchool.Helpers.Constants.Defaulter : StudentModal.ContactModal.Address2 %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>City</th>
                                        <td>
                                            <%= StudentModal.ContactModal.City %></td>
                                    </tr>
                                    <tr>
                                        <th>State</th>
                                        <td>
                                            <%= StudentModal.ContactModal.State %></td>
                                    </tr>
                                    <tr>
                                        <th>Country</th>
                                        <td>
                                            <%= StudentModal.ContactModal.Country %></td>
                                    </tr>
                                    <tr>
                                        <th>Pincode</th>
                                        <td>
                                            <%= StudentModal.ContactModal.Pincode %></td>
                                    </tr>
                                    <tr>
                                        <th>Phone1</th>
                                        <td>
                                            <%= StudentModal.ContactModal.Phone1 %></td>
                                    </tr>
                                    <tr>
                                        <th>Phone2</th>
                                        <td>
                                            <%= StudentModal.ContactModal.Phone2==null ? LikeSchool.Helpers.Constants.Defaulter : StudentModal.ContactModal.Phone2 %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Mobile No</th>
                                        <td>
                                            <%= StudentModal.ContactModal.Mobile %></td>
                                    </tr>
                                    <tr>
                                        <th>Email</th>
                                        <td>
                                            <%= StudentModal.ContactModal.Email %></td>
                                    </tr>
                                </tbody>
                            </table>
                            <% if (IsAdmin)
                               { %>
                            <div class="form-actions">
                                <button type="button" class="btn btn-primary">
                                    <i class="icon-pencil icon-white"></i>&nbsp;Edit
                                </button>
                                <button type="button" class="btn btn-danger">
                                    <i class="icon-trash icon-white"></i>&nbsp;Delete
                                </button>
                            </div>
                            <%} %>
                            <div class="pre updater">
                                <ul>
                                    <li>Created by
                                        <%=StudentModal.ContactModal.UpdateModal.CreatedBy %>
                                        at
                                        <%=StudentModal.ContactModal.UpdateModal.CreatedTime %></li>
                                    <li>Last Modified by
                                        <%= StudentModal.ContactModal.UpdateModal.LastModifiedBy %>
                                        at
                                        <%=StudentModal.ContactModal.UpdateModal.LastModifiedTime %>
                                    </li>
                                </ul>
                            </div>
                            <%} %>
                        </div>
                        <div class="tab-pane fade" id="otherTab">
                            <% if (StudentModal.OtherModal == null)
                               { %>
                            <span>Oops!.No entries of other details.</span>
                            <%if (IsAdmin)
                              { %>
                            <div class="form-actions">
                                <button type="button" class="btn btn-info">
                                    <i class="icon-plus icon-black"></i>&nbsp;Add Other details
                                </button>
                            </div>
                            <%} %>
                            <%}
                               else
                               { %>
                            <table class="table  table-bordered">
                                <tbody>
                                    <tr>
                                        <th style="width: 20%;">Date of Birth</th>
                                        <td>
                                            <%= StudentModal.OtherModal.DateOfBirth %></td>
                                    </tr>
                                    <tr>
                                        <th>Blood Group</th>
                                        <td>
                                            <%= StudentModal.OtherModal.BloodGroup %></td>
                                    </tr>
                                    <tr>
                                        <th>Gender</th>
                                        <td>
                                            <%= StudentModal.OtherModal.Gender %></td>
                                    </tr>
                                    <tr>
                                        <th>Nationality</th>
                                        <td>
                                            <%= StudentModal.OtherModal.Nationality %></td>
                                    </tr>
                                    <tr>
                                        <th>Language</th>
                                        <td>
                                            <%= StudentModal.OtherModal.Language %></td>
                                    </tr>
                                    <tr>
                                        <th>Category</th>
                                        <td>
                                            <%= StudentModal.OtherModal.Category %></td>
                                    </tr>
                                    <tr>
                                        <th>Religion</th>
                                        <td>
                                            <%= StudentModal.OtherModal.Religion %></td>
                                    </tr>
                                </tbody>
                            </table>
                            <%if (IsAdmin)
                              { %>
                            <div class="form-actions">
                                <button type="button" class="btn btn-primary">
                                    <i class="icon-pencil icon-white"></i>&nbsp;Edit
                                </button>
                                <button type="button" class="btn btn-danger">
                                    <i class="icon-trash icon-white"></i>&nbsp;Delete
                                </button>
                            </div>
                            <%} %>
                            <div class="pre updater">
                                <ul>
                                    <li>Created by
                                        <%=StudentModal.OtherModal.UpdateModal.CreatedBy %>
                                        at
                                        <%=StudentModal.OtherModal.UpdateModal.CreatedTime %></li>
                                    <li>Last Modified by
                                        <%= StudentModal.OtherModal.UpdateModal.LastModifiedBy %>
                                        at
                                        <%=StudentModal.OtherModal.UpdateModal.LastModifiedTime %>
                                    </li>
                                </ul>
                            </div>
                            <%} %>
                        </div>
                        <div class="tab-pane fade" id="parentTab">
                            <%if (StudentModal.ParentModal == null)
                              { %>
                            <span>Oops!.No entries of Parent or Gaurdian details.</span>
                            <%if (IsAdmin)
                              { %>
                            <div class="form-actions">
                                <button type="button" class="btn btn-info">
                                    <i class="icon-plus icon-black"></i>&nbsp;Add Parent details
                                </button>
                            </div>
                            <%} %>
                            <%}
                              else
                              { %>
                            <table class="table  table-bordered">
                                <tbody>
                                    <tr>
                                        <th>FirstName</th>
                                        <td>
                                            <%= StudentModal.ParentModal.FirstName %></td>
                                    </tr>
                                    <tr>
                                        <th>MiddleName</th>
                                        <td>
                                            <%= StudentModal.ParentModal.MiddleName == null ? LikeSchool.Helpers.Constants.Defaulter: StudentModal.ParentModal.MiddleName %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>LastName</th>
                                        <td>
                                            <%= StudentModal.ParentModal.LastName %></td>
                                    </tr>
                                    <tr>
                                        <th>Relation</th>
                                        <td>
                                            <%= StudentModal.ParentModal.Relation %></td>
                                    </tr>
                                    <tr>
                                        <th>Date Of Birth</th>
                                        <td>
                                            <%= StudentModal.ParentModal.DateOfBirth %></td>
                                    </tr>
                                    <tr>
                                        <th>Education</th>
                                        <td>
                                            <%= StudentModal.ParentModal.Education %></td>
                                    </tr>
                                    <tr>
                                        <th>Occupation</th>
                                        <td>
                                            <%= StudentModal.ParentModal.Occupation %></td>
                                    </tr>
                                    <tr>
                                        <th>Annual Income</th>
                                        <td>
                                            <%= StudentModal.ParentModal.Income %></td>
                                    </tr>
                                    <tr>
                                        <th>Email</th>
                                        <td>
                                            <%= StudentModal.ParentModal.ContactModal.Email %></td>
                                    </tr>
                                    <tr>
                                        <th>Office Address1</th>
                                        <td>
                                            <%= StudentModal.ParentModal.ContactModal.Address1 %></td>
                                    </tr>
                                    <tr>
                                        <th>Office Address2</th>
                                        <td>
                                            <%= StudentModal.ParentModal.ContactModal.Address2 ==null? LikeSchool.Helpers.Constants.Defaulter: StudentModal.ParentModal.ContactModal.Address2 %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>City</th>
                                        <td>
                                            <%= StudentModal.ParentModal.ContactModal.City %></td>
                                    </tr>
                                    <tr>
                                        <th>State</th>
                                        <td>
                                            <%= StudentModal.ParentModal.ContactModal.State %></td>
                                    </tr>
                                    <tr>
                                        <th>Country</th>
                                        <td>
                                            <%= StudentModal.ParentModal.ContactModal.Country %></td>
                                    </tr>
                                    <tr>
                                        <th>Office Phone1</th>
                                        <td>
                                            <%= StudentModal.ParentModal.ContactModal.Phone1 %></td>
                                    </tr>
                                    <tr>
                                        <th>Office Phone2</th>
                                        <td>
                                            <%= StudentModal.ParentModal.ContactModal.Phone2 %></td>
                                    </tr>
                                    <tr>
                                        <th>Mobile No</th>
                                        <td>
                                            <%= StudentModal.ParentModal.ContactModal.Mobile %></td>
                                    </tr>
                                </tbody>
                            </table>
                            <% if (IsAdmin)
                               { %>
                            <div class="form-actions">
                                <button type="button" class="btn btn-primary">
                                    <i class="icon-pencil icon-white"></i>&nbsp;Edit
                                </button>
                                <button type="button" class="btn btn-danger">
                                    <i class="icon-trash icon-white"></i>&nbsp;Delete
                                </button>
                            </div>
                            <%} %>
                            <div class="pre updater">
                                <ul>
                                    <li>Created by
                                        <%=StudentModal.ParentModal.UpdateModal.CreatedBy %>
                                        at
                                        <%=StudentModal.ParentModal.UpdateModal.CreatedTime %></li>
                                    <li>Last Modified by
                                        <%= StudentModal.ParentModal.UpdateModal.LastModifiedBy %>
                                        at
                                        <%=StudentModal.ParentModal.UpdateModal.LastModifiedTime %>
                                    </li>
                                </ul>
                            </div>
                            <%} %>
                        </div>
                    </div>
                </div>
                <div id="sendemail" class="profs" style="display: none;">
                </div>
                <div id="report" class="profs" style="display: none;">
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
