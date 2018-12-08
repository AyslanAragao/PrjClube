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

function removerParticipante(item, id) {
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

/***********Eventos sem chamadas***********/
$('select[id="ddmodoPagamento"]').ready(function () {
    var helpers =
    {
        buildDropdown: function (result, dropdown, emptyMessage) {
            //Remove current options
            dropdown.html('');
            //Add the empty option with the empty message
            dropdown.append('<option value="0">' + emptyMessage + '</option>');
            // Check result isnt empty
            if (result != '') {
                // Loop through each of the results and append the option to the dropdown
                $.each(result, function (k, v) {
                    dropdown.append('<option value="' + v.cdTipoPagamento + '">' + v.dsTipoPagamento + '</option>');
                });
            }
        }
    }

    $.ajax({
        type: "GET",
        url: '../Funcoes/GetModoPagamentos',
        success: function (data) {
            helpers.buildDropdown(
                jQuery.parseJSON(data),
                $('#ddmodoPagamento'),
                'Selecione um Pagamento'
            );
        },
        cache: false
    });
    return false;
});

$('.dataTable').dataTable({
    "dom": 'rtp',
    "language": {
        "url":"../Content/Componentes/datatables.net/plugins/Portuguese-Brasil.json"
    }
})