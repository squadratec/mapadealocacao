(function () {
    $(document).ready(function () {
        $('#tableRecurso').DataTable({
            language: {
                url: "/lib/DataTables-1.10.16/js/pt-BR.js"
            },
            'aaSorting': [],
            'columnDefs': [
                { 'targets': 0, "orderable": true },
                { 'targets': 1, "orderable": false }
            ]
        });
    });
})();