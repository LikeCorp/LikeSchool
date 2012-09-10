var currentid;
var times = ["01:00",
"01:30",
"02:00",
"02:30",
"03:00",
"03:30",
"04:00",
"04:30",
"05:00",
"05:30",
"06:00",
"06:30",
"07:00",
"07:30",
"08:00",
"08:30",
"09:00",
"09:30",
"10:00",
"10:30",
"11:00",
"11:30",
"12:00",
"12:30"];
var designators = ["AM", "PM"];
//Todo: Need to create an option for the event colors
var colors = ['5484ED', 'A4BDFC', '46D6DB', '51B749', 'FBD75B', 'FFB878', 'FF887C', 'DC2127', 'DBADFF', 'E1E1E1'];

//This method initializes on loading
function InitializeValues() {
    $("#wholeDay").click(function () {
        HideTimes();
    });
    $("#startTime,#endTime").append(GetOptions(times));
    $("#startdesignator,#enddesignator").append(GetOptions(designators));
    $("#startDate").datepicker({ dateFormat: 'dd/mm/yy' });
    $("#endDate").datepicker({ dateFormat: 'dd/mm/yy' });
    $("#datepicker").datepicker({ inline: true });
    InitializeDialog();
}
//Loading function
$(document).ready(function () {
    InitializeValues();
    InitializeCalendar();
    $("#add").click(function (e) {
        e.preventDefault();
        var references = ['start', 'end', 'title', 'description', 'allday', 'eventcolor'];
        var rvalues = [];
        var allDay = GetHtmlElementValue('wholeDay');
        var formattedstart = FormatDate(GetHtmlElementValue('startDate'), GetHtmlElementValue('startTime'), GetHtmlElementValue('startdesignator'), allDay);
        rvalues.push(formattedstart);
        var formattedend = FormatDate(GetHtmlElementValue('endDate'), GetHtmlElementValue('endTime'), GetHtmlElementValue('enddesignator'), allDay);
        rvalues.push(formattedend);
        rvalues.push(GetHtmlElementValue('title'));
        rvalues.push(GetHtmlElementValue('description'));
        rvalues.push(allDay);
        rvalues.push('3366CC');

        var loginReference = ['id', 'username'];
        var loginValues = [];
        loginValues.push(GetLoginId());
        loginValues.push(GetLoginName());

        $.ajax({
            url: "/Services/EventService.asmx/InsertEventTable",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ jsonValue: GetJsonString(references, rvalues), loginValues: GetJsonString(loginReference, loginValues) }),
            dataType: "json",
            success: function (res) {
                var view = $('#calendar').fullCalendar('getView');
                UpdateView(view);
                $('#calendar').fullCalendar('renderEvent',
						{
						    id: parseInt(res.d),
						    title: GetHtmlElementValue('title'),
						    start: formattedstart,
						    end: formattedend,
						    allDay: allDay,
						    description: GetHtmlElementValue('description'),
						    eventcolor: '#3366CC',
						    // createdById: result[i].UpdateModal.CreatedById,
						    createdBy: GetLoginName(),
						    // createdTime: result[i].UpdateModal.CreatedTime,
						    //lastmodifiedId: result[i].UpdateModal.LastModifiedId,
						    lastmodifiedBy: GetLoginName(),
						    //lastmodifiedTime: result[i].UpdateModal.LastModifiedTime,

						},
						true // make the event "stick"
					);
                $('#calendar').fullCalendar('unselect');
                $("#eventWindow").modal('hide');
            }
        });

    });

    $("#deleteEvent").click(function () {
        DeleteEvent();
    });

    $(".delete > a").click(function () {
        currentid = $(this).attr('eventid');
        DeleteEvent();
    });
});

