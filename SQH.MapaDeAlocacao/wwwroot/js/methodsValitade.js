$(function () {
    $.validator.unobtrusive.adapters.add("datecompare", ['with', 'tipo'], function (options) {
        options.rules.datecompare = options.params;
        options.messages["datecompare"] = options.message;
    });

    $.validator.addMethod("datecompare",
        function (value, element, parameters) {
            var valorComparacao = $('#' + parameters['with']).val();
            var arrayValorComparacao = valorComparacao.split('/');
            var dataComparacao = new Date(arrayValorComparacao[2], arrayValorComparacao[1] - 1, arrayValorComparacao[0]).getTime();

            var arrayValor = value.split('/');
            var data = new Date(arrayValor[2], arrayValor[1] - 1, arrayValor[0]).getTime();

            var tipo = parameters['tipo'];

            if (tipo == 'Menor') {
                if (data < dataComparacao)
                    return true;
                else
                    return false;
            }
            else if (tipo == 'MenorIgual') {
                if (data < dataComparacao || data == dataComparacao)
                    return true;
                else
                    return false;
            }
            else if (tipo == 'Maior') {
                if (data > dataComparacao)
                    return true;
                else
                    return false;
            }
            else if (tipo == 'MaiorIgual') {
                if (data > dataComparacao || data == dataComparacao)
                    return true;
                else
                    return false;
            }
            else {
                if (data == dataComparacao)
                    return true;
                else
                    return false;
            }
        });
}(jQuery));