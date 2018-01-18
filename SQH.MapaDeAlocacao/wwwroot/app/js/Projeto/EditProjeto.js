(function () {
    $(document).ready(function () {
        //alocação
        $('#btnModalAdicionarTipoAlocacao').click(function (e) {
            e.preventDefault();

            var idProjeto = $('#Id').val();

            $.get('/Alocacao/ObtemModalAlocacaoProjeto?idProjeto=' + idProjeto, function (result) {
                $('#divModalAlocacaoProjeto').html(result);

                $('.dataInicioAlocacaoProjeto').val('');
                $('.dataFinalAlocacaoProjeto').val('');

                setDatePicker();

                $('#modalSalvarTipoAlocacao').modal({
                    show: true,
                    backdrop: 'static'
                });
            });
        });

        $('.lnkEditarPeriodo').click(function (e) {
            e.preventDefault();

            var tr = $(this).closest('tbody tr');

            var alocacao = $(tr).children().find('.tipoAlocacao').html().trim();
            var idTipoAlocacao = $(tr).children().find('.idTipoAlocacao').val();
            var idAlocacao = $(tr).children().find('.idAlocacao').val();
            var idProjeto = $('#Id').val();

            var dataInicio = $(tr).children().find('.dataInicio').html().trim();
            var dataFinal = $(tr).children().find('.dataFim').html().trim();

            $('.dataInicioAlocacaoProjeto').val(dataInicio);
            $('.dataFinalAlocacaoProjeto').val(dataFinal);

            setDatePicker();

            $('#divCboAlocacao').addClass('hide');
            $('#divStrAlocacao').removeClass('hide');
            $('#lblTipoAlocacao').html(alocacao);
            $('#IdProjeto').val(idProjeto);
            $('#IdAlocacao').val(idAlocacao);
            $('#IdTipoAlocacao').val(idAlocacao);

            $('#formSalvarAlocacaoProjeto').attr('action', '/Alocacao/EditarPeriodoAlocacao');

            $('#modalSalvarTipoAlocacao').modal({
                show: true,
                backdrop: 'static'
            });
        });
    });

    function setDatePicker() {
        $.datetimepicker.setLocale('pt-BR');
        $('.data').datetimepicker({
            timepicker: false,
            format: 'd/m/Y',
            formatDate: 'Y/m/d',
            startDate: new Date()
        });
    };
})();