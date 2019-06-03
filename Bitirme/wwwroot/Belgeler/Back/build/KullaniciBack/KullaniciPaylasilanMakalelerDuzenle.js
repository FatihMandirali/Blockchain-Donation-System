var app = angular.module("MakaleDuzenle", []);


app.controller("makaleDuzenle", function ($scope, $http) {
 var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
    //   alert(ID);
var integer = parseInt(secondLevelLocation);
    var emp = {
        "Id": integer
    };
    $http.post("http://localhost:63698/api/KullaniciMakaleler/PostPaylasilanBlogDuzenle/",emp).then(function (response) {
        $scope.makale = response.data;
    });
});