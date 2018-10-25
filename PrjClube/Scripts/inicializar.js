jQuery(document).ready(function () {

    //var datepicker = $.fn.datepicker.noConflict(); // return $.fn.datepicker to previously assigned value
    //$.fn.bootstrapDP = datepicker;                 // give $().bootstrapDP the bootstrap-datepicker functionality

    //Aplica as mascaras
    //aplicarMascaras();
    //aplicarMaxlengths();

    $('#defaultCountdown').countdown({ until: 1200, format: 'MS', compact: true });

    //removerDataValDrop();
});

//function aplicarMascaras() {
//    //$(".telefone").trigger('focusout');
//     $(".telefone").focusout(function () {
//         var phone, element;
//         element = $(this);
//         element.unmask();
//         phone = element.val().replace(/\D/g, '');
//         if (phone.length > 10) {
//             element.mask("(99)99999-999?9");
//         } else {
//             element.mask("(99)9999-9999?9");
//         }
//     }).trigger('focusout');
//     $(".cpf").mask("999.999.999-99");
//     $(".cnpj").mask("99.999.999/9999-99");
//     $(".cep").mask("99999-999");
//     //$(".decimal").mask("9.999,99");
//     $(".decimal").maskMoney({ allowNegative: true ,allowZero:true, thousands: '.', decimal: ',' });
//     $(".ip_address").mask("099.099.099.099");
//     $(".data").datepicker({
//         format: "dd/mm/yyyy",
//         language: "pt-BR",
//         autoclose: true,
//         todayBtn: "linked",
//         todayHighlight: true,
//         clearBtn: true
//     }).mask("99/99/9999");
//    // Configuração para campos de Real.
//    //$(".real").maskMoney({ showSymbol: true, symbol: "R$", decimal: ",", thousands: "." });
//     $(".inteiro").keyup(function () {
//         //var valor = $(this).val().replace(/[^0-9]+/g, '');
//         var valor = $(this).val().replace(/\D/g, '');
//         $(this).val(valor);

//     });

//     $(".mascaraCustom").each(function () {
//         var $this = $(this);
//         var data = $this.data();
//         var mascara = data.mascaraCustom;
//         $this.mask(mascara);
//     });
// };

//function aplicarMaxlengths() {
//     $("input[data-val-length-max]").each(function () {
//         var $this = $(this);
//         var data = $this.data();
//         var maxLength = data.valLengthMax;
//         $this.attr("maxlength", maxLength);

//         /*var inputSize = "input-xxlarge";
//         if (maxLength < 5) {
//             inputSize = "input-mini";
//         }
//         else if (maxLength < 10) {
//             inputSize = "input-small";
//         }
//         else if (maxLength < 30) {
//             inputSize = "input-medium";
//         }
//         else if (maxLength < 75) {
//             inputSize = "input-large";
//         }
//         else if (maxLength < 150) {
//             inputSize = "input-xlarge";
//         }

//         $this.addClass(inputSize);*/

//     });
//}

 function num(dom) {
     dom.value = dom.value.replace(/\D/g, '');
 }




