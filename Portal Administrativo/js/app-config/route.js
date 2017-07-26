(function () {
    "use strict";

    angular.module("EasyCare")
    .config(['$stateProvider', '$urlRouterProvider','$locationProvider', function($stateProvider, $urlRouterProvider,$locationProvider) {
        // Redirect any unmatched url
        //$urlRouterProvider.otherwise("/dashboard");  
        
        $stateProvider
        .state('public', {
            abstract: true,
            views: { 
                    'main@': {template: "<ui-view/>"}
                }        
            })
            // Login
            .state("public.login", {
                url: "/login",
                templateUrl: "views/mainPages/login.html",
                controller: "LoginController as loginCtrl",
                resolve:{
                       deps: ['$ocLazyLoad', function($ocLazyLoad) {
                        return $ocLazyLoad.load([{
                            name: 'MCare',
                            files: [
                                //controller
                                'js/Controllers/Login/login-ctrl.js',
                                //service
                                'js/Services/Login/login-srv.js',
                                'js/Services/MI-Box/MI-Box-srv.js',
                            ] 
                        }]);
                    }] 
                }
            })
            .state('private', {                 
                abstract: true,    
                views: { 
                    'main@': {templateUrl: "views/mainPages/adminContainer.html"}
                }
            })
            // Lista Usuarios
            .state('private.listaUsuarios', {
                url: "/listaUsuarios",
                templateUrl: "views/usuarios/listaUsuarios.html",            
                data: {pageTitle: 'MCare Lista de Usuarios'},
                controller: "ListaUsuariosController as ListaUsuariosCtrl",  
                resolve: {
                    deps: ['$ocLazyLoad', function($ocLazyLoad) {
                        return $ocLazyLoad.load({
                            name: 'MCare',
                            files: [
                                'assets/global/plugins/morris/morris.css',                            
                                'assets/global/plugins/morris/morris.min.js',
                                'assets/global/plugins/morris/raphael-min.js',                            
                                'assets/global/plugins/jquery.sparkline.min.js',
                                'assets/pages/scripts/dashboard.min.js',
                                'js/Controllers/usuario/ListaUsuario-ctrl.js',
                                'js/Services/Usuario/usuario-srv.js',
                                'tpl/tpl-controllers/footer-controller.js',
                                'tpl/tpl-controllers/header-controller.js',
                                'tpl/tpl-controllers/page-head-controller.js',
                                'tpl/tpl-controllers/sidebar-controller.js',
                                'js/Services/UsuarioDevice/usuarioDevice-srv.js'
                            ] 
                        });
                    }]
                }
            })
            // usuario Configurações
            .state('private.adicionarUsuario', {
                url: "/adicionarUsuario",
                templateUrl: "views/usuarios/adicionarUsuario.html",            
                data: {
                    pageTitle: 'MCare Adicionar Usuario'},
                controller: "AdicionarUsuarioController as AdicionarUsuarioCtrl",  
                resolve: {
                    deps: ['$ocLazyLoad', function($ocLazyLoad) {
                        return $ocLazyLoad.load({
                            name: 'MCare',
                            insertBefore: '#ng_load_plugins_before',
                            files: [
                                'assets/pages/css/profile.min.css',
                                'assets/global/plugins/bootstrap-fileinput/bootstrap-fileinput.js',
                                'assets/global/plugins/jquery.sparkline.min.js',
                                'style/html-datepicker.css',
                                'js/Controllers/usuario/AdicionarUsuario-ctrl.js',
                                'js/Services/usuario/usuario-srv.js'
                            ] 
                        });
                    }]
                }
            })
            
            // Otherwise
            .state('private.otherwise', {
                url: '*path',
                templateUrl: 'views/404.html',
                data: {pageTitle: 'Dashboard'},
                  resolve: {
                    deps: ['$ocLazyLoad', function($ocLazyLoad) {
                        return $ocLazyLoad.load({
                            name: 'MCare',
                            insertBefore: '#ng_load_plugins_before', // load the above css files before a LINK element with this ID. Dynamic CSS files must be loaded between core and theme css files
                            files: [
                                'assets/global/plugins/font-awesome/css/font-awesome.min.css',
                                'assets/global/plugins/simple-line-icons/simple-line-icons.min.css',
                                'assets/global/plugins/bootstrap/css/bootstrap.min.css',
                                'assets/global/plugins/uniform/css/uniform.default.css',
                                'assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css',
                                'assets/global/css/components.min.css',
                                'assets/global/css/plugins.min.css',
                                'assets/pages/css/error.min.css'
                            ] 
                        });
                    }]
                }
            });  
    }]);

})();

   
