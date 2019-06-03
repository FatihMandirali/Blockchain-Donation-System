$(document).on('click','#btnBegen',function(){
var session=$('#sessionDeger').val();


if(session==''){
alert("Lütfen Giriş Yaptıktan Sonra Bağış Yapınız.");
}else{
    var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];

    var emp = {
        "Slug": secondLevelLocation,
        "KullaniciAdi": session
    };
    
       $.ajax({
        method: "POST",
        url: "http://localhost:63698/api/KullaniciMakaleler/PostBegen",
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

$(document).on('click','#btnBagisYolla',function(){

var bagistutar=$('#txtBagisTutar').val();
var session=$('#sessionDeger').val();
var pathArray = window.location.pathname.split('/');
var secondLevelLocation = pathArray[3];
var bitd=$('#bitcoindeger').val();
var dolard=$('#dolardeger').val();
var dolarkarsi=bagistutar/dolard;
var coinkarsi=dolarkarsi/bitd;
//alert(Number(dolarkarsi.toFixed(2))+" a");
//alert(Number(coinkarsi.toFixed(6))+" a");
if(bagistutar=='')
alert("Lütfen bağış tutarı girin");
else{

  var emp = {
        "KullaniciAdi": session,
        "BagisTutari": coinkarsi.toFixed(6),
        "YapilanMakale":secondLevelLocation,
        "Tl":bagistutar
    };

    $.ajax({
        method: "POST",
        url: "http://localhost:63698/api/KullaniciMakaleler/PostBagisYap",
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
