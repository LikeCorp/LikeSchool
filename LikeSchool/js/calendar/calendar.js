﻿
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
    $("#startDate").datepicker();
    $("#endDate").datepicker();
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
            data: JSON.stringify({ jsonValue: GetJsonString(references, rvalues) , loginValues: GetJsonString(loginReference,loginValues) }),
            dataType: "json",
            success: function (res) {
                $('#calendar').fullCalendar('renderEvent',
						{
						    id:parseInt(res.d),
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
});
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
            if (bool) $('#loading').show();
            else $('#loading').hide();
        },
        editable: true,
        viewDisplay:function(view){
            //alert(new DateDetail(view.start).GetDateText());
            //alert(new DateDetail(view.end).GetDateText());
            alert(view.start);
            alert(view.end);
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
            $("#deleteEvent").click(function () {
                $("#eventView").modal('hide');
                var id = calEvent.id;
                var refs=['id'];
                var vals=[];
                vals.push(id);
                $.ajax({
                    url: "/Services/EventService.asmx/DeleteEventTable",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify({ jsonValue: GetJsonString(refs, vals)}) ,
                    dataType: "json",
                    success: function (res) {
                        $(this).fullCalendar('refetchEvents');
                    }
                });

            });
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
function ProcessEvent(start, end, allDay)
{
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


function GetDisplayDate(calEvent)
{
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

