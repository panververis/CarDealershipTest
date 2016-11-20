(function () {
    'use strict';

    angular
        .module('app', [])
        .service('SalesService', [function () {
            return {
                getSales: function() {
                    return 'Sales';
                }
            };
        }])
    .controller('main', ['SalesService', '$scope', function (salesService, $scope) {
        $scope.search = function () {
            var a = salesService.getSales();
            return a;
        };

    }]);
})();