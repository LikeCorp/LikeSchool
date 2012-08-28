$(document).ready(function () {
    $('#profile').show();
    $('#subheading').text(" - Student Profile");
    $('.active').find('i').removeClass('icon-black');
    $('.active').find('i').addClass('icon-white');
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
        $('#subheading').text(" - " + $(this).text());
    })

});