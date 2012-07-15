var viewid;
var increment = 0;
var totalCount = 42;
var todayDate = new DateDetail(Date.today());
var istartDate;
var iendDate;
var times = ["00:00",
"01:00",
"02:00",
"03:00",
"04:00",
"05:00",
"06:00",
"07:00",
"08:00",
"09:00",
"10:00",
"11:00",
"12:00",
"13:00",
"14:00",
"15:00",
"16:00",
"17:00",
"18:00",
"19:00",
"20:00",
"21:00",
"22:00",
"23:00"];
//Initializer
$(document).ready(function () {
    $("#wholeDay").click(function () {
        HideTimes();
    });

    LoadCurrentView();//loads the current view
    $("#options > button").each(function () {
        $(this).click(function () {
            viewid = $(this).attr("viewId");
            LoadValues(viewid, 0);
        });


    });
    $("#previous").click(function () {
        increment -= 1;
        LoadValues(viewid, increment);
    });
    $("#today").click(function () {
        increment = 0;

        LoadValues(viewid, increment);
    });
    $("#after").click(function () {
        increment += 1;

        LoadValues(viewid, increment);
    });

    $("#confirmation input:button").button();
    $("#startTime,#endTime").append(GetOptionTimes());
    $("#startDate").datepicker();
    $("#endDate").datepicker();
    $("#datepicker").datepicker({ inline: true });

    $("#add").click(function () {
        var references = ['startdate', 'starttime', 'enddate', 'endtime', 'title', 'description', 'isrecursive'];
        var rvalues = [];
        rvalues.push($('#startDate').val());
        rvalues.push(GetOptionValue($("#startTime option:selected").text()));
        rvalues.push($('#endDate').val());
        rvalues.push(GetOptionValue($("#endTime option:selected").text()));
        rvalues.push($('#title').val());
        rvalues.push($('#description').val());

        if ($('#recursive').is(':checked')) {
            rvalues.push('1');
        } else {
            rvalues.push('0');
        }

        $.ajax({
            url: "/Services/EventService.asmx/InsertEventTable",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ jsonValue: GetJsonString(references, rvalues) }),
            dataType: "json",
            success: function (res) {
                Check(res)
                $("#eventWindow").modal('hide');
            }
        });
    });
});
function Check(res) {

    var first = parseDate($('#startDate').val());
    var second = parseDate($('#endDate').val());
    var title = $('#title').val();
    UpdateInnerEvents(first, second, res.d, title);
    UpdateRightSide(false);

}
function UpdateInnerEvents(first, second, id, t) {

    var diff = daydiff(first, second);
    var dae;
    var len;
    if (diff > 0) {
        for (var day = 0; day <= diff; day++) {
            var temp = first.clone();
            dae = new DateDetail(temp.addDays(day));
            len = $("." + dae.GetUniqueDateId() + " > ul > li").size();
            if (len < 4) {
                $("." + dae.GetUniqueDateId() + " > ul").append("<li class='event' id='" + id + "'><a href='#' title='" + t + "' desc='" + (new DateDetail(first)).GetDateText() + "-" + (new DateDetail(second)).GetDateText() + "' id='" + id + "'>" + GetText(t, 155, $(".event").css('font-size')) + "</a></li>");

            }
            else if (len == 4) {

                $("." + dae.GetUniqueDateId() + " > ul").append("<li class='eventmore'><a href='#' date='" + dae.GetUniqueDateId() + "'> More</a></li>");

            }
        }
    }
    else {
        dae = new DateDetail(first.clone());
        len = $("." + dae.GetUniqueDateId() + " > ul > li").size();
        if (len < 4) {

            $("." + dae.GetUniqueDateId() + " > ul").append("<li class='event' id='" + id + "'><a href='#' title='" + t + "' desc='" + dae.GetDateText() + "' id='" + id + "'>" + GetText(t, 155, $(".event").css('font-size')) + "</a></li>");
        }
        else if (len == 4) {

            $("." + dae.GetUniqueDateId() + " > ul").append("<li class='eventmore'><a href='#' date='" + dae.GetUniqueDateId() + "'> More</a></li>");

        }
    }

    $(".event > a").click(function () {
        $("#eventviewtitle").text($(this).attr("title"));
        $("#durationdetail").text($(this).attr("desc"));
        $("#eventView").modal({});
    });
}
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
function GetOptionValue(val) {
    return parseInt(val.slice(0, 2));
}
function UpdateActiveClass() {
    $("#options > button").each(function () {
        $(this).removeClass('active');
        if ($(this).attr("viewId") == viewid) {
            $(this).addClass('active');
        }
    });
}
/*Loads the current calendar view*/
function LoadCurrentView() {
    viewid = localStorage.getItem("currentView");
    increment = parseInt(localStorage.getItem("monthincrement"));
    if (viewid == null) viewid = 0;
    if (isNaN(increment)) increment = 0;
    LoadValues(viewid, increment);

}
/*Loads the respective calendar view*/
function LoadValues(viewId, increment) {
    UpdateActiveClass();
    switch (viewId.toString()) {
        case "0":
            totalCount = 42;
            $("#body").html(GetMonthValues(increment));
            break;
        case "1":
            $("#body").html(GetWeekValues(increment));
            break;
        case "2":
            $("#body").html(GetDayValues(increment));
            break;
    }
    UpdateRightSide(true);
    InitializeDialog();
    UpdateEvents(viewId);
    SetOption(viewId);
    localStorage.setItem("currentView", viewId.toString());
    localStorage.setItem("monthincrement", increment);
}
function InitializeDialog() {
    $("div.month_body,.weekday,.daybody,.appointment").dblclick(function () {
        ClearValues();
        HideTimes();
        $("#eventWindow").modal({

        });
    });
}

