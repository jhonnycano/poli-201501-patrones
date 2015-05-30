$.datepicker.setDefaults($.datepicker.regional["es"]);

function mostrarLista(origen, destino) {
    $(destino).empty();
    for (var ind in origen) {
        var itm = origen[ind];
        $('<li />', { html: itm.Nombre }).appendTo(destino);
    }
}
function capturarVotos() {
    var arr = $("input.chk-votar:checked").map(function () {
        return $(this).data("objeto");
    }).get();
    $("#hidVotos").val(JSON.stringify(arr));
}

$(function () {
    $(".fch").datepicker({ "dateFormat": "yy-mm-dd" });
    $(".btn").button();
    
    $("input.chk-votar").on('click', function () {
        capturarVotos();
    });
    $("#btnVotar").click(function () {
        var arr = JSON.parse($("#hidVotos").val());
        arr = JSON.stringify(arr);

        $(this).attr("href", $(this).attr("href") + "?v=" + arr);
    });
    $("#btnQuitarVotos").click(function () {
        var arr = JSON.parse($("#hidVotos").val());
        arr = JSON.stringify(arr);

        $(this).attr("href", $(this).attr("href") + "?d=true&v=" + arr);
    });
});
