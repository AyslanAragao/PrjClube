function exibirMensagem(titulo, texto, tipo) {
    BootstrapDialog.alert({
        title: titulo,
        message: texto,
        draggable: true,
        type: tipo != null ? tipo : BootstrapDialog.TYPE_PRIMARY
    });
}

function Confirmar (message , callback) {
    new BootstrapDialog({
        title: 'Confirmação',
        message: message,
        closable: false,
        data: {
            'callback': callback
        },
        buttons: [{
            label: 'Cancelar',
            action: function (dialog) {
                typeof dialog.getData('callback') === 'function' && dialog.getData('callback')(false);
                //return false;
                dialog.close();
            }
        }, {
            label: 'Sim',
            cssClass: 'btn-primary',
            action: function (dialog) {
                typeof dialog.getData('callback') === 'function' && dialog.getData('callback')(true);
                //return true;
                dialog.close();
            }
        }]
    }).open();
};

(function ($) {
    $.fn.cascade = function (options) {
        var defaults = {};
        var opts = $.extend(defaults, options);

        return this.each(function () {
            $(this).change(function () {
                var selectedValue = $(this).val();
                var params = {};
                params[opts.paramName] = selectedValue;
                $.getJSON(opts.url, params, function (items) {
                    opts.childSelect.empty();
                    $.each(items, function (index, item) {
                        opts.childSelect.append(
                            $('<option/>')
                                .attr('value', item.Id)
                                .text(item.Name)
                        );
                    });
                });
            });
        });
    };
})(jQuery);

function retornoAjaxForm(result) {
    if (result.isRedirect) {
        window.location.href = result.redirectUrl;
    }
    else {
        if (result.isClear) {
            resetFormValues();
        }
        if (result.mensagem != null && result.mensagem != 'undefined' && $.trim(result.mensagem) != '') {
            exibirMensagem("Mensagem", result.mensagem, result.tpMensagem);
        }
    }
}

function resetFormValues() {

    $(":text").each(function () {
        $(this).val("");
    });

    $(":radio").each(function () {
        $(this).prop({ checked: false })
    });

   /* $("select").each(function () {
        $(this).val("");
    });*/
    $('[data-limpar="true"] tbody > tr').remove();
}

//function removerDataValDrop() {
//    $("select[data-val-number]").each(function () {
//        var drop = $(this);
//        //drop.removeAttr("data-val-number");
//        drop.attr('data-val-number', 'Campo obrigatório');
//    });
//    //$.validator.unobtrusive.parse("form");
//}

//function toogle_class(ckd, el) {
//    if (ckd == true)
//        el.addClass('selecionado');
//    else
//        el.removeClass('selecionado');
//}

String.prototype.format = String.prototype.f = function () {
    var s = this,
        i = arguments.length;

    while (i--) {
        s = s.replace(new RegExp('\\{' + i + '\\}', 'gm'), arguments[i]);
    }
    return s;
};

String.prototype.json = function () {
    var texto = this;
    try
    {
        var jsonObject = JSON.parse(texto);
        return jsonObject;
    }
    catch(e)
    {
        return null;
    }
};

function converteDataPtBr(data){
    var objDate = new Date();
    objDate.setYear(data.split("/")[2]);
    objDate.setMonth(data.split("/")[1] - 1);//- 1 pq em js é de 0 a 11 os meses
    objDate.setDate(data.split("/")[0]);
    return objDate;
}

$(function () {
        $(".details").click(function () {
            var id = $(this).attr("data-id");
            $("#modal").load("Editar?id=" + id, function () {
                $("#modal").modal();
            })
        });
    })