(function () {
    'use strict';

    angular
        .module('app', [])
        .service('SalesService', function($http) {
            this.getSales = function (filterObject) {
                //return $http.get("/api/Sales");
                //return $http({
                //    url: "/api/Sales",
                //    method: "GET", 
                //    params: { param1: angular.toJson(filterObject, false) }
                //});
                var filterStr = angular.toJson(filterObject);
                return $http.get("/api/Sales" + "/?filter=" + filterStr);
            }
        })
    .controller('main', ['SalesService', '$scope', function (salesService, $scope) {
        searchFunc();
        $scope.search = searchFunc;

        function searchFunc() {

            var filterObject = {
                DateFrom: $scope.startDate,
                DateTo: $scope.endDate,
                Region: $scope.region,
                Area: $scope.area,
                Staff: $scope.staff
            };

            var salesServCall = salesService.getSales(filterObject);
                salesServCall.then(
                    function (d) {
                        var dData = d.data;
                        $scope.sales = dData;
                    }
                );
        }

    }]);
})();