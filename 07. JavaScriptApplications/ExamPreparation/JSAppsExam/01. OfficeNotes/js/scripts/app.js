var app = app || {};

(function () {
    var rootUrl = 'https://api.parse.com/1/';
    var dataPersister = app.dataPersister.getDataPersister(rootUrl);
    var controller = app.controller.getController(dataPersister);
    app.router = Sammy(function () {
        var menu = "#menu";
        var container = "#container";
        controller.attachEventListeners(container);

        this.get("#/", function () {
            controller.loadNavMenu(menu);
            controller.loadWelcomeScreen(container);
        });

        this.get("#/login/", function () {
            controller.loadNavMenu(menu);
            controller.loadLoginScreen(container);
        });

        this.get("#/register/", function () {
            controller.loadNavMenu(menu);
            controller.loadRegisterScreen(container);
        });

        this.get("#/home/", function () {
            controller.loadNavMenu(menu);
            controller.loadUserHomeScreen(container);
        });

        this.get("#/addNote/", function () {
            controller.loadNavMenu(menu);
            controller.loadAddNoteScreen(container);
        });

        this.get("#/myNotes/:page", function () {
            var number = parseInt(this.params['page']);
            controller.loadNavMenu(menu);
            controller.loadMyNotesScreen(container, number);
        });

        this.get("#/myNotes/edit/:objectId/", function () {
            var objectId = this.params['objectId'];
            controller.loadNavMenu(menu);
            controller.loadEditMyNote(container, objectId);
        });

        this.get("#/myNotes/delete/:objectId/", function () {
            var objectId = this.params['objectId'];
            controller.loadNavMenu(menu);
            controller.loadDeleteMyNote(container, objectId);
        });

        this.get("#/office/:page", function () {
            var number = parseInt(this.params['page']);
            controller.loadNavMenu(menu);
            controller.loadOfficeNotesScreen(container, number);
        });

        this.get("#/logout/", function () {
            controller.logout();
            controller.loadNavMenu(menu);
        });
    });

    app.router.run("#/");
}());