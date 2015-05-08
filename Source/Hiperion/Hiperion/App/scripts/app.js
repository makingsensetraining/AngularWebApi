'use strict';

angular.module('hiperionApp', ['ngRoute','ngTable', 'ngTableExport', 'ngDialog'])
.config(function ($routeProvider) {
    $routeProvider
         .when('/', {templateUrl: 'App/views/home.html',controller: 'HomeCtrl'})
        .when('/users', { templateUrl: 'App/views/users.html', controller: 'UserCtrl' })
        .when('/about', { templateUrl: 'App/views/about.html', controller: 'AboutCtrl' })
        .otherwise({ redirectTo: '/home' });

})
.filter('userRange', function () {
    return function (input, min, max) {
        min = parseInt(min); 
        max = parseInt(max);
        for (var i = min; i < max; i++)
            input.push(i);
        return input;
    };
});