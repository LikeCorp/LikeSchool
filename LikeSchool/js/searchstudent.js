
var place;
$(document).ready(function () {
    UpdateSearchTextPlaceHolder();
    $('input[name=optionsRadios]').click(function () {
        UpdateSearchTextPlaceHolder();
    });
    
});
function UpdateSearchTextPlaceHolder()
{    
    var radioVal = $('input[name=optionsRadios]:checked', '#search').val();
    switch (radioVal) {
        case 'admission':
            place = "Show Admission";
            break;
        case 'batch':
            place = "Show Batch";
            break;
        case 'class':
            place = "show class";
            break;
    }
    $('#searchtext').attr("placeholder", place);
}