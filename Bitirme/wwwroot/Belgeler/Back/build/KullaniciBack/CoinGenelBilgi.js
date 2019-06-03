var app = angular.module("BagisKullaniciList", []);


app.controller("coinGenel", function ($scope, $http) {
 
    var secondLevelLocation = $("#sessiondeger").val();
    //   alert(ID);
    var emp = {
        "KullaniciAdi": secondLevelLocation
    };
    $http.post("http://localhost:63698/api/KullaniciMakaleler/PostCoinGenel/",emp).then(function (response) {
        $scope.coin = response.data;
    });
});


app.controller("bagisKullaniciList", function ($scope, $http) {
// var pathArray = window.location.pathname.split('/');
  //  var secondLevelLocation = pathArray[3];
    //   alert(ID);
//var integer = parseInt(secondLevelLocation);

        var kAdi=$("#sessiondeger").val();
    var emp = {
        "KullaniciAdi": kAdi
    };
    $http.post("http://localhost:63698/api/KullaniciMakaleler/PostBagisList/",emp).then(function (response) {
        $scope.bagis = response.data;
    });
});