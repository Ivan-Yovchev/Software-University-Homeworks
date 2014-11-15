'use strict';

function sortArray(arr) {

    for (var i = 0; i < arr.length - 1; i++) {

        var min = arr[i];
        var index = i;

        for (var j = i + 1; j < arr.length; j++) {

            if (min > arr[j]) {

                min = arr[j];
                index = j;

            }

        }

        var swap = arr[index];
        arr[index] = arr[i];
        arr[i] = swap;

    }

    console.log(arr.join(', '));

}

sortArray([5, 4, 3, 2, 1]);
sortArray([12, 12, 50, 2, 6, 22, 51, 712, 6, 3, 3]);