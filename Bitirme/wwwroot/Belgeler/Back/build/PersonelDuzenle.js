var app = angular.module("PersonelDuzenle", []);


app.controller("personelDuzenle", function ($scope, $http) {
 var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
    //   alert(ID);
    var emp = {
        "KullaniciAdi": secondLevelLocation
    };
    $http.post("http://localhost:63698/api/Personeller/PostPersonelDuzenle/",emp).then(function (response) {
        $scope.perso = response.data;
    });
});