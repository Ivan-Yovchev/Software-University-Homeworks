'use strict';

function checkDigit(number) {

    number = Math.floor(number / 100);

    if (number % 10 == 3) {
        return true;
    }
    else {
        return false;
    }

}

console.log(checkDigit(1235));
console.log(checkDigit(25368));
console.log(checkDigit(123456));