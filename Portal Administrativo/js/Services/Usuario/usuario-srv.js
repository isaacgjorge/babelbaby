(function(){
    "use strict";

    angular.module('BebelBaby').service('usuarioService', 
    ['$http', '$rootScope',
    function($http, $rootScope) {
         var retornarUsuarioAtual = function(){
           var promise = $http.get($rootScope.baseUrl + 'usuario/retornarUsuarioAtual')
                .success(function (response) {
                    return response;                  
                });
                return promise;
        };


        var alterarSenha = function(senhaAtual, novaSenha){
           var promise = $http.post($rootScope.baseUrl + 'usuario/alterarSenha', {SenhaAtual: senhaAtual, NovaSenha: novaSenha})
                .success(function (response) {
                    return response;                  
                });
                return promise;
        };

        var alterarDadosCadastrais = function(UsuarioAlteracao){
            var promise = $http.post($rootScope.baseUrl + 'usuario/alterarUsuario', UsuarioAlteracao)
                .success(function (response) {
                    return response;                  
                });
                return promise;
        } 

        var inserirNovoUsuario = function(Usuario){
             var promise = $http.post($rootScope.baseUrl + 'usuario/signup/perfil/1', Usuario)
                .success(function (response) {
                    return response;                  
                });
                return promise;
        }
        
        var listarUsuario = function(){
             var promise = $http.get($rootScope.baseUrl + 'usuario/retornarUsuarios')
                .success(function (response) {
                    return response;                  
                });
                return promise;
        }
        

        return {
            alterarSenha: alterarSenha,
            alterarDadosCadastrais: alterarDadosCadastrais,
            retornarUsuarioAtual: retornarUsuarioAtual,
            inserirNovoUsuario: inserirNovoUsuario,
            listarUsuario: listarUsuario
        }

    }]);
})();