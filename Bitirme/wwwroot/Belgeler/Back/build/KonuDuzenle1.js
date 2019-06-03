var app = angular.module("KonuDuzenle", []);


app.controller("konuDuzenle", function ($scope, $http) {
 var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
    //   alert(ID);
var integer = parseInt(secondLevelLocation);
    var emp = {
        "Id": integer
    };
    $http.post("http://localhost:63698/api/Konular/PostKonuDuzenle/",emp).then(function (response) {
        $scope.konu = response.data;
    });
});