(function (module) {

    AccidenteTransitoController.$inject = ["$scope", "toastr", "AccidenteTransitoFactory"];

    function AccidenteTransitoController($scope, toastr, AccidenteTransitoFactory) {

        $scope.ListaAccidenteTransito = [];

        $scope.ResetAccidenteTransito = function () {
            $scope.AccidenteTransito = {
                IndicadorHabilitado: true,
                EstadoObjeto: EstadoObjeto.SinCambios
            };
        }

        $scope.Iniciar = function () {
            $scope.ResetAccidenteTransito();
            $scope.ObtenerAccidenteTransito();
        };

        $scope.AbrirModalAccidenteTransitoAgregar = function () {
            $scope.ResetAccidenteTransito();
            $scope.AccidenteTransito.EstadoObjeto = EstadoObjeto.Nuevo;
            Bootstrap.AbrirModal(Modal.AccidenteTransito);
        };

        $scope.AbrirModalAccidenteTransitoModificar = function (AccidenteTransito) {
            $scope.ResetAccidenteTransito();
            $scope.AccidenteTransito = AccidenteTransito;
            $scope.AccidenteTransito.EstadoObjeto = EstadoObjeto.Modificado;
            Bootstrap.AbrirModal(Modal.AccidenteTransito);
        };

        $scope.CerrarModalAccidenteTransito = function () {
            Bootstrap.CerrarModal(Modal.AccidenteTransito);
        };

        $scope.GuardarAccidenteTransito = function () {
            AccidenteTransitoFactory.GuardarAccidenteTransito($scope.AccidenteTransito).$promise
                .then(function (RespuestaApi) {
                    if (RespuestaApi.Estado) {
                        Bootstrap.CerrarModal(Modal.AccidenteTransito);
                        toastr.success(Mensaje.Correcto.Descripcion, Mensaje.Correcto.Titulo);
                        $scope.ObtenerAccidenteTransito();
                    } else {
                        Bootstrap.CerrarModal(Modal.AccidenteTransito);
                        toastr.error(RespuestaApi.Mensaje, Mensaje.Error.Titulo);
                    }
                }).catch(function (error) {
                    toastr.error(Mensaje.Error.Descripcion, Mensaje.Error.Titulo);
                });
        };

        $scope.ObtenerAccidenteTransito = function () {
            AccidenteTransitoFactory.ObtenerAccidenteTransito().$promise
                .then(function (RespuestaApi) {
                    if (RespuestaApi.Estado) {
                        $scope.ListaAccidenteTransito = RespuestaApi.Datos;
                    } else {
                        toastr.error(RespuestaApi.Mensaje, Mensaje.Error.Titulo);
                    }
                }).catch(function (error) {
                    toastr.error(Mensaje.Error.Descripcion, Mensaje.Error.Titulo);
                });
        };
    }

    module.controller("AccidenteTransitoController", AccidenteTransitoController);

})(angular.module("uptAdministracion"));

var Modal = {
    AccidenteTransito: "#ModalAccidenteTransito"
}

