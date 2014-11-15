'use strict';

function divisionBy3(number) {

    if (number % 3 == 0) {
        console.log(number + ': the number is divided by 3 without remainder');
    }
    else {
        console.log(number + ': the number is not divided by 3 without remainder');
    }

    var sum = 0;
    while (number != 0) {
        sum += number % 10;
        number = Math.floor(number/10);
    }

    console.log('Sum of digits: ' + sum);

}

divisionBy3(12);
divisionBy3(188);
divisionBy3(591);