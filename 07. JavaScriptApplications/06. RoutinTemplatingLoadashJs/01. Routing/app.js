$(function() {
    var router = Sammy(function() {
        var selector = "#greeting";

        this.get("/#/", function () {
            var welcomeText = $("<h2>").text("Welcome! This is the routers' main page. Please select a name.");
            $(selector).html(welcomeText);
        });

        this.get("/#/Bob", function() {
            var heading = createHeading("Bob");
            $(selector).html(heading);
        });

        this.get("/#/Sam", function () {
            var heading = createHeading("Sam");
            $(selector).html(heading);
        });

        this.get("/#/Pesho", function () {
            var heading = createHeading("Pesho");
            $(selector).html(heading);
        });
    });

    router.run("/#/");

    function createHeading(name) {
        return $("<h2>").text("Hello, " + name + "!");
    }
});