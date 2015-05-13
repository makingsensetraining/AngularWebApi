'use strict';

angular.module('hiperionApp')
       .directive('timeHeader', function () {
           return {
               restict:'E',
               templateUrl: 'App/views/templates/timeHeader.html'
           };
       });