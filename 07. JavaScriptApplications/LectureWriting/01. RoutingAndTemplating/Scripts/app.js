var app = app || {};

(function () {
    app.router = Sammy(function () {
        var selector = "#wrapper";

        this.get('#/', function () {
            showHomePage(selector);
        });

        this.get('#/Login', function () {
            showLoginPage(selector);
        });

        this.get('#/Register', function () {
            showRegisterPage(selector);
        });

        this.get('#/Students', function () {
            showStudentsPage(selector);
        });
    });

    app.router.run("#/");

    function showHomePage(selector) {
        $(selector).empty();
        var h1 = $('<h1>').text("Welcome to Students repo");
        $(selector).append(h1);
    }

    function showLoginPage(selector) {
        $(selector).empty();

        var usernameLabel = $("<label for=username>");
        usernameLabel.text("Username:");
        var username = $("<input type=text id=username>");
        var passwordLabel = $("<label for=password>");
        passwordLabel.text("Password:");
        var password = $("<input type=password id=password>");
        var loginButton = $("<button>").text("Login");

        $(selector)
            .append(usernameLabel)
            .append(username)
            .append(passwordLabel)
            .append(password)
            .append(loginButton);
    }

    function showRegisterPage(selector) {
        $(selector).empty();

        var usernameLabel = $("<label for=username>");
        usernameLabel.text("Username:");
        var username = $("<input type=text id=username>");
        var passwordLabel = $("<label for=password>");
        passwordLabel.text("Password:");
        var password = $("<input type=password id=password>");
        var repeatPassLabel = $("<label for=repeat-password>");
        repeatPassLabel.text("Repeat Password:");
        var repeatPassword = $("<input type=password id=repeat-password>");
        var loginButton = $("<button>").text("Login");

        $(selector)
            .append(usernameLabel)
            .append(username)
            .append(passwordLabel)
            .append(password)
            .append(repeatPassLabel)
            .append(repeatPassword)
            .append(loginButton);
    }

    function showStudentsPage(selector) {
        $(selector).empty();

        var students = [
            { name: "Gosho", grade: 4 },
            { name: "Pesho", grade: 5 },
            { name: "Minka", grade: 6 }
        ];

        var ol = $('<ol>');
        students.forEach(function (student) {
            var li = $("<li>").text("Name: " + student.name + ", Grade: " + student.grade);
            ol.append(li);
        });

        $(selector).append(ol);
    }
})();