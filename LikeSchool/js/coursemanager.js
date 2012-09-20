$(document).ready(function () {
    $("#clearbtn").click(function () {
        clear_form_elements("#addTab");
        RemoveModalErrors('#addTab');
    });
    $("#addCoursebtn").click(function () {
        var errorStatus = SetErrorIfEmpty("#addTab");
        if (errorStatus) {

        }
    });
});
