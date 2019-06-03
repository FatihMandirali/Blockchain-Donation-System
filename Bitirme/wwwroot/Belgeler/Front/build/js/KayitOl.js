$(document).on("click", "#btnKullaniciKayit", function () {
   
    var ad = $("#aAdi").val();
    var soyad = $("#aSoyadi").val();
    var mail = $("#aEmaili").val();
    var tel = $("#aTelefonu").val();
    var kAdi = $("#aKullaniciAdi").val();
    var sifre = $("#aSifre").val();
    var biyog = $("#aBiyografis").val();

if(document.getElementById('aResim').files[0]==null){
var filename="bos";
}else{
var filename = document.getElementById('aResim').files[0].name;
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
        "Resim": filename,
        "Biyografi": biyog
    };

    $.ajax({
        method: "POST",
        url: "http://localhost:63698/api/Kullanicilar/PostKullaniciEkle",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data:JSON.stringify(emp),
  success: function (data) {
alert(data.mesaj);
if(data.durum==true)
location.reload();
    },
error:function (data) {
       alert("Bir Hata Oluştu");
    }
});
}
});