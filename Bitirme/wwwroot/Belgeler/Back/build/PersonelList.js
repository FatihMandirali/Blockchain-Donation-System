var app = angular.module("PersonellerList", []);


app.controller("personelList", function ($scope, $http) {
    $http.get("http://localhost:63698/api/Personeller/GetPersonellerList").then(function (response) {
        $scope.perso = response.data;
    });
});