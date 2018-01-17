(function () {
    $(document).ready(function () {
        $.datetimepicker.setLocale('pt-BR');
        $('.data').datetimepicker({
            timepicker: false,
            format: 'd/m/Y',
            formatDate: 'Y/m/d',
            startDate: new Date()
        });
    });
})();