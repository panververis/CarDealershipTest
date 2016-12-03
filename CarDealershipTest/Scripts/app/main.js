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
        .service('StaffSalesService', function ($http) {
            this.getStaffSales = function (filterObject) {
                var filterStr = angular.toJson(filterObject);
                return $http.get("/api/Staffs" + "/?filter=" + filterStr);
            }
        })
        .directive('hcPieChart', function () {
            return {
                restrict: 'E', template: '<div></div>',
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
    .controller('main', ['SalesService', 'StaffSalesService', '$scope', function (salesService, staffSalesService, $scope) {
        searchFunc();

        var something = [{ name: "Microsoft Internet Explorer", y: 56.33 },
                        { name: "Chrome", y: 24.03, sliced: true, selected: true },
                        { name: "Firefox", y: 10.38 },
                        { name: "Safari", y: 4.77 },
                        { name: "Opera", y: 0.91 },
                        { name: "Proprietary or Undetectable", y: 0.2 }];

        $scope.pieData = something;

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
                function (response) {
                    var salesData = response.data;
                    $scope.sales = salesData;
                }
            );

            var staffSalesServCall = staffSalesService.getStaffSales(filterObject);
            staffSalesServCall.then(
                function (response) {
                    var staffSalesData = response.data;
                    var staffSalesResponseLength = staffSalesData.length;
                    var pieDataArray = [];
                    for (var i = 0; i < staffSalesResponseLength; i++) {
                        pieDataArray.push({ name: staffSalesData[i].FullName, y: staffSalesData[i].NumberOfSales});
                    }
                    $scope.pieData = pieDataArray;
                }
            );
        }

    }]);
})();