var app = angular.module("BlogPaylasimList", []);


app.controller("blogpaylasimList", function ($scope, $http) {

 
    var secondLevelLocation = $("#sessiondeger").val();
    var emp = {
        "KullaniciAdi": secondLevelLocation
    };
    $http.post("http://localhost:63698/api/KullaniciMakaleler/PostPaylasilanBlogList/",emp).then(function (response) {
        $scope.blogPay = response.data;
    });
});