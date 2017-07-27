/* Setup Layout Part - Footer */
(function () {
    "use strict";
    angular.module("BebelBaby").controller('FooterController', ['$scope', function($scope) {
        $scope.$on('$includeContentLoaded', function() {
            Layout.initFooter(); // init footer
        });
    }]);
})();
