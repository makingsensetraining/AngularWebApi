'use strict';

angular.module('hiperionApp')
    .controller('UserCtrl', function($scope, $http, $filter, ngTableParams, $sce, ngDialog) {
        var data = [];
        $http.get('/api/User').
            success(function(result, status, headers, config) {
                data = result;
                $scope.tableParams.reload();
            }).
            error(function(result, status, headers, config) {
                    // called asynchronously if an error occurs
                    // or server returns response with an error status.
                }
            );

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

        $scope.editUser = function (user) {
            user.$edit = true;
        };

        $scope.saveUser = function (user) {
            user.$edit = false;
            var userdto = {
                id: user.id,
                name: user.name,
                lastName: user.lastName,
                age: user.age
            };

            $http.post('/api/User', JSON.stringify(userdto), { headers: { 'Content-Type': 'application/json' } });
        };

        $scope.cancelEditUser = function (user) {
            user.$edit = false;
        };

        $scope.removeUser = function (user) {
            $http.delete('/api/User?id=' + user.id);
            data = _.filter(data, function(item) {
                return item.id != user.id;
            });
            $scope.tableParams.reload();
        };
    }).filter('userRange', function () {
        return function (input, min, max) {
            min = parseInt(min);
            max = parseInt(max);
            for (var i = min; i < max; i++)
                input.push(i);
            return input;
        };
    });