var app = angular.module("KullaniciDuzenle", []);


app.controller("kullaniciDuzenle", function ($scope, $http) {
 var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
    //   alert(ID);
var integer = parseInt(secondLevelLocation);
    var emp = {
        "Id": integer
    };
    $http.post("http://localhost:63698/api/Kullanicilar/PostKullaniciDuzenle/",emp).then(function (response) {
        $scope.kullanici = response.data;
    });
});