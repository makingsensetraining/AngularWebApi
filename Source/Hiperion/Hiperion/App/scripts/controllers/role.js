'use strict';

angular.module('hiperionApp')
    .controller('RoleCtrl', function($scope, $http, $filter, ngTableParams, $sce, ngDialog) {
        var data = [];
        $scope.id = '';
        $scope.name = '';
        $scope.roleToDeleteId = 0;

        loadRoles();

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

        $scope.addNewRole = function() {
            clearData();
            openRoleDialog();
        };

        $scope.editRole = function(role) {
            loadRoleInDialog(role);
            openRoleDialog();
        };

        $scope.saveRole = function() {
            var roleDto = {
                id: $scope.id,
                name: $scope.name
            };

            $http.post('/api/Role',
                    JSON.stringify(roleDto),
                    { headers: { 'Content-Type': 'application/json' } })
                .success(function() {
                    loadRoles();
                });
        };

        $scope.removeRole = function(role) {
            $scope.roleToDeleteId = role.id;
            openConfirmDeleteDialog();
        };

        function loadRoles() {
            $http.get('api/Role').
                success(function(result, status, headers, config) {
                    data = result;
                    $scope.tableParams.reload();
                })
                .error(function(result, status, headers, config) {});
        }

        function loadRoleInDialog(role) {
            $scope.id = role.id;
            $scope.name = role.name;
        }

        function openRoleDialog() {
            ngDialog.openConfirm({
                template: 'App/views/templates/roleDialog.html',
                className: 'ngdialog-theme-default',
                preCloseCallback: 'preCloseCallbackOnScope',
                scope: $scope
            }).then(function(role) {
                loadRoleInDialog(role);
                $scope.saveRole();
                clearData();
            });
        }

        function openConfirmDeleteDialog() {
            ngDialog.openConfirm({
                template: 'App/views/templates/deleteRoleDialog.html',
                className: 'ngdialog-theme-default',
                scope: $scope
            }).then(function(value) {
                deleteRole();
            });
        }

        function clearData() {
            $scope.id = '';
            $scope.name = '';
            $scope.roleToDeleteId = 0;
        }

        function deleteRole() {
            $http.delete('/api/Role?id=' + $scope.roleToDeleteId)
                .success(function() {
                    loadRoles();
                    clearData();
                });
        }

    });