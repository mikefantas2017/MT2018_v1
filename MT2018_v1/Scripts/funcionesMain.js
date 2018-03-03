/*
Mon Tool v1.
Febrero, 2018.
Funciones para la vista "Main".
*/

$(function () {
    $(".panel-info").hover(function () {
        $(this).css("cursor", "pointer");
        $(this).toggleClass("panel-info panel-primary");
    });
});