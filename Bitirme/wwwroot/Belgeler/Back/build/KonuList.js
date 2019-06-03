var app = angular.module("KonuList", []);


app.controller("konuList", function ($scope, $http) {
    $http.get("http://localhost:63698/api/Konular/GetKonularList").then(function (response) {
        $scope.konu = response.data;
    });
});