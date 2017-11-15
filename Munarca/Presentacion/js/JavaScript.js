
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
