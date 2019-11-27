//-------------------日曆-----------------------//
$(function () {
    $("#flatpickr").flatpickr({
        maxDate: "today",
        theme: "dark"
    })
});

//-------------------Toggle-----------------------//
$(function () {
    $('#detail-toggle').on("click", function () {
        $('.option-detail').toggle("display", "block")
    });
});

//-------------------Scroll-----------------------//
$(window).scroll(function () {
    var Card = $(window).scrollTop()
    var Width = $(window).width();
    if (Card < 350) {
        $("#booking-bar").css("position", "initial")
        $("#booking-bar").css("top", "0px")
    }
    if (Card >= 350) {
        $("#booking-bar").css("position", "fixed")
        $("#booking-bar").css("top", "105px")
    }
    if (Width < 1200) {
        $("#booking-bar").css("position", "initial")
        $("#booking-bar").css("top", "0px")
    }
});