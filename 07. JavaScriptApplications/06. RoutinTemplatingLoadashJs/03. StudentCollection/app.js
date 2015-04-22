$(function() {
    var students = [
        { "gender": "Male", "firstName": "Joe", "lastName": "Riley", "age": 22, "country": "Russia" },
        { "gender": "Female", "firstName": "Lois", "lastName": "Morgan", "age": 41, "country": "Bulgaria" },
        { "gender": "Male", "firstName": "Roy", "lastName": "Wood", "age": 33, "country": "Russia" },
        { "gender": "Female", "firstName": "Diana", "lastName": "Freeman", "age": 40, "country": "Argentina" },
        { "gender": "Female", "firstName": "Bonnie", "lastName": "Hunter", "age": 23, "country": "Bulgaria" },
        { "gender": "Male", "firstName": "Joe", "lastName": "Young", "age": 16, "country": "Bulgaria" },
        { "gender": "Female", "firstName": "Kathryn", "lastName": "Murray", "age": 22, "country": "Indonesia" },
        { "gender": "Male", "firstName": "Dennis", "lastName": "Woods", "age": 37, "country": "Bulgaria" },
        { "gender": "Male", "firstName": "Billy", "lastName": "Patterson", "age": 24, "country": "Bulgaria" },
        { "gender": "Male", "firstName": "Willie", "lastName": "Gray", "age": 42, "country": "China" },
        { "gender": "Male", "firstName": "Justin", "lastName": "Lawson", "age": 38, "country": "Bulgaria" },
        { "gender": "Male", "firstName": "Ryan", "lastName": "Foster", "age": 24, "country": "Indonesia" },
        { "gender": "Male", "firstName": "Eugene", "lastName": "Morris", "age": 37, "country": "Bulgaria" },
        { "gender": "Male", "firstName": "Eugene", "lastName": "Rivera", "age": 45, "country": "Philippines" },
        { "gender": "Female", "firstName": "Kathleen", "lastName": "Hunter", "age": 28, "country": "Bulgaria" }
    ];

    function displayResults(caption, students, names) {
        var data = {
            caption: caption,
            students: students,
            names: names
        };

        $.get("student-template.html", function (template) {
            var htmlStudents = Mustache.render(template, data);
            $("#wrapper").append(htmlStudents);
        });
    }

    var filteredByAge = _.filter(students, function(student) {
        return student["age"] >= 18 && student["age"] <= 24;
    });
    displayResults("Students between the age of 18 and 24", filteredByAge);

    var filteredByName = _.filter(students, function (student) {
        return student["firstName"].localeCompare(student["lastName"]) < 1;
    });
    displayResults("Students whose first name is before their last name", filteredByName);

    var filteredByNameAndCountry = _.where(students, { country: "Bulgaria" });
    displayResults("The names of all students from Bulgaria", null, filteredByNameAndCountry);

    var lastFiveStudents = _.slice(students, students.length - 5, students.length);
    displayResults("Last five Students", lastFiveStudents);

    var firstThreeBulgarianMales = _.where(students, { "gender": "Male" })
        .filter(function(student) {
            return student["country"] !== "Bulgaria";
        });
    displayResults("First three male students not from Bulgaria", _.slice(firstThreeBulgarianMales, 0, 3));
});