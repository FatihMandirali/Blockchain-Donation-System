var app = angular.module("KategoriOzelList", []);


app.controller("KategoriOzelList", function ($scope, $http) {

    var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
    
var emp={
        "KategoriAd":secondLevelLocation
}

    $http.post("http://localhost:63698/api/KullaniciMakaleler/PostKategoriOzelBlogList",emp).then(function (response) {
        $scope.Blog = response.data;
    });
});