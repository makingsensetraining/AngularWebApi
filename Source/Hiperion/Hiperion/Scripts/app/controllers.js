'use strict';

angular.module('hiperionApp')
    .controller('HomeCtrl', function ($scope) {
        $scope.title = 'HOME';
        $scope.activeSection = '';
        $scope.setActiveSection = function (section) {
            $scope.activeSection = section;
            $scope.title = section.toUpperCase();
        };
    })
    .controller('UserCtrl', function ($scope, ngTableParams) {
        $scope.users = [{ name: 'Mick', country: 'US', age: 26 },
              { name: 'John', country: 'US', age: 26 },
              { name: 'Rick', country: 'US', age: 26 },
              { name: 'Liz', country: 'US', age: 26 },
              { name: 'Mon', country: 'US', age: 26 },
              { name: 'Jessy', country: 'US', age: 26 },
              { name: 'Charlie', country: 'US', age: 26 },
              { name: 'Mary', country: 'US', age: 26 },
              { name: 'Peter', country: 'US', age: 26 },
              { name: 'Peter2', country: 'US', age: 26 },
              { name: 'Peter3', country: 'US', age: 26 },
              { name: 'Peter4', country: 'US', age: 26 },
              { name: 'Peter5', country: 'US', age: 26 },
              { name: 'Andre', country: 'US', age: 26 }];

        $scope.tableParams = new ngTableParams({
            page: 1,            // show first page
            count: 5           // count per page
        }, {
            total: $scope.users.length, // length of data
            getData: function ($defer, params) {
                $defer.resolve($scope.users.slice((params.page() - 1) * params.count(), params.page() * params.count()));
            }
        });
    })
    .controller('AboutCtrl', function ($scope) {
        $scope.description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing sof";
    });
