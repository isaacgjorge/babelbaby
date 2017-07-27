(function(){
    "use strict";

    angular.module('BebelBaby').service('usuarioDeviceService', 
    ['$http', '$rootScope',
    function($http, $rootScope) {
         var associarDeviceUsuario = function(usuarioDevice){
           var promise = $http.post($rootScope.baseUrl + 'dispositivo/associar', usuarioDevice)
                .success(function (response) {
                    return response;                  
                });
                return promise;
        };
        
        var deassociarTodosDevicesUsuario = function(idUsuario){
           var promise = $http.post($rootScope.baseUrl + 'dispositivo/desassociarTodos/idUsuario/' + idUsuario)
                .success(function (response) {
                    return response;                  
                });
                return promise;
        };

        return {
            associarDeviceUsuario: associarDeviceUsuario,
            deassociarTodosDevicesUsuario: deassociarTodosDevicesUsuario
        }

    }]);
})();