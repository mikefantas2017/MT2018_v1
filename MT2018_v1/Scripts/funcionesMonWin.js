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

// Evento de selección de select2.
$("#selectStruct").on("select2:select", function (e) {
    alert("Ha seleccionado el modelo " + $(this).select2("data")[0].text);
    // Cargar modelo.
    // Preparar el canvas del panel de visualización.
    $("#panelView").css("background", "white");
    $("#noLoadedModelMessage").replaceWith("" +
        "<canvas id = 'g1'  style = 'width: 100%; height: 100%; background: #F2F2F2; border: 1px solid #D8D8D8'>" +
            "El navegador no soporta el elemento canvas." +
        "</canvas>");
    // Desplegar la información general del modelo en el panel de información general.
    // Desplegar el modelo en el panel de visualización.
    // displayModel();
    displayModel();
    // Mostrar herramientas y opciones adicionales....
});

// Evento de deselección de select2.
$("#selectStruct").on("select2:unselect", function (e) {
    // Volver a mostrar mensaje de no carga.
    $("#panelView").css("background", "#868383");
    $("#g1").replaceWith("<div id='noLoadedModelMessage' style='height: 100%'>Ningún modelo cargado.</div>");
});
