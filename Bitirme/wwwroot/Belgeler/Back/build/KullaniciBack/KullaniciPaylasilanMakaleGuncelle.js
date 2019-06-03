$(document).on("click", "#btnKullaniciDuzenle", function () {
   
    var konuad = $("#KonuAdi").val();
if(document.getElementById('Resim').files[0]==null){
var filename="bos";
}else{
var filename = document.getElementById('Resim').files[0].name;
}
    

    var baslik = $("#Baslik").val();
    var altbaslik = $("#AltBaslik").val();
    var icerik = $("#Icerik").val();

    var tarih = $("#Tarih").val();
    var kazanilan = $("#KazanilanPara").val();
var kazanilanInt = parseInt(kazanilan);
    var konuId = $(this).attr('name');
    var integer = parseInt(konuId);
//if(ad=="" || soyad=="" || email=="" || tel==""  || kAdi==""  || sifre==""  ){

//alert("Lütfen boş yerleri doldurun.");
//}else{

   var emp = {
        "KonuAdi": konuad,
        "Baslik": baslik,
        "AltBaslik": altbaslik,
        "Icerik": icerik,
        "Tarih": tarih,
        "KazanilanPara": kazanilan,
        "Resim": filename,
        "Id":integer
    };

    $.ajax({
        method: "POST",
        url: "http://localhost:63698/api/KullaniciMakaleler/PostPaylasilanBlogGuncelle",
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