$(document).on("click", "#btnYorumYap", function () {
   
    var adSoyad = $("#cName").val();
    var mail = $("#cEmail").val();
    var msj = $("#cMessage").val();
    var pathArray = window.location.pathname.split('/');
    var secondLevelLocation = pathArray[3];
 //   var konuId = $(this).attr('name');
   // var integer = parseInt(konuId);
    if(adSoyad!="" && mail!="" && msj!=""){
   var emp = {
        "AdSoyad": adSoyad,
        "Mail": mail,
        "Mesaj": msj,
        "Slug":secondLevelLocation
    };

    $.ajax({
        method: "POST",
        url: "http://localhost:63698/api/Makaleler/PostYorumYap",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data:JSON.stringify(emp),
  success: function (data) {
alert(data.mesaj);
    },
error:function (data) {
       alert("Bir Hata Oluştu");
    }
});
}else{
alert("Boş yerleri doldurunuz.");
}
});