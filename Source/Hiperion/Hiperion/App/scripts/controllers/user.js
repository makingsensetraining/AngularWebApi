'use strict';

angular.module('hiperionApp')
    .controller('UserCtrl', function($scope, $http, $filter, ngTableParams, $sce, ngDialog, userService) {
        var data = [];
        $scope.id = '';
        $scope.name = '';
        $scope.lastName = '';
        $scope.age = '';
        $scope.role = '';
        $scope.roles = [];
        $scope.userToDeleteId = 0;

        loadUsers();
        loadRoles();

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

        $scope.addNewUser = function() {
            clearData();
            openUserDialog();
        };

        $scope.editUser = function(user) {
            loadUserInDialog(user);
            openUserDialog();
        };

        $scope.saveUser = function() {
            var userdto = {
                id: $scope.id,
                name: $scope.name,
                lastName: $scope.lastName,
                age: $scope.age,
                role: $scope.role
            };

            $http.post('/api/User',
                    JSON.stringify(userdto),
                    { headers: { 'Content-Type': 'application/json' } })
                .success(function() {
                    loadUsers();
                });
        };

        $scope.removeUser = function(user) {
            $scope.userToDeleteId = user.id;
            openConfirmDeleteDialog();
        };

        $scope.getCurrentTime = function() {
            return userService.getTime();
        };

        function loadUsers() {
            $http.get('/api/User').
                success(function(result, status, headers, config) {
                    data = result;
                    $scope.tableParams.reload();
                })
                .error(function(result, status, headers, config) {
                    // called asynchronously if an error occurs
                    // or server returns response with an error status.
                });
        }

        function loadRoles() {
            $http.get('api/Role').
                success(function(result, status, headers, config) {
                    $scope.roles = result;
                })
                .error(function(result, status, headers, config) {});
        }

        function loadUserInDialog(user) {
            $scope.id = user.id;
            $scope.name = user.name;
            $scope.lastName = user.lastName;
            $scope.age = user.age;
            $scope.role = user.role;
        }

        function openUserDialog() {
            ngDialog.openConfirm({
                template: 'App/views/templates/userDialog.html',
                className: 'ngdialog-theme-default',
                preCloseCallback: 'preCloseCallbackOnScope',
                scope: $scope
            }).then(function(user) {
                loadUserInDialog(user);
                $scope.saveUser();
                clearData();
            });
        }

        function openConfirmDeleteDialog() {
            ngDialog.openConfirm({
                template: 'App/views/templates/deleteUserDialog.html',
                className: 'ngdialog-theme-default',
                //preCloseCallback: 'preCloseCallbackOnScope',
                scope: $scope
            }).then(function(value) {
                deleteUser();
            });
        }

        function clearData() {
            $scope.id = '';
            $scope.name = '';
            $scope.lastName = '';
            $scope.age = '';
            $scope.role = '';
            $scope.userToDeleteId = 0;
        }

        function deleteUser() {
            $http.delete('/api/User?id=' + $scope.userToDeleteId)
                .success(function() {
                    loadUsers();
                    clearData();
                });
        }

    })
    .filter('userRange', function() {
        return function(input, min, max) {
            min = parseInt(min);
            max = parseInt(max);
            for (var i = min; i < max; i++)
                input.push(i);
            return input;
        };
    });