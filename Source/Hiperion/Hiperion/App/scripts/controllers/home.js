'use strict';

angular.module('hiperionApp')
    .controller('HomeCtrl', function($scope, ngDialog) {
        $scope.title = 'HOME';
        $scope.name = "";
        $scope.comment = "";
        $scope.comments = [];
        $scope.isCommentsVisible = false;
        $scope.showStatistics = function() {
            $scope.isCommentsVisible = false;
            ngDialog.open({
                template: 'stadisticsTemplate',
                className: 'ngdialog-theme-default'
            });
        };
        $scope.showComments = function() {
            $scope.isCommentsVisible = true;
        };
        $scope.preCloseCallbackOnScope = function(value) {
            return true;
        };
        $scope.addComment = function() {
            ngDialog.openConfirm({
                template: 'commentTemplate',
                className: 'ngdialog-theme-default',
                preCloseCallback: 'preCloseCallbackOnScope',
                scope: $scope
            }).then(function(data) {
                $scope.comments.push(data);
            }, function(reason) {
            });
        };
    });