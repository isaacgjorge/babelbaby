(function () {
    "use strict";
    angular.module('BebelBaby').controller('AdicionarUsuarioController', 
    ['$rootScope', '$scope', 'usuarioService', 'toastr', '$state',
    function($rootScope, $scope, usuarioService, toastr, $state) {
          $scope.$on('$viewContentLoaded', function() {   
            // initialize core components
            App.initAjax();
            Layout.setSidebarMenuActiveLink('set', $('#sidebar_menu_link_adicionarUsuario')); // set profile link active in sidebar menu 
        });
        var self = this;
        self.usuario = {};

        self.cancelar = function(){
            $state.go('private.listaUsuarios');  
        };

        self.incluirUsuario = function(){
            //self.usuario.senha = self.usuario.Cpf;
            self.usuario.senha = self.usuario.Cpf;
            self.usuario.DtNascimento = self.usuario.DtNascimento.substr(3,2) + "-" + self.usuario.DtNascimento.substr(0,2) + "-" + self.usuario.DtNascimento.substr(6,4);

            usuarioService.inserirNovoUsuario(self.usuario) 
                .then(function(response) {
                    toastr.success( 'Usuario incluído com sucesso!','Inclusão de novo usuário.');
                    //$rootScope.$user.currentUser.usuario = self.usuario;
                    $state.go('private.listaUsuarios');  
                })
                .catch(function(fallback) {
                    toastr.error(fallback.data.Message,'Inclusão de novo usuário.');                    
                });
           
        };

       

    }]);
})();
