$('#paint').on('click', function () {
    var classSelected = "." + $('#getClass').val();
    var color = $('#getColor').val();
    $(classSelected).css('background-color', color);
});