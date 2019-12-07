//-------------------日曆-----------------------//
$(function () {
    $("#flatpickr").flatpickr({
        minDate: new Date().fp_incr(5),
        maxDate: new Date().fp_incr(180),
        theme: "dark"
    })
});
//-------------------Toggle-----------------------//
// $(function() {
//     $('.detail-toggle').on("click", function() {
//         $('.option-detail').toggle("display", "block")
//     });
// });

$(function () {
    $('.detail-toggle').on("click", function () {
        $(this).next().toggle("display", "block");
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

//-------------------Data-----------------------//
//$(function () {
//    $('.select-option').click(function () {
//        var date = $('#flatpickr').val();
//        if (date == "") {
//            $('#flatpickr').focus();
//        }
//        if (date != "") {
//            $('.lowest-price').css('display', 'none');
//            $('.booking-hint').css('display', 'none');
//            $('.view-option').css('display', 'block');
//            $('.booking-price').css('display', 'block');
//        }
//        // var x = $(this).parent().index();
//        var x = $(this).parent().index();
//        var title = $(".option-item").find(".option-title").eq(x).text();
//        var cost = $(".option-item").find(".product-pricing>h4").eq(x).text();
//        $('#booking-title').text(title);
//        $('#booking-date').text(date);
//        $('#booking-cost').text(cost);
//        $('#flatpickr').click(function () {
//            $('#booking-title').text("請選擇行程");
//            $('#booking-date').text("YYYY-MM-DD");
//            $('#booking-cost').text("0");
//        });
//    });
//});
$(function () {
    $('.select-option').click(function () {
        var date = $('#flatpickr').val();
        var x = $(this).parent().index();
        if (date == "") {
            $('#flatpickr').focus();
        }
        if (date != "") {
            $('.lowest-price').css('display', 'none');
            $('.booking-hint').css('display', 'none');
            $('.view-option').css('display', 'block');
            $('.booking-price').css('display', 'block');
        }
        // var x = $(this).parent().index();
        var x = $(this).parent().index();
        var title = $(".option-item").find(".option-title").eq(x).text();
        var cost = $(".option-item").find(".product-pricing>h4").eq(x).text();
        $('#booking-title').text(title);
        $('#booking-date').text(date);
        $('#booking-cost').text(cost);
    });
    $('#flatpickr').click(function () {
        $('#booking-date').text("");
        $('#booking-title').text("");
        $('#booking-cost').text("");
    });
    //$('#BookNow').click(function () {
    //    var date = $('#flatpickr').val();
    //    if (date == "") {
    //        $('#flatpickr').focus();
    //    }
    //});
});