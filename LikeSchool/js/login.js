function  fnShowMessage()
{
    $("#errorid").css('display', 'block');
}
function fnHideMessage()
{
    $("#errorid").css('display', 'none');
}

$(document).ready(function () {
    $("#user,#pass").focus(function () {
        fnHideMessage();
    });

});