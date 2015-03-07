"use strict";

function testContext() {
    console.log(this);
}

console.log("Test from global scope:");
testContext();
console.log();


console.log("Test inside antoher function:");
(function () {
    testContext();
})();
console.log();

console.log("Test as an object:");
var contextObject = new testContext;
contextObject;
console.log();