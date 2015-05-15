var app = app || {};

app.controller = (function () {
    function Controller(dataPersister) {
        this.dataPersister = dataPersister;
    }

    Controller.prototype.loadNavMenu = function(selector) {
        var currentUser = app.userSession.getCurrentUser();
        if (currentUser) {
            $(selector).show();
        } else {
            $(selector).hide();
        }
    }

    Controller.prototype.loadWelcomeScreen = function(selector) {
        $(selector).load("./templates/welcome.html");
    }

    Controller.prototype.loadLoginScreen = function (selector) {
        $(selector).load("./templates/login.html");
    }

    Controller.prototype.loadRegisterScreen = function (selector) {
        $(selector).load("./templates/register.html");
    }

    Controller.prototype.loadUserHomeScreen = function(selector) {
        var currentUser = app.userSession.getCurrentUser();
        if (!currentUser) {
            Noty.error("You have to login first");
            app.router.setLocation("#/");
        } else {
            this.dataPersister.users.getUserById(currentUser.objectId)
                .then(function(data) {
                    $.get("./templates/home.html", function(template) {
                        var output = Mustache.render(template, data);
                        $(selector).html(output);
                    });
                }, function(error) {
                    Noty.error("Could not load home page. Please try again.");
                });
        }
    }

    Controller.prototype.loadAddNoteScreen = function (selector) {
        var currentUser = app.userSession.getCurrentUser();
        if (!currentUser) {
            Noty.error("You have to login first");
            app.router.setLocation("#/");
        } else {
            $(selector).load("./templates/addNote.html");
        }
    }

    Controller.prototype.loadMyNotesScreen = function (selector, pageNumber) {
        var currentUser = app.userSession.getCurrentUser();
        if (!currentUser) {
            Noty.error("You have to login first");
            app.router.setLocation("#/");
        } else {
            this.dataPersister.notes.getAllMyNotes(pageNumber)
                .then(function(data) {
                    $.get("./templates/myNoteTemplate.html", function(template) {
                        var output = Mustache.render(template, data);
                        $(selector).html(output);
                        $("#pagination").pagination({
                            items: data.count,
                            itemsOnPage: 10,
                            cssStyle: 'light-theme',
                            hrefTextPrefix: "#/myNotes/"
                        }).pagination('selectPage', pageNumber);
                    });
                }, function(error) {
                    Noty.error("Could not load my notes. Please try again.");
                });
        }
    }

    Controller.prototype.loadEditMyNote = function (selector, objectId) {
        this.dataPersister.notes.getNoteById(objectId)
            .then(function (data) {
                $.get("./templates/editNote.html", function (template) {
                    var output = Mustache.render(template, data);
                    $(selector).html(output);
                });
            }, function (error) {
                Noty.error("Could not get data for selected note. Please try again.");
            });
    }

    Controller.prototype.loadDeleteMyNote = function(selector, objectId) {
        this.dataPersister.notes.getNoteById(objectId)
            .then(function(data) {
                $.get("./templates/deleteNote.html", function(template) {
                    var output = Mustache.render(template, data);
                    $(selector).html(output);
                });
            }, function(error) {
                Noty.error("Could not get data for selected note. Please try again.");
            });
    }

    Controller.prototype.loadOfficeNotesScreen = function (selector, pageNumber) {
        var currentUser = app.userSession.getCurrentUser();
        if (!currentUser) {
            Noty.error("You have to login first");
            app.router.setLocation("#/");
        } else {
            this.dataPersister.notes.getAllOfficeNotes(pageNumber)
            .then(function (data) {
                $.get("./templates/officeNoteTemplate.html", function (template) {
                    var output = Mustache.render(template, data);
                    $(selector).html(output);
                    $("#pagination").pagination({
                        items: data.count,
                        itemsOnPage: 10,
                        cssStyle: 'light-theme',
                        hrefTextPrefix: "#/office/"
                    }).pagination('selectPage', pageNumber);
                });
            }, function (error) {
                Noty.error("Could not load office notes. Please try again.");
            });
        }
    }

    Controller.prototype.logout = function() {
        this.dataPersister.users.logout()
            .then(function(data) {
                app.router.setLocation("#/");
                Noty.success("Successfully logged out");
            }, function(error) {
                Noty.error("Could not log out. Please try again.");
            });
    };

    var attachRegisterListener = function(selector) {
        var _this = this;
        $(selector).on("click", "#registerButton", function () {
            var username = $("#username").val(),
                password = $("#password").val(),
                fullName = $("#fullName").val();

            _this.dataPersister.users.register(username, password, fullName)
                .then(function(data) {
                    Noty.success("Registration successful");
                    app.router.setLocation("#/home/");
                }, function(error) {
                    Noty.error("Registration has encountered an error. Please try again.");
                    app.router.setLocation("#/");
                });
        });
    }

    var attachLoginListener = function (selector) {
        var _this = this;
        $(selector).on("click", "#loginButton", function () {
            var username = $("#username").val(),
                password = $("#password").val();

            _this.dataPersister.users.login(username, password)
                .then(function(data) {
                    app.router.setLocation("#/home/");
                    Noty.success("Successfully logged in");
                }, function(error) {
                    Noty.error("Could not log in. Please try again.");
                    app.router.setLocation("#/");
                });
        });
    }

    var attachAddNoteListener = function (selector) {
        var _this = this;
        $(selector).on("click", "#addNoteButton", function () {
            var title = $("#title").val(),
                text = $("#text").val(),
                deadline = $("#deadline").val();

            var currentUser = app.userSession.getCurrentUser();
            var note = {
                title: title,
                text: text,
                deadline: deadline,
                author: currentUser.fullName
            };

            return _this.dataPersister.notes.add(note, currentUser.objectId)
                .then(function(data) {
                    Noty.success("Successfully added new note");
                    app.router.setLocation("#/myNotes/1");
                }, function(error) {
                    Noty.error("Could not add new note. Please try again");
                    app.router.setLocation("#/home/");
                });
        });
    }

    var attachSelectNoteForEditListener = function (selector) {
        $(selector).on("click", ".edit", function () {
            var objectId = $(this).closest("li").attr("data-id");
            app.router.setLocation("#/myNotes/edit/" + objectId + "/");
        });
    }

    var attachEditNoteListener = function (selector) {
        var _this = this;
        $(selector).on("click", "#editNoteButton", function () {
            var objectId = $("#edit-note").attr("data-id");
            var title = $("#title").val(),
                text = $("#text").val(),
                deadline = $("#deadline").val();
            var currentUser = app.userSession.getCurrentUser();

            var note = {
                title: title,
                text: text,
                deadline: deadline,
                auhtor: currentUser.objectId,
                objectId: objectId
            }

            return _this.dataPersister.notes.update(note)
                .then(function(data) {
                    Noty.success("Successfully updated note.");
                    app.router.setLocation("#/myNotes/1");
                }, function(error) {
                    Noty.error("Could not update note. Please try again");
                    app.router.setLocation("#/myNotes/1");
                });
        });
    }

    var attachSelectNoteForDeleteListener = function(selector) {
        $(selector).on("click", ".delete", function () {
            var objectId = $(this).closest("li").attr("data-id");
            app.router.setLocation("#/myNotes/delete/" + objectId + "/");
        });
    }

    var attachDeleteNoteListener = function(selector) {
        var _this = this;
        $(selector).on("click", "#deleteNoteButton", function () {
            var objectId = $("#delete-note").attr("data-id");

            return _this.dataPersister.notes.delete(objectId)
                .then(function(data) {
                    Noty.success("Successfully deleted note.");
                    app.router.setLocation("#/myNotes/1");
                }, function(error) {
                    Noty.error("Could not delete note. Please try again");
                    app.router.setLocation("#/myNotes/1");
                });
        });
    }

    Controller.prototype.attachEventListeners = function(selector) {
        attachRegisterListener.call(this, selector);
        attachLoginListener.call(this, selector);
        attachAddNoteListener.call(this, selector);
        attachSelectNoteForEditListener.call(this, selector);
        attachEditNoteListener.call(this, selector);
        attachSelectNoteForDeleteListener.call(this, selector);
        attachDeleteNoteListener.call(this, selector);
    }

    return {
        getController: function (dataPersister) {
            return new Controller(dataPersister);
        }
    }
}());