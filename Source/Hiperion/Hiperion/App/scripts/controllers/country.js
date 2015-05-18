'use strict';

angular.module('hiperionApp')
    .controller('CountryCtrl', function ($scope, $http, $filter, ngTableParams, $sce, ngDialog) {    
        var data = [];
        $scope.id = '';
        $scope.name = '';
        $scope.userToDeleteId = 0;

        loadCounties();

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

            $http.post('/api/Country',
                    JSON.stringify(countryDto),
                    { headers: { 'Content-Type': 'application/json' } })
                .success(function() {
                    loadCounties();
                });
        };

        $scope.removeCountry = function(country) {
            $scope.userToDeleteId = country.id;
            openConfirmDeleteDialog();
        };

        function loadCounties() {
            //$http.get('api/Country').
            //    success(function(result, status, headers, config) {
            //        data = result;
            //        $scope.tableParams.reload();
            //    })
            //    .error(function(result, status, headers, config) {});
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
            $scope.userToDeleteId = 0;
        }

        function deleteCountry() {
            //$http.delete('/api/Country?id=' + $scope.userToDeleteId)
            //    .success(function() {
            //        loadCountries();
            //        clearData();
            //    });
        }

    });