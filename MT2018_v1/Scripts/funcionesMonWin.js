/*
Mon Tool v1.
Enero - Febrero, 2018.
Funciones para la vista parcial "MonWindow".
*/

var pVw = $("#panelView")[0].clientWidth;
var pVh = $("#panelView")[0].clientHeight;

// jQuery select2.
$("#selectStruct").select2({
    placeholder: 'Seleccione un modelo',
    minimumInputLength: 0,
    allowClear: true,
    ajax: {
        url: 'BuscaModelo',
        dataType: 'json',
        type: 'GET',
        delay: 250,
        data: function (params) {
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

// Evento de selección de select2.
$("#selectStruct").on("select2:select", function (e) {
    // Cargar modelo.
    // Preparar el canvas del panel de visualización.
    $("#panelView").css("background", "white");
    $("#noLoadedModelMessage").replaceWith("" +
        "<canvas id = 'g1' width = '" + pVw + "' height = '" + pVh + "' style = 'background: #F2F2F2; border: 1px solid #D8D8D8'>" +
            "El navegador no soporta el elemento canvas...." +
        "</canvas>");
    // Desplegar la información general del modelo en el panel de información general.
    // Desplegar el modelo en el panel de visualización.
    displayModel();
    // Mostrar herramientas y opciones adicionales....
});

// Evento de deselección de select2.
$("#selectStruct").on("select2:unselect", function (e) {
    // Volver a mostrar mensaje de no carga.
    $("#panelView").css("background", "#868383");
    $("#g1").replaceWith("<table id ='noLoadedModelMessage' style='height: 100%; width: 100%'>" + 
                            "<tbody><tr><td class='text-center'>Ningún modelo cargado.</td>" +
                            "</tr></tbody></table>");
});

// Evento de ajuste de tamaño del panelView.
$(window).resize(function () {
    if ($("#g1").length == 1) {
        pVw = $("#panelView")[0].clientWidth;
        pVh = $("#panelView")[0].clientHeight;
    }
});
