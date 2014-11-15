'use strict';

function checkBrackets(str) {

    var bracketLeft = 0;
    var bracketRight = 0;

    for (var i = 0; i < str.length; i++) {

        if (str.charAt(i) == '(') {
            bracketLeft++;
        }
        else if (str.charAt(i) == ')') {
            bracketRight++;
        }

    }

    if (bracketLeft == bracketRight) {
        console.log('correct');
    }
    else {
        console.log('incorrect');
    }

}

checkBrackets('( ( a + b ) / 5 – d )');
checkBrackets(') ( a + b ) )');
checkBrackets('( b * ( c + d *2 / ( 2 + ( 12 – c / ( a + 3 ) ) ) )');