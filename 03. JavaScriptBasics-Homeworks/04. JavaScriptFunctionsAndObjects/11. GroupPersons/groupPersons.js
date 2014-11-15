'use strict';

function group(arr, property) {

    var groups = {};

    for (var i = 0; i < people.length; i++) {

        var tempObj = people[i];

        if (groups[tempObj[property]] !== undefined) {

            groups[tempObj[property]].push(tempObj.firstName + ' ' + tempObj.lastName + '(age ' + tempObj.age + ')');
        }
        else {
            groups[tempObj[property]] = [tempObj.firstName + ' ' + tempObj.lastName + '(age ' + tempObj.age + ')'];
        }
    }

    for (var obj in groups) {
        console.log('Group ' + obj + ' : ' + '[' + groups[obj].join(', ') + ']');
    }
    console.log();

    return groups;

}

function Person(firstName, lastName, age) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.age = age;
}

var people = [];
people.push(new Person("Scott", "Guthrie", 38));
people.push(new Person("Scott", "Johns", 36));
people.push(new Person("Scott", "Hanselman", 39));
people.push(new Person("Jesse", "Liberty", 57));
people.push(new Person("Jon", "Skeet", 38));
group(people, 'firstName');

people = [];
people.push(new Person("Scott", "Guthrie", 38));
people.push(new Person("Scott", "Johns", 40));
people.push(new Person("Scott", "Hanselman", 36));
people.push(new Person("Jesse", "Liberty", 57));
people.push(new Person("Jon", "Skeet", 36));
group(people, 'age');

people = [];
people.push(new Person("Scott", "Guthrie", 38));
people.push(new Person("Scott", "Johns", 40));
people.push(new Person("Scott", "Hanselman", 36));
people.push(new Person("Jesse", "Johns", 57));
people.push(new Person("Jon", "Skeet", 36));
group(people, 'lastName');