(function () {
    var localVars = {
        form: "#formEditRecurso"
    };

    $(document).ready(function () {
        $(localVars.form).on("submit", function (e) {
            e.preventDefault();

            var url = '/Recurso/Edit';

            $.post(url, $(localVars.form).serialize(), function (result) {
                console.log(result);
            }).error(function (result) {
                console.log(result);
            });
        });
    });
})();