
var place;
var radioVal;
var baseurl = "/Services/StudentService.asmx/";
$(document).ready(function () {
    UpdateSearchTextPlaceHolder();
    $('input[name=optionsRadios]').click(function () {
        UpdateSearchTextPlaceHolder();
    });
    $('#searchSubmit').click(function () {
        var searchURL = baseurl;
        var searchText = $('#searchtext').val();
        var classModal;
        var admissionNo;
        var references=[];
        var values=[];
        switch (radioVal) {
            case 'admission':
                admissionNo = searchText;
                searchURL += "SearchByAdmission";
                references.push("AdmissionNo");
                values.push(admissionNo);
                break;
            case 'class':
                var items = searchText.split('-');
                var clName = items[0];
                var section = items[1];
                searchURL += "SearchByClass";
                references.push("ClassName");
                values.push(clName);
                references.push("Section");
                values.push(section);
                break;
        }

        $.ajax({
            url: searchURL,
            data: JSON.stringify({ jsonValue: GetJsonString(references, values) }),
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (res) {
                $("#searchResult").empty();
                var result = eval(res.d);
                var resultText = ConstructSearchResult(result);
                $("#searchResult").append(resultText);
            }
        });

    });

});

function ConstructSearchResult(result) {
    if (result.length == 0)
        return "Sorry your search does not matches the record.We request you to select the system suggested text";
    else {
        var table = "<table class='table table-striped table-bordered'>";
        table += "<thead><tr>";
        table += "<th>No</th>";
        table += "<th> Admission No</th>";
        table += "<th> Name </th>";
        table += "<th> Class-Section</th>";
        table += "</tr></thead>";

        table += "<tbody>";
        for (var x = 0; x < result.length; x++) {
            var data = result[x];
            table += "<tr>";
            table += "<td>" + (x + 1) + "</td>";
            table += "<td><a href='/studentdetail.aspx?adno=" + data.AdmissionNo + "'>" + data.AdmissionNo + "</a></td>";
            table += "<td>" + data.FirstName + "</td>";
            table += "<td>" + data.ClassName+"-"+data.Section + "</td>";
            table += "</tr>";

        }
        table += "</tbody>";
        table += "</table>";
        return table;
    }
}
function UpdateSearchTextPlaceHolder() {
    $('#searchtext').val('');
    radioVal = $('input[name=optionsRadios]:checked', '#search').val();
    switch (radioVal) {
        case 'admission':
            place = "Type the admission No [eg: 1045]";
            break;
        case 'class':
            place = "Type the Class-Section [eg: VI-A] ";
            break;
    }
    SetTypeAheadItems(radioVal);
    $('#searchtext').attr("placeholder", place);
}

function SetTypeAheadItems() {

    var aheadUrl = baseurl;

    switch (radioVal) {
        case 'admission':
            aheadUrl += "SelectAdmissionNoTable";
            break;
        case 'class':
            aheadUrl += "SelectClassTable";
            break;
    }
    $.ajax({
        url: aheadUrl,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (res) {
            var result = eval(res.d);
            var items;
            switch (radioVal) {
                case 'admission':
                    items = GetAdmissionArray(result);
                    break;
                case 'class':
                    items = GetClassArray(result);
                    break;
            }
            $("#searchtext").attr('data-source', JSON.stringify(items));
        }
    });
}

function GetClassArray(result) {
    var classItems = [];
    for (var x = 0; x < result.length; x++) {
        var classData = result[x];
        classItems.push(classData.ClassName + '-' + classData.Section);
    }
    return classItems;
}

function GetAdmissionArray(result) {
    var adItems = [];
    for (var x = 0; x < result.length; x++) {
        var adData = result[x];
        adItems.push(adData.AdmissionNo);
    }
    return adItems;
}

function ClassModal(inputText) {
    this.input = inputText;
    this.items = this.input.split('-');
    this.ClassName = this.items[0];
    this.Section = this.items[1];
}