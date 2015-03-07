var Person = (function () {
    function Person(fname, lname) {
        var firstName = fname;
        var lastName = lname;
        var fullName = firstName + " " + lastName;
        
        this.__defineGetter__("firstName", function () {
            return firstName;
        });
        
        this.__defineSetter__("firstName", function (name) {
            firstName = name;
            fullName = name + " " + lastName;
        });
        
        this.__defineGetter__("lastName", function () {
            return lastName;
        });
        
        this.__defineSetter__("lastName", function (name) {
            lastName = name;
            fullName = firstName + " " + name;
        });
        
        this.__defineGetter__("fullName", function () {
            return fullName;
        });
        
        this.__defineSetter__("fullName", function (name) {
            firstName = name.split(' ')[0];
            lastName = name.split(' ')[1];
            fullName = name;
        });
    }

    return Person;
})();

var person = new Person("Peter", "Jackson");

console.log(person.firstName);
console.log(person.lastName);
console.log(person.fullName);

person.firstName = "Michael";
console.log(person.firstName);
console.log(person.fullName);
person.lastName = "Williams";
console.log(person.lastName);
console.log(person.fullName);

person.fullName = "Alan Marcus";
console.log(person.fullName);
console.log(person.firstName);
console.log(person.lastName);


