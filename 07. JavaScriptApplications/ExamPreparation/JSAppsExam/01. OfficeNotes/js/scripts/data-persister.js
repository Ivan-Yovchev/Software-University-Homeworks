var app = app || {};

app.dataPersister = (function () {
    function Persister(rootUrl) {
        this.serviceUrl = rootUrl;
        this.users = new Users(rootUrl);
        this.notes = new Notes(rootUrl);
    }

    function getHeaders() {
        var headers = {
            'X-Parse-Application-Id': "wc9E2GlU1gIHoG4qFHLYdHZmceyLsqwDm7VylPKl",
            'X-Parse-REST-API-Key': "otbXTBomEwK2YKsBDSZkwECBgqpbji5Ik4poOsY3"
        };
        var currentUser = app.userSession.getCurrentUser();
        if (currentUser) {
            headers['X-Parse-Session-Token'] = currentUser.sessionToken;
        }

        return headers;
    }

    function getCurrentDate() {
        var today = new Date();
        var day = today.getDate();
        var month = today.getMonth() + 1;

        var year = today.getFullYear();
        if (day < 10) {
            day = '0' + day;
        }
        if (month < 10) {
            month = '0' + month;
        }
        today = year + '-' + month + '-' + day;

        return today;
    }

    var Users = (function () {
        function Users(rootUrl) {
            this.serviceUrl = rootUrl;
        }

        Users.prototype.login = function (username, password) {
            var url = this.serviceUrl + "login?username=" + username + "&password=" + password;
            return ajaxRequester.get(getHeaders(), url)
                .then(function (data) {
                    app.userSession.login(data);
                    return data;
                }, function (error) {
                    return error;
                });
        }

        Users.prototype.logout = function () {
            var url = this.serviceUrl + "logout";
            return ajaxRequester.post(getHeaders(), url, null)
                .then(function (data) {
                    app.userSession.logout();
                    return data;
                }, function (error) {
                    return error;
                });
        }

        Users.prototype.register = function (username, password, fullName) {
            var url = this.serviceUrl + "users";
            var user = {
                username: username,
                password: password,
                fullName: fullName
            };

            return ajaxRequester.post(getHeaders(), url, user)
                .then(function(data) {
                    data.username = user.username;
                    data.fullName = user.fullName;
                    data.password = user.password;
                    app.userSession.login(data);
                    return data;
                }, function(error) {
                    return error;
                });
        }

        Users.prototype.getUserById = function (objectId) {
            var url = this.serviceUrl + "users/" + objectId;
            return ajaxRequester.get(getHeaders(), url)
                .then(function (data) {
                    return data;
                }, function (error) {
                    return error;
                });
        }

        return Users;
    }());

    var Notes = (function() {
        function Notes(baseUrl) {
            this.serviceUrl = baseUrl + "classes/Note";
        }

        Notes.prototype.getAllOfficeNotes = function (pageNumber) {
            var today = getCurrentDate();
            var url = this.serviceUrl + '?where={"deadline":"' + today + '"}'
            + "&count=1" + "&skip=" + ((pageNumber - 1) * 10) + "&limit=10";
            return ajaxRequester.get(getHeaders(), url)
                .then(function (data) {
                    return data;
                }, function(error) {
                    return error;
                });
        }

        Notes.prototype.getAllMyNotes = function(pageNumber) {
            var currentUser = app.userSession.getCurrentUser();
            var url = this.serviceUrl
                + '?where={"author":"' + currentUser.fullName + '"}'
                + "&count=1" + "&skip=" + ((pageNumber - 1) * 10) + "&limit=10";
            return ajaxRequester.get(getHeaders(), url)
                .then(function(data) {
                    return data;
                }, function(error) {
                    return error;
                });
        }

        Notes.prototype.getNoteById = function (objectId) {
            var url = this.serviceUrl + "/" + objectId;
            return ajaxRequester.get(getHeaders(), url)
                .then(function (data) {
                    return data;
                }, function (error) {
                    return error;
                });
        }

        Notes.prototype.add = function (note, ownerId) {
            note.ACL = {};
            note.ACL[ownerId] = { "write": true, "read": true };
            note.ACL['*'] = { "read": true };
            return ajaxRequester.post(getHeaders(), this.serviceUrl, note)
                .then(function (data) {
                    return data;
                }, function (error) {
                    return error;
                });
        }

        Notes.prototype.update = function(note) {
            var url = this.serviceUrl + "/" + note.objectId;
            return ajaxRequester.put(getHeaders(), url, note)
                .then(function(data) {
                    return data;
                }, function(error) {
                    return error;
                });
        }

        Notes.prototype.delete = function (objectId) {
            var url = this.serviceUrl + "/" + objectId;
            return ajaxRequester.delete(getHeaders(), url)
                .then(function (data) {
                    return data;
                }, function (error) {
                    return error;
                });
        }

        return Notes;
    }());

    return {
        getDataPersister: function (rootUrl) {
            return new Persister(rootUrl);
        }
    }
}());