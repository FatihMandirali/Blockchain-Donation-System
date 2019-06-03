$(document).on("click", "#btnKullaniciDuzenle", function () {
   
    var ad = $("#Adi").val();
if(document.getElementById('Resim').files[0]==null){
var filename="bos";
}else{
var filename = document.getElementById('Resim').files[0].name;
}
    

    var soyad = $("#Soyadi").val();
    var email = $("#Emaili").val();
    var tel = $("#Telefonu").val();

    var bakiye = $("#Bakiyes").val();
var bakiyeInt = parseInt(bakiye);
    var biyografi = $("#Biyografis").val();
    var kAdi = $("#KullaniciAdii").val();
    var sifre = $("#Sifres").val();
    var konuId = $(this).attr('name');
    var integer = parseInt(konuId);
alert(ad+" " + soyad+" " + email+"  "+ tel+" " + bakiye+" " +kAdi+" " + sifre);
//if(ad=="" || soyad=="" || email=="" || tel==""  || kAdi==""  || sifre==""  ){

//alert("Lütfen boş yerleri doldurun.");
//}else{

   var emp = {
        "Ad": ad,
        "Soyad": soyad,
        "Email": email,
        "Telefon": tel,
        "Bakiye": bakiye,
        "Biyografi": biyografi,
        "KullaniciAdi": kAdi,
        "Sifre": sifre,
        "Resim": filename,
        "Id":integer
    };

    $.ajax({
        method: "POST",
        url: "http://localhost:63698/api/Kullanicilar/PostKullaniciGuncelle",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data:JSON.stringify(emp),
  success: function (data) {
alert("Güncelleme Başarılı");
    },
error:function (data) {
       alert("Bir Hata Oluştu");
    }
});
//}
});