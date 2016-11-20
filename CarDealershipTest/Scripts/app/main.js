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
            var servCall = salesService.getSales();
            servCall.then(
                function (d) {
                    var dData = d.data;
                    $scope.getSales = dData;
                }, function (error) {
                    $log.error('Oops! Something went wrong while fetching the data.');
                }
            );
        };

    }]);
})();