$(document).on("click", "#btnPersonelGuncelleGenel", function () {

var ad=$("#yAdi").val();
var soyad=$("#ySoyadi").val();
var tc=$("#yTc").val();
var email=$("#yEmail").val();
var tel=$("#yTel").val();
var kadi=$("#yKadi").val();
var sifre=$("#ySifre").val();



 var konuId = $(this).attr('name');
var integer = parseInt(konuId);
    var emp = {
        "Ad":ad,
        "Soyad":soyad,
        "Tc":tc,
        "Email":email,
        "Telefon":tel,
        "KullaniciAdi":kadi,
        "Sifre":sifre,
        "Id": konuId
    };
    $.ajax({
        method: "POST",
        url: "http://localhost:63698/api/Personeller/PostGenelBilgiGuncelle",
         dataType: "json",
        contentType: "application/json; charset=utf-8",
        data:JSON.stringify(emp),
    }).done(function (response, statusText, jqXHR) {


            window.location = "http://localhost:63698/Yonetim/GenelBilgi/";

      
    });
});