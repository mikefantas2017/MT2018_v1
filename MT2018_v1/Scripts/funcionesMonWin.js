/*
Mon Tool v1.
Enero - Febrero, 2018.
Funciones para la vista parcial "MonWindow".
*/

// jQuery select2.
$("#selectStruct").select2({
    placeholder: 'Seleccione un modelo',
    minimumInputLength: 0,
    allowClear: true,
    ajax: {
        // url: $(this).data('request-url'),
        url: 'BuscaModelo',
        dataType: 'json',
        type: 'GET',
        delay: 250,
        data: function (params) {
            // console.log($(this).data('request-url'));
            // console.log(this.url);
            return {
                q: params.term,
                page: params.page
            }
        },
        processResults: function (data) {
            return {
                results: $.map(data, function (item) {
                    return {
                        id: item.id,
                        text: item.text,
                        data: item
                    }
                })
            };
        },
        cache: true,
        width: 'resolve'
    },
    width: '75%'
});


// $("#panelWin").append();

/*var canv = $("#g1")[0];
var cntx = canv.getContext("2d");
cntx.font = "30px Arial";
cntx.fillStyle = "red";
cntx.textAlign = "center";
cntx.fillText("Ningún modelo cargado.", canv.width/2, canv.heigth/2);
alert("width: " + canv.width + "; height: " + canv.height);*/

/*var gl = getWebGLContext(canv);
if(!gl){
    console.log('WebGL no soportado.');
    return;
}*/