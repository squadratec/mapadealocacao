(function () {
    $(document).ready(function () {
        $('#tableTipoAlocacao').DataTable({
            language: {
                url: "/lib/DataTables-1.10.16/js/pt-BR.js"
            },
            "paging": true,
            "pagingType": "full_numbers",
            'aaSorting': [],
            'columnDefs': [
                { 'targets': 0, "orderable": true },
                { 'targets': 1, "orderable": false }
            ]
        });
    });
})();