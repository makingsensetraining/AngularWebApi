'use strict';

angular.module('hiperionApp')
    .controller('UserCtrl', function ($scope, $filter, ngTableParams, $sce, ngDialog) {
        // TODO: Replace this with the data from the web Api.
        var data = [{ name: 'Nick', lastName: 'Rimando', age: 26 },
                        { name: 'William', lastName: 'Yarbrough', age: 26 },
                        { name: 'DeAndre', lastName: 'Yedlin', age: 60 },
                        { name: 'Omar', lastName: 'Gonzalez', age: 28 },
                        { name: 'Matt', lastName: 'Besler', age: 26 },
                        { name: 'Mix', lastName: 'Diskerud', age: 52 },
                        { name: 'Brad', lastName: 'Evans', age: 29 },
                        { name: 'Brek', lastName: 'Shea', age: 30 },
                        { name: 'Greg', lastName: 'Garza', age: 36 },
                        { name: 'Lee', lastName: 'Nguyen', age: 56 },
                        { name: 'Michael', lastName: 'Bradley', age: 40 },
                        { name: 'Gyasi', lastName: 'Zardes', age: 56 }];

        $scope.tableParams = new ngTableParams({
            page: 1,
            count: 5,
            sorting: { name: 'asc' },
            filter: { name: '', lastName: '' }
        }, {
            total: data.length,
            getData: function ($defer, params) {
                var orderedData = params.filter() ?
                                   $filter('filter')(data, params.filter()) :
                                   data;

                orderedData = params.sorting() ?
                                    $filter('orderBy')(orderedData, params.orderBy()) :
                                    orderedData;

                $defer.resolve(orderedData.slice((params.page() - 1) * params.count(), params.page() * params.count()));
            }
        });

        $scope.users = [];
        $scope.name = "";
        $scope.lastName = "";
        $scope.age = "";

        $scope.addNewUser = function () {
            ngDialog.openConfirm({
                template: 'App/views/userDialog.html',
                className: 'ngdialog-theme-default',
                preCloseCallback: 'preCloseCallbackOnScope',
                scope: $scope
            }).then(function (user) {
                data.push(user);
            }, function (reason) {
            });
        };
    });
  
