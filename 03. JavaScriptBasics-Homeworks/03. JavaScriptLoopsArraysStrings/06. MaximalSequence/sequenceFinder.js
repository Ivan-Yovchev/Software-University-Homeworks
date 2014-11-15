'use strict';

function findMaxSequence(arr) {

    var maxSequence = new Array();

    for (var i = 0; i < arr.length; i++) {

        var element = arr[i];
        var tempSequence = new Array();
        tempSequence.push(element);

        for (var j = i + 1; j < arr.length; j++) {

            if (arr[j] === element) {
                tempSequence.push(arr[j]);
            }
            else {
                i = j - 1;
                break;
            }

        }

        if (maxSequence.length <= tempSequence.length) {
            maxSequence = tempSequence;
        }

    }

    console.log(maxSequence);

}

findMaxSequence([2, 1, 1, 2, 3, 3, 2, 2, 2, 1]);
findMaxSequence(['happy']);
findMaxSequence([2, 'qwe', 'qwe', 3, 3, '3']);