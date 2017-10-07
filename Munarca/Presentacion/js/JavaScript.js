$(document).ready(function(){
    $('[data-toggle="tooltip"]').tooltip();   
});
$(window).load(function () {

    $(function () {
        $('#ContentPlaceHolder1_ContentPlaceHolder1_FileUpload1').change(function (e) {
            addImage(e);
        });

        function addImage(e) {
            var file = e.target.files[0],
            imageType = /image.*/;

            if (!file.type.match(imageType))
                return;

            var reader = new FileReader();
            reader.onload = fileOnload;
            reader.readAsDataURL(file);
        }

        function fileOnload(e) {
            var result = e.target.result;
            $('#imgSalida').attr("src", result);
        }
    });
});