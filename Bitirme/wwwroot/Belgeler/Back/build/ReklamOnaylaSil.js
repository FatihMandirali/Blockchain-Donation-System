$(document).on("click", "#ReklamOnayla", function () {
   
    var ad = $(this).attr('name');

  var emp = {
        "Id": ad
    };

    $.ajax({
        method: "POST",
        url: "http://localhost:63698/api/KullaniciMakaleler/PostReklamOnayla/",
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

});

$(document).on("click", "#ReklamSil", function () {
   
    var ad = $(this).attr('name');

  var emp = {
        "Id": ad
    };

    $.ajax({
        method: "POST",
        url: "http://localhost:63698/api/KullaniciMakaleler/PostReklamSil/",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data:JSON.stringify(emp),
  success: function (data) {
alert(data.mesaj);
location.reload();

    },
error:function (data) {
       alert("Bir Hata Oluştu");
    }
});

});