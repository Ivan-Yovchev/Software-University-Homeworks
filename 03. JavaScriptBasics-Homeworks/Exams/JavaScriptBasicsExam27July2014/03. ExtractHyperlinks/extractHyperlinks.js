'use strict';

//function extractLinks(arr) {

//    var result = [];

//    for (var i = 0; i < arr.length; i++) {

//        if (arr[i].indexOf('<a') > -1) {

//            if (i < arr.length - 1) {

//                if (arr[i].indexOf('</a>') == -1) {
//                    var findEndTag = arr[i + 1].indexOf('</a>') + 4;
//                    arr[i] = arr[i] + arr[i + 1].slice(0, findEndTag);
//                    arr[i + 1] = arr[i + 1].slice(findEndTag, arr[i + 1].length);
//                }

//            }

//        }

//        if (arr[i].indexOf('</a>')) {

//            var end = arr[i].indexOf('</a>');

//            var roughLink = arr[i].slice(0, end + 1);
//            roughLink = roughLink.slice(roughLink.indexOf('href'), roughLink.length);
//            roughLink = roughLink.slice(0, roughLink.indexOf('>'));

//            for (var g = 0; g < roughLink.length; g++) {

//                if (roughLink[g] == ' ' && roughLink[g + 1] == '=') {
//                    roughLink = roughLink.replace(roughLink.charAt(g), '');
//                }

//            }

//            roughLink = roughLink.slice(roughLink.indexOf('href='), roughLink.length);
//            roughLink = roughLink.slice(5, roughLink.length);

//            if (roughLink.charAt(0) == ' ') {
//                roughLink = roughLink.slice(1, roughLink.length);
//            }

//            roughLink = roughLink.split(/[ ]/).filter(Boolean);

//            var link = roughLink[0];

//            if (typeof link === 'undefined') {
//                continue;
//            }
//            else {

//                result.push(link);
//            }

//        }
//    }

//    if (result.length == 0) {
//        console.log();
//    }
//    else {
//        for (var i = 0; i < result.length; i++) {

//            if (result[i].indexOf('\'') > -1 || result[i].indexOf('"') > -1) {
//                result[i] = result[i].slice(1, result[i].length - 1);
//            }

//            console.log(result[i]);

//        }
//    }

//}


function extractLinks(input) {
    var html = input.join('\n');
    var regex = /<a\s+([^>]+\s+)?href\s*=\s*('([^']*)'|"([^"]*)|([^\s>]+))[^>]*>/g;
    var match;
    while (match = regex.exec(html)) {
        var hrefValue = match[3];
        if (hrefValue == undefined) {
            var hrefValue = match[4];
        }
        if (hrefValue == undefined) {
            var hrefValue = match[5];
        }
        console.log(hrefValue);
    }
}

extractLinks(['<p>This text has no links</p>']);
extractLinks(['<a href="http://softuni.bg" class="new"></a>']);
extractLinks(['<!DOCTYPE html>', '<html>', '<head>', '<title>Hyperlinks</title>',
'<link href="theme.css" rel="stylesheet" />', '</head>', '<body>', '<ul><li><a   href="/"  id="home">Home</a></li><li><a',
'class="selected" href=/courses>Courses</a>', '</li><li><a href = ', "'/forum' >Forum</a></li><li><a class='href'",
'onclick="go()" href= "#">Forum</a></li>', '<li><a id="js" href =', "\"javascript:alert('hi')\" class='new'>click</a></li>",
"<li><a id='nakov' href =", "http://www.nakov.com class='new'>nak</a></li></ul>",
'<a href="#empty"></a>', "<a id='href'>href='fake'<img src='http://abv.bg/i.gif'",
"alt='abv'/></a><a href='#'>&lt;a href='hello'&gt;</a>", '<!-- This code is commented:',
'<a href="#commented">commentex hyperlink</a> -->', '</body>']);