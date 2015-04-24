var app = app || {};

(function () {
    var rootUrl = 'https://api.parse.com/1/classes/';
    var dataPersister = app.dataPersister.getPersister(rootUrl);
    var controller = app.controller.getController(dataPersister);

    app.router = Sammy(function() {
        this.get('/#/books/', function() {
            controller.load("#books-on-display");
        });
    });

    app.router.run('/#/books/');
}())