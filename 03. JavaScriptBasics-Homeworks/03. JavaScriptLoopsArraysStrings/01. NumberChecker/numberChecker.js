'use strict';

function printNUmbers(number) {

    var numbers = new Array();

    for (var i = 1; i <= number; i++) {

        if (i % 4 != 0 && i % 5 != 0) {
            numbers.push(i);
        }

    }

    if (numbers.length > 0) {
        console.log(numbers.join(', '));
    }
    else {
        console.log('no');
    }
}

printNUmbers(20);
printNUmbers(-5);
printNUmbers(13);