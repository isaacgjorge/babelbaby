
/* Setup Layout Part - Sidebar */
(function () {
    "use strict";
    angular.module("EasyCare").controller('SidebarController', ['$scope', function($scope) {
        $scope.$on('$includeContentLoaded', function() {
            Layout.initSidebar(); // init sidebar
        });
    }]);
})();