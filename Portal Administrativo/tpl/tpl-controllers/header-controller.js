/* Setup Layout Part - Header */
(function () {
    "use strict";
    angular.module("BebelBaby").controller('HeaderController', ['$scope', '$rootScope', 
    function($scope, $rootScope) {
        $scope.$on('$includeContentLoaded', function() {
            $scope.usuario = $rootScope.$user;
            $scope.usuarioAvatar = $rootScope.$user.currentUser.avatarImage;
            Layout.initHeader(); // init header
        });
    }]);
})();
