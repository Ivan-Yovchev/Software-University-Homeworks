var app = app || {};

app.dataPersister = function(rootUrl) {
    function getHeaders() {
        var headers = {
            'X-Parse-Application-Id': "OC9bZO2U0cZu2uwnf71UTUB6UI2JtYIg8ZvTkncZ",
            'X-Parse-REST-API-Key': "HKVS9rW6of8JHUuDWmqerFCjVw73wl7Am89wBZoQ"
        };
        var currentUser = app.userSession.getCurrentUser();
        if (currentUser) {
            headers['X-Parse-Session-Token'] = currentUser.sessionToken;
        }

        return headers;
    }

    var users = {
        login: function(username, password, success, error) {
            var url = rootUrl + "login?username=" + username + "&password=" + password;
            return app.ajaxRequester.get(getHeaders(), url, function(data) {
                app.userSession.login(data);
                success(data);
            }, error);
        },
        logout: function() {
            app.userSession.logout();
        },
        register: function(username, password, fullName, success, error) {
            var url = rootUrl + "users";
            var user = {
                username: username,
                password: password,
                fullName: fullName
            }

            return app.ajaxRequester.post(getHeaders(), url, user, function(data) {
                data.username = username;
                data.fullName = fullName;
                app.userSession.login(data);
                success(data);
            }, error);
        },
        getById: function(objectId, success, error) {
            var url = rootUrl + 'users/' + objectId;
            return app.ajaxRequester.get(getHeaders(), url, success, error);
        },
        editProfile: function(user, success, error) {
            var url = rootUrl + 'users/' + user.objectId;
            return app.ajaxRequester.put(getHeaders(), url, user, success, error);
        }
    };

    var phones = {
        getAll: function(success, error) {
            var url = rootUrl + "classes/Phone";
            return app.ajaxRequester.get(getHeaders(), url, success, error);
        },
        getById: function(objectId, success, error) {
            var url = rootUrl + "classes/Phone/" + objectId;
            return app.ajaxRequester.get(getHeaders(), url, success, error);
        },
        add: function(phone, ownerObjectId, success, error) {
            phone.ACL = {};
            phone.ACL[ownerObjectId] = { "write": true, "read": true };
            var url = rootUrl + "classes/Phone";
            return app.ajaxRequester.post(getHeaders(), url, phone, success, error);
        },
        update: function(phone, succes, error) {
            var url = rootUrl + "classes/Phone/" + phone.objectId;
            return app.ajaxRequester.put(getHeaders(), url, phone, succes, error);
        },
        delete: function(objectId, success, error) {
            var url = rootUrl + "classes/Phone/" + objectId;
            return app.ajaxRequester.delete(getHeaders(), url, success, error);
        }
    };

    return {
        users: users,
        phones: phones
    }
};