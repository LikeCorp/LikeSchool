$(document).ready(function () {
    
    $('#first').show();
    $('li.active').find('i').removeClass('icon-black');
    $('li.active').find('i').addClass('icon-white');
    $('.prof > li a').click(function () {
        $('.prof li').each(function () {
            $(this).removeClass('active');
            $(this).find('i').removeClass('icon-white');
            $(this).find('i').addClass('icon-black');
        });
        $('.profs').hide();
        $('#' + $(this).attr('hint')).show();
        $(this).parent().addClass('active');
        $(this).find('i').removeClass('icon-black');
        $(this).find('i').addClass('icon-white');
    });
    $('.sDataTable').dataTable({
        "sDom": "<'row'<'span6'l><'span6'f>r>t<'row'<'span6'i><'span6'p>>",
        "sPaginationType": "bootstrap",
        "oLanguage": {
            "sLengthMenu": "_MENU_ records per page"
        }
    });


});