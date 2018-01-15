﻿(function () {
    var localVars = {
        form: "#formCreateRecurso"
    };

    $(document).ready(function () {
        $(localVars.form).on("submit", function (e) {
            e.preventDefault();

            var url = '/Recurso/Create';

            $.post(url, $(localVars.form).serialize(), function (result) {
                console.log(result);
            }).error(function (result) {
                console.log(result);
            });
        });
    });
})();