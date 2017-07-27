(function () {
    "use strict";
    angular.module('BebelBaby').controller('UsuarioContaController', 
    ['$rootScope', '$scope', 'usuarioService', 'toastr',
    function($rootScope, $scope, usuarioService, toastr) {
          $scope.$on('$viewContentLoaded', function() {   
            // initialize core components
            App.initAjax();
            Layout.setSidebarMenuActiveLink('set', $('#sidebar_menu_configuracoes_de_conta')); // set profile link active in sidebar menu 
        });
        var self = this;
        self.senhasDiferentes =  false;
        self.usuario = {};
        self.avatarImage = $rootScope.$user.currentUser.avatarImage;
        usuarioService.retornarUsuarioAtual().then(function(response) {
            self.usuario = response.data.usuario;
        });

        //var usuarioOriginal = self.usuario;

        self.cancelarMudancas = function(){
            usuarioService.retornarUsuarioAtual().then(function(response) {
                self.usuario = response.data.usuario;               
            });          
        };

        self.salvarMudancas = function(){
            usuarioService.alterarDadosCadastrais(self.usuario) 
                .then(function(response) {
                    toastr.success( 'Informações alteradas com sucesso!','Alteração de dados cadastrais.');
                    $rootScope.$user.currentUser.usuario = self.usuario;
                })
                .catch(function(fallback) {
                    toastr.error(fallback.data.Message,'Alteração de dados cadastrais.');                    
                });
           
        };

        self.alterarSenha = function(senhaAtual, novaSenha, novaSenhaVerificacao){
            self.senhasDiferentes = false;
            if(!senhaAtual){
                toastr.info('Informe a senha atual.','Alteração de senha');
                return;
            };

            if(novaSenha !== novaSenhaVerificacao ){
                self.senhasDiferentes = true;
                toastr.error('Nova senha informada não é igual a sua repetição.','Alteração de senha');
                return;
            };

            if(!novaSenha || !novaSenhaVerificacao ){
                self.senhasDiferentes = true;
                toastr.error('Senha não pode ser vazia.','Alteração de senha');
                return;
            };

            usuarioService.alterarSenha(senhaAtual,novaSenha)
                .then(function(response) {
                    toastr.success( 'Senha Alterada com sucesso!','Alteração de senha.');
                })
                .catch(function(fallback) {
                    if(fallback.data.Message === "Senha não é válida."){
                        toastr.error('Senha atual informada não é válida.','Alteração de senha');
                    }else{
                        toastr.error(fallback.data.Message,'Alteração de senha.');
                    }
                    
                });
        };

    }]);
})();
