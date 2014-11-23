'use strict';

function findKeyValueStrings(arr) {

    for (var i = 0; i < arr.length; i++) {

        var string = arr[i];

        while (string.indexOf('%20') > -1) {
            string = string.slice(0, string.indexOf('%20')).concat(' ').concat(string.slice(string.indexOf('%20') + 3, string.length));
        }
        
        while (string.indexOf('+') > -1) {
            string = string.slice(0, string.indexOf('+')).concat(' ').concat(string.slice(string.indexOf('+') + 1, string.length));
        }

        var split = string.split('?');

        var equalSplits = [], obj = {};

        for (var j = 0; j < split.length; j++) {

            if (split[j].indexOf('&') > -1) {

                var deepSplit = split[j].split('&');

                for (var g = 0; g < deepSplit.length; g++) {

                    if (deepSplit[g].indexOf('=') > -1) {
                        
                        var temp = deepSplit[g].split('=');

                        var key = temp[0].trim();
                        var value = temp[1].trim();

                        if (value.indexOf(' ') > -1) {
                            value = value.replace(/\s\s+/g, ' ');
                        }

                        if (obj[key] == undefined) {
                            obj[key] = [];
                        }

                        obj[key].push(value);

                    }

                }

            }
            else if (split[j].indexOf('=') > -1) {
                var temp = split[j].split('=');

                var key = temp[0].trim();
                var value = temp[1].trim();

                if (value.indexOf(' ') > -1) {
                    value = value.replace(/\s\s+/g, ' ');
                }

                if (obj[key] == undefined) {
                    obj[key] = [];
                }

                obj[key].push(value);
            }
        }

        var result = '';
        for (var k in obj) {

            var str = '';

            str += k + '=[';

            for (var h = 0; h < obj[k].length; h++) {

                str += obj[k][h];

                if (h != obj[k].length - 1) {
                    str += ', ';
                }

            }

            result += str + ']';

        }
        console.log(result);

    }

}

findKeyValueStrings(['login=student&password=student']);

findKeyValueStrings(['field=value1&field=value2&field=value3',
'http://example.com/over/there?name=ferret']);

findKeyValueStrings(['foo=%20foo&value=+val&foo+=5+%20+203',
'foo=poo%20&value=valley&dog=wow+',
'url=https://softuni.bg/trainings/coursesinstances/details/1070',
'https://softuni.bg/trainings.asp?trainer=nakov&course=oop&course=php']);