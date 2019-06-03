$(document).on("click", "#btnOdemeAl", function () {
   
    var tutar = $("#tutar").val();
    var kullanici = $("#sessiondeger").val();
    var bitd=$('#bitcoindeger').val();
    var dolard=$('#dolardeger').val();
    var dolarkarsi=tutar/dolard;
    var coinkarsi=dolarkarsi/bitd;
  var emp = {
        "KullaniciAdi": kullanici,
        "GelenPara":coinkarsi.toFixed(6),
        "Tl":tutar
    };

    $.ajax({
        method: "POST",
        url: "http://localhost:63698/api/Kullanicilar/PostKullaniciOdemeAl",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data:JSON.stringify(emp),
  success: function (data) {
alert(data.mesaj);
window.location="http://localhost:63698/Kullanici/OdemeAl";
    },
error:function (data) {
       alert("Bir Hata Oluştu");
    }
});
});