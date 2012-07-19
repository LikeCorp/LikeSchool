<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Calendar.ascx.cs" Inherits="LikeSchool.Calendar" %>
<link rel="stylesheet" type="text/css" href="../css/bootstrap.css" />
<link rel="stylesheet" type="text/css" href="../css/calendar/calendar.css" />
<link rel="stylesheet" type="text/css" href="../css/fullcalendar.css" />
<script type="text/javascript" src="../js/jquery/core/jquery-1.7.2.js"></script>
<script type="text/javascript" src="../js/bootstrap_button.js"></script>
<script type="text/javascript" src="../js/bootstrap_modal.js"></script>
<script type="text/javascript" src="../js/thirdparty/json2.js"></script>
<script type="text/javascript" src="../js/thirdparty/date.js"></script>
<script type="text/javascript" src="js/jquery/ui/jquery-ui-1.8.17.custom.min.js"></script>
<script type="text/javascript" src="js/fullcalendar.js"></script>
<%--<script type="text/javascript" src="../js/calendar/calendar.js"></script>--%>
<script type="text/javascript" src="../js/utilities/utilities.js"></script>
<script type='text/javascript'>

    $(document).ready(function () {

        var date = new Date();
        var d = date.getDate();
        var m = date.getMonth();
        var y = date.getFullYear();

        $('#calendar').fullCalendar({
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'month,agendaWeek,agendaDay'
            },
            selectable: true,
            select: function (start, end, allDay) {
                var title;
                $("#eventWindow").modal({

                });;
                if (title) {
                    calendar.fullCalendar('renderEvent',
						{
						    title: title,
						    start: start,
						    end: end,
						    allDay: allDay
						},
						true // make the event "stick"
					);
                }
                calendar.fullCalendar('unselect');
            },
            editable: true,
            events: [
				{
				    title: 'All Day Event',
				    start: new Date(y, m, 1)
				},
				{
				    title: 'Long Event',
				    start: new Date(y, m, d - 5),
				    end: new Date(y, m, d - 2)
				},
				{
				    id: 999,
				    title: 'Repeating Event',
				    start: new Date(y, m, d - 3, 16, 0),
				    allDay: false
				},
				{
				    id: 999,
				    title: 'Repeating Event',
				    start: new Date(y, m, d + 4, 16, 0),
				    allDay: false
				},
				{
				    title: 'Meeting',
				    start: new Date(y, m, d, 10, 30),
				    allDay: false
				},
				{
				    title: 'Lunch',
				    start: new Date(y, m, d, 12, 0),
				    end: new Date(y, m, d, 14, 0),
				    allDay: false
				},
				{
				    title: 'Birthday Party',
				    start: new Date(y, m, d + 1, 19, 0),
				    end: new Date(y, m, d + 1, 22, 30),
				    allDay: false
				},
				{
				    title: 'Click for Google',
				    start: new Date(y, m, 28),
				    end: new Date(y, m, 29),
				    url: 'http://google.com/'
				}
            ]
        });

    });

</script>
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
                    <input class="span4" type="text" id="startDate" placeholder="Enter the Start Date [mm/dd/yyyy]" />
                </div>
                <div id="sTime">
                    <label class="control-label" for="startTime">Start Time</label>
                    <div class="controls">
                        <select class="span4" id="startTime">
                        </select>
                    </div>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="endDate">End Date</label>
                <div class="controls">
                    <input class="span4" type="text" id="endDate" placeholder="Enter the End Date [mm/dd/yyyy]" />
                </div>
                <div id="eTime">
                    <label class="control-label" for="endTime">End Time</label>
                    <div class="controls">
                        <select class="span4" id="endTime">
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
            <div class="control-group">
                <div class="controls">
                    <label class="checkbox">
                        <input type="checkbox" id="recursive" />
                        Add it as a recursive event
                    </label>
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
        <label>When :</label>
        <span id="durationdetail"></span>
    </div>
    <div class="modal-footer">
        <a href="#" class="btn btn-info" id="a1"><i class=" icon-trash icon-black"></i>Delete
        </a>&nbsp; <a href="#" class="btn" id="A2"><i class="icon-remove icon-black"></i>Cancel
        </a>
    </div>
</div>
