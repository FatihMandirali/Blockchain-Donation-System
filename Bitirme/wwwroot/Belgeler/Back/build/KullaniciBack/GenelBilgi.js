var app = angular.module("KullaniciGenel", []);


app.controller("kullaniciGenel", function ($scope, $http) {

    var kAdi=$("#sessiondeger").val();
    var emp = {
        "KullaniciAdi": kAdi
    };
    $http.post("http://localhost:63698/api/Kullanicilar/PostKullaniciBul/",emp).then(function (response) {
        $scope.kullanici = response.data;
    });
});