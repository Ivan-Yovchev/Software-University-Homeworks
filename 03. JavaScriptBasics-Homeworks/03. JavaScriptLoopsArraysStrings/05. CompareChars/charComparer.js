'use strict';

function compareChars(firstArray, secondArray) {

    if (firstArray.lenght != secondArray.lenght) {
        console.log('Not Equal');
    }
    else {

        var equal = true;

        // check if all values are the same
        for (var i = 0; i < firstArray.length; i++) {

            if (firstArray[i] != secondArray[i]) {
                equal = false;
                break;
            }
            else {
                continue;
            }

        }

        // output
        if (equal == true) {
            console.log('Equal');
        }
        else {
            console.log('Not Equal');
        }

    }

}

compareChars(['1', 'f', '1', 's', 'g', 'j', 'f', 'u', 's', 'q'], ['1', 'f', '1', 's', 'g', 'j', 'f', 'u', 's', 'q']);
compareChars(['3', '5', 'g', 'd'], ['5', '3', 'g', 'd']);
compareChars(['q', 'g', 'q', 'h', 'a', 'k', 'u', '8', '}', 'q', '.', 'h', '|', ';'], ['6', 'f', 'w', 'q', ':', '”', 'd', '}', ']', 's', 'r']);