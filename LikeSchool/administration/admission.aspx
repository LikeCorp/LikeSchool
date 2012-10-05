<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/mainpage.Master" AutoEventWireup="true" CodeBehind="admission.aspx.cs" Inherits="LikeSchool.admission" %>

<%@ Register Src="~/Controls/breadcrumb.ascx" TagPrefix="bc1" TagName="BreadCrumb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../css/layout.css" rel="stylesheet" />
    <link href="../css/bootstrap-datatables.css" rel="stylesheet" />
    <link href="../css/jquery.dataTables.css" rel="stylesheet" />
    <script src="../js/jquery.dataTables.js"></script>
    <script src="../js/bootstrap-alert.js"></script>
    <script type="text/javascript" src="../js/bootstrap-tab.js"></script>
    <script src="../js/chosen.jquery.js"></script>

    <script src="../js/bootstrap-datatables.js">      
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <bc1:BreadCrumb runat="server" ID="BreadCrumb" />
        <legend>Admission</legend>

        <div class="container" style="width: 1100px !important">
            <span>Admission Progress</span>
            <h1 id="precentage">10%</h1>
            <div class="progress progress-info progress-striped" style="margin-top: 10px;">
                <div class="bar" style="width: 10%"></div>
            </div>
        </div>
        <hr />
        <div class="container" style="width: 1100px !important;">
            <div class="tabbable tabs-left">
                <ul class="nav nav-tabs">
                    <li class="active"><a href="#studPane" id="studid" data-toggle="tab">Student Details</a></li>
                    <li><a href="#comPane" id="comid" data-toggle="tab">Communication Details</a></li>
                    <li><a href="#perPane" id="perid" data-toggle="tab">Personal Details</a></li>
                    <li><a href="#parPane" id="parid" data-toggle="tab">Parent/Guardian Details</a></li>
                </ul>
                <div class="tab-content">
                    <div class="tab-pane active" id="studPane">
                        <legend>Student Details</legend>
                        <form class="form-horizontal">
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">Admission No</label>
                                <div class="controls">
                                    <input class="input-xlarge" id="disabledInput" type="text" placeholder="AdmissionNo" disabled>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">Admission Date</label>
                                <div class="controls">
                                    <input type="text" id="Text1" placeholder="Admission Date">
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">FirstName</label>
                                <div class="controls">
                                    <input type="text" id="Text2" placeholder="First Name">
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">MiddleName[*]</label>
                                <div class="controls">
                                    <input type="text" id="Text3" placeholder="Middle Name">
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">LastName</label>
                                <div class="controls">
                                    <input type="text" id="Text4" placeholder="Last Name">
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">Class & Section</label>
                                <div class="controls">
                                    <select>
                                    </select>

                                    <select>
                                    </select>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">Batch [From - To]</label>
                                <div class="controls">
                                    <select>
                                    </select>
                                    <select>
                                    </select>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">Image</label>
                                <div class="controls">
                                    <input class="input-file" id="fileInput" type="file">
                                    <p class="help-block">
                                        Please provide the student image [Size 100 * 100 ].
                                    </p>
                                </div>
                            </div>

                        </form>
                        <hr />
                        <button class="btn btn-info" onclick="document.getElementById('comid').click()">Save & Continue</button>
                    </div>
                    <div class="tab-pane" id="comPane">
                        <legend>Communication Details</legend>
                        <form class="form-horizontal">
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">Address</label>
                                <div class="controls">
                                    <textarea rows="3"></textarea>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">City</label>
                                <div class="controls">
                                    <input type="text" id="Text7" placeholder="City">
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">State</label>
                                <div class="controls">
                                    <input type="text" id="Text8" placeholder="State">
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">Country</label>
                                <div class="controls">
                                    <input type="text" id="Text9" placeholder="Country">
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">Phone 1</label>
                                <div class="controls">
                                    <input type="text" id="Text10" placeholder="Phone 1">
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">Phone 2</label>
                                <div class="controls">
                                    <input type="text" id="Text11" placeholder="Phone 2">
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">Mobile No</label>
                                <div class="controls">
                                    <input type="text" id="Text12" placeholder="Mobile No">
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">Email</label>
                                <div class="controls">
                                    <div class="input-prepend">
                                        <span class="add-on"><i class="icon-envelope"></i></span>
                                        <input class="input-large" id="Text5" type="text" style="margin-left: -4px; margin-bottom: 0.5px;">
                                    </div>
                                </div>
                            </div>
                        </form>
                        <hr />
                        <button class="btn btn-info" onclick="document.getElementById('perid').click()">Save & Continue</button>
                    </div>
                    <div class="tab-pane" id="perPane">
                        <legend>Personal Details</legend>
                        <form class="form-horizontal">
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">DateofBirth</label>
                                <div class="controls">
                                    <input type="text" id="Text14" placeholder="DateofBirth">
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">Blood Group</label>
                                <div class="controls">
                                    <input type="text" id="Text15" placeholder="Blood Group">
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">Gender</label>
                                <div class="controls">
                                    <select>
                                    </select>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">Nationality</label>
                                <div class="controls">
                                    <input type="text" id="Text17" placeholder="Nationality">
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">Language</label>
                                <div class="controls">
                                    <input type="text" id="Text18" placeholder="Language">
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">Category</label>
                                <div class="controls">
                                    <input type="text" id="Text19" placeholder="Category">
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">Religion</label>
                                <div class="controls">
                                    <input type="text" id="Text20" placeholder="Religion">
                                </div>
                            </div>
                        </form>
                        <hr />
                        <button class="btn btn-info" onclick="document.getElementById('parid').click()">Save & Continue</button>
                    </div>
                    <div class="tab-pane" id="parPane">
                        <legend>Parent/Guardian Details</legend>
                        <form class="form-horizontal">
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">First Name</label>
                                <div class="controls">
                                    <input type="text" id="Text16" placeholder="FirstName">
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">Middle Name</label>
                                <div class="controls">
                                    <input type="text" id="Text21" placeholder="MiddleName">
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">Last Name</label>
                                <div class="controls">
                                    <input type="text" id="Text22" placeholder="LastName">
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">RelationShip</label>
                                <div class="controls">
                                    <input type="text" id="Text23" placeholder="RelationShip">
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">Date Of Birth</label>
                                <div class="controls">
                                    <input type="text" id="Text24" placeholder="Date Of Birth">
                                    <p class="help-block">
                                        Please follow the "mm/dd/yyy" format.
                                    </p>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">Education</label>
                                <div class="controls">
                                    <input type="text" id="Text25" placeholder="Education">
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">Occupation</label>
                                <div class="controls">
                                    <input type="text" id="Text26" placeholder="Occupation">
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">Annual Income</label>
                                <div class="controls">
                                    <input type="text" id="Text27" placeholder="Annual Income">
                                    Rs.
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">Office Address</label>
                                <div class="controls">
                                    <textarea rows="3"></textarea>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">City</label>
                                <div class="controls">
                                    <input type="text" id="Text30" placeholder="City">
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">State</label>
                                <div class="controls">
                                    <input type="text" id="Text31" placeholder="State">
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">Country</label>
                                <div class="controls">
                                    <input type="text" id="Text32" placeholder="Country">
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">Pincode</label>
                                <div class="controls">
                                    <input type="text" id="Text33" placeholder="Pincode">
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">OffPhone 1</label>
                                <div class="controls">
                                    <input type="text" id="Text34" placeholder="Office Phone 1">
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">Off Phone 2</label>
                                <div class="controls">
                                    <input type="text" id="Text35" placeholder="Office Phone 2">
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputEmail">Mobile No</label>
                                <div class="controls">
                                    <input type="text" id="Text36" placeholder="Mobile No">
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="inputIcon">Email address</label>
                                <div class="controls">
                                    <div class="input-prepend">
                                        <span class="add-on"><i class="icon-envelope"></i></span>
                                        <input class="input-large" id="inputIcon" type="text" style="margin-left: -4px; margin-bottom: 0.5px;">
                                    </div>
                                </div>
                            </div>
                        </form>
                        <hr />
                        <button class="btn btn-info">Save</button>
                    </div>
                </div>
            </div>
            <div class="help-inline pull-right">
                <p class="help-block" style="color: red">
                    Note : Fields with [*] are optional.
                </p>
            </div>
        </div>
    </div>
</asp:Content>
