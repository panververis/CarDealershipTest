(function () {
    'use strict';

    angular
        .module('app', [])
        .service('SalesService', function($http) {
            this.getSales = function (filterObject) {
                //return $http.get("/api/Sales");
                return $http({
                    url: "/api/Sales",
                    method: "GET", 
                    params: { param1: angular.toJson(filterObject, false) }
                });
            }
        })
    .controller('main', ['SalesService', '$scope', function (salesService, $scope) {
        searchFunc();
        $scope.search = searchFunc;

        function searchFunc() {


            var filterObject = {
                DateFrom: $scope.startDate,
                DateTo: $scope.endDate,
                Region: $scope.Region,
                Area: $scope.area,
                Staff: $scope.staff
            }

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