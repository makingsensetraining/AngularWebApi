'use strict';

angular.module('hiperionApp')
    .controller('CountryCtrl', function ($scope, $http, $filter, ngTableParams, $sce, ngDialog, countryService) {    
        var data = [];
        $scope.id = '';
        $scope.name = '';
        $scope.countryToDeleteId = 0;

        loadCountries();

        $scope.tableParams = new ngTableParams({
            page: 1,
            count: 100,
            sorting: { name: 'asc' },
            filter: { name: '' }
        }, {
            total: data.length,
            getData: function($defer, params) {
                var orderedData = params.filter() ?
                    $filter('filter')(data, params.filter()) :
                    data;

                orderedData = params.sorting() ?
                    $filter('orderBy')(orderedData, params.orderBy()) :
                    orderedData;

                $defer.resolve(orderedData.slice((params.page() - 1) * params.count(), params.page() * params.count()));
            }
        });

        $scope.addCountry = function() {
            clearData();
            openCountryDialog();
        };

        $scope.editCountry = function(country) {
            loadCountryInDialog(country);
            openCountryDialog();
        };

        $scope.saveCountry = function() {
            var countryDto = {
                id: $scope.id,
                name: $scope.name
            };

            countryService.saveCountry(countryDto)
                .success(function() {
                    loadCountries();
                });
        };

        $scope.removeCountry = function(country) {
            $scope.countryToDeleteId = country.id;
            openConfirmDeleteDialog();
        };

        function loadCountries() {
            countryService.getCountries().
                success(function(result, status, headers, config) {
                    data = result;
                    $scope.tableParams.reload();
                })
        }

        function loadCountryInDialog(country) {
            $scope.id = country.id;
            $scope.name = country.name;
        }

        function openCountryDialog() {
            ngDialog.openConfirm({
                template: 'App/views/templates/countryDialog.html',
                className: 'ngdialog-theme-default',
                preCloseCallback: 'preCloseCallbackOnScope',
                scope: $scope
            }).then(function(country) {
                loadCountryInDialog(country);
                $scope.saveCountry();
                clearData();
            });
        }

        function openConfirmDeleteDialog() {
            ngDialog.openConfirm({
                template: 'App/views/templates/deleteCountryDialog.html',
                className: 'ngdialog-theme-default',
                scope: $scope
            }).then(function(value) {
                deleteCountry();
            });
        }

        function clearData() {
            $scope.id = '';
            $scope.name = '';
            $scope.countryToDeleteId = 0;
        }

        function deleteCountry() {
            countryService.removeCountry($scope.countryToDeleteId).
                success(function() {
                    loadCountries();
                    clearData();
                });
        }

    });