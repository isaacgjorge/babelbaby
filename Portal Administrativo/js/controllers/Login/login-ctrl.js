(function () {
    "use strict";

    /* Setup general page controller */
    angular.module('BebelBaby').controller('LoginController', ['loginService', '$state', 'miboxService', '$rootScope', '$http', '$sce', '$window',
    function(loginService, $state, miboxService, $rootScope, $http, $sce, $window) {
        var vm = this;
 
        vm.login = login;
        vm.logout = logout;
        vm.divError = false;
        initController();
 
        function initController() {
            // reset login status
            loginService.Logout();
        };
 
        function login() {
            vm.loading = true;

            if(!vm.usuario || !vm.senha ){
                vm.divError = true;
                vm.messageError = "Coloque corretamente seu email e senha."
                return false;
            }

            loginService.Login(vm.usuario, vm.senha).then(function (result) {
                if (result.data.token) {                               
                    $http.defaults.headers.common.Authorization = $rootScope.defaultToken;  
                    $state.go('private.listaUsuarios');                    
                } 
            }).catch(function(response) {
                vm.divError = true;
                vm.messageError = response.data.Message;
                
            });
        };

        function logout(click) {
            $rootScope.miBoxToken = '';
            $http.defaults.headers.common.Authorization = '';
            $window.sessionStorage.clear();
            loginService.Logout(click,function(){
                $state.go('public.login');
            });
        };

    }]);
})();


