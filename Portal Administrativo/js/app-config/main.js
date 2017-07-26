Date.prototype.addDays = function(days) {
    this.setDate(this.getDate() + parseInt(days));
    return this;
};

(function () {
    "use strict";
    var EasyCare = angular.module("EasyCare", [
        "angulardatepicker",
        "ui.router", 
        "ui.bootstrap", 
        "oc.lazyLoad",  
        "ngSanitize",
        "ngStorage",
        "LocalStorageModule",
        "toastr",
        "chart.js",
        "ui.utils.masks"
        
    ]); 

    /* Configure ocLazyLoader(refer: https://github.com/ocombe/ocLazyLoad) */
    EasyCare.config(['$ocLazyLoadProvider', function($ocLazyLoadProvider) {
        $ocLazyLoadProvider.config({
            // global configs go here
        });
    }]);

    EasyCare.config(['toastrConfig', function(toastrConfig){
        angular.extend(toastrConfig, {
            autoDismiss: false,
            position: 'toast-top-right',
            timeout: '5000',
            extendedTimeout: '1000',
            html: true,
            closeButton: true,
            tapToDismiss: true,
            progressBar: true,
            closeHtml: '<button>&times;</button>',
            newestOnTop: true,
            maxOpened: 0,
            preventDuplicates: false,
            preventOpenDuplicates: true
        });
    }]);

    EasyCare.config(['$controllerProvider', function($controllerProvider) {
    // this option might be handy for migrating old apps, but please don't use it
    // in new ones!
    $controllerProvider.allowGlobals();
    }]);

    /* Setup global settings */
    EasyCare.factory('globalSettings', ['$rootScope', function($rootScope) {
        // supported languages
        var settings = {
            layout: {
                pageSidebarClosed: false, // sidebar menu state
                pageContentWhite: true, // set page content layout
                pageBodySolid: false, // solid body color state
                pageAutoScrollOnLoad: 1000 // auto scroll to top on page load
            },
            assetsPath: 'assets',
            globalPath: 'assets/global',
            layoutPath: 'assets/layouts/layout4',
        };

        $rootScope.settings = settings;

        return settings;
    }]);

    /* Setup App Main Controller */
    EasyCare.controller('AppController', ['$scope', '$rootScope', function($scope, $rootScope) {
        $scope.$on('$viewContentLoaded', function() {
            App.initComponents(); // init core components
            //Layout.init(); //  Init entire layout(header, footer, sidebar, etc) on page load if the partials included in server side instead of loading with ng-include directive 
        });
    }]);
})();