
/* Setup Layout Part - Sidebar */
(function () {
    "use strict";
    angular.module("BebelBaby").controller('SidebarController', ['$scope', function($scope) {
        $scope.$on('$includeContentLoaded', function() {
            Layout.initSidebar(); // init sidebar
        });
    }]);
})();