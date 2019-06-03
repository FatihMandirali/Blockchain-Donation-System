var app = angular.module("BitcoinDetay", []);



app.controller("Bitcoin", function ($scope, $http) {
 $http.get("http://localhost:63698/api/KullaniciMakaleler/GetCoinKur").then(function (response) {
        $scope.data = response.data;
    });
});