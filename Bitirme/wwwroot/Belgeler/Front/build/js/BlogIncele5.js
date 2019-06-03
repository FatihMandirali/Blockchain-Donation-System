var app = angular.module("BlogIncele", []);


app.controller("blogIncele", function ($scope, $http) {
 var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
var integer = parseInt(secondLevelLocation);
    var emp = {
        "Slug": secondLevelLocation
    };
    $http.post("http://localhost:63698/api/KullaniciMakaleler/PostBlogIncele/",emp).then(function (response) {
        $scope.blog = response.data;
    });
});

app.controller("Bitcoin", function ($scope, $http) {
 $http.get("http://localhost:63698/api/KullaniciMakaleler/GetCoinKur").then(function (response) {
        $scope.data = response.data;
    });
});
