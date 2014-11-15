'use strict';

function bitChecker(number) {

    if (number & Math.floor(Math.pow(2, 3)) != 0) {
        return true;
    }

    else {
        return false;
    }

}

console.log(bitChecker(333));
console.log(bitChecker(425));
console.log(bitChecker(2567564754));