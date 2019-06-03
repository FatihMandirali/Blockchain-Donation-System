var app = angular.module("OnaylananBlogList", []);


app.controller("OnaylananBlogList", function ($scope, $http) {
    $http.get("http://localhost:63698/api/KullaniciMakaleler/GetBlogOnaylananList").then(function (response) {
        $scope.onaylanBlog = response.data;
    });
});