'use strict';

angular.module('hiperionApp')
    .controller('HomeCtrl', function ($scope, ngDialog) {
        $scope.title = 'HOME';
        $scope.activeSection = 'home';
        $scope.setActiveSection = function (section) {
            $scope.activeSection = section;
            $scope.title = section.toUpperCase();
        };
        $scope.name = "";
        $scope.comment = "";
        $scope.comments = [];
        $scope.isCommentsVisible = false;
        $scope.showStatistics = function () {
            $scope.isCommentsVisible = false;
            ngDialog.open({
                template: 'stadisticsTemplate',
                className: 'ngdialog-theme-default'
            });
        };
        $scope.showComments = function () {
            $scope.isCommentsVisible = true;
        };
        $scope.preCloseCallbackOnScope = function (value) {
            return true;
        };
        $scope.addComment = function () {
            ngDialog.openConfirm({
                template: 'commentTemplate',
                className: 'ngdialog-theme-default',
                preCloseCallback: 'preCloseCallbackOnScope',
                scope: $scope
            }).then(function (data) {
                $scope.comments.push(data);
            }, function (reason) {
                console.log('Modal promise rejected. Reason: ', reason);
            });
        };
    })
    .controller('UserCtrl', function ($scope, $filter, ngTableParams, $sce) {
        $scope.tableForms = ['None', 'Default', 'Sort', 'Filter', 'Styling-ExportCsv'];
        $scope.tableFormSelected = 'None';
        $scope.users = [{ name: 'Mick', country: 'US', age: 26 },
              { name: 'John', country: 'US', age: 60 },
              { name: 'Rick', country: 'US', age: 28 },
              { name: 'Liz', country: 'ENG', age: 26 },
              { name: 'Mon', country: 'ENG', age: 29 },
              { name: 'Jessy', country: 'US', age: 30 },
              { name: 'Charlie', country: 'US', age: 36 },
              { name: 'Jean', country: 'FR', age: 46 },
              { name: 'Charlie', country: 'FR', age: 56 },
              { name: 'Brandon', country: 'US', age: 16 },
              { name: 'Jim', country: 'US', age: 56 },
              { name: 'John', country: 'US', age: 26 },
              { name: 'Peter', country: 'AR', age: 32 },
              { name: 'Mary', country: 'AR', age: 35 }];

        $scope.tableParams01 = new ngTableParams({
            page: 1,
            count: 5
        }, {
            total: $scope.users.length,
            getData: function ($defer, params) {
                var orderedData = params.sorting() ?
                                    $filter('orderBy')($scope.users, params.orderBy()) :
                                    $scope.users;

                $defer.resolve(orderedData.slice((params.page() - 1) * params.count(), params.page() * params.count()));
            }
        });

        $scope.tableParams02 = new ngTableParams({
            page: 1,
            count: 5,
            sorting: { name: 'asc' }
        }, {
            total: $scope.users.length,
            getData: function ($defer, params) {
                var orderedData = params.sorting() ?
                                    $filter('orderBy')($scope.users, params.orderBy()) :
                                    $scope.users;

                $defer.resolve(orderedData.slice((params.page() - 1) * params.count(), params.page() * params.count()));
            }
        });

        $scope.tableParams03 = new ngTableParams({
            page: 1,
            count: 5,
            filter: { name: '', country: '' }
        }, {
            total: $scope.users.length,
            getData: function ($defer, params) {
                var orderedData = params.filter() ?
                   $filter('filter')($scope.users, params.filter()) :
                    $scope.users;

                $scope.usersFiltered = orderedData.slice((params.page() - 1) * params.count(), params.page() * params.count());

                params.total(orderedData.length);
                $defer.resolve($scope.usersFiltered);
            }
        });

        $scope.tableParams04 = new ngTableParams({
            page: 1,
            count: 5
        }, {
            total: $scope.users.length,
            getData: function ($defer, params) {
                var orderedData = params.sorting() ?
                            $filter('orderBy')($scope.users, params.orderBy()) :
                            $scope.users;

                $defer.resolve(orderedData.slice((params.page() - 1) * params.count(), params.page() * params.count()));
            }
        });
    })
    .controller('AboutCtrl', function ($scope) {
        $scope.description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing sof";
    });
