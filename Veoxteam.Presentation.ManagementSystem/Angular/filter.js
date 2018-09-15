(function (module) {

    function Fecha() {
        var formatoFecha = /\/Date\(([0-9]*)\)\//;
        return function (fechaJson) {
            var fecha = fechaJson.match(formatoFecha);
            if (fecha)
                return new Date(parseInt(fecha[1]));
            else
                return null;
        };
    };

    function NumeroElementosDetalle() {
        return function (listaElementos) {
            var listaDetalles = listaElementos.filter(function (item) {
                return item.IndicadorMostrar;
            });
            return listaDetalles.length;
        };
    };

    module.filter('Fecha', Fecha);
    module.filter('NumeroElementosDetalle', NumeroElementosDetalle);

})(angular.module('ayudame'));



