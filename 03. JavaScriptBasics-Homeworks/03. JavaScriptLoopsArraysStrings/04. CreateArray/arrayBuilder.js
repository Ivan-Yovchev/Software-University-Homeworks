'use strict';

function createArray() {

    var arr = new Array(20);

    for (var i = 0; i < arr.length; i++) {

        arr[i] = i * 5;

    }

    console.log(arr.join(' '));

}

createArray();