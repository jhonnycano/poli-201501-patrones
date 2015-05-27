function mostrarLista(origen, destino) {
    $(destino).empty();
    for (var ind in origen) {
        var itm = origen[ind];
        $('<li />', { html: itm.Nombre }).appendTo(destino);
    }
}

$(function () {
});