'use strict';

angular.module('hiperionApp').controller('LoginCtrl', ['$scope', '$location', 'authService', function ($scope, $location, authService) {

    $scope.loginData = {
        userName: "",
        password: ""
    };

    $scope.message = "";

    $scope.login = function () {
        authService.login($scope.loginData).then(function (response) {
            $location.path('/users');
            $scope.isAuth = true;
        },
        function (err) {
            $scope.message = err.error_description;
            $scope.isAuth = false;
        });
    };

}]);