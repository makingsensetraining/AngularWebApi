'use strict';

angular.module('hiperionApp')
    .service('roleService', function($http) {
        this.getRoles = function() {
            return $http.get('api/Role');
        };
    });