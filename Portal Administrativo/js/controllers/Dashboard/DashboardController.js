(function () {
    "use strict";
    angular.module('BebelBaby').controller('DashboardController',
    ['$rootScope', '$scope', '$http', '$timeout', 'globalSettings', '$state', 'toastr',
    function($rootScope, $scope, $http, $timeout,globalSettings, $state, toastr) {
        $scope.$on('$viewContentLoaded', function() {   
            // initialize core components
            App.initAjax();
            Layout.setSidebarMenuActiveLink('set', $('#sidebar_menu_link_listaUsuarios')); // set profile link active in sidebar menu 
            // toastr.success('Hello world!', 'Toastr fun!');
            // toastr.info('Hello world!', 'Toastr fun!');
            // toastr.warning('Hello world!', 'Toastr fun!');
            // toastr.error('Hello world!', 'Toastr fun!');
        });
        var a = $state;
        // set sidebar closed and body solid layout mode
        globalSettings.layout.pageContentWhite = true;
        globalSettings.layout.pageBodySolid = false;
        globalSettings.layout.pageSidebarClosed = false;
    }]);
})();