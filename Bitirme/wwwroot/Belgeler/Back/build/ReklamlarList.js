var app = angular.module("ReklamList", []);


app.controller("reklamList", function ($scope, $http) {
    $http.get("http://localhost:63698/api/KullaniciMakaleler/GetReklamlarList").then(function (response) {
        $scope.reklam = response.data;
    });
});