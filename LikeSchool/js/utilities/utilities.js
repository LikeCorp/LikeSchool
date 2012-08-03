
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
        case 'input':
            returnValue = $('#' + id).val();
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

function SetErrorIfEmpty(element)
{
    $(element).find(':input').each(function () {
        switch (this.type) {
            case 'password':
            case 'select-multiple':
            case 'select-one':
            case 'text':
            case 'textarea':
                if ($(this).val() == '')
                    SetErrorBorder(this);
                else
                    ClearErrorBorder(this);
                break;          
        }
    });   
}

function SetErrorBorder(id)
{
    $(id).addClass(' error');
}
function ClearErrorBorder(id)
{
    $(id).removeClass(' error');
}


