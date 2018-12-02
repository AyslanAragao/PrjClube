function AbrirModal(idDivModal, urlModal) {
    $(idDivModal).load(urlModal).modal({
        keyboard: false,
        backdrop: 'static'
    });
};

function somenteNumeros(num) {
    var er = /[^0-9.]/;
    er.lastIndex = 0;
    var campo = num;
    if (er.test(campo.value)) {
        campo.value = "";
    }
};

function removerParticipante(item,id) {
    var tbody = document.getElementById("listaParticipantes");
    //var linha = tbody.getElementsByTagName("tr");
    var tr = $(item).closest('tr');
    tr.fadeOut(400, function () { tr.remove(); });

    $.ajax({
        url: 'RemoverParticipante?id=' + id,
        cache: false,
        type: 'GET'
    });
    return false;
}