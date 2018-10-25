var mensagem = null;
var tipoDialog = 'type-default';
var temMensagem = false;

function isErroJson (jsonObj) {
    return (jsonObj != null && jsonObj.isErro == true);
};

function retornoAjax(result) {
    hideProgressDialog();
    if (result != null && result.mensagem != null && result.mensagem != 'undefined' && $.trim(result.mensagem) != '') {
        exibirMensagem("Mensagem", result.mensagem, result.tpMensagem);
    }
    else if (this.mensagem != null && this.mensagem != 'undefined' && this.mensagem != '') {
        exibirMensagem("Mensagem", this.mensagem, this.tipoDialog);
        this.mensagem = null;
    }
};

// Abre modal para adição de um novo status
function abrirModalCadastro(idModal, urlAction, parametros) {
    showProgressDialog();
    var modal = "#" + idModal;
    $(modal).load(urlAction, parametros,
        function (response, status, xhr) {
            var json = response.json();
            retornoAjax(json);
            if (!isErroJson(json)) {
                $(modal).modal('show');
            }
        }
    );
};

// Adiciona um novo Status
function salvarItem(idGrid, urlAction, parametros, idModal ) {
    showProgressDialog();
    $("#" + idGrid).load(urlAction,parametros,
    function (response, status, xhr) {
        var json = response.json();
            
        retornoAjax(json);

        if (idModal && !temMensagem) {
            $("#" + idModal).modal('hide');
        }
    });
}

function salvarFormulario(urlAction, parametros, formID) {
    var form;
    if(formID)
        form = $("#" + formID);
    else
        form = $("form");
    form.validate();
    if (form.valid()) {
        showProgressDialog()
        //Posting them to server with ajax
        $.ajax({
            url: urlAction,
            data: parametros,
        dataType: 'json',
        type: 'POST',
        success: function (result) {
            retornoAjaxForm(result);
        },
        complete: function () {
            hideProgressDialog();
        }
    });
}
}
