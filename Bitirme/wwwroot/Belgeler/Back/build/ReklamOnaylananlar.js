var app = angular.module("ReklamList1", []);


app.controller("reklamList1", function ($scope, $http) {
    $http.get("http://localhost:63698/api/KullaniciMakaleler/GetReklamlarOnaylananList").then(function (response) {
        $scope.reklam = response.data;
    });
});