function UpdateView(view) {
    $("#eventTitle").html("Events of this " + view.name + " | <strong>" + view.title + "</strong>");
    var displayrefs = ['start', 'end'];
    var displayValues = [];
    displayValues.push(view.start);
    displayValues.push(view.end);
    $("#displayloading").show();
    $.ajax({
        url: "/Services/EventService.asmx/SelectEventTableWithConstrain",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ jsonValue: GetJsonString(displayrefs, displayValues) }),
        dataType: "json",
        success: function (res) {
            $("#displayloading").hide();
            $("#events").empty();
            var result = eval(res.d);
            var finalResult = ConstructTable(result, view);
            $("#events").append(finalResult);
            $('#calendarDataTable').dataTable({
                "bLengthChange": false,
                "sDom": "<'row'<'span6'l><'span6'f>r>t<'row'<'span6'i><'span6'p>>",
                "sPaginationType": "bootstrap",
                "oLanguage": {
                    "sLengthMenu": "_MENU_ records per page"
                }
            });
        }
    });
}
function DeleteEvent() {

    if (!confirm("Do you want to delete this event?"))
        return;

    $("#eventView").modal('hide');
    var view = $('#calendar').fullCalendar('getView');
    var id = currentid;
    var refs = ['id'];
    var vals = [];
    vals.push(id);
    $.ajax({
        url: "/Services/EventService.asmx/DeleteEventTable",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ jsonValue: GetJsonString(refs, vals) }),
        dataType: "json",
        success: function (res) {
            $('#calendar').fullCalendar('removeEvents', id);
            UpdateView(view);
        }
    });
}
//This method load the Full calendar functionalities
function InitializeCalendar() {
    $('#calendar').fullCalendar({
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        selectable: true,
        select: function (start, end, allDay) {
            ProcessEvent(start, end, allDay);
        },
        loading: function (bool) {
            if (bool) $('#calendarloading').show();
            else $('#calendarloading').hide();
        },
        editable: true,
        viewDisplay: function (view) {
            UpdateView(view);
        },
        eventClick: function (calEvent, jsEvent, view) {
            var dateDetail;
            dateDetail = GetDisplayDate(calEvent);
            $("#eventviewtitle").text(calEvent.title);
            $("#durationdetail").text(dateDetail);
            $("#createdby").text(calEvent.createdBy);
            //$("#createdtime").text(GetDisplayDate(calEvent.createdTime));Need to convert the date(ms) to date
            $("#lastmodifiedby").text(calEvent.lastmodifiedBy);
            //$("#lastmodifiedtime").text(GetDisplayDate(calEvent.lastmodifiedTime));;Need to convert the date(ms) to date
            $("#eventView").modal({});
            currentid = calEvent.id;
        },
        events: function (start, end, callback) {
            lineItems = new Object();
            lineItems.Entrys = new Array();
            $.ajax({
                url: "/Services/EventService.asmx/SelectEventTable",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (res) {
                    var result = eval(res.d);
                    for (var i = 0; i < result.length; i++) {
                        lineItems.Entrys[i] = new Object({
                            id: result[i].Id,
                            title: result[i].Title,
                            description: result[i].Description,
                            start: new Date(result[i].Start),
                            end: new Date(result[i].End),
                            eventcolor: '#' + result[i].EventColor,
                            allDay: result[i].AllDay,
                            // createdById: result[i].UpdateModal.CreatedById,
                            createdBy: result[i].UpdateModal.CreatedBy,
                            // createdTime: result[i].UpdateModal.CreatedTime,
                            //lastmodifiedId: result[i].UpdateModal.LastModifiedId,
                            lastmodifiedBy: result[i].UpdateModal.LastModifiedBy,
                            //lastmodifiedTime: result[i].UpdateModal.LastModifiedTime,
                        });
                    }
                    var calevents = lineItems.Entrys;
                    // then, pass the CalEvent array to the callback
                    callback(calevents);
                }
            });

        },
    });
}
function ProcessEvent(start, end, allDay) {
    var title;
    var startDate = new DateDetail(start);
    var endDate = new DateDetail(end);

    $('#startDate').val(startDate.GetDateText());
    $('#endDate').val(endDate.GetDateText());
    $('#startTime').val(startDate.GetTime());
    $('#startdesignator').val(startDate.GetDesignator());
    $('#endTime').val(endDate.GetTime());
    $('#enddesignator').val(endDate.GetDesignator());
    $("#wholeDay").click();
    $('#wholeDay').attr('checked', allDay);
    if (!allDay) {
        $("#wholeDay").click();
        $('#wholeDay').attr('checked', false);
    }
    else {
        $("#wholeDay").click();
        $('#wholeDay').attr('checked', true);
    }
    $("#eventWindow").modal({

    });

}


