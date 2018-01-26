(function () {
    $(document).ready(function () {
        $('span').tooltip();
    });

    $('.data').datetimepicker({
        locale: 'pt-BR',
        viewMode: 'months',
        format: 'MM/YYYY'
    });
})();