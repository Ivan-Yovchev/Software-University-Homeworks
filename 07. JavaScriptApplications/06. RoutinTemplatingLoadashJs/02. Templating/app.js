$(function() {
    function getData() {
        $("table").hide();

        $.ajax({
            method: "GET",
            headers: {
                "X-Parse-Application-Id": "LENsmbpEa6UFKkYfmqogm98YntrtXSYpQ8eQvY2c",
                "X-Parse-REST-API-Key": "cU274jg8hhy01xeIgsLR82GOsfQ6ZeWdqacuX4HH"
            },
            url: "https://api.parse.com/1/classes/Table/",
            contentType: "application/json",
            success: function (data) {
                $("table").show();
                $.get('row-template.html', function(template) {
                    data['results'].forEach(function(person) {
                        var row = Mustache.render(template, person);
                        $("#data").append(row);
                    });
                });
            },
            error: function(error) {
                console.log(error);
            }
        });
    }

    getData();
});