function fnShowMessage() {
    $("#errorid").css('display', 'block');
}
function fnHideMessage() {
    $("#errorid").css('display', 'none');
}
function fnHideUserError() {
    fnHideMessage();
    $('#erroruser').css('display', 'none');
    ClearErrorBorder('.usernameClass');
}
function fnHiderPassError() {
    fnHideMessage();
    $('#errorpass').css('display', 'none');
    ClearErrorBorder('.passwordClass');
}
function fnValidateUser() {
    var user = $('.usernameClass').val();
    if (user == '' || null || undefined) {
        $('#erroruser').css('display', 'block');
        SetErrorBorder('.usernameClass');
        $('.usernameClass').focus();
    }
    else {
        fnHideUserError();
    }
}
function fnValidatePass() {
    var pass = $('.passwordClass').val();
    if (pass == '' || null || undefined) {
        $('#errorpass').css('display', 'block');
        SetErrorBorder('.passwordClass');
        $('.passwordClass').focus();        
    }
    else {
        fnHiderPassError();        
    }
}

$(document).ready(function () {
    $('.usernameClass').focus();
});



