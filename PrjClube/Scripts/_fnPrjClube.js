﻿function AbrirModal(idDivModal, urlModal) {
    $(idDivModal).load(urlModal).modal({
        keyboard: false,
        backdrop: 'static'
    });
};
function SomenteNumero(e) {
    var tecla = (window.event) ? event.keyCode : e.which;
    if ((tecla > 47 && tecla < 58)) return true;
    else {
        if (tecla == 8 || tecla == 0) return true;
        else return false;
    }
};
$(function () {
    $('input[name="dtDoacao"]').datepicker({
        singleDatePicker: true,
        showDropdowns: true
    });
});