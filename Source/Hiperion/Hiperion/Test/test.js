'use strict';

describe("Test 001 - Simple one", function () { it("This is a simple expect to test the conexion", function () { expect(true).toBe(true); }); });

describe("Test 002 - User Controller", function () {

    beforeEach(module('hiperionApp'));

    var userCtrl, scope;

    beforeEach(inject(function ($controller, $rootScope) {
        scope = $rootScope.$new();
        userCtrl = $controller('UserCtrl', {
            $scope: scope
        });
    }));

    it('test 002.1', function () {
        expect(scope.name).toBe('');
    });

    it('test 002.2', function () {
        expect(scope.lastName).toBe('');
    });

    it('test 002.3', function () {
        expect(scope.tableParams.count()).toBe(5);
    });
});

describe("Test 003 - Home Controller", function () {
    beforeEach(module('hiperionApp'));

    var controller, scope;

    beforeEach(inject(function ($controller, $rootScope) {
        scope = $rootScope.$new();
        controller = $controller('HomeCtrl', {
            $scope: scope
        });
    }));

    it('test 003.1', function () {
        expect(scope.title).toBe('HOME');
    });

    it('test 003.2', function () {
        expect(scope.addComment()).not.toBe(null);
    });

    it('test 003.3', function () {
        expect(scope.title).toMatch('H');
    });
});

describe("Test 004 - About Controller", function () {
    beforeEach(module('hiperionApp'));

    var controller, scope;

    beforeEach(inject(function ($controller, $rootScope) {
        scope = $rootScope.$new();
        controller = $controller('AboutCtrl', {
            $scope: scope
        });
    }));

    it('test 004.1', function () {
        expect(scope.description).not.toBe('');
    });
});
