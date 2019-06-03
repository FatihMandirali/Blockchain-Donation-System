var app = angular.module("YProfilGenelBakiye", []);


app.controller("YprofilGenelBakiye", function ($scope, $http) {
   
    $http.get("http://localhost:63698/api/Kullanicilar/GetPesronelGenelFinans",).then(function (response) {
        $scope.prof = response.data;
    });
});


