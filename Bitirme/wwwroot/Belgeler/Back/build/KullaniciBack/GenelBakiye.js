var app = angular.module("ProfilGenelBakiye", []);


app.controller("profilGenelBakiye", function ($scope, $http) {
 var session = $("#sessiondeger").val();
    
    var emp = {
        "Dolar": 12,
        "KullaniciAdi": session
    };
    $http.post("http://localhost:63698/api/Kullanicilar/PostGenelFinans/",emp).then(function (response) {
        $scope.prof = response.data;
    });
});


