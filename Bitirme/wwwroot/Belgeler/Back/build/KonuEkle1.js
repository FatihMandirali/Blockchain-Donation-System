$(document).on("click", "#btnKonuEkle", function () {
   
    var konuAd = $("#KonuAdi").val();
    var res = $("#Resim").val();
if(document.getElementById('Resim').files[0]==null){
var filename="bos";
}else{
var filename = document.getElementById('Resim').files[0].name;
}
    var hak = $("#Hakkinda").val();
if(konuAd!="" && hak!=""){


    var konuId = $(this).attr('name');
    var integer = parseInt(konuId);
   var emp = {
        "KonuAdi": konuAd,
        "Resim": filename,
        "Hakkinda": hak,
        "Id":1
    };

    $.ajax({
        method: "POST",
        url: "http://localhost:63698/api/Konular/PostKonuEkle",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data:JSON.stringify(emp),
  success: function (data) {
alert("Ekleme Başarılı");
    },
error:function (data) {
       alert("Bir Hata Oluştu");
    }
});
}else{
alert("Lütfen boş yerleri doldurun.");
}
});