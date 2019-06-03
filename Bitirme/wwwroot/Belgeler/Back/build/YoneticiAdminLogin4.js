$(document).on("click", "#btnYoneticiGirisYap", function () {
   var kadi = $("#YoneticiKullaniciAdi").val();
    var sifre = $("#YoneticiSifre").val();

    var emp = {
        "KullaniciAdi": kadi,
        "Sifre": sifre
    };
    $.ajax({
        method: "POST",
        url: "http://localhost:63698/api/Personeller/YoneticiLogin",
         dataType: "json",
        contentType: "application/json; charset=utf-8",
        data:JSON.stringify(emp),
    }).done(function (response, statusText, jqXHR) {


           if(response.durum==true)
            window.location = "http://localhost:63698/Yonetim/Personeller/";
            else
            alert("Kullanıcı Adı veya Şifre Yanlış");

      
    });
});