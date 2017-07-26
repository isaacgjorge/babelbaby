(function () {
    "use strict";

    /* Setup general page controller */
    angular.module('EasyCare').controller('GeneralPageController', 
    ['$rootScope', '$scope', 'globalSettings', function($rootScope, $scope, globalSettings) {
        $scope.$on('$viewContentLoaded', function() {   
            // initialize core components
            App.initAjax();

            // set default layout mode
            globalSettings.layout.pageContentWhite = true;
            globalSettings.layout.pageBodySolid = false;
            globalSettings.layout.pageSidebarClosed = false;
        });
    }]);
})();




