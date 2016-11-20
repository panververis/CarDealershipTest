(function () {
    'use strict';

    angular
        .module('app')
        .controller('main', main);

    main.$inject = ['$scope']; 

    function main($scope) {
        $scope.food = 'pizza';
        $scope.Search = function() {
            $scope.food = 'this is an invoked food';
        }
        //activate();

        //function activate() { }
    }
})();
