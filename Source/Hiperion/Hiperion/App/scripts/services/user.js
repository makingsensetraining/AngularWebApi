'use strict';

angular.module('hiperionApp')
    .service('userService', function($http) {
        this.getTime = function() {
            return new Date().toUTCString();
        };
        this.getUsers = function() {
            return $http.get('/api/User');
        };
        this.addUser = function(user) {
            return $http.post('/api/User',
                JSON.stringify(user),
                { headers: { 'Content-Type': 'application/json' } });
        };
    });