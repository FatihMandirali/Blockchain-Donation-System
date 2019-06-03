

$(document).on("click", "#personelEkle", function () {
   
    var ad = $("#Adi").val();
    var soyad = $("#Soyadi").val();
    var tc = $("#Tc").val();
    var telefon = $("#Telefon").val();
    var kullaniciAdi = $("#KullaniciAdi").val();
    var sifre = $("#Sifre").val();
    var email = $("#EMail").val();

   var emp = {
        "Ad": ad,
        "Soyad": soyad,
        "Tc": tc,
        "Telefon": telefon,
        "Email": email,
        "KullaniciAdi": kullaniciAdi,
        "Sifre": sifre
    };

    $.ajax({
        method: "POST",
        url: "http://localhost:63698/api/Personeller/PostPersonelEkle",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data:JSON.stringify(emp),
  success: function (data) {
    },
error:function (data) {
       
    }
});
});

