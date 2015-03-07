"use strict";

function add(a){
    var sum = a;

    function addingNumber(b){
        sum += b;
        return addingNumber;
    }
    
    addingNumber.toString = function () {
        return +sum;
    }

    return addingNumber;
}

console.log(+add(2)(3)(4));
var addTwo = add(2);
console.log(+addTwo(3)(5));
