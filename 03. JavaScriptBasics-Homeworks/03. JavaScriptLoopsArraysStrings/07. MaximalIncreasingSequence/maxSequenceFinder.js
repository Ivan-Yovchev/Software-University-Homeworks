'use strict';

function findMaxSequence(arr) {

    var maxSequence = new Array();

    for (var i = 0; i < arr.length; i++) {

        var element = arr[i];
        var tempSequence = new Array();
        tempSequence.push(element);

        for (var j = i + 1; j < arr.length; j++) {

            if (arr[j] > element) {
                tempSequence.push(arr[j]);
                element = arr[j];
            }
            else {
                i = j - 1;
                break;
            }

        }

        if (maxSequence.length < tempSequence.length) {
            maxSequence = tempSequence;
        }

    }

    if (maxSequence.length != 1) {
        console.log(maxSequence);
    }
    else {
        console.log('no');
    }

}

findMaxSequence([3, 2, 3, 4, 2, 2, 4]);
findMaxSequence([3, 5, 4, 6, 1, 2, 3, 6, 10, 32]);
findMaxSequence([3, 2, 1]);