
var emailRegEx = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
//This method gets the values and keys and gives you back the json key value pair
function GetJsonString(references, values) {
    var jsonArray = [];
    for (var x = 0; x < references.length; x++) {

        jsonArray.push("'" + references[x] + "':'" + values[x] + "'");
    }
    return "{" + jsonArray.join(",").toString() + "}";
}

//This method returns the constructed html part for the select with the array of values
function GetOptions(arrayValues) {
    var resultHtml = "";
    for (var x = 0; x < arrayValues.length; x++) {
        resultHtml += "<option value='" + arrayValues[x] + "'>" + arrayValues[x] + "</option>";
    }
    return resultHtml;
}

function GetHtmlElementValue(id) {
    var tagName = $('#' + id)[0].tagName;
    var returnValue;
    switch (tagName.toLowerCase()) {
        case 'select':
            returnValue = $('#' + id + ' option:selected').text();
            break;
        case 'textarea':
            returnValue = $('#' + id).val();
        case 'input':
            {
                switch ($('#' + id).attr('type')) {
                    case 'text':
                        returnValue = $('#' + id).val();
                        break;
                    case 'checkbox':
                        returnValue = $('#' + id).attr('checked')=='checked' ? true:false;
                        break;
                }
            }
            break;

    }
    return returnValue;
}
function clear_form_elements(ele) {
    $(ele).find(':input').each(function () {
        switch (this.type) {
            case 'password':
            case 'select-multiple':
            case 'select-one':
            case 'text':
            case 'textarea':
                $(this).val('');
                break;
            case 'checkbox':
            case 'radio':
                this.checked = false;
        }
    });
}

function SetErrorIfEmpty(element) {
    var noError = true;
    $(element).find(':input').each(function () {
        switch (this.type) {
            case 'password':
            case 'select-multiple':
            case 'select-one':
            case 'text':
            case 'textarea':
                noError = SetErrorBorder(this);
                if (!noError)
                    return noError;
                break;
        }
    });
    return noError;
}

function SetErrorBorder(inputId) {
    var validationType = $(inputId).attr('validationtype');
    var errorText = '';
    var value = $(inputId).val();
    var check = true;
    if (value == '') {
        errorText = 'Required';
    }
    else {
        switch (validationType) {
            case 'email':
                if (!emailRegEx.test($(inputId).val())) {
                    errorText = "Enter Valid Mail Address";
                }
                break;
        }
    }
    if (errorText != '') {
        check = false;
        $(inputId).addClass(' error');
        if ($(inputId).nextAll('span.error').length == 0) {
            $(inputId).parent().append("<span class='error'>" + errorText + "</span>");
        }
    } else {
        ClearErrorBorder(inputId);
    }

    return check;
}
function ClearErrorBorder(id) {
    $(id).removeClass(' error');
    $(id).nextAll('span.error').remove()
}

function RemoveModalErrors(element) {
    $(element).find(':input').each(function () {
        ClearErrorBorder(this);
    });
}


