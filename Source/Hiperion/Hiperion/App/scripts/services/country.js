'use strict';

angular.module('hiperionApp')
    .service('countryService', function ($http) {        
        this.getRoles = function () {
            return $http.get('api/Country');            
        };
        
    });