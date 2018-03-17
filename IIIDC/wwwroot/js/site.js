// Write your JavaScript code.
$(function (ready) {

    var y = $(window);

    window.addEventListener('scroll', function (e) {
        var x = $(y).scrollTop();
        if (x > 910 || (x > 165 && location.pathname == "/Contact-us")) {
            animatefooter();
        }
        else {
            $("#firstColumn").removeClass("animated fadeInRight");
            $("#thirdColumn").removeClass("animated fadeInLeft");
        }
       
    })
    function animatefooter() {
        $("#firstColumn").addClass("animated fadeInRight");
        $("#thirdColumn").addClass("animated fadeInLeft");
    }

    var items = $("li.nav-item > a");

    var str = location.pathname;
    console.log(str);
    for (i = 0; i < $(items).length; i++) {
        var eleme = $(items).get(i)
        var url = $(eleme).attr("href");
        if (url == str) {
            $(eleme).addClass("active");
        }
    }







});