$(document).on("click", "#aCikis", function () {
  
    $.ajax({
        method: "Get",
        url: "http://localhost:63698/api/Kullanicilar/KullaniciLoginClose",
         dataType: "json",
        contentType: "application/json; charset=utf-8",
    }).done(function (response, statusText, jqXHR) {


           if(response.durum==true)
            window.location = "http://localhost:63698/Home/Index/";
            else
            alert("Kullanıcı Adı veya Şifre Yanlış");

      
    });
});