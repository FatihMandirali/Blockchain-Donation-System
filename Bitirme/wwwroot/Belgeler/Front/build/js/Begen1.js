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
