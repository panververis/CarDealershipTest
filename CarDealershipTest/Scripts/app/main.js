(function () {
    'use strict';

    angular
        .module('app', [])
        .service('SalesService', function($http) {
            this.getSales = function() {
                return $http.get("api/Sales");
            }
        })
    .controller('main', ['SalesService', '$scope', function (salesService, $scope) {
        $scope.search = function () {
            var a = salesService.getSales();
            return a;
        };

    }]);
})();