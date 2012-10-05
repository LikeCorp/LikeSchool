var addCourseTab = "#addTab";
var addSubjectTab = "#addSTab";

$(document).ready(function () {
    

    $('#viewCourse,#manageCourse').click(function () {

        $.ajax({
            url: "/Services/CourseService.asmx/SelectDB",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            error: function () {
            },
            success: function (res) {
                $("#viewSTab").empty();
                $("#viewTab").empty();
                var result = eval(res.d);
                $("#viewTab").append(ConstructCourse(result));
                SetDataTableTheme();
            }
        });
    });
    $('#viewCourse').click();

    $('#viewSubject,#manageSubject').click(function () {
        $.ajax({
            url: "/Services/SubjectService.asmx/SelectDB",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            error: function () {
            },
            success: function (res) {
                $("#viewTab").empty();
                $("#viewSTab").empty();
                var result = eval(res.d);
                $("#viewSTab").append(ConstructSubject(result));
                SetDataTableTheme();
            }
        });
    });

    $("#clearbtn,#addCourse").click(function () {
        clear_form_elements(addCourseTab);
        RemoveModalErrors(addCourseTab);
    });
    $('#clearSub,#addSubject').click(function () {
        clear_form_elements(addSubjectTab);
        RemoveModalErrors(addSubjectTab);
    });
    $("#addCoursebtn").click(function () {
        var errorStatus = SetErrorIfEmpty(addCourseTab);
        if (errorStatus) {
            var references = ['CourseName', 'NoOfStudents', 'SubjectIds'];
            var rvalues = [];
            rvalues.push(GetHtmlElementValue('#inputCourse'));
            rvalues.push(GetHtmlElementValue('#inputNoStudents'));
            var subjects;
            $("#assignSubject").find('option').each(function () {
                if ($(this).prop('selected')) {
                    if (subjects == undefined)
                        subjects = $(this)[0].value + ",";
                    else
                        subjects += $(this)[0].value + ",";
                }
            });
            rvalues.push(subjects);

            var loginReference = ['id', 'username'];
            var loginValues = [];
            loginValues.push(GetLoginId());
            loginValues.push(GetLoginName());

            $.ajax({
                url: "/Services/CourseService.asmx/InsertDBWithLogin",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({ jsonValue: GetJsonString(references, rvalues), loginValues: GetJsonString(loginReference, loginValues) }),
                dataType: "json",
                error: function () {
                    $(".alert-error").css('display', 'block');
                },
                success: function (res) {
                    $(".alert").css('display', 'block');
                    clear_form_elements(addCourseTab);
                }
            });
        }
    });

    $('#addSub').click(function () {
        var errorSubStatus = SetErrorIfEmpty(addSubjectTab);
        if (errorSubStatus) {
            var references = ['SubjectName'];
            var rvalues = [];
            rvalues.push(GetHtmlElementValue('#inputSubject'));
            var loginReference = ['id', 'username'];
            var loginValues = [];
            loginValues.push(GetLoginId());
            loginValues.push(GetLoginName());
            $.ajax({
                url: "/Services/SubjectService.asmx/InsertDBWithLogin",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({ jsonValue: GetJsonString(references, rvalues), loginValues: GetJsonString(loginReference, loginValues) }),
                dataType: "json",
                success: function (res) {
                    $(".alert").css('display', 'block');
                    clear_form_elements(addSubjectTab);
                }
            });
        }
    });

});

function ViewCourse() {
    $.ajax({
        url: "/Services/CourseService.asmx/SelectDB",
        type: "POST",
        contenttype: "application/json;charset=utf-8",
        datatype: "json",
        error: function () {

        },
        success: function (res) {
            $("#viewTab").empty();
            var result = eval(res.d);
            $("#viewTab").append(ConstructCourse(result));

        }
    });
}

function ConstructCourse(course) {
    var table = "<legend>Courses</legend><table cellpadding='0' cellspacing='0' border='0' class='table table-striped table-bordered sDataTable'>";
    table += "<thead>";
    table += "<tr>";
    table += "<th>Course Name</th>";
    table += "<th>No of Students</th>";
    table += "<th>View</th>";
    table += "<th>Edit</th>";
    table += "<th>Delete</th>";
    table += "</tr>";
    table += "</thead>";
    table += "<tbody>";
    for (var c = 0; c < course.length; c++) {
        var tempCourse = course[c];
        table += "<tr>";
        table += "<td>" + tempCourse.CourseName + "</td>";
        table += "<td>" + tempCourse.NoOfStudents + "</td>";
        table += "<td><a href='#'><i class='icon-eye-open icon-black'></i></a></td>";
        table += "<td><a href='#'><i class='icon-pencil icon-black'></i></a></td>";
        table += "<td><a href='#'><i class='icon-remove icon-black'></i></a></td>";
        table += "</tr>";
    }
    table += "</tbody>";
    table += "</table>";
    return table;
}

function ConstructSubject(subject) {
    var table = "<legend>Subjects</legend><table cellpadding='0' cellspacing='0' border='0' class='table table-striped table-bordered sDataTable'>";
    table += "<thead>";
    table += "<tr>";
    table += "<th>Subject Name</th>";
    table += "<th>View</th>";
    table += "<th>Edit</th>";
    table += "<th>Delete</th>";
    table += "</tr>";
    table += "</thead>";
    table += "<tbody>";
    for (var s = 0; s < subject.length; s++) {
        table += "<tr>";
        table += "<td>" + subject[s].SubjectName + "</td>";
        table += "<td><a href='#'><i class='icon-eye-open icon-black'></i></a></td>";
        table += "<td><a href='#'><i class='icon-pencil icon-black'></i></a></td>";
        table += "<td><a href='#'><i class='icon-remove icon-black'></i></a></td>";
        table += "</tr>";
    }
    table += "</tbody>";
    table += "</table>";

    return table;
}
