!(function ($) {
    $.autoComplete = function () {
        $('.autocomplete').each(function (i) {

            var minCaracteres = $(this).data('min-caracteres');
            var urlDados = $(this).data("url-dados");
            var idValue = $(this).data("id-value");
            
            $(this).autocomplete({
                minLength: minCaracteres,
                source: function (request, response) {
                    $.get(urlDados.concat("?termos=", request.term), function (data) {
                        response(data);
                    });
                },
                select: function (event, ui) {
                    event.preventDefault();

                    $(this).val(ui.item.label);
                    $("#" + idValue).val(ui.item.value);
                },
                change: function (event, ui) {
                    if (ui.item == null)
                        $("#" + idValue).val('');
                }
            })
        });
    };
})(jQuery);