var app = app || {};

app.controller = (function() {
    function controller(dataPersister) {
        this.dataPersister = dataPersister;
    }

    controller.prototype.loadMenu = function() {
        var currentUser = app.userSession.getCurrentUser();
        if (currentUser) {
            $("#menu ul:first-child").hide();
            $("#menu ul:eq(1)").show();
        } else {
            $("#menu ul:first-child").show();
            $("#menu ul:eq(1)").hide();
        }
    }

    controller.prototype.loadGuestWelcomeScreen = function(selector) {
        $(selector).load("./templates/default-welcome-screen.html");
    }

    controller.prototype.loadUserWelcomeScreen = function (selector) {
        var currentUser = app.userSession.getCurrentUser();
        $.get("./templates/user-welcome-screen.html", function(template) {
            var output = Mustache.render(template, currentUser);
            $(selector).html(output);
        });
    }

    controller.prototype.loadLoginScreen = function(selector) {
        $(selector).load("./templates/login-screen.html");
    }

    controller.prototype.loadRegisterScreen = function (selector) {
        $(selector).load("./templates/registration-screen.html");
    }

    controller.prototype.loadProductsScreen = function (selector) {
        this.dataPersister.products.getAll()
            .then(function(data) {
                $.get("./templates/list-products-screen.html", function(template) {
                    var products = data.results,
                        categories = [],
                        userId = app.userSession.getCurrentUser();

                    products.forEach(function(product) {
                        if (product.ACL[userId.objectId]) {
                            product.showButtons = true;
                        }

                        categories[product.category] = product.category;
                    });

                    data.categories = Object.keys(categories)
                        .map(function(value, index) {
                            return value;
                        });

                    var output = Mustache.render(template, data);
                    $(selector).html(output);
                });
            });
    }

    controller.prototype.loadAddProductScreen = function (selector) {
        $(selector).load("./templates/add-product-screen.html");
    }

    controller.prototype.loadEditProductScreen = function(objectId, selector) {
        this.dataPersister.products.getProductById(objectId)
            .then(function(data) {
                $.get("./templates/edit-product-screen.html", function(template) {
                    var output = Mustache.render(template, data);
                    $(selector).html(output);
                });
            }, function(error) {
                console.log(error);
            });
    }

    controller.prototype.loadDeleteProductScreen = function (objectId, selector) {
        this.dataPersister.products.getProductById(objectId)
            .then(function (data) {
                $.get("./templates/delete-product-screen.html", function (template) {
                    var output = Mustache.render(template, data);
                    $(selector).html(output);
                });
            }, function (error) {
                console.log(error);
            });
    }

    controller.prototype.logout = function () {
        this.dataPersister.users.logout();
        Noty.success("Successfully logged out");
        app.router.setLocation("#/");
    }

    var registrationClick = function (selector) {
        var _this = this;
        $(selector).on("click", "#register-button", function () {
            var username = $("#username").val(),
                password = $("#password").val(),
                confirmPassword = $("#confirm-password").val();

            if (password !== confirmPassword) {
                Noty.error("Passwords must be identical.");
                $("input").val("");
                return;
            }

            return _this.dataPersister.users.register(username, password, confirmPassword)
                .then(function(data) {
                    Noty.success("Registration successful");
                    app.router.setLocation("#/user/home");
                }, function(error) {
                    Noty.error("Your registration has encountered an error.");
                });
        });
    }

    var loginClick = function (selector) {
        var _this = this;
        $(selector).on("click", "#login-button", function () {
            var username = $("#username").val(),
                password = $("#password").val();

            return _this.dataPersister.users.login(username, password)
                .then(function (data) {
                    app.router.setLocation("#/user/home");
                }, function (error) {
                    Noty.error("Incorrect username/password.");
                });
        });
    }

    var addProductClick = function (selector) {
        var _this = this;
        $(selector).on("click", "#add-product-button", function () {
            var productName = $("#name").val(),
                category = $("#category").val(),
                price = parseFloat($("#price").val());

            var product = {
                name: productName,
                category: category,
                price: price
            };

            var currentUser = app.userSession.getCurrentUser();

            return _this.dataPersister.products.add(product, currentUser.objectId)
                .then(function(data) {
                    app.router.setLocation("#/user/products");
                    Noty.success("Product successfully created!");
                }, function(error) {
                    Noty.error("Error creating product.");
                });
        });
    }

    var editProductClick = function (selector) {
        var _this = this;
        $(selector).on("click", "#edit-product-button", function() {
            var itemName = $("#item-name").val(),
                price = $("#price").val(),
                category = $("#category").val(),
                objectId = $(".data").attr("data-id");

            var product = {
                objectId: objectId,
                name: itemName,
                category: category,
                price: parseFloat(price)
            };

            _this.dataPersister.products.update(product)
                .then(function(data) {
                    Noty.success("Product successfully edited.");
                    app.router.setLocation("#/user/products");
                }, function(error) {
                    Noty.error("Error. Try again.");
                    app.router.setLocation("#/user/products");
                });
        });
    }

    var deleteProductClick = function (selector) {
        var _this = this;
        $(selector).on("click", "#delete-product-button", function () {
            var objectId = $(".data").attr("data-id");

            _this.dataPersister.products.delete(objectId)
                .then(function(data) {
                    Noty.success("Product successfully deleted.");
                    app.router.setLocation("#/user/products");
                }, function(error) {
                    Noty.error("Could not delete product.");
                    app.router.setLocation("#/user/products");
                });
        });
    }

    var filterProductsClick = function (selector) {
        var _this = this;
        $(selector).on('click', '#filter', function (e) {
            var keyword = $('#search-bar').val(),
                    minPrice = parseFloat($('#min-price').val()),
                    maxPrice = parseFloat($('#max-price').val()),
                    category = $('#category').val();

            $('div.products ul').children()
                .each(function (index) {
                    var self = $(this),
                        productName = self.attr('data-name'),
                        productPrice = parseFloat(self.attr('data-price')),
                        productCategory = self.attr('data-category');

                    if (productName.contains(keyword) &&
                        minPrice <= productPrice && maxPrice >= productPrice &&
                        (category === "All" || category === productCategory)) {
                        $(this).show();
                    } else {
                        $(this).hide();
                    }
                });
        });
    }

    var clearFilterClick = function (selector) {
        $(selector).on('click', '#clear-filters', function () {
            $('div.products ul').children()
                .each(function (index) {
                    $(this).show();
                });
        });
    }

    controller.prototype.attatchEventListeners = function(selector) {
        registrationClick.call(this, selector);
        loginClick.call(this, selector);
        addProductClick.call(this, selector);
        editProductClick.call(this, selector);
        deleteProductClick.call(this, selector);
        filterProductsClick.call(this, selector);
        clearFilterClick.call(this, selector);
    }

    String.prototype.contains = function (needle) {
        return this.toLowerCase().indexOf(needle.toLowerCase()) !== -1;
    }

    return {
        getController: function(dataPersister) {
            return new controller(dataPersister);
        }
    }
}());