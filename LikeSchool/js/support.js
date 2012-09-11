
$(document).ready(function () {

    $('#supportId').click(function () {
        InitializeSupport();
    });

    $('#submitSupport').click(function () {
        if (SetErrorIfEmpty("#supportElements")) {
            var fd = new FormData();
            fd.append('file', $('#fileInput')[0].files[0]);
            fd.append('email', $("#email").val());
            fd.append('severity', GetHtmlElementValue('severity'));
            fd.append('schoolname', $("#schoolName").val());
            fd.append('short', $("#sDesc").val());
            fd.append('desc', $("#description").val());
            $.ajax
        (
            {
                url: "/Handlers/Supporthandler.ashx",
                secureuri: false,
                data: fd,
                type: 'POST',
                contentType: false,
                processData: false,
                beforeSend : function () { $('#loader').css('display', 'block');},
                complete:function(){$('#loader').css('display', 'none');},
                success: function (data) {
                    $('#supportWindow').modal('hide')
                    var result = jQuery.parseJSON(data).result;
                    if (result == "True") {                       
                        $('#thanksWindow').modal({

                        });
                    }
                    else {
                        $('#errorWindow').modal({

                        });
                    }
                }
            }
        )
        }
    });


    $('#clearAll,.close').click(function () {
        clear_form_elements('#supportElements');
        $("#fileInput").replaceWith("<input class='input-file' id='fileInput' type='file'>");
        RemoveModalErrors("#supportElements");
    });
});

function InitializeSupport()
{
    $("#email").focus();
    $("#supportWindow").modal({

    });
}