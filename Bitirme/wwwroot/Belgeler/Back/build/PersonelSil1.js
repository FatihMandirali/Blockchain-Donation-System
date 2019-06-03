
$(document).on("click", "#PersonelSil", function () {
  alert("Tıklandı");
 var kullaniciAdi = $(this).attr('name');
    var emp = {
        "KullaniciAdi": kullaniciAdi
    };
alert(kullaniciAdi);
    $.ajax({
        method: "POST",
        url: "http://localhost:63698/api/Personeller/PostPersonelSil",
         dataType: "json",
        contentType: "application/json; charset=utf-8",
        data:JSON.stringify(emp),
    }).done(function (response, statusText, jqXHR) {


           
            alert(response);
            window.location = "http://localhost:63698/Yonetim/Personeller/";

      
    });
});