function GetDisplayDate(calEvent) {
    var dateDetail;
    var sDate;
    var eDate;
    if (calEvent.start != null) {
        sDate = new DateDetail(calEvent.start);
    }
    if (calEvent.end != null) {
        eDate = new DateDetail(calEvent.end);
    }

    if (calEvent.allDay) {
        if (calEvent.start != null)
            dateDetail = sDate.GetDateText();

        if (calEvent.end != null)
            dateDetail += ' to ' + eDate.GetDateText();
    }
    else {
        dateDetail = sDate.GetDateText();
        dateDetail += ' - ' + sDate.GetTimeWithDesignator() + ' to ' + eDate.GetTimeWithDesignator();
    }

    return dateDetail;
}
function GetTableDate(result) {
    var dateDetail;
    var sDate;
    var eDate;
    if (result.Start != null) {
        sDate = new DateDetail(Date.parse(result.Start));
    }
    if (result.End != null) {
        eDate = new DateDetail(Date.parse(result.End));
    }

    if (result.AllDay) {
        if (result.Start != null)
            dateDetail = sDate.GetDateText();

        if (result.End != null && result.End != result.Start)
            dateDetail += ' to ' + eDate.GetDateText();
    }
    else {
        dateDetail = sDate.GetDateText();
        dateDetail += ' - ' + sDate.GetTimeWithDesignator() + ' to ' + eDate.GetTimeWithDesignator();
    }

    return dateDetail;
}
//This method clears the values of the Event Modal
function ClearValues() {
    $('#startDate').val('');
    $('#startTime').prop('selectedIndex', 0);
    $('#endDate').val('');
    $('#endTime').prop('selectedIndex', 0);
    $('#title').val('');
    $('#description').val('');
    $('#recursive').attr('checked', false);
    $('#wholeDay').attr('checked', true);
}
//This method hides the time in the Event modal 
function HideTimes() {

    if ($("#wholeDay").is(":checked")) {
        $("#sTime").hide();
        $("#eTime").hide();
    }
    else {
        $("#sTime").show();
        $("#eTime").show();
    }
}

//This method Initializes the dialog for create event button
function InitializeDialog() {
    $(".appointment").click(function () {
        ClearValues();
        HideTimes();
        $("#eventWindow").modal({

        });
    });
}
//This method formats the date,time,designator
function FormatDate(date, time, designator, allDay) {
    var formatDate;
    if (allDay)
        formatDate = Date.parseExact(date, 'dd/mm/yyyy');
    else {
        formatDate = Date.parseExact(date + ' ' + time + ' ' + designator, 'dd/mm/yyyy hh:mm tt');
    }
    return formatDate;
}

/*DateDetail class for date details*/
function DateDetail(date) {
    this.Date = date;
    this.MonthName = this.Date.toString("MMM");
    this.MonthNo = this.Date.getMonth();
    this.DayNo = this.Date.getDate();
    this.WeekDayNo = this.Date.getDay();
    this.Year = this.Date.getFullYear();
    this.GetMonthText = function () {
        return this.Date.toString("MMM-yyyy");
    };
    this.GetDateText = function () {
        return this.Date.toString("dd/MM/yyyy");
    };
    this.GetDBDate = function () {
        return this.Date.toString('yyyy-MM-dd');
    };
    this.GetTime = function () {
        return this.Date.toString('hh:mm').toLowerCase();
    };
    this.GetDesignator = function () {
        return this.Date.toString('tt');
    };
    this.GetTimeWithDesignator = function () {
        return this.GetTime() + ' ' + this.GetDesignator();
    };
    this.GetUniqueDateId = function () {
        return this.DayNo.toString() + this.MonthNo.toString() + this.Year.toString() + this.WeekDayNo.toString();
    };
}

function ConstructTable(result, view) {

    var cview = $('#calendar').fullCalendar('getView');
    if (result == undefined || result.length == 0)
        return "Oops! No Events for this " + view.name;
    else {
        var table = " <table cellpadding='0' cellspacing='0' border='0' class='table table-striped table-bordered' id='calendarDataTable'>";

        table += "<thead><tr>";
        table += "<th>Title</th>";
        table += "<th>Date and Time</th>";
        table += "<th>View</th>";
        table += "<th>Edit</th>";
        table += "<th>Delete</th>";
        table += "</tr></thead>";

        table += "<tbody>";
        for (var x = 0; x < result.length; x++) {
            var data = result[x];
            table += "<tr>";
            table += "<td>" + data.Title + "</td>";
            table += "<td>" + GetTableDate(data) + "</td>";
            table += "<td><a href='#' ><i class='icon-eye-open icon-black'></i></a></td>";
            table += "<td><a href='#' ><i class='icon-pencil icon-black'></i></a></td>";
            table += "<td class='delete'><a href='#' eventid='" + data.Id + "' ><i class='icon-remove icon-black'></i></a></td>";
            table += "</tr>";

        }
        table += "</tbody>";
        table += "</table>";
        return table;
    }
}

