'use strict';

function findPalindromes(str) {

    str = str.toLowerCase();

    str = str.split(/\W+/).filter(Boolean);

    var result = [];

    for (var i = 0; i < str.length; i++) {

        if (str[i] == str[i].split('').reverse().join('')) {
            result.push(str[i]);
        }

    }

    console.log(result.join(', '));

}

findPalindromes('There is a man, his name was Bob.');