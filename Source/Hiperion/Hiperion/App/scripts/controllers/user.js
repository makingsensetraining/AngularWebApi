'use strict';

angular.module('hiperionApp')
    .controller('UserCtrl', function ($scope, $http, $filter, ngTableParams, $sce, ngDialog) {
        var data = [];
        $scope.id = '';
        $scope.name = '';
        $scope.lastName = '';
        $scope.age = '';

        loadUsers();

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

        $scope.addNewUser = function () {
            clearData();
            openDialog();
        };

        $scope.editUser = function (user) {
            loadUserInDialog(user);
            openDialog();
        };

        $scope.saveUser = function () {
            var userdto = {
                id: $scope.id,
                name: $scope.name,
                lastName: $scope.lastName,
                age: $scope.age
            };

            $http.post('/api/User',
                       JSON.stringify(userdto),
                       { headers: { 'Content-Type': 'application/json' } })
                 .success(function () {
                     loadUsers();
                 });
        };
           
        $scope.removeUser = function (user) {
            $http.delete('/api/User?id=' + user.id)
                 .success(function () {
                     loadUsers();
                 });

            //data = _.filter(data, function (item) {
            //    return item.id != user.id;
            //});
            //$scope.tableParams.reload();
        };

        function loadUsers() {
            $http.get('/api/User').
                success(function (result, status, headers, config) {
                    data = result;
                    $scope.tableParams.reload();
                })
                .error(function (result, status, headers, config) {
                    // called asynchronously if an error occurs
                    // or server returns response with an error status.
                });
        }

        function loadUserInDialog(user) {
            $scope.id = user.id;
            $scope.name = user.name;
            $scope.lastName = user.lastName;
            $scope.age = user.age;
        }

        function openDialog() {
            ngDialog.openConfirm({
                template: 'App/views/userDialog.html',
                className: 'ngdialog-theme-default',
                preCloseCallback: 'preCloseCallbackOnScope',
                scope: $scope
            }).then(function (user) {
                loadUserInDialog(user);
                $scope.saveUser();
                clearData();               
            });
        }

        function clearData() {
            $scope.id = '';
            $scope.name = '';
            $scope.lastName = '';
            $scope.age = '';
        }
    })
    .filter('userRange', function () {
        return function (input, min, max) {
            min = parseInt(min);
            max = parseInt(max);
            for (var i = min; i < max; i++)
                input.push(i);
            return input;
        };
    });