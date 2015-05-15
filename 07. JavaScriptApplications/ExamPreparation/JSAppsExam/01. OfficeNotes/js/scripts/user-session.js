var app = app || {};

app.userSession = {
    login: function (user) {
        sessionStorage['currentUser'] = JSON.stringify(user);
    },
    getCurrentUser: function () {
        var user = sessionStorage['currentUser'];
        if (user) {
            return JSON.parse(sessionStorage['currentUser']);
        }
    },
    logout: function () {
        delete sessionStorage['currentUser'];
    }
};