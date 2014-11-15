'use strict';

function reverseWordsInString(str) {

    str = str.split(/\s+/);

    var reversedStr = [];

    for (var i = 0; i < str.length; i++) {

        var word = str[i];
        var reversedWord = '';

        for (var j = word.length - 1; j >= 0; j--) {
            reversedWord += word.charAt(j);
        }

        reversedStr.push(reversedWord);

    }

    return reversedStr.join(' ');

}

console.log(reverseWordsInString('Hello, how are you.'));
console.log(reverseWordsInString("Life is pretty good, isn't it?"));