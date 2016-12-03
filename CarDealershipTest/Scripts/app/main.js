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
        .directive('hcPieChart', function () {
            return { restrict: 'E', template: '<div></div>',
                scope: { title: '@', data: '=' },
                link: function (scope, element) {
                    Highcharts.chart(element[0], {
                        chart: { type: 'pie'},
                        title: {text: scope.title}, 
                        plotOptions: {
                            pie: { allowPointSelect: true, cursor: 'pointer',
                                dataLabels: { enabled: true, format: '<b>{point.name}</b>: {point.percentage:.1f} %' }
                            }
                        },
                        series: [{ data: scope.data }]
                    });
                }
            };
        })
    .controller('main', ['SalesService', '$scope', function (salesService, $scope) {
        searchFunc();

        // Sample data for pie chart
        $scope.pieData =
            [{ name: "Microsoft Internet Explorer", y: 56.33 },
             { name: "Chrome", y: 24.03, sliced: true, selected: true },
             { name: "Firefox", y: 10.38 },
             { name: "Safari", y: 4.77 },
             { name: "Opera", y: 0.91 },
             { name: "Proprietary or Undetectable", y: 0.2 }]

        //define the "Search" Function
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