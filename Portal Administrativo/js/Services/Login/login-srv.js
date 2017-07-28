(function(){
    "use strict";

    angular.module('BebelBaby').service('loginService', 
    ['$http', '$localStorage', 'localStorageService', '$rootScope', '$window',
    function($http, $localStorage, localStorageService, $rootScope, $window ) {
        var service = {}; 
        service.Login = Login;
        service.Logout = Logout;
 
        return service;
 
        function Login(username, password) {
           var promise = $http.post($rootScope.baseUrl + 'UserController/signin', { "Login": username, "Senha": password })
                .success(function (response) {
                    
                    // login successful if there's a token in the response
                    if (response.token) {
                        //$window.sessionStorage.setItem('currentUser', response.usuario)
                        $window.sessionStorage.setItem('currentUser', JSON.stringify(response.usuario));
                        // store username and token in local storage to keep user logged in between page refreshes
                            //$localStorage.clearAll();
                            // $rootScope.$user = $localStorage.$default({
                            //     currentUser: { usuario: response.usuario, token: response.token }
                            // });
                        $rootScope.$user = {};
                        $rootScope.$user.currentUser = {};
                        $rootScope.$user.currentUser.usuario = response.usuario;

                        // add jwt token to auth header for all requests made by the $http service
                        $window.sessionStorage.setItem('defaultToken', 'Bearer ' + response.token);
                        $rootScope.defaultToken = 'Bearer ' + response.token;
                        //$http.defaults.headers.common.Authorization = $rootScope.defaultToken;
 
                        // execute callback with true to indicate successful login
                       return true;
                    } else {
                        // execute callback with false to indicate failed login
                        return false;
                    }
                }).error(function(response){
                   return response;
                });

                return promise;
        }
 
        function Logout(click,callback) {
            // remove user from local storage and clear http auth header
            if(click){
                delete $rootScope.$user;
                $http.defaults.headers.common.Authorization = '';
                
                callback();
            }
        }

    }]);
})();