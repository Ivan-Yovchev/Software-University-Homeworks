var app = app || {};

(function() {
    var rootUrl = 'https://api.parse.com/1/';
    var dataPersister = new app.dataPersister(rootUrl);
    var selector = "#wrapper";

    app.router = Sammy(function() {
        this.before(function() {
            var currentUser = app.userSession.getCurrentUser();
            if (currentUser) {
                $("#menu").show();
            } else {
                $("#menu").hide();
            }
        });

        this.get("#/", function() {
            var currentUser = app.userSession.getCurrentUser();
            if (currentUser) {
                app.router.setLocation("#/user/home");
            } else {
                setTitle("Welcome");
                $(selector).load("./templates/default-welcome-screen.html");
            }
        });

        this.get("#/user/home", function() {
            setTitle("Home");
            var currentUser = app.userSession.getCurrentUser();
            var user = { name: currentUser.username };
            if (currentUser.fullName) {
                user = { name: currentUser.fullName + ' (' + currentUser.username + ')' };
            }
            $.get('templates/user-home.html', function (template) {
                var output = Mustache.render(template, user);
                $(selector).html(output);
            });
        });

        this.get("#/register", function () {
            setTitle("Register");
            $(selector).load("./templates/registration-screen.html");
        });

        this.get("#/login", function () {
            setTitle("Login");
            $(selector).load("./templates/login-screen.html");
        });

        this.get("#/logout", function () {
            dataPersister.users.logout();
            app.router.setLocation("#/");
        });

        this.get("#/user/phonebook", function () {
            setTitle("List");
            dataPersister.phones.getAll(function(data) {
                $.get("./templates/phonebook-screen.html", function(template) {
                    var result = Mustache.render(template, data);
                    $(selector).html(result);
                });
            }, function(error) {
                console.log(error);
                app.router.setLocation("#/");
            });
        });

        this.get("#/add-phone", function () {
            setTitle("Add Phone");
            $(selector).load("./templates/add-phone-screen.html");
        });

        this.get("#/user/add-phone", function () {
            app.router.setLocation("#/add-phone");
        });

        this.get("#/user/edit-profile", function () {
            setTitle("Edit Profiles");
            var currentUser = app.userSession.getCurrentUser();
            dataPersister.users.getById(currentUser.objectId, function (data) {
                $.get("./templates/edit-profile-screen.html", function(template) {
                    var output = Mustache.render(template, data);
                    $(selector).html(output);
                });
            }, function(error) {
                console.log(error);
            });
        });

        this.get("#/user/edit-phone/:objectId", function () {
            setTitle("Edit Phone");
            var objectId = this.params["objectId"];
            dataPersister.phones.getById(objectId, function (data) {
                $.get("./templates/edit-phone-screen.html", function(template) {
                    var output = Mustache.render(template, data);
                    $(selector).html(output);
                });
            }, function(error) {
                console.log(error);
                app.router.setLocation("#/");
            });
        });

        this.get("#/user/delete-phone/:objectId", function () {
            setTitle("Delete Phone");
            var objectId = this.params["objectId"];
            dataPersister.phones.getById(objectId, function (data) {
                $.get("./templates/delete-phone-screen.html", function (template) {
                    var output = Mustache.render(template, data);
                    $(selector).html(output);
                });
            }, function (error) {
                console.log(error);
                app.router.setLocation("#/");
            });
        });

        this.get("#/do-register", function () {
            var username = $("#username").val(),
                password = $("#password").val(),
                fullName = $("#fullName").val();

            dataPersister.users.register(username, password, fullName,
                function(data) {
                    app.router.setLocation("#/user/home");
                }, function(error) {
                    app.router.setLocation("#/register");
                });
        });

        this.get("#/do-login", function () {
            var username = $("#username").val(),
                password = $("#password").val();

            dataPersister.users.login(username, password,
                function(data) {
                    app.router.setLocation("#/user/home");
                }, function(error) {
                    app.router.setLocation("#/login");
                });
        });

        this.get("#/do-add-phone", function () {
            var name = $("#personName").val(),
                number = $("#phoneNumber").val();

            var currentUser = app.userSession.getCurrentUser();
            var phone = {
                person: name,
                number: number
            };
            dataPersister.phones.add(phone, currentUser.objectId, function(data) {
                app.router.setLocation("#/user/phonebook");
            }, function(error) {
                console.log(error);
                app.router.setLocation("#/");
            });
        });

        this.get("#/do-cancel-phone", function () {
            app.router.setLocation("#/user/phonebook");
        });

        this.get("#/user/do-edit-phone", function () {
            var objectId = $("#edit-phone-form").attr("data-id");
            var person = $("#personName").val(),
                number = $("#phoneNumber").val();

            var phone = {
                objectId: objectId,
                person: person,
                number: number
            };

            dataPersister.phones.update(phone, function(data) {
                app.router.setLocation("#/user/phonebook");
            }, function(error) {
                app.router.setLocation("#/");
            });
        });

        this.get("#/user/cancel-edit-phone", function () {
            app.router.setLocation("#/user/phonebook");
        });

        this.get("#/user/do-delete-phone", function () {
            var objectId = $("#delete-phone-form").attr("data-id");
            dataPersister.phones.delete(objectId, function(data) {
                app.router.setLocation("#/user/phonebook");
            }, function(error) {
                app.router.setLocation("#/");
            });
        });

        this.get("#/user/cancel-delete-phone", function () {
            app.router.setLocation("#/user/phonebook");
        });

        this.get("#/user/do-edit-profile", function () {
            var username = $("#username").val(),
                password = $("#password").val(),
                fullName = $("#fullName").val();
            var currentUser = app.userSession.getCurrentUser();
            var user = {
                username: username,
                password: password,
                objectId: currentUser.objectId
            };

            dataPersister.users.editProfile(user, function (data) {
                dataPersister.users.logout();
                app.router.setLocation("#/");
            }, function(error) {
                console.log(error);
            });
        });
    });

    function setTitle(title) {
        $("#header span").text(" - " + title);
    }

    app.router.run("#/");
}());