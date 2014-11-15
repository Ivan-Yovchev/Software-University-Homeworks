'use strict';

function reverseString(str) {

    var result = '';

    for (var i = str.length - 1; i >= 0 ; i--) {

        result += str.charAt(i);

    }

    console.log(result);

}

reverseString('sample');
reverseString('softUni');
reverseString('java script');