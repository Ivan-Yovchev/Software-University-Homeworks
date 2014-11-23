'use strict';

function xRemoval(input) {

    var rememberIndex = [];

    for (var i = 0; i < input.length; i++) {
        var temp = [];
        rememberIndex.push(temp);
    }

    for (var i = 0; i < input.length - 2; i++) {

        for (var j = 0; j < input[i].length; j++) {

            if (input[i].charAt(j + 2) != undefined && input[i + 1].charAt(j + 1) != undefined && input[i + 2].charAt(j + 2) != undefined) {
                
                var character = input[i][j].toLowerCase();

                if (character == input[i].charAt(j + 2).toLowerCase()) {
                    if (character == input[i + 1].charAt(j + 1).toLowerCase()) {
                        if (character == input[i + 2].charAt(j).toLowerCase() && character == input[i + 2].charAt(j + 2).toLowerCase()) {
                            
                            rememberIndex[i].push(j, j + 2);
                            rememberIndex[i + 1].push(j + 1);
                            rememberIndex[i + 2].push(j, j + 2);

                        }
                    }
                }

            }

        }

    }

    //console.log(rememberIndex);
    
    for (var i = 0; i < rememberIndex.length; i++) {

        if (rememberIndex[i].length != 0) {

            var str = '';

            for (var j = 0; j < input[i].length; j++) {

                if (rememberIndex[i].indexOf(j) == -1) {
                    str += input[i][j];
                }

            }
            console.log(str);

        }
        else {
            console.log(input[i]);
        }

    }

}

//xRemoval(['abnbjs',
//'xoBab',
//'Abmbh',
//'aabab',
//'ababvvvv']);

//xRemoval(['8888888',
//'08*8*80',
//'808*888',
//'0**8*8?']);

//xRemoval(['^u^',
//'j^l^a',
//'^w^WoWl',
//'adw1w6',
//'(WdWoWgPoop)']);

xRemoval(['puoUdai',
'miU',
'ausupirina',
'8n8i8',
'm8o8a',
'8l8o860',
'M8i8',
'8e8!8?!']);