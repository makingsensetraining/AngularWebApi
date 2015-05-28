'use strict';

angular.module('hiperionApp',
    ['ngRoute', 'ngTable', 'ngTableExport', 'LocalStorageModule', 'ngDialog', 'ngLoadingSpinner', 'angularjs-dropdown-multiselect'])
    .config(function ($routeProvider, $httpProvider) {
        $routeProvider
            .when('/', {
                templateUrl: 'App/views/users.html',
                controller: 'UserCtrl'
            })
            .when('/users', {
                templateUrl: 'App/views/users.html',
                controller: 'UserCtrl'
            })
            .when('/roles', {
                templateUrl: 'App/views/roles.html',
                controller: 'RoleCtrl'
            })
            .when('/countries', {
                templateUrl: 'App/views/countries.html',
                controller: 'CountryCtrl'
            })
            .when('/login', {
                templateUrl: 'App/views/login.html',
                controller: 'LoginCtrl'
            })
            .when('/about', {
                templateUrl: 'App/views/about.html',
                controller: 'AboutCtrl'
            })
            .otherwise({
                redirectTo: '/users'
            });
    });

angular.module('hiperionApp').config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorProvider');
});

angular.module('hiperionApp').run(['authService', function (authService) {
    authService.fillAuthData();
}]);