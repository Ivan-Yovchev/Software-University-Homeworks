'use strict';

function calcCylinderVol() {
    return (Math.PI * arguments[0] * arguments[0] * arguments[1]).toFixed(3);
}

console.log(calcCylinderVol(2, 4));
console.log(calcCylinderVol(5, 8));
console.log(calcCylinderVol(12, 3));