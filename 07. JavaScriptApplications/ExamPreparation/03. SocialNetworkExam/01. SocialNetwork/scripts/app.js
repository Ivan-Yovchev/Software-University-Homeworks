var app = app || {};

(function () {
    var rootUrl = 'https://api.parse.com/1/';
    var dataPersister = app.dataPersister.getDataPersister(rootUrl);
    var controller = app.controller.getController(dataPersister);
    app.router = Sammy(function () {
        var header = "#header";
        var main = "#main";
        controller.attachEventListeners();

        this.get("#/", function() {
            controller.loadHeader(header);
            controller.loadHomePage(main);
        });

        this.get("#/register", function () {
            controller.loadHeader(header);
            controller.loadRegisterPage(main);
        });

        this.get("#/login", function () {
            controller.loadHeader(header);
            controller.loadLoginPage(main);
        });

        this.get("#/logout", function () {
            controller.logout();
        });

        this.get("#/user/home", function () {
            controller.loadHeader(header);
            controller.loadHomePage(main);
        });

        this.get("#/user/edit-profile", function () {
            controller.loadHeader(header);
            controller.loadEditProfilePage(main);
        });
    });

    app.router.run("#/");
}());