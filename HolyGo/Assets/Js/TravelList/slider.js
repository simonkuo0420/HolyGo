$(function () {
    $("#slider").slider({
        range: true,
        min: 0,
        max: 19999,
        values: [700, 9999],
        slide: function (event, ui) {
            $("#sidebar-price").val("$" + ui.values[0] + " ~ $" + ui.values[1]);
            $("#MaxCost").val(ui.values[1]);
            $("#MinCost").val(ui.values[0]);
        }
    });
    $("#sidebar-price").val("$" + $("#slider").slider("values", 0) + " ~ $" + $("#slider").slider("values", 1));
});