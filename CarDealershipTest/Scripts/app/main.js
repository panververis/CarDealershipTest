(function () {
    'use strict';

    angular
        .module('app', [])
        .service('SalesService', function($http) {
            this.getSales = function() {
                //return $http.get("/api/Sales");
                return $http({
                    url: "/api/Sales",
                    method: "GET"
                    //,params: { param1: angular.toJson(myComplexObject, false) }
                });
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