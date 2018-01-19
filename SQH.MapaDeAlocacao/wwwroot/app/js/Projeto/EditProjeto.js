(function () {
    $(document).ready(function () {
        setDatePicker();

        $.autoComplete();

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

            var divAlocacao = $(this).closest('.alocacoes');

            var alocacao = $(divAlocacao).find('.tipoAlocacao').html().trim();
            var idTipoAlocacao = $(divAlocacao).find('.idTipoAlocacao').val();
            var idAlocacao = getIdAlocacao(this);
            var idProjeto = $('#Id').val();

            var dataInicio = $(divAlocacao).find('.dataInicio').html().trim();
            var dataFinal = $(divAlocacao).find('.dataFim').html().trim();

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

        $('.lnkAdicionarRecurso').click(function (e) {

            var idAlocacao = getIdAlocacao(this);
            var idProjeto = $('#Id').val();
            
            $('#idAlocacaoRecurso').val(idAlocacao);
            $('#idProjetoAlocacaoRecurso').val(idProjeto);

            $('#modalSalvarRecursoAlocacao').modal({
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

    function getIdAlocacao(e) {
        var divAlocacao = $(e).closest('.alocacoes');
        
        var idAlocacao = $(divAlocacao).find('.idAlocacao').val();

        return idAlocacao;
    };
})();