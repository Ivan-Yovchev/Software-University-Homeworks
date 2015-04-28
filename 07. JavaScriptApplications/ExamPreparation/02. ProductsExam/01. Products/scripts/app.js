var app = app || {};

(function() {
    var rootUrl = 'https://api.parse.com/1/';
    var dataPersister = app.dataPersister.getDataPersister(rootUrl);
    var controller = app.controller.getController(dataPersister);
    app.router = Sammy(function () {
        var selector = "#main";
        controller.attatchEventListeners(selector);

        this.get("#/", function() {
            controller.loadMenu();
            controller.loadGuestWelcomeScreen(selector);
        });

        this.get("#/login", function () {
            controller.loadMenu();
            controller.loadLoginScreen(selector);
        });

        this.get("#/register", function () {
            controller.loadMenu();
            controller.loadRegisterScreen(selector);
        });

        this.get("#/user/home", function () {
            controller.loadMenu();
            controller.loadUserWelcomeScreen(selector);
        });

        this.get("#/user/products", function () {
            controller.loadMenu();
            controller.loadProductsScreen(selector);
        });

        this.get("#/user/add-product", function () {
            controller.loadMenu();
            controller.loadAddProductScreen(selector);
        });

        this.get("#/user/cancel-add-product", function () {
            app.router.setLocation("#/user/products");
        });

        this.get("#/user/edit-product/:objectId", function () {
            var objectId = this.params['objectId'];
            controller.loadMenu();
            controller.loadEditProductScreen(objectId, selector);
        });

        this.get("#/user/cancel-edit", function () {
            app.router.setLocation("#/user/products");
        });

        this.get("#/user/delete-product/:objectId", function () {
            var objectId = this.params['objectId'];
            controller.loadMenu();
            controller.loadDeleteProductScreen(objectId, selector);
        });

        this.get("#/user/cancel-delete", function () {
            app.router.setLocation("#/user/products");
        });

        this.get("#/user/logout", function () {
            controller.logout();
            controller.loadMenu();
        });
    });

    app.router.run("#/");
}());