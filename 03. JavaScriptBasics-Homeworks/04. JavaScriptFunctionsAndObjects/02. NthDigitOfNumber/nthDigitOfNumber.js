'use strict';

function findNthDigit(arr) {

    var number = arr[1];
    if (number < 0) {
        number = 0 - number;
    }

    var strNumber = number.toString();
    
    strNumber = strNumber.split('.');

    if (strNumber.length > 1) {
        strNumber = strNumber[0] + strNumber[1];
    }
    else {
        strNumber = '' + strNumber;
    }

    //console.log(strNumber);

    var digitIndex = strNumber.length - arr[0];

    if (digitIndex >= 0) {

        return strNumber.charAt(digitIndex);
    }
    else {

        return 'The number doesn\'t have ' + arr[0] + ' digits';
    }

}

console.log(findNthDigit([1, 6]));
console.log(findNthDigit([2, -55]));
console.log(findNthDigit([6, 923456]));
console.log(findNthDigit([3, 1451.78]));
console.log(findNthDigit([6, 888.88]));