function UpdateRightSide(update) {
    var references = ['inputstartdate', 'inputenddate'];
    var rvalues = [];
    rvalues.push(istartDate);
    rvalues.push(iendDate);
    $.ajax({
        url: "/Services/EventService.asmx/SelectEventTable",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ jsonValue: GetJsonString(references, rvalues) }),
        dataType: "json",
        success: function (res) {
            WriteContents(res,update);
        }
    });
}
function WriteContents(result,update) {
    var parseResult = JSON.parse(result.d);
    var result;
    if (parseResult.length == 0) {
        result = "Boo !!! There is no events registered in this month";
    }
    else {
        result = "<table class='table table-striped'>";
        result += "<thead>";
        result += "<th>";
        result += "EventTitle";
        result += "</th>";
        result += "<th>";
        result += "When";
        result += "</th>";
        result += "</thead>";
        result += "<tbody>";
        for (var i = 0; i < parseResult.length; i++) {
            result += "<tr>";
            result += "<td>";
            result += parseResult[i].Title;
            result += "</td>";
            result += "<td>";
            result += parseResult[i].StartDate + " to " + parseResult[i].EndDate;
            result += "</td>";
            result += "</tr>";
            if(update)
            UpdateInnerEvents(parseDbDate(parseResult[i].StartDate), parseDbDate(parseResult[i].EndDate), parseResult[i].EventId, parseResult[i].Title);
        }
        result += "</tbody>";
        result += "</table>";
    }

    $("#events").html('');
    $("#events").html(result);

}
function GetWeekDates(week) {
    var weekDts = [];
    var currentDate = Date.today().clone().addWeeks(week);
    var currenClone;
    for (var x = 0; x < 7; x++) {
        currenClone = currentDate.clone();
        weekDts.push(new DateDetail(currenClone.addDays(x)));
    }
    return weekDts;
}

function GetWeekValues(week) {
    var currentIndex;
    var weekDates = GetWeekDates(week);
    UpdateDateShow(weekDates[0].GetDateText() + " - " + weekDates[6].GetDateText());
    istartDate = weekDates[0].GetDBDate();
    iendDate = weekDates[6].GetDBDate();
    var htmlContent = "<div id='topsection'>";
    htmlContent += "<table><tbody>";
    htmlContent += "<tr>";
    htmlContent += "<td><div class='month_head time_head'>Time</div></td>";
    for (var day = 0; day < weekDates.length; day++) {
        htmlContent += "<td class='day'>";
        if (todayDate.GetUniqueDateId() == weekDates[day].GetUniqueDateId()) {
            htmlContent += "<div class='month_head_now week_head'>" + weekDates[day].GetDateText() + "</div></td>";
        }
        else {
            htmlContent += "<div class='month_head week_head'>" + weekDates[day].GetDateText() + "</div></td>";
        }

    }
    htmlContent += "</tr>";
    htmlContent += "</tbody></table>";
    htmlContent += "</div>";

    htmlContent += "<div id='wrapper'>";
    htmlContent += "<div id='weekbodyright'>";
    htmlContent += "<table><tbody>";
    htmlContent += "<tr>";
    for (var day1 = 0; day1 < 7; day1++) {
        htmlContent += "<td>";
        htmlContent += "<div class='weekday'></div></td>";
    }
    htmlContent += "</tr>";
    htmlContent += "</tbody></table>";
    htmlContent += "</div>";
    htmlContent += "</div>";

    htmlContent += "<div id='weekbodyleft'>";
    htmlContent += "<table><tbody>";

    for (var t = 0; t < times.length; t++) {
        htmlContent += "<tr>";
        htmlContent += "<td>";
        htmlContent += "<div class='month_head time_head time_side_head'>" + times[t] + "</div>";
        htmlContent += "</td>";
        htmlContent += "</tr>";
    }

    htmlContent += "</tbody></table>";
    htmlContent += "</div>";

    return htmlContent;
}

