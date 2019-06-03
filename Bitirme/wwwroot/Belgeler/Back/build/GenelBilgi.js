var app = angular.module("PersonelGenelIncele", []);


app.controller("personelGenelIncele", function ($scope, $http) {
        
    var session=$("#sessiondeger").val();
var emp={
"KullaniciAdi":session
};
    $http.post("http://localhost:63698/api/Personeller/PostPersonelDuzenle/",emp).then(function (response) {
        $scope.pers = response.data;
    });
});