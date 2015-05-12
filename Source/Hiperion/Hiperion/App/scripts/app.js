'use strict';

angular.module('hiperionApp', ['ngRoute', 'ngTable', 'ngTableExport', 'ngDialog'])
    .config(function($routeProvider) {
        $routeProvider
            .when('/', { templateUrl: 'App/views/home.html', controller: 'HomeCtrl' })
            .when('/users', { templateUrl: 'App/views/users.html', controller: 'UserCtrl' })
            .when('/about', { templateUrl: 'App/views/about.html', controller: 'AboutCtrl' })
            .otherwise({ redirectTo: '/home' });

    });