function GetDate(week) {
    return new DateDetail(Date.today().clone().addDays(week));
}

function GetDayValues(week) {
    var weekDate = GetDate(week);
    UpdateDateShow(weekDate.GetDateText());
    istartDate = weekDate.GetDBDate();
    iendDate = weekDate.GetDBDate();
    var htmlContent = "<div id='topsection'>";
    htmlContent += "<table><tbody>";
    htmlContent += "<tr>";
    htmlContent += "<td><div class='month_head time_head'>Time</div></td>";

    htmlContent += "<td class='day'>";
    if (weekDate.GetUniqueDateId() == todayDate.GetUniqueDateId()) {
        htmlContent += "<div class='month_head_now day_head'>" + GetDayName(weekDate.WeekDayNo) + "</div></td>";
    }
    else {
        htmlContent += "<div class='month_head day_head'>" + GetDayName(weekDate.WeekDayNo) + "</div></td>";
    }

    htmlContent += "</tr>";
    htmlContent += "</tbody></table>";
    htmlContent += "</div>";

    htmlContent += "<div id='wrapper'>";
    htmlContent += "<div id='weekbodyright'>";
    htmlContent += "<table><tbody>";
    htmlContent += "<tr>";
    htmlContent += "<td>";
    htmlContent += "<div class='daybody'></div></td>";
    htmlContent += "</tr>";
    htmlContent += "</tbody></table>";
    htmlContent += "</div>";
    htmlContent += "</div>";

    htmlContent += "<div id='weekbodyleft'>";
    htmlContent += "<table><tbody>";

    for (var t = 0; t < times.length; t++) {
        htmlContent += "<tr>";
        htmlContent += "<td>";
        htmlContent += "<div class='month_head time_head time_side_head'>" + times[t] + "</div>";
        htmlContent += "</td>";
        htmlContent += "</tr>";
    }

    htmlContent += "</tbody></table>";
    htmlContent += "</div>";

    return htmlContent;
}
function UpdateEvents(viewid) {
    var title = " ";
    switch (viewid.toString()) {
        case "0":
            title = "Events of this Month";
            break;
        case "1":
            title = "Events of this Week";
            break;
        case "2":
            title = "Events of this Day";
            break;
    }
    $("#eventTitle").html(title);
}
/*This method responsible for loading the month values.*/
function GetMonthValues(month) {
    var currentDate = new DateDetail(Date.today().addMonths(month));
    UpdateDateShow(currentDate.GetMonthText());
    var noOfDaysInMonth = Date.getDaysInMonth(currentDate.Year, currentDate.MonthNo);
    var firstDateOfCurrentMonth = new Date(currentDate.Year, currentDate.MonthNo, 1);
    var firstDateDayNo = firstDateOfCurrentMonth.getDay();
    var lastDateOfCurrentMonth = new Date(currentDate.Year, currentDate.MonthNo, noOfDaysInMonth);
    var lastDateDayNo = lastDateOfCurrentMonth.getDay();


    var currentDays = GetCurrenMonthDays(firstDateOfCurrentMonth, noOfDaysInMonth);
    totalCount -= currentDays.length;
    var beforeCount;

    beforeCount = Math.round(totalCount / 2);

    var beforeDays = GetBeforeDays(firstDateDayNo, firstDateOfCurrentMonth, beforeCount);
    totalCount -= beforeDays.length;

    var afterDays = GetAfterDays(lastDateDayNo, lastDateOfCurrentMonth, totalCount);
    totalCount -= afterDays.length;
    var completeMonthDays = beforeDays.concat(currentDays).concat(afterDays);

    istartDate = completeMonthDays[0].GetDBDate();
    iendDate = completeMonthDays[completeMonthDays.length - 1].GetDBDate();

    var monthHtmlContent = GetConstructedMonthHTML(GetSplitDates(completeMonthDays));
    return monthHtmlContent;
}

function UpdateDateShow(dateText) {
    $("#dateShow").html(dateText);
}

