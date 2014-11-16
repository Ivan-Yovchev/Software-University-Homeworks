'use strict';

function revealTriangles(arr) {

    for (var i = 0; i < arr.length; i++) {

        for (var j = 1; j < arr[i].length; j++) {

            var letter = arr[i].charAt(j);

            if (i != arr.length - 1) {

                if (arr[i + 1].charAt(j).toLowerCase() == letter || arr[i + 1].charAt(j).toUpperCase() == letter) {

                    //arr[i] = arr[i].slice(0, j).concat(letter.toUpperCase()).concat(arr[i].slice(j + 1, arr[i].length));
                    //arr[i + 1] = arr[i + 1].slice(0, j).concat(letter.toUpperCase()).concat(arr[i + 1].slice(j + 1, arr[i + 1].length));

                    if((arr[i + 1].charAt(j + 1).toLowerCase() == letter || arr[i + 1].charAt(j + 1).toUpperCase() == letter)
                        && (arr[i + 1].charAt(j - 1).toLowerCase() == letter || arr[i + 1].charAt(j - 1).toUpperCase() == letter)) {

                        arr[i] = arr[i].slice(0, j).concat(letter.toUpperCase()).concat(arr[i].slice(j + 1, arr[i].length));
                        arr[i + 1] = arr[i + 1].slice(0, j - 1).concat(letter.toUpperCase() + letter.toUpperCase() + letter.toUpperCase()).concat(arr[i + 1].slice(j + 2, arr[i + 1].length));
                    }

                }
            }

        }

    }

    for (var i = 0; i < arr.length; i++) {
        
        for (var j = 0; j < arr[i].length; j++) {

            if (arr[i].charAt(j).toLowerCase() != arr[i].charAt(j)) {
                arr[i] = arr[i].replace(arr[i].charAt(j), '*');
            }

        }

        console.log(arr[i]);

    }
}

revealTriangles(['abcdexgh', 'bbbdxxxh', 'abcxxxxx']);
revealTriangles(['aa', 'aaa', 'aaaa', 'aaaaa']);
revealTriangles(['ax', 'xxx', 'b', 'bbb', 'bbbb']);
revealTriangles(['dffdsgyefg', 'ffffeyeee', 'jbfffays', 'dagfffdsss', 'dfdfa', 'dadaaadddf', 'sdaaaaa', 'daaaaaaasf']);