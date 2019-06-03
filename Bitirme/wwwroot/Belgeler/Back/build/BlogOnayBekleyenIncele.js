var app = angular.module("BlogOnaylanmamisIncele", []);


app.controller("blogOnaylanmamisIncele", function ($scope, $http) {
 var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
var integer = parseInt(secondLevelLocation);
    var emp = {
        "Id": secondLevelLocation
    };
    $http.post("http://localhost:63698/api/KullaniciMakaleler/PostBlogOnaylanmamisIncele/",emp).then(function (response) {
        $scope.blog = response.data;
    });
});