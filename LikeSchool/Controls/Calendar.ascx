<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Calendar.ascx.cs" Inherits="LikeSchool.Calendar" %>
<link rel="stylesheet" type="text/css" href="../css/bootstrap.css" />
<link rel="stylesheet" type="text/css" href="../css/calendar/calendar.css" />
<link rel="stylesheet" type="text/css" href="../css/fullcalendar.css" />
<link rel="stylesheet" type="text/css" href="../css/uicss/jquery-ui-1.8.21.custom.css" />
<link rel="stylesheet" type="text/css" href="../css/uicss/jquery.ui.datepicker.css" />

<script type="text/javascript" src="../js/thirdparty/json2.js"></script>
<script type="text/javascript" src="../js/thirdparty/date.js"></script>
<script type="text/javascript" src="../js/jquery/ui/jquery.ui.datepicker.js"></script>
<script type="text/javascript" src="js/fullcalendar.js"></script>
<script type="text/javascript" src="../js/calendar/calendar.js"></script>

<div class="container_calendar">
    <div class="container-fluid">
        <div class="row-fluid">
            <div class="span3">
                <div class="span8">
                    <div id="pagetitle">
                        <h2>Calendar</h2>
                    </div>
                </div>
                <div class="settings">
                    <a href="#" class="btn btn-danger appointment"><i class="icon-plus icon-black"></i>&nbsp;Add
                        an Event </a>
                </div>
                <hr />
                <div class="settings">
                    <span id="eventTitle">Events of this Month</span>
                </div>
                <div class="settings" id="events">
                </div>
            </div>
            <div class="span9">
                <div id='loading' style='display: none'>loading...</div>
                <div id="calendar">
                </div>
            </div>
        </div>
    </div>
</div>
<div class="createEvent">
    <div class="modal hide" id="eventWindow">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">×</button>
            <h3>Add an Event</h3>
        </div>
        <div class="modal-body">
            <div class="control-group">
                <label class="control-label" for="startDate">Start Date</label>
                <div class="controls">
                    <input class="span4" type="text" id="startDate" placeholder="Enter the Start Date [dd/mmmm/yy]" />
                </div>
                <div id="sTime">
                    <label class="control-label" for="startTime">Start Time</label>
                    <div class="controls">
                        <select class="span2" id="startTime">
                        </select>
                        <select class="span1" id="startdesignator">
                        </select>
                    </div>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="endDate">End Date</label>
                <div class="controls">
                    <input class="span4" type="text" id="endDate" placeholder="Enter the End Date [dd/mmmm/yy]" />
                </div>
                <div id="eTime">
                    <label class="control-label" for="endTime">End Time</label>
                    <div class="controls">
                        <select class="span2" id="endTime">
                        </select>
                        <select class="span1" id="enddesignator">
                        </select>
                    </div>
                </div>
            </div>
            <div class="control-group">
                <label class="checkbox">
                    <input type="checkbox" id="wholeDay" checked="checked" />
                    Whole Day
                </label>
            </div>
            <div class="control-group">
                <label class="control-label" for="title">Title</label>
                <div class="controls">
                    <input type="text" id="title" placeholder="Short description of your Event" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="description">Description</label>
                <div class="controls">
                    <textarea id="description"></textarea>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <a href="#" class="btn" data-dismiss="modal" id="cancel"><i class="icon-remove icon-black">
            </i>Cancel </a><a href="#" class="btn btn-info" id="add"><i class="icon-plus icon-black">
            </i>Add </a>
        </div>
    </div>
</div>
<div class="modal hide" id="eventView">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">×</button>
        <h3 id="eventviewtitle"></h3>
    </div>
    <div class="modal-body">
        <span id="durationdetail"></span>
    </div>
    <div class="modal-footer">
        <a href="#" class="btn btn-info" id="a1"><i class=" icon-trash icon-black"></i>Delete
        </a>&nbsp; <a href="#" class="btn" data-dismiss="modal" id="A2"><i class="icon-remove icon-black">
        </i>Cancel </a>
    </div>
</div>
