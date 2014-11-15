'use strict';

function roundNumber(number) {

    var round = Math.round(number);
    var floor = Math.floor(number);

    console.log('Floored: ' + floor);
    console.log('Rounded: ' + round);
    console.log();
}

roundNumber(22.7);
roundNumber(12.3);
roundNumber(58.7);