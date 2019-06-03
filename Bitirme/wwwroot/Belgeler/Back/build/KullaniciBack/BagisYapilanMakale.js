var app = angular.module("MakaleDuzenle1", []);


app.controller("makaleDuzenle1", function ($scope, $http) {
 var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
    //   alert(ID);
    var emp = {
        "KullaniciAdi": secondLevelLocation
    };
    $http.post("http://localhost:63698/api/KullaniciMakaleler/PostBagisYapilanBlogDuzenle/",emp).then(function (response) {
        $scope.makale = response.data;
    });
});