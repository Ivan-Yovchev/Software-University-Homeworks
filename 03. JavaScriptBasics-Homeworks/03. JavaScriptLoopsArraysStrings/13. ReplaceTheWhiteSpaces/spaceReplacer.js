'use strict';

function replaceSpaces(str) {

    str = str.replace(/ /g, '&nbsp;');

    console.log(str);

}

replaceSpaces('But you were living in another world tryin\' to get your message through');