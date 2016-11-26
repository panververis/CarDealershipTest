(function () {
    'use strict';

    angular
        .module('app', [])
        .service('SalesService', function($http) {
            this.getSales = function (filterObject) {
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