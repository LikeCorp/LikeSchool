$(document).ready(function () {
    var loc = window.location.pathname.substring(1, window.location.pathname.indexOf('.'));
    if (loc == "index") {
        $("#menu").css("display", "none");
    }
    else {
        $("#menu").css("display", "block");
    }
});
