'use strict';

function replaceATag(str) {

    var start, end;

    for (var i = 0; i < str.length; i++) {

        if (str.charAt(i) == '<' && str.charAt(i + 1) == 'a') {

            start = i;

            for (var j = i + 2; j < str.length; j++) {

                if (str.charAt(j) == '>' && str.charAt(j - 1) == 'a') {

                    end = j;
                    break;

                }

            }

            var link = str.slice(start, end + 1);

            var newLink, href;

            href = link.slice(3, link.indexOf('>'));

            var linkWithoutHref = link.slice(0, 2).concat(link.slice(3 + href.length, link.length));

            newLink = linkWithoutHref.replace('<a>', '[URL]');
            newLink = newLink.replace('</a>', '[/URL]');

            newLink = newLink.slice(0, 4).concat(' ').concat(href).concat(newLink.slice(4, newLink.length));

            str = str.replace(link, newLink);
        }

        
    }

    console.log(str);

}

replaceATag('<ul><li><a href=http://softuni.bg>SoftUni</a></li></ul>');
replaceATag('<ul><li><a href=http://gmail.com>GMail</a><a href=http://google.bg>Google</a></li></ul>');