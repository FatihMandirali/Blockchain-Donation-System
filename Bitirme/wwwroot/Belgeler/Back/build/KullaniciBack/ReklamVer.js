$(document).on("click", "#btnReklamVer", function () {
   
    var blog = $("#comboBlogList").val();
    var tarife = $("#comboTarifeList").val();

    var kullaniciad = $("#sessiondeger").val();

  var emp = {
        "BlogId": blog,
        "Tarife":tarife,
        "KullaniciAdi": kullaniciad
    };

    $.ajax({
        method: "POST",
        url: "http://localhost:63698/api/KullaniciMakaleler/PostReklamVer",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data:JSON.stringify(emp),
  success: function (data) {
alert(data.mesaj);
location.reload();
    },
error:function (data) {
       alert("Bir Hata Oluştu");
    }
});
});