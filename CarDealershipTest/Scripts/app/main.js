(function () {
    'use strict';

    angular
        .module('app', [])
        .service('SalesService', function($http) {
            this.getSales = function() {
                return $http.get("/api/Sales");
            }
        })
    .controller('main', ['SalesService', '$scope', function (salesService, $scope) {
        searchFunc();
        $scope.search = searchFunc;

        function searchFunc() {
            var salesServCall = salesService.getSales();
                salesServCall.then(
                    function (d) {
                        var dData = d.data;
                        $scope.sales = dData;
                    }
                );
        }

    }]);
})();