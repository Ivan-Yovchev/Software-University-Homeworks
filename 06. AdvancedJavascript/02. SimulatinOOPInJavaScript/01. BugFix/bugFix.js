var Person = (function () {
    function Person(firstName, lastName) {
        if (!(this instanceof arguments.callee)) {
            return new arguments.callee(firstName, lastName);
        }

        this.firstName = firstName;
        this.lastName = lastName;
        this.name = firstName + " " + lastName;
    }

    return Person;
})();

var peter = new Person("Peter", "Jackson");
console.log(peter.name);
console.log(peter.firstName);
console.log(peter.lastName);
