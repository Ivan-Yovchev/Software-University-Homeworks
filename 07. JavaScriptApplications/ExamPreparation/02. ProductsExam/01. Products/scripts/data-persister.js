var app = app || {};

app.dataPersister = (function() {
    function Persister(rootUrl) {
        this.serviceUrl = rootUrl;
        this.users = new users(rootUrl);
        this.products = new products(rootUrl);
    }

    function getHeaders() {
        var headers = {
            'X-Parse-Application-Id': "2wHIHbFMDNeteCkOtoDXalMZUyVbBqLrCkg2GQZN",
            'X-Parse-REST-API-Key': "0DkdU18teeBWHwYTYl1uKjZCF7ed6lmqGO55NUTu"
        };
        var currentUser = app.userSession.getCurrentUser();
        if (currentUser) {
            headers['X-Parse-Session-Token'] = currentUser.sessionToken;
        }

        return headers;
    }

    var users = (function() {
        function users(rootUrl) {
            this.serviceUrl = rootUrl;
        }

        users.prototype.login = function(username, password) {
            var url = this.serviceUrl + "login?username=" + username + "&password=" + password;
            return ajaxRequester.get(getHeaders(), url)
                .then(function(data) {
                    app.userSession.login(data);
                    return data;
                }, function(error) {
                    return error;
                });
        }

        users.prototype.logout = function () {
            app.userSession.logout();
        }

        users.prototype.register = function (username, password, repeatPassword) {
            var url = this.serviceUrl + "users";
                var user = {
                    username: username,
                    password: password
                };

                return ajaxRequester.post(getHeaders(), url, user)
                    .then(function(data) {
                        data.username = username;
                        app.userSession.login(data);
                        return data;
                    }, function(error) {
                        return error;
                    });
        }

        users.prototype.getUserById = function(objectId) {
            var url = this.serviceUrl + "users/" + objectId;
            return ajaxRequester.get(getHeaders(), url)
                .then(function(data) {
                    return data;
                }, function(error) {
                    return error;
                });
        }

        return users;
    }());

    var products = (function() {
        function products(rootUrl) {
            this.serviceUrl = rootUrl + "classes/Product";
        }

        products.prototype.getAll = function() {
            var url = this.serviceUrl;
            return ajaxRequester.get(getHeaders(), url)
                .then(function(data) {
                    return data;
                }, function(error) {
                    return error;
                });
        }

        products.prototype.getProductById = function (objectId) {
            var url = this.serviceUrl + "/" + objectId;
            return ajaxRequester.get(getHeaders(), url)
                .then(function (data) {
                    return data;
                }, function (error) {
                    return error;
                });
        }

        products.prototype.add = function (product, ownerId) {
            var url = this.serviceUrl;
            product.ACL = {};
            product.ACL[ownerId] = { "write": true, "read": true };
            product.ACL['*'] = { "read": true };
            return ajaxRequester.post(getHeaders(), url, product)
                .then(function (data) {
                    return data;
                }, function (error) {
                    return error;
                });
        }

        products.prototype.update = function (product) {
            var url = this.serviceUrl + "/" + product.objectId;
            return ajaxRequester.put(getHeaders(), url, product)
                .then(function (data) {
                    return data;
                }, function (error) {
                    return error;
                });
        }

        products.prototype.delete = function (objectId) {
            var url = this.serviceUrl + "/" + objectId;
            return ajaxRequester.delete(getHeaders(), url)
                .then(function (data) {
                    return data;
                }, function (error) {
                    return error;
                });
        }

        return products;
    }());

    return {
        getDataPersister: function(rootUrl) {
            return new Persister(rootUrl);
        }
    }
}());