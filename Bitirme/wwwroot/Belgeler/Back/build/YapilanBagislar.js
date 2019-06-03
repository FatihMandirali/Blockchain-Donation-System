var app = angular.module("YoneticiBagisListt", []);


app.controller("yoneticiBagisListt", function ($scope, $http) {
    $http.get("http://localhost:63698/api/KullaniciMakaleler/GetYoneticiBagisList").then(function (response) {
        $scope.yoneticiBagis = response.data;
    });
});

app.controller("yoneticiCoinGenel", function ($scope, $http) {
 
  
    $http.get("http://localhost:63698/api/KullaniciMakaleler/GetYoneticiCoinGenel").then(function (response) {
        $scope.coin = response.data;
    });
});