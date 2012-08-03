
$(document).ready(function () {
    $('.usernameClass').removeClass('focused')
    $("#clearAll").click(function () {
        clear_form_elements("#supportWindow");
    });
    $('#supportId').click(function () {
        $("#email").addClass('focused');
        $("#supportWindow").modal({

        });
    });

    $('#submitSupport').click(function () {
        SetErrorIfEmpty("#supportElements");
    });

    $('#clearAll').click(function () {
        clear_form_elements('#supportElements');
    });

});