var app = angular.module("KullanicilarList", []);


app.controller("kullanicilarListesi", function ($scope, $http) {
    $http.get("http://localhost:63698/api/Kullanicilar/GetKullaniciList").then(function (response) {
        $scope.kullanici = response.data;
    });
});