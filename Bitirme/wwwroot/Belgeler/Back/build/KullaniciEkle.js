$(document).on("click", "#btnKullaniciEkle", function () {
   
    var ad = $("#Adi").val();
    var soyad = $("#Soyadi").val();
    var mail = $("#Emaili").val();
    var tel = $("#Telefonu").val();
    var kAdi = $("#KullaniciAdi").val();
    var sifre = $("#Sifre").val();

if(document.getElementById('Resim').files[0]==null){
var filename="bos";
}else{
var filename = document.getElementById('Resim').files[0].name;
}


if(ad=="" || soyad=="" || mail=="" || tel=="" || kAdi==""|| sifre=="" ){
 alert("Lütfen boş yerleri doldurun.");
}else{

  var emp = {
        "Ad": ad,
        "Soyad":soyad,
        "Email": mail,
        "Telefon": tel,
        "KullaniciAdi": kAdi,
        "Sifre": sifre,
        "Resim": filename
    };

    $.ajax({
        method: "POST",
        url: "http://localhost:63698/api/Kullanicilar/PostKullaniciEkle",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data:JSON.stringify(emp),
  success: function (data) {
alert("Ekleme Başarılı");

    },
error:function (data) {
       alert("Bir Hata Oluştu");
    }
});
}
});