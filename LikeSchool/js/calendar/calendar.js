
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

var colors = ['5484ED', 'A4BDFC', '46D6DB', '51B749', 'FBD75B', 'FFB878', 'FF887C', 'DC2127', 'DBADFF', 'E1E1E1'];

function InitializeValues() {
    $("#wholeDay").click(function () {
        HideTimes();
    });
    $("#startTime,#endTime").append(GetOptions(times));
    $("#startdesignator,#enddesignator").append(GetOptions(designators));
    $("#startDate").datepicker({ dateFormat: 'dd/MM/yy' });
    $("#endDate").datepicker({ dateFormat: 'dd/MM/yy' });
    $("#datepicker").datepicker({ inline: true });
    InitializeDialog();
}

$(document).ready(function () {
    InitializeValues();
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
            $("#add").click(function () {
                var references = ['start', 'end', 'title', 'description', 'allday', 'eventcolor'];
                var rvalues = [];
                var formattedstart = FormatDate($('#startDate').val(), $("#startTime option:selected").text(), $("#startdesignator option:selected").text(), allDay);
                rvalues.push(formattedstart);
                var formattedend = FormatDate($('#endDate').val(), $("#endTime option:selected").text(), $("#enddesignator option:selected").text(), allDay);
                rvalues.push(formattedend);
                rvalues.push($('#title').val());
                rvalues.push($('#description').val());
                rvalues.push(allDay);
                rvalues.push('3366CC');

                $.ajax({
                    url: "/Services/EventService.asmx/InsertEventTable",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify({ jsonValue: GetJsonString(references, rvalues) }),
                    dataType: "json",
                    success: function (res) {
                        $('#calendar').fullCalendar('renderEvent',
						{
						    id: res.d,
						    title: $('#title').val(),
						    start: formattedstart,
						    end: formattedend,
						    allDay: allDay,
						    description: $('#description').val(),
						    eventcolor: '#3366CC'
						},
						true // make the event "stick"
					);
                        $('#calendar').fullCalendar('unselect');
                        $("#eventWindow").modal('hide');
                    }
                });
            });

        },
        loading: function (bool) {
            if (bool) $('#loading').show();
            else $('#loading').hide();
        },
        editable: true,
        eventClick: function (calEvent, jsEvent, view) {
            var dateDetail;
            if (calEvent.start != null)
                dateDetail = calEvent.start.toShortTimeString();

            if (calEvent.end != null)
                dateDetail += ' to ' + calEvent.end.toShortTimeString();

            $("#eventviewtitle").text(calEvent.title);
            $("#durationdetail").text(dateDetail);
            $("#eventView").modal({});
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
                            start:new Date(result[i].Start),
                            end: new Date(result[i].End),
                            eventcolor: '#' + result[i].EventColor,
                            allDay: result[i].AllDay
                        });
                    }
                    var calevents = lineItems.Entrys;
                    // then, pass the CalEvent array to the callback
                    callback(calevents);
                }
            });

        },
    });

});

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

function InitializeDialog() {
    $(".appointment").click(function () {
        ClearValues();
        HideTimes();
        $("#eventWindow").modal({

        });
    });
}

function FormatDate(date, time, designator, allDay) {
    var formatDate;
    if (allDay)
        formatDate = Date.parseExact(date, 'dd/MMMM/yy');
    else {
        formatDate = Date.parseExact(date + ' ' + time + ' ' + designator, 'dd/MMMM/yy hh:mm tt');
    }
    return formatDate;
}
function GetOptions(arrayValues) {
    var resultHtml = "";
    for (var x = 0; x < arrayValues.length; x++) {
        resultHtml += "<option value='" + arrayValues[x] + "'>" + arrayValues[x] + "</option>";
    }
    return resultHtml;
}
/*DateDetail class for date details*/
function DateDetail(date, isBefore, isAfter, isNow) {
    this.Date = date;
    this.MonthName = this.Date.toString("MMM");
    this.MonthNo = this.Date.getMonth();
    this.DayNo = this.Date.getDate();
    this.WeekDayNo = this.Date.getDay();
    this.Year = this.Date.getFullYear();
    this.IsAfter = isAfter;
    this.IsBefore = isBefore;
    this.IsNow = isNow;
    this.GetMonthText = function () {
        return this.Date.toString("MMM-yyyy");
    };
    this.GetDateText = function () {
        return this.Date.toString("dd/MMMM/yy");
    };
    this.GetDBDate = function () {
        return this.Date.toString('yyyy-MM-dd');
    };
    this.GetTime = function () {
        return this.Date.toString('hh:mm').toLowerCase();
    };
    this.GetDesignator = function () {
        return this.Date.toString('tt');
    }
    this.GetUniqueDateId = function () {
        return this.DayNo.toString() + this.MonthNo.toString() + this.Year.toString() + this.WeekDayNo.toString();
    };
}

