$(carregarGrid = function () {
    $('.edit-mode').hide();
    $('.edit-user, .cancel-user').on('click', function () {
        var tr = $(this).parents('tr:first');
        tr.find('.edit-mode, .display-mode').toggle();
    });

    $('.save-user').on('click', function () {
        var tr = $(this).parents('tr:first');
        var Name = tr.find("#Name").val();
        var Peso = tr.find("#Peso").val();
        var Minimo = tr.find("#Minimo").val();
        var UserID = tr.find("#UserID").html();
        tr.find("#lblPeso").text(Peso);
        tr.find("#lblName").text(Name);
        tr.find("#lblMinimo").text(Minimo);
        tr.find('.edit-mode, .display-mode').toggle();
        var UserModel =
        {
            "idKPI": UserID,
            "nome": Name,
            "vlPeso": Peso,
            "vlMinimo": Minimo
        };
        $.ajax({
            cache: false,
            url: '/FRI/KPIEquipe/',
            data: JSON.stringify(UserModel),
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                //alert(data);
            }
        });

    });


});