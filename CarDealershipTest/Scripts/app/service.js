app.service("APIService", function ($http) {
    this.getSales = function () {
        return $http.get("api/Sales");
    }
});
