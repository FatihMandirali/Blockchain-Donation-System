$(document).on("click", "#btnGenelBilgiDuzenle", function () {
   
    var ad = $("#gAdi").val();
if(document.getElementById('gResim').files[0]==null){
var filename="bos";
}else{
var filename = document.getElementById('gResim').files[0].name;
}
    

    var soyad = $("#gSoyadi").val();
    var email = $("#gEmaili").val();
    var tel = $("#gTelefonu").val();

    var bakiye = $("#gBakiyes").val();
var bakiyeInt = parseInt(bakiye);
    var biyografi = $("#gBiyografis").val();
    var kAdi = $("#gKullaniciAdii").val();
    var sifre = $("#gSifres").val();
    var konuId = $(this).attr('name');
    var integer = parseInt(konuId);
//alert(ad+" " + soyad+" " + email+"  "+ tel+" " + bakiye+" " +kAdi+" " + sifre);
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
alert(data.mesaj);
if(data.durum==true)
location.reload();
    },
error:function (data) {
       alert("Bir Hata Oluştu");
    }
});
//}
});