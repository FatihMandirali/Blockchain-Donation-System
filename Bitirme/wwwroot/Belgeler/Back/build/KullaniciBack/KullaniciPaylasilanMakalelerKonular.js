var app = angular.module("MakaleEkle", []);


app.controller("makaleKonular", function ($scope, $http) {

    $http.get("http://localhost:63698/api/Konular/GetKonularList/").then(function (response) {
        $scope.konu = response.data;
    });
});