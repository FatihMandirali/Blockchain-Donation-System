$(document).on("click", "#KonuSil", function () {

 var konuId = $(this).attr('name');
var integer = parseInt(konuId);
    var emp = {
        "Id": integer
    };
    $.ajax({
        method: "POST",
        url: "http://localhost:63698/api/Konular/PostKonuSil",
         dataType: "json",
        contentType: "application/json; charset=utf-8",
        data:JSON.stringify(emp),
    }).done(function (response, statusText, jqXHR) {


           
            alert(response+"iki");
            window.location = "http://localhost:63698/Yonetim/Konular/";

      
    });
});