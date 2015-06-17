'use strict';

angular.module('hiperionApp').controller('LoginCtrl', ['$scope', '$location', 'authService', function ($scope, $location, authService) {

    $scope.loginData = {
        userName: "",
        password: "",
        isAuth: false
    };

    $scope.message = "";

    $scope.login = function () {
        authService.login($scope.loginData).then(function (response) {
            $location.path('/users');
            $scope.loginData.isAuth = true;
        },
        function (err) {
            $scope.message = err.error_description;
            $scope.loginData.isAuth = false;
        });
    };

}]);