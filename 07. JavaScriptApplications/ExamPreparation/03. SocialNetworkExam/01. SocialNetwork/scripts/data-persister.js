var app = app || {};

app.dataPersister = (function () {
    function Persister(rootUrl) {
        this.serviceUrl = rootUrl;
        this.users = new users(rootUrl);
        this.posts = new posts(rootUrl);
    }

    function getHeaders() {
        var headers = {
            'X-Parse-Application-Id': "EV1adwfoMjMITWUxtvKJj9HvLCy1rV2l3jVjqQJD",
            'X-Parse-REST-API-Key': "2s2KPfKDGu9IGwQLcX02oE5KmF693itAvFjsB1wM"
        };
        var currentUser = app.userSession.getCurrentUser();
        if (currentUser) {
            headers['X-Parse-Session-Token'] = currentUser.sessionToken;
        }

        return headers;
    }

    var users = (function () {
        function users(rootUrl) {
            this.serviceUrl = rootUrl;
        }

        users.prototype.login = function (username, password) {
            var url = this.serviceUrl + "login?username=" + username + "&password=" + password;
            return ajaxRequester.get(getHeaders(), url)
                .then(function (data) {
                    app.userSession.login(data);
                    return data;
                }, function (error) {
                    return error;
                });
        }

        users.prototype.logout = function () {
            app.userSession.logout();
        }

        users.prototype.register = function (user) {
            var url = this.serviceUrl + "users";

            return ajaxRequester.post(getHeaders(), url, user)
                .then(function (data) {
                    app.userSession.login(data);
                    return data;
                }, function (error) {
                    return error;
                });
        }

        users.prototype.getUserById = function (objectId) {
            var url = this.serviceUrl + "users/" + objectId;
            return ajaxRequester.get(getHeaders(), url)
                .then(function (data) {
                    return data;
                }, function (error) {
                    return error;
                });
        }

        users.prototype.editProfile = function (userId, userProfileData) {
            var url = this.serviceUrl + 'users/' + userId;

            return ajaxRequester.put(getHeaders(), url, userProfileData)
                .then(function(data) {
                    userProfileData.objectId = userId;
                    app.userSession.login(userProfileData);
                    return userProfileData;
                }, function(error) {
                    return error;
                });
        }

        return users;
    }());

    var posts = (function() {
        function posts(baseUrl) {
            this.serviceUrl = baseUrl + "classes/Post";
        }

        posts.prototype.getAll = function() {
            var url = this.serviceUrl + "?include=createdBy";
            return ajaxRequester.get(getHeaders(), url)
                .then(function(data) {
                    return data;
                }, function(error) {
                    return error;
                });
        }

        posts.prototype.getPostById = function (objectId) {
            var url = this.serviceUrl + "/" + objectId;
            return ajaxRequester.get(getHeaders(), url)
                .then(function (data) {
                    return data;
                }, function (error) {
                    return error;
                });
        }

        posts.prototype.add = function (post, ownerId) {
            post.ACL = {};
            post.ACL[ownerId] = { "write": true, "read": true };
            post.ACL['*'] = { "read": true };
            return ajaxRequester.post(getHeaders(), this.serviceUrl, post)
                .then(function(data) {
                    return data;
                }, function(error) {
                    return error;
                });
        }

        return posts;
    }());

    return {
        getDataPersister: function (rootUrl) {
            return new Persister(rootUrl);
        }
    }
}());