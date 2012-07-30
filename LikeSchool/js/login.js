function fnShowMessage() {
    $("#errorid").css('display', 'block');
}
function fnHideMessage() {
    $("#errorid").css('display', 'none'); 
}
function fnHideUserError() {
    fnHideMessage();
    $('#erroruser').css('display', 'none');
    $('.usernameClass').css('border-color', '#000');
}
function fnHiderPassError() {
    fnHideMessage();
    $('#errorpass').css('display', 'none');
    $('.passwordClass').css('border-color', '#000');
}
function fnValidateUser() {
    var user = $('.usernameClass').val();
    if (user == '' || null || undefined) {
        $('#erroruser').css('display', 'block');
        $('.usernameClass').css('border-color', '#DD4B39');
        $('.usernameClass').focus();
        return false;
    }
    else {
        fnHideUserError();
        return true;
    }
}
function fnValidatePass() {
    var pass = $('.passwordClass').val();
    if (pass == '' || null || undefined) {
        $('#errorpass').css('display', 'block');
        $('.passwordClass').css('border-color', '#DD4B39');
        $('.passwordClass').focus();
        return false;
    }
    else {
        fnHiderPassError();
        return true;
    }
}



