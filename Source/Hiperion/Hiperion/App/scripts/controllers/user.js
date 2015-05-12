'use strict';

angular.module('hiperionApp')
    .controller('UserCtrl', function($scope, $http, $filter, ngTableParams, $sce, ngDialog) {
        var data = [];

        $scope.tableParams = new ngTableParams({
            page: 1,
            count: 5,
            sorting: { name: 'asc' },
            filter: { name: '', lastName: '' }
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

        $http.get('/api/User').
            success(function (result, status, headers, config) {
                data = result;
                $scope.tableParams.reload();
            }).
            error(function (result, status, headers, config) {
                // called asynchronously if an error occurs
                // or server returns response with an error status.
            }
        );

        $scope.users = [];
        $scope.name = "";
        $scope.lastName = "";
        $scope.age = "";

        $scope.addNewUser = function() {
            ngDialog.openConfirm({
                template: 'App/views/userDialog.html',
                className: 'ngdialog-theme-default',
                preCloseCallback: 'preCloseCallbackOnScope',
                scope: $scope
            }).then(function(user) {
                data.push(user);
            }, function(reason) {
            });
        };

        $scope.removeUser = function(user) {
            data = _.filter(data, function(item) {
                return item.id != user.id;
            });
        };
    });