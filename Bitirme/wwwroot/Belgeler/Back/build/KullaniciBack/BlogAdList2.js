var app = angular.module("BlogAdList", []);


app.controller("blogAdList", function ($scope, $http) {
      var session=$("#sessiondeger").val();
        var emp={
            "KullaniciAdi":session
        };
    $http.post("http://localhost:63698/api/KullaniciMakaleler/PostBlogAdList/",emp).then(function (response) {
        $scope.blog = response.data;
    });
});

  //  $("#Semt").attr("disabled", false).html("<option value=''>Seçin..</option>");

$("#comboBlogList").on("change", function () {
    var blogId = $(this).val();
        var emp={
            "Id":blogId
        };
   $.ajax({
        method: "POST",
        url: "http://localhost:63698/api/KullaniciMakaleler/PostPaylasilanBlogDuzenle/",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data:JSON.stringify(emp),
  success: function (data) {
//alert("geldi");
    },
error:function (data) {
       alert("Bir Hata Oluştu");
    }

   });
});