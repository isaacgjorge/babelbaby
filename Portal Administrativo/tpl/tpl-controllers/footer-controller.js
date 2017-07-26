/* Setup Layout Part - Footer */
(function () {
    "use strict";
    angular.module("EasyCare").controller('FooterController', ['$scope', function($scope) {
        $scope.$on('$includeContentLoaded', function() {
            Layout.initFooter(); // init footer
        });
    }]);
})();
