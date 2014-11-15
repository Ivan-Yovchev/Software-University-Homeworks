'use strict';

var numsArr = [3, 5, 2, 7, 9];
var langsArr = ['Java', 'Python', 'C#', 'JavaScript', 'Ruby'];
var citiesArr = ['Silicon Valley', 'London', 'Las Vegas', 'Paris', 'Sofia'];
var carsArr = ['BMW', 'Audi', 'Lada', 'Skoda', 'Opel'];

function soothsayer(numsArr, langsArr, citiesArr, carsArr) {

    var years = Math.floor(Math.random() * 5);
    var lang = Math.floor(Math.random() * 5);
    var city = Math.floor(Math.random() * 5);
    var car = Math.floor(Math.random() * 5);

    console.log('You will work ' + numsArr[years] + ' years on ' + 
        langsArr[lang] + '. You will live in ' + citiesArr[city] + 
        ' and drive ' + carsArr[car] + '.');

}

soothsayer(numsArr, langsArr, citiesArr, carsArr);