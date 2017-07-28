/* Init global settings and run the app */
(function () {
    "use strict";
    angular.module("BebelBaby")
    .run(["$rootScope", "$state", '$http', '$stateParams', '$window',
    function($rootScope, $state,$http, $location, $window) {
        $rootScope.$state = $state; // state to be accessed from view
        $rootScope.baseUrl = "http://localhost:55698/api/";
         // keep user logged in after page refresh
         if ($rootScope.$user) {
             $http.defaults.headers.common.Authorization = 'Bearer ' + $rootScope.$user.currentUser.token;
         }    

        // redirect to login page if not logged in and trying to access a restricted page
        $rootScope.$on('$stateChangeStart', function ( e, toState, toParams, fromState, fromParams) {
            var currentUser = JSON.parse($window.sessionStorage.getItem("currentUser"));            

            if(currentUser){
                if(!$rootScope.$user){
                    $rootScope.$user = {};
                    $rootScope.$user.currentUser = {};
                    $rootScope.$user.currentUser.usuario = currentUser;

                    $rootScope.$user.currentUser.avatarImage  = $window.sessionStorage.getItem("avatarimageUser");
                    $http.defaults.headers.common.Authorization = $window.sessionStorage.getItem("defaultToken");
                    $rootScope.miBoxToken = $window.sessionStorage.getItem("miBoxToken");
                }
            };

            if(!(toState.name == "public.login")){
                if(toState.name.split('.')[0] == "private" && !currentUser){
                   e.preventDefault();
                   $state.go("public.login");
                };
            };   

             
        });

    }]);
})();




 