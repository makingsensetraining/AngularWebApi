'use strict';

describe("Test 001", function () { it("OK", function () { expect(true).toBe(true); }); });

describe("Test 002", function () { it("Ok", function () { expect(true).toBe(true); }); });

describe("Test Controller:UserCtrl > users fake collection amount", function () {

    beforeEach(module('app'));

    var userCtrl, scope;

    beforeEach(inject(function ($controller, $scope) {
        scope = $rootScope.$new();
        userCtrl = $controller('UserCtrl', {
            $scope: scope
        });
    }));

    it('test 003', function () {
        expect(scope.$data.length).toBe(12);
    });

});