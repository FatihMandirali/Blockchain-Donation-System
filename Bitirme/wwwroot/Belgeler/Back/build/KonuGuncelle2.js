$(document).on("click", "#btnKonuDuzenle", function () {
   
    var konuAd = $("#KonuAdi").val();
if(document.getElementById('Resim').files[0]==null){
var filename="bos";
}else{
var filename = document.getElementById('Resim').files[0].name;
}
    

    var hak = $("#Hakkinda").val();
    var konuId = $(this).attr('name');
    var integer = parseInt(konuId);
if(konuAd!="" && hak!=""){

   var emp = {
        "KonuAdi": konuAd,
        "Resim": filename,
        "Hakkinda": hak,
        "Id":integer
    };

    $.ajax({
        method: "POST",
        url: "http://localhost:63698/api/Konular/PostKonuGuncelle",
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
}else{
alert("Lütfen boş yerleri doldurun.");
}
});