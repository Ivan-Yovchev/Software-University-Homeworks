'use strict';

function countDivs(html) {

    var countOfDivs = 0;

    for (var i = 0; i < html.length; i++) {

        if (html.charAt(i) == '<' && html.charAt(i + 1) == 'd') {
            countOfDivs++;
        }

    }

    return countOfDivs;

}

console.log(countDivs('<!DOCTYPE html>' +
                        '<html>' +
                        '<head lang="en">' +
                            '<meta charset="UTF-8">' +
                                '<title>index</title>' +
                                '<script src="/yourScript.js" defer></script>' +
                            '</head>' +
                            '<body>' +
                                '<div id="outerDiv">' +
                                   '<div' +
                                    'class="first">' +
                                       '<div><div>hello</div></div>' +
                                    '</div>' +
                                    '<div>hi<div></div></div>' +
                                    '<div>I am a div</div>' +
                                '</div>' +
                            '</body>' +
                        '</html>'));