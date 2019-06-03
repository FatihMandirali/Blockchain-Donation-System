$(document).on("click", "#btnKullaniciGiris", function () {
   var kadi = $("#txtKullaniciAdi").val();
    var sifre = $("#txtSifre").val();

    var emp = {
        "KullaniciAdi": kadi,
        "Sifre": sifre
    };
    $.ajax({
        method: "POST",
        url: "http://localhost:63698/api/Kullanicilar/KullaniciLogin",
         dataType: "json",
        contentType: "application/json; charset=utf-8",
        data:JSON.stringify(emp),
    }).done(function (response, statusText, jqXHR) {


           if(response.durum==true)
            location.reload();
            else
            alert("Kullanıcı Adı veya Şifre Yanlış");

      
    });
});