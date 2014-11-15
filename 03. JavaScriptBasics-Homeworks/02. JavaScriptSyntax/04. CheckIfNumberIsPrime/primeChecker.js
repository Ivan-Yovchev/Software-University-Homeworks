'use strict';

function isPrime(number) {

    if (number != 0) {

        if (number == 1) {
            return false;
        }

        else {

            var prime = true;

            for (var i = 2; i < number/2 ; i++) {

                if (number % i == 0) {
                    prime = false;
                    break;
                }

            }

            return prime;
        }
    }
}

console.log(isPrime(7));
console.log(isPrime(254));
console.log(isPrime(587));