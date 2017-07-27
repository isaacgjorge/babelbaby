(function () {
    "use strict";
    angular.module('BebelBaby').controller('ListaUsuariosController',
    ['$rootScope', '$scope', '$http', '$timeout', 'globalSettings', '$state', 'toastr', 'usuarioService', 'usuarioDeviceService',
    function($rootScope, $scope, $http, $timeout,globalSettings, $state, toastr, usuarioService, usuarioDeviceService) {
        $scope.$on('$viewContentLoaded', function() {   
            // initialize core components
            App.initAjax();
            Layout.setSidebarMenuActiveLink('set', $('#sidebar_menu_link_listaUsuarios')); // set profile link active in sidebar menu 
            // toastr.success('Hello world!', 'Toastr fun!');
            // toastr.info('Hello world!', 'Toastr fun!');
            // toastr.warning('Hello world!', 'Toastr fun!');
            // toastr.error('Hello world!', 'Toastr fun!');
        });
        
        // set sidebar closed and body solid layout mode
        globalSettings.layout.pageContentWhite = true;
        globalSettings.layout.pageBodySolid = false;
        globalSettings.layout.pageSidebarClosed = false;

        var self = this;
        self.usuarios = [];
        
        usuarioService.listarUsuario().then(function(response){
            self.usuarios = response.data.usuarios;
        });

        self.associarMedidorPadrao = function (usuario, idDevice, tipoMedidor) {
            var usuarioDevice = {
                IdUsuario: usuario.IdUsuario,
                IdDevice: idDevice
            }

            usuarioDeviceService.associarDeviceUsuario(usuarioDevice).then(function (response) {
                toastr.success( tipoMedidor + ' associado com sucesso!', 'Associação de dispositivo');
            });
        }

        self.desassociarMedidores = function (usuario) {
            usuarioDeviceService.deassociarTodosDevicesUsuario(usuario.IdUsuario).then(function (response) {
                   toastr.success( 'Dispositivos desassociados com sucesso', 'Desassociação de dispositivos');
                // body...
            });
        }




    }]);
})();