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

    let resposta = confirm("Realmente deseja excluir esse registro?");
    if (resposta) {
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
    } else {
        return false;
    }

}

/***********Eventos sem chamadas***********/
$(document).ready(function () {
    $('select[id="ddmodoPagamento"]').ready(function () {
        var helpers =
        {
            buildDropdown: function (result, dropdown, emptyMessage) {
                let tempData = $('#hdmodoPagamento');
                //Remove current options
                dropdown.html('');
                //Add the empty option with the empty message
                dropdown.append('<option value="0">' + emptyMessage + '</option>');
                // Check result isnt empty
                if (result != '') {
                    // Loop through each of the results and append the option to the dropdown
                    $.each(result, function (k, v) {
                        if (v.cdTipoPagamento == tempData.val()) {
                            dropdown.append('<option value="' + v.cdTipoPagamento + '" selected>' + v.dsTipoPagamento + '</option>');
                        } else {
                            dropdown.append('<option value="' + v.cdTipoPagamento + '">' + v.dsTipoPagamento + '</option>');
                        }
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

    $('select[id="ddIndicador"]').ready(function () {
        var helpers =
        {
            buildDropdown: function (result, dropdown, emptyMessage) {
                let tempData = $('#hdIndicador');
                //Remove current options
                dropdown.html('');
                //Add the empty option with the empty message
                dropdown.append('<option value="0">' + emptyMessage + '</option>');
                // Check result isnt empty
                if (result != '') {
                    // Loop through each of the results and append the option to the dropdown
                    $.each(result, function (k, v) {
                        if (v.cdParticipante == tempData.val()) {
                            dropdown.append('<option value="' + v.cdParticipante + '" selected>' + v.nmParticipante + '</option>');
                        } else {
                            dropdown.append('<option value="' + v.cdParticipante + '">' + v.nmParticipante + '</option>');
                        }
                    });
                }
            }
        }

        $.ajax({
            type: "GET",
            url: '../Funcoes/GetParticipantes',
            success: function (data) {
                helpers.buildDropdown(
                    jQuery.parseJSON(data),
                    $('#ddIndicador'),
                    'Selecione quem indicou'
                );
            },
            cache: false
        });
        return false;
    });

    $('.tabela').DataTable({
        "dom": 'rt <"text-sm" p>',
        "language": {
            "url": "../Content/Componentes/datatables.net/plugins/Portuguese-Brasil.json"
        }
    });

    moment.locale('pt-br');
    $('.daterange').daterangepicker({
        autoUpdateInput: false
    }, function (dataInicio, dataFim) {
        $('.daterange').val(dataInicio.format("DD/MM/YYYY") + ' - ' + dataFim.format('DD/MM/YYYY'));
    });

    $('.daterange2').daterangepicker({
        autoUpdateInput: false
    }, function (dataInicio, dataFim) {
        $('.daterange').val(dataInicio.format("DD/MM/YYYY") + ' - ' + dataFim.format('DD/MM/YYYY'));
    });

    $('.datepicker').daterangepicker({
        singleDatePicker: true
    });

    $('[data-mask]').inputmask();

    $('.select2').select2({
        containerCssClass: 'form-control rounded'
        , width: "100%"
    });

    $('#defaultCountdown').countdown({ until: 1200, format: 'MS', compact: true });

});