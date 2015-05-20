'use strict';

angular.module('hiperionApp')
    .service('countryService', function($http) {
        this.getCountries = function() {
            return $http.get('api/Country');
        };
        this.saveCountry = function(country) {
            return $http.post('/api/Country', JSON.stringify(country), { headers: { 'Content-Type': 'application/json' } });
        };
        this.removeCountry = function(countryId) {
            return $http.delete('/api/Country?id=' + countryId);
        };
    });