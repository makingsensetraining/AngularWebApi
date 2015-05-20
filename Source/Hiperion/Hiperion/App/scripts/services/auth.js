'use strict';

angular.module('hiperionApp')
    .service('authService', ['$http', '$q', 'localStorageService', function ($http, $q, localStorageService) {
        var authentication = {
            isAuth: false,
            userName: ""
        };

        this.saveRegistration = function (registration) {
            this.logOut();
            //return $http.post('/api/account/register', registration).then(function (response) {
            //    return response;
            //});
        };

        this.login = function (loginData) {
            var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;
            var deferred = $q.defer();
            $http.post('/token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {
                localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName });

                authentication.isAuth = true;
                authentication.userName = loginData.userName;

                deferred.resolve(response);

            }).error(function (err, status) {
                this.logOut();
                deferred.reject(err);
            });
            return deferred.promise;
        };

        this.logOut = function () {
            localStorageService.remove('authorizationData');

            authentication.isAuth = false;
            authentication.userName = "";
        };

        this.fillAuthData = function () {
            var authData = localStorageService.get('authorizationData');
            if (authData) {
                authentication.isAuth = true;
                authentication.userName = authData.userName;
            }
        };
    }]);