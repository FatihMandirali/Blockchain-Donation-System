$(document).on("click", "#btnMakaleEkle", function () {
   
    var baslik = $("#Baslik").val();
    var altbaslik = $("#AltBaslik").val();
    var icerik = $("#Icerik").val();
    var konuad = $("#KonuAdi").val();

    var kullaniciad = $("#sessiondeger").val();

if(document.getElementById('Resim').files[0]==null){
var filename="bos";
}else{
var filename = document.getElementById('Resim').files[0].name;
}

  var emp = {
        "Baslik": baslik,
        "AltBaslik":altbaslik,
        "Icerik": icerik,
        "KullaniciAdi": kullaniciad,
        "KonuIdi": konuad,
        "Resim": filename
    };

    $.ajax({
        method: "POST",
        url: "http://localhost:63698/api/KullaniciMakaleler/PostPaylasilanBlogEkle",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data:JSON.stringify(emp),
  success: function (data) {
alert("Ekleme Başarılı");
window.location="http://localhost:63698/Kullanici/BlogPaylasimlar";
    },
error:function (data) {
       alert("Bir Hata Oluştu");
    }
});
});