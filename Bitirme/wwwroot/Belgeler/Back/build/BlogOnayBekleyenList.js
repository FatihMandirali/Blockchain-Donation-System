var app = angular.module("OnayBekleyenBlogList", []);


app.controller("OnayBekleyenBlogList", function ($scope, $http) {
    $http.get("http://localhost:63698/api/KullaniciMakaleler/GetBlogOnayBekleyenList").then(function (response) {
        $scope.bekleyenBlog = response.data;
    });
});