'use strict';

angular.module('hiperionApp')
    .service('userService', function() {
        this.getTime = function() {
            return new Date().toUTCString();
        };
    });