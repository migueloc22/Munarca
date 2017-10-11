$(document).ready(function(){
    $('[data-toggle="tooltip"]').tooltip();   
});
$('#ContentPlaceHolder1_ContentPlaceHolder1_txtFechaNac').datepicker({
    formato: 'mm / dd / aaaa',
    startDate: '-3d'
});
