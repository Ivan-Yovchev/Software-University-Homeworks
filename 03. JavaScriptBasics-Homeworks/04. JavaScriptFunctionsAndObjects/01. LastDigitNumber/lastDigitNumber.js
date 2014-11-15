'use strict';

function lastDigitAsText(number) {

    if (number < 0) {
        number = 0 - number;
    }

    var lastDigit = number % 10;

    var result;

    switch (lastDigit) {
        case 0: result = 'Zero'; break;
        case 1: result = 'One'; break;
        case 2: result = 'Two'; break;
        case 3: result = 'Three'; break;
        case 4: result = 'Four'; break;
        case 5: result = 'Five'; break;
        case 6: result = 'Six'; break;
        case 7: result = 'Seven'; break;
        case 8: result = 'Eight'; break;
        case 9: result = 'Nine'; break;
    }

    return result;

}

console.log(lastDigitAsText(6));
console.log(lastDigitAsText(-55));
console.log(lastDigitAsText(133));
console.log(lastDigitAsText(14567));