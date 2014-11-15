'use strict';

function convertKWtoHP(speed) {
    return ((speed / 0.745699872).toFixed(2));
}

console.log(75 + 'kW = ' + convertKWtoHP(75) + 'hp');
console.log(75 + 'kW = ' + convertKWtoHP(150) + 'hp');
console.log(75 + 'kW = ' + convertKWtoHP(1000) + 'hp');