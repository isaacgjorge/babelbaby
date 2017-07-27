(function(){
    "use strict";

    angular.module('BebelBaby').service('miboxService', 
    ['$http', '$rootScope', '$q', '$window',
    function($http, $rootScope, $q, $window) {
        var LoginMiBox = function(callback){
            $q(function(resolve) {
                
                var xhr = new XMLHttpRequest();
                //xhr.onload = reqListener;
                xhr.open("POST", 'http://ecm-homol.montreal.com.br/MIBox.WebAPI/oauth/token', true);

                xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
                //xhr.responseType = 'blob';
                
                xhr.onload = function(e) {
                    var response = JSON.parse(xhr.response);
                    $rootScope.miBoxToken =  response.token_type + ' ' + response.access_token;
                    $window.sessionStorage.setItem('miBoxToken', $rootScope.miBoxToken );
                    callback();

                }        

                xhr.send("grant_type=password&username=BebelBabyAdmin@montreal.com.br&password=Montreal@01");

            }); 

        };

        var DownlodImageMiBox = function(idImagem){

            return $q(function(resolve) {
                
                var xhr = new XMLHttpRequest();
                //xhr.onload = reqListener;
                xhr.open("get", 'http://ecm-homol.montreal.com.br/MIBox.WebAPI/api/Document/' + idImagem + '/Content', true);

                xhr.setRequestHeader('Authorization', $rootScope.miBoxToken);
                xhr.responseType = 'blob';
                
                xhr.onload = function(e) {
                    var windowUrl = window.URL;
                    var donwloadedUrl = windowUrl.createObjectURL(xhr.response);  
                    resolve(donwloadedUrl);
                }        

                xhr.send();

            });        

        };

        return {
            LoginMiBox: LoginMiBox,
            DownlodImageMiBox: DownlodImageMiBox
        }
      

    }]);
})();