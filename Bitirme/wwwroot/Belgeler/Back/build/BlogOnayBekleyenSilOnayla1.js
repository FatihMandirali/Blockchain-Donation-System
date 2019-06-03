$(document).on("click", "#BlogOnayla", function () {

 var konuId = $(this).attr('name');
var integer = parseInt(konuId);
    var emp = {
        "Id": integer
    };
    $.ajax({
        method: "POST",
        url: "http://localhost:63698/api/KullaniciMakaleler/PostBlogOnaylanmamisOnayla",
         dataType: "json",
        contentType: "application/json; charset=utf-8",
        data:JSON.stringify(emp),
    }).done(function (response, statusText, jqXHR) {


           
            alert(response.mesaj);
            window.location = "http://localhost:63698/Yonetim/OnayBekleyenBloglar/";

      
    });
});

$(document).on("click", "#BlogSil", function () {

 var konuId = $(this).attr('name');
var integer = parseInt(konuId);
    var emp = {
        "Id": integer
    };
    $.ajax({
        method: "POST",
        url: "http://localhost:63698/api/KullaniciMakaleler/PostBlogOnaylanmamisSil",
         dataType: "json",
        contentType: "application/json; charset=utf-8",
        data:JSON.stringify(emp),
    }).done(function (response, statusText, jqXHR) {


           
            alert(response.mesaj);
            window.location = "http://localhost:63698/Yonetim/OnayBekleyenBloglar/";

      
    });
});
$(document).on("click", "#BlogOnaySil", function () {

 var konuId = $(this).attr('name');
var integer = parseInt(konuId);
    var emp = {
        "Id": integer
    };
    $.ajax({
        method: "POST",
        url: "http://localhost:63698/api/KullaniciMakaleler/PostBlogOnaylanmamisSil",
         dataType: "json",
        contentType: "application/json; charset=utf-8",
        data:JSON.stringify(emp),
    }).done(function (response, statusText, jqXHR) {


           
            alert(response.mesaj);
            window.location = "http://localhost:63698/Yonetim/OnaylananBloglar/";

      
    });
});