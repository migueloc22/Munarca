
//$('#ContentPlaceHolder1_ContentPlaceHolder1_txtFechaNac').datepicker({
//    formato: 'mm / dd / aaaa',
//    startDate: '-3d'
//});

$(function () {
    $('[data-toggle="tooltip"]').tooltip()
});

$(function () {
    $('[data-toggle="popover"]').popover()
});
$(function () {
    $("#rondellCarousel").rondell({
        preset: "slider",
    });

});
$("#ContentPlaceHolder1_ContentPlaceHolder1_uploadFile1").fileinput({ language: "es",uploadUrl: "/file-upload-batch/2",
    allowedFileExtensions: ["jpg", "png", "gif"], showCaption: false
});

jQuery(function ($) {

    $(".check-seguridad").strength({
        templates: {
            toggle: '<span class="input-group-addon"><span class="glyphicon glyphicon-eye-open {toggleClass}"></span></span>'

        },
        scoreLables: {
            empty: 'Vacío',
            invalid: 'Invalido',
            weak: 'Débil',
            good: 'Bueno',
            strong: 'Fuerte'
        },
        scoreClasses: {
            empty: '',
            invalid: 'label-danger',
            weak: 'label-warning',
            good: 'label-info',
            strong: 'label-success'
        },

    });
});
$.datepicker.regional['es'] = {
    closeText: 'Cerrar',
    prevText: '<Ant',
    nextText: 'Sig>',
    currentText: 'Hoy',
    monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
    monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
    dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
    dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
    dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'],
    weekHeader: 'Sm',
    dateFormat: 'dd/mm/yy',
    firstDay: 1,
    isRTL: false,
    showMonthAfterYear: false,
    yearSuffix: ''
};
$.datepicker.setDefaults($.datepicker.regional['es']);
$(function () {
    $(".DataPicker").datepicker({
        dateFormat: "yy/mm/dd",
        yearRange: '1950:2000',
        changeMonth: true,
        changeYear: true


    });
});
//$(function () {
//    var dateFormat = "mm/dd/yy",
//      from = $(".dateInicio")
//        .datepicker({
//            defaultDate: "+1w",
//            changeMonth: true,
//            numberOfMonths: 3
//        })
//        .on("change", function () {
//            to.datepicker("option", "minDate", getDate(this));
//        }),
//      to = $(".dateFinal").datepicker({
//          defaultDate: "+1w",
//          changeMonth: true,
//          numberOfMonths: 3
//      })
//      .on("change", function () {
//          from.datepicker("option", "maxDate", getDate(this));
//      });

//    function getDate(element) {
//        var date;
//        try {
//            date = $.datepicker.parseDate(dateFormat, element.value);
//        } catch (error) {
//            date = null;
//        }

//        return date;
//    }
//});