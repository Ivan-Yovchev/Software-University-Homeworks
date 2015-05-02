var app = app || {};

app.controller = (function () {
    function controller(dataPersister) {
        this.dataPersister = dataPersister;
    }

    controller.prototype.loadHeader = function(selector) {
        var currentUser = app.userSession.getCurrentUser();
        if (currentUser) {
            return this.dataPersister.users.getUserById(currentUser.objectId)
                .then(function(data) {
                    $.get("./templates/user-header.html", function(template) {
                        var output = Mustache.render(template, data);
                        $(selector).show();
                        $(selector).html(output);
                    });
                });
        } else {
            $(selector).hide();
        }
    }

    controller.prototype.loadHomePage = function (selector) {
        var currentUser = app.userSession.getCurrentUser();
        if (currentUser) {
            this.dataPersister.posts.getAll()
                .then(function(data) {
                    $.get("./templates/posts.html", function(template) {
                        var output = Mustache.render(template, data);
                        $(selector).html(output);
                    });
                });
        } else {
            $(selector).load("./templates/guest-home.html");
        }
    }

    controller.prototype.loadRegisterPage = function (selector) {
        $(selector).load("./templates/register.html");
    }

    controller.prototype.loadLoginPage = function (selector) {
        $(selector).load("./templates/login.html");
    }

    controller.prototype.loadEditProfilePage = function(selector) {
        var currentUser = app.userSession.getCurrentUser();
        if (!currentUser) {
            app.router.setLocation("#/");
        }

        return this.dataPersister.users.getUserById(currentUser.objectId)
            .then(function(data) {
                $.get("./templates/edit-profile.html", function(template) {
                    var output = Mustache.render(template, data),
                        gender = data.gender;
                    $(selector).html(output);
                    $('input[type="radio"][value=' + gender + ']')
                        .attr('checked', true);
                });
            }, function(error) {
                Noty.error("Could not load current user. Please try again");
            });
    }

    controller.prototype.logout = function() {
        this.dataPersister.users.logout();
        Noty.success("Successfully logged out");
        app.router.setLocation("#/");
    }

    var attachPictureUploadEvent = function (selector) {
        $(selector).on('click', '#upload-file-button', function () {
            $('#picture').click();
        });

        $(selector).on('change', '#picture', function () {
            var file = this.files[0];
            if (file.type.match(/image\/.*/)) {
                var reader = new FileReader();
                reader.onload = function () {
                    $('.picture-name').text(file.name);
                    $('.picture-preview').attr('src', reader.result);
                    $('#picture').attr('data-picture-data', reader.result);
                };
                reader.readAsDataURL(file);
            } else {
                Noty.error("Invalid file format.");
            }
        });
    }

    var attachRegisterListener = function (selector) {
        var _this = this;
        $(selector).on('click', '#reg-btn', function () {
            var userRegData = {
                username: $('#reg-username').val(),
                password: $('#reg-password').val(),
                name: $('#reg-name').val(),
                about: $('#reg-about').val(),
                gender: $('input[name="gender-radio"]:checked').val(),
                picture: $('#picture').attr('data-picture-data')
            };

            _this.dataPersister.users.register(userRegData)
                .then(function(data) {
                    Noty.success("Registration successful.");
                    app.router.setLocation("#/user/home");
                }, function(error) {
                    Noty.error("Registration has encountered an error");
                });
        });
    }

    var attachLoginListener = function (selector) {
        var _this = this;
        $(selector).on('click', '#log-btn', function () {
            var username = $("#login-username").val(),
                password = $("#login-password").val();

            _this.dataPersister.users.login(username, password)
                .then(function(data) {
                    Noty.success("Successfully logged in");
                    app.router.setLocation("#/user/home");
                }, function(error) {
                    Noty.error("Error during login. Plase try again.");
                });
        });
    }

    var attachCancelEditListener = function(selector) {
        $(selector).on("click", ".cancel-btn", function () {
            app.router.setLocation("#/user/home");
        });

    }

    var attachEditListener = function (selector) {
        var _this = this;
        $(selector).on("click", "#save-edit", function () {
            var currentUser = app.userSession.getCurrentUser();
            var userData = {
                username: $('#username').val(),
                password: $('#password').val(),
                name: $('#name').val(),
                about: $('#about').val(),
                gender: $('input[name="gender-radio"]:checked').val(),
                picture: $('#picture').attr('data-picture-data')
            };

            return _this.dataPersister.users.editProfile(currentUser.objectId, userData)
                .then(function(data) {
                    _this.dataPersister.users.login(data.username, data.password)
                        .then(function(data) {
                            Noty.success("Successfully edited profile");
                            app.router.setLocation("#/user/home");
                        }, function(error) {
                            Noty.error("Error during edit. Plase try again.");
                        });
                }, function(error) {
                    Noty.error("Error. Could not update profile");
                });
        });

    }

    var attachShowPostHandler = function (selector) {
        $(selector).on('click', '#post-btn', function () {
            app.router.setLocation("#/user/home");
            var container = $('#post-container');
            container.is(':visible') ? container.slideUp() : container.slideDown();
        });
    }

    var attachCommitNewPost = function (selector) {
        var _this = this;
        $(selector).on("click", "#post", function () {
            var content = $("#content").val();
            var currentUser = app.userSession.getCurrentUser();
            var post = {
                content: content,
                createdBy: {
                    __type: "Pointer",
                    className: "_User",
                    objectId: currentUser.objectId
                }
            };

            return _this.dataPersister.posts.add(post, currentUser.objectId)
                .then(function(data) {
                    Noty.success("Successfylly added new post");
                    _this.loadHomePage(selector);
                }, function(error) {
                    Noty.error("Could not add new post");
                });
        });
    }

    var attachHoverHandler = function (selector) {
        var _this = this;
        $(selector).on('mouseenter', '.profile-link', function () {
            var thisPerson = this,
                id = $(thisPerson).attr('data-user-id');

            var offset = $(thisPerson).offset();
            $('.hover-box')
                .css({
                    top: offset.top + 30,
                    left: offset.left + 10
                })
                .show();

            _this.dataPersister.users.getUserById(id)
                .then(function(data) {
                    $.get("./templates/hover-box.html", function(template) {
                        var output = Mustache.render(template, data);
                        $('.hover-box').html(output);
                    });
                }, function(error) {
                    Noty.error("Error retrieving data.");
                });
        });

        $(selector).on('mouseleave', '.profile-link', function () {
            $('.hover-box').html("<p>Loading...</p>");
            $('.hover-box').hide();
        });
    }

    controller.prototype.attachEventListeners = function () {
        var selector = '#main',
            headerSelector = '#header';

        attachPictureUploadEvent.call(this, selector);
        attachRegisterListener.call(this, selector);
        attachLoginListener.call(this, selector);
        attachCancelEditListener.call(this, selector);
        attachEditListener.call(this, selector);
        attachShowPostHandler.call(this, headerSelector);
        attachCommitNewPost.call(this, selector);
        attachHoverHandler.call(this, selector);
    }

    return {
        getController: function (dataPersister) {
            return new controller(dataPersister);
        }
    }
}());