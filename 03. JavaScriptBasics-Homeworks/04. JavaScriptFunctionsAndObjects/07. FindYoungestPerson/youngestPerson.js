'use strict';

function findYoungestPerson(persons) {

    var age = Number.MAX_VALUE;
    var name;

    for (var i = 0; i < persons.length; i++) {

        var personObject = persons[i];

        if (personObject.age < age) {
            age = personObject.age;
            name = personObject.firstname + ' ' + personObject.lastname;
        }

    }

    console.log('The youngest person is ' + name);

}

var persons = [
  { firstname: 'George', lastname: 'Kolev', age: 32 },
  { firstname: 'Bay', lastname: 'Ivan', age: 81 },
  { firstname: 'Baba', lastname: 'Ginka', age: 40 }]
findYoungestPerson(persons);
