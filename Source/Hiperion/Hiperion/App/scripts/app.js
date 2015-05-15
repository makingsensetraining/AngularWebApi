'use strict';

angular.module('hiperionApp', ['ngRoute', 'ngTable', 'ngTableExport', 'ngDialog', 'ngLoadingSpinner'])
    .config(function($routeProvider) {
        $routeProvider
            .when('/', { templateUrl: 'App/views/users.html', controller: 'UserCtrl' })
            .when('/users', { templateUrl: 'App/views/users.html', controller: 'UserCtrl' })
            .when('/roles', { templateUrl: 'App/views/roles.html', controller: 'RoleCtrl' })
            .when('/about', { templateUrl: 'App/views/about.html', controller: 'AboutCtrl' })
            .otherwise({ redirectTo: '/users' });

    });