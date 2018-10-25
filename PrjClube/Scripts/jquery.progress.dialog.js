function showProgressDialog() {
    /*
    $("#progressDialog").dialog({
        autoOpen: false,
        draggable: false,
        modal: true,
        bgiframe: true,
        resizable: false,
        closeOnEscape: false,
        open: function () { $(".ui-dialog-titlebar-close").hide(); } // Hide close button
    });

    $('#progressDialog').dialog('open');*/
    waitingDialog.show();
}

function hideProgressDialog() {
    /*
    if ($('#progressDialog').dialog('isOpen')) {

        $('#progressDialog').dialog('close');
    }*/
    waitingDialog.hide();
}

