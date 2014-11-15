'use strict';

function extractContent(str) {

    var result = [];

    for (var i = 0; i < str.length; i++) {

        if (str.charAt(i) == '>') {

            var word = '';
            var index = i + 1;

            for (var j = i + 1; j < str.length; j++) {

                if (str.charAt(j) == '<') {
                    break;
                }
                else {
                    word += str.charAt(j);
                }

            }

            result.push(word);
            i += word.length;
        }

    }

    console.log(result.filter(Boolean).join(''));

}

extractContent("<p>Hello</p><a href='http://w3c.org'>W3C</a>");
extractContent('<tr><td>Software</td></tr><tr><td>University</td></tr>');