/*This methods gets the before days of the previous month from the current month*/
function GetBeforeDays(firstDateDayNo, firstDateOfCurrentMonth, beforeCount) {
    var beforeDays = [];
    var beforeDate = firstDateOfCurrentMonth.clone();
    for (var d = 0; d <= beforeCount; d++) {
        var before = beforeDate.addDays(-1);
        var detail = new DateDetail(before, true, false, false);
        beforeDays.push(detail);
        beforeDate = before.clone();
        if (detail.WeekDayNo == 0)
            return beforeDays.reverse();

    }
    return beforeDays.reverse();
}
/*This method gets the after days of the after month from the current month*/
function GetAfterDays(lastDateDayNo, lastDateOfCurrentMonth, afterCount) {
    var afterDays = [];
    var afterDate = lastDateOfCurrentMonth.clone();

    for (var d = 0; d < afterCount  ; d++) {
        var after = afterDate.addDays(1);
        afterDays.push(new DateDetail(after, false, true, false));
        afterDate = after.clone();
    }

    return afterDays;
}
/*This method gets the current month days*/
function GetCurrenMonthDays(firstDateOfCurrentMonth, noOfDaysInMonth) {
    var currentMonthDays = [];
    var currentDate = firstDateOfCurrentMonth.clone();
    var isNow = IsEqual(Date.today(), currentDate);
    currentMonthDays.push(new DateDetail(currentDate.clone(), false, false, isNow));
    for (var d = 1; d < noOfDaysInMonth; d++) {
        var current = currentDate.addDays(1);
        isNow = IsEqual(Date.today(), current);
        currentMonthDays.push(new DateDetail(current, false, false, isNow));
        currentDate = current.clone();
    }
    return currentMonthDays;
}
/*This method will split the values of the completedays into 5*7 matrix array [to-do:later this can be changes based on the settings]*/
function GetSplitDates(completeMonthDays) {
    var returnArray = new Array(6);
    var itemCount = 0;
    for (var item = 0; item < returnArray.length; item++) {
        returnArray[item] = new Array(7);
        var result = completeMonthDays.slice(itemCount, itemCount + 7);
        for (var x = 0; x < result.length; x++) {
            returnArray[item][x] = result[x];
        }
        itemCount += 7;
    }
    return returnArray;
}
/*This method constructs the month html content with dates*/
function GetConstructedMonthHTML(completeDays) {
    var htmlContent = "<table><tbody>";
    htmlContent += "<tr>";
    for (var day = 0; day < 7; day++) {
        htmlContent += "<td class='day'>";
        htmlContent += "<div class='month_head'>" + GetDayName(day) + "</div></td>";
    }
    htmlContent += "</tr>";
    for (var row = 0; row < completeDays.length; row++) {
        htmlContent += "<tr>";
        var items = completeDays[row];
        for (var d = 0; d < 7; d++) {
            var item = items[d];
            htmlContent += "<td class='" + GetTableDataClass(item) + "'>";
            htmlContent += "<div class='month_body " + item.GetUniqueDateId().toString() + "'>" + GetDayNo(item) + "<ul></ul></div></td>";
        }
        htmlContent += "</tr>";
    }
    htmlContent += "</tbody></table>";
    return htmlContent;
}
/*This method returns the day name for the day no [to-do: this may be changes based on the settings]*/
function GetDayName(dayNo) {

    switch (dayNo.toString()) {
        case "0":
            return "Sunday";
            break;
        case "1":
            return "Monday";
            break;
        case "2":
            return "Tuesday";
            break;
        case "3":
            return "Wedneday";
            break;
        case "4":
            return "Thursday";
            break;
        case "5":
            return "Friday";
            break;
        case "6":
            return "Saturday";
            break;
    }
}
/*This method return the class name based on the date settings*/
function GetTableDataClass(data) {
    if (data.IsAfter)
        return "after";
    else if (data.IsBefore)
        return "before";
    else if (data.IsNow)
        return "now";
    else
        return " ";
}
function GetDayNo(item) {

    if (item.DayNo == "1")
        return item.MonthName + ' ' + item.DayNo;

    return item.DayNo;

}
/*This method sets the options of month,day,week to be checked */
function SetOption(view) {
    $("#options > input").each(function () {
        var vId = $(this).attr("viewId");
        if (IsEqual(vId, view)) {
            $(this).attr("checked", true);
        }
        else {
            $(this).attr("checked", false);
        }
    });
}
function GetOptionTimes() {
    var timeHtml = "";
    for (var x = 0; x < times.length; x++) {
        timeHtml += "<option value='" + times[x] + "'>" + times[x] + "</option>";
    }
    return timeHtml;
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
        return this.Date.toString("dd/MMM/yy");
    };
    this.GetDBDate = function () {
        return this.Date.toString('yyyy-MM-dd');
    };
    this.GetUniqueDateId = function () {
        return this.DayNo.toString() + this.MonthNo.toString() + this.Year.toString() + this.WeekDayNo.toString();
    };
}


