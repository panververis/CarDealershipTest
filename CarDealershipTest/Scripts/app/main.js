(function () {
    'use strict';

    angular
        .module('app')
        .controller('main', main);

    main.$inject = ['$scope']; 

    function main($scope) {
        $scope.food = 'pizza';

        activate();

        function activate() { }
    }
})();
