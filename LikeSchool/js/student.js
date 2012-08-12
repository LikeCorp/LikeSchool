$(document).ready(function () {
    $('#search').show();
    $('#subheading').text(" - Search Student");
    $('.prof > li a').click(function () {
        $('.prof li').each(function () {
            $(this).removeClass('active');
        });
        $('.profs').hide();
        $('#' + $(this).attr('hint')).show();
        $(this).parent().addClass('active');
        
        $('#subheading').text(" - " + $(this).text());
    })

});