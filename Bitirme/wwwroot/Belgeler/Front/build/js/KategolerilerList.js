var app = angular.module("KategorilerList", []);


app.controller("kategorilerList", function ($scope, $http) {
    $http.get("http://localhost:63698/api/Konular/GetKonularList").then(function (response) {
        $scope.Kategori = response.data;
    });
});