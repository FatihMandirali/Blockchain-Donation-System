var app = angular.module("IndexBlogList", []);


app.controller("BlogList", function ($scope, $http) {
    $http.get("http://localhost:63698/api/KullaniciMakaleler/GetBlogList").then(function (response) {
        $scope.Blog = response.data;
    });
});

app.controller("Bitcoin", function ($scope, $http) {
 $http.get("http://localhost:63698/api/KullaniciMakaleler/GetCoinKur").then(function (response) {
        $scope.data = response.data;
    });
});

app.controller("Reklamlar", function ($scope, $http) {
 $http.get("http://localhost:63698/api/KullaniciMakaleler/GetReklamlarOnaylananList").then(function (response) {
        $scope.reklam = response.data;
    });
});