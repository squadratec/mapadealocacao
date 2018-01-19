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

            $('.dataInicioAlocacaoRecurso').val('');
            $('.dataFimAlocacaoRecurso').val('');

            $('#modalSalvarRecursoAlocacao').modal({
                show: true,
                backdrop: 'static'
            });
        });

        $('.lnkEditarRecursoAlocacao').click(function (e) {
            e.preventDefault();

            $('#alertErroSalvarRecurso').addClass('hide');
            $('#formSalvarRecursoAlocacao').validate().resetForm();

            var divAlocacao = $(this).closest('.alocacoes');
            var trRecurso = $(this).closest('tbody tr');

            var idAlocacao = getIdAlocacao(this);
            var idProjeto = $('#Id').val();
            var idRecurso = $(trRecurso).children().find('.idRecurso').val();
            var recurso = $(trRecurso).children().find('.recurso').html().trim();

            var dataInicio = $(trRecurso).children().find('.dataInicio').html().trim();
            var dataFinal = $(trRecurso).children().find('.dataFim').html().trim();

            $('.dataInicioAlocacaoRecurso').val(dataInicio);
            $('.dataFimAlocacaoRecurso').val(dataFinal);

            setDatePicker();

            $('#idProjetoAlocacaoRecurso').val(idProjeto);
            $('#idAlocacaoRecurso').val(idAlocacao);
            $('#IdRecurso').val(idRecurso);
            $('#Recurso').val(recurso).attr('readonly', 'readonly');

            $('#formSalvarRecursoAlocacao').attr('action', '/AlocacaoRecurso/Editar');

            $('#modalSalvarRecursoAlocacao').modal({
                show: true,
                backdrop: 'static'
            });
        });

        $('#btnSalvarRecursoAlocacao').click(function (e) {

            if ($('#formSalvarRecursoAlocacao').valid()) {
                var url = $('#formSalvarRecursoAlocacao').attr('action');
                $.post(url, $('#formSalvarRecursoAlocacao').serialize(), function (result) {
                    if (!result.valido) {
                        $('#msgErroSalvarRecurso').html(result.mensagem);
                        $('#alertErroSalvarRecurso').removeClass('hide');
                    } else {
                        window.location = "/Projeto/Edit/" + $('#Id').val();
                    }
                }).error(function (result) {
                    $('#msgErroSalvarRecurso').html(result.mensagem);
                    $('#alertErroSalvarRecurso').removeClass('hide');
                });
            }
        });

        $(document).on('click', '#btnSalvarAlocacaoProjeto', function (e) {
            var form = $('#formSalvarAlocacaoProjeto');

            $.validator.unobtrusive.parse(form);

            if ($(form).valid()) {
                var url = $(form).attr('action');
                $.post(url, $(form).serialize(), function (result) {
                    if (!result.valido) {
                        $('#msgErroSalvarAlocacaoProjeto').html(result.mensagem);
                        $('#alertErroSalvarAlocacaoProjeto').removeClass('hide');
                    } else {
                        window.location = "/Projeto/Edit/" + $('#Id').val();
                    }
                }).error(function (result) {
                    $('#msgErroSalvarAlocacaoProjeto').html(result.mensagem);
                    $('#alertErroSalvarAlocacaoProjeto').removeClass('hide');
                });
            }
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