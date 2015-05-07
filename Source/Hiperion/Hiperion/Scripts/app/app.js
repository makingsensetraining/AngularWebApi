'use strict';

angular.module('hiperionApp', ['ngTable', 'ngTableExport', 'ngDialog'])
.filter('userRange', function () {
    return function (input, min, max) {
        min = parseInt(min); //Make string input int
        max = parseInt(max);
        for (var i = min; i < max; i++)
            input.push(i);
        return input;
    };
});

