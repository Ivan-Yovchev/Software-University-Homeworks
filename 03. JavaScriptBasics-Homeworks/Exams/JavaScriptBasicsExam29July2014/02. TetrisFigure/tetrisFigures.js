'use strict';

function findTetrisFigures(arr) {

    var result = {'I': 0, 'L': 0, 'J': 0, 'O': 0, 'Z': 0, 'S': 0, 'T': 0};

    for (var i = 0; i < arr.length; i++) {

        for (var j = 0; j < arr[i].length; j++) {

            
            if (arr[i][j] == 'o') {

                //check for an I
                if (arr[i + 3] != undefined) {
                    if (arr[i + 1][j] == 'o' && arr[i + 2][j] == 'o' && arr[i + 3][j] == 'o') {
                        result.I++;
                    }
                }
                //check for an L
                if (arr[i][j + 1] != undefined && arr[i + 2] != undefined) {
                    if (arr[i + 1][j] == 'o' && arr[i + 2][j] == 'o' && arr[i + 2][j + 1] == 'o') {
                        result.L++;
                    }
                }
                //check for a J
                if (arr[i][j - 1] != undefined && arr[i + 2] != undefined) {
                    if (arr[i + 1][j] == 'o' && arr[i + 2][j] == 'o' && arr[i + 2][j - 1] == 'o') {
                        result.J++;
                    }
                }
                //check for an O
                if (arr[i + 1] != undefined && arr[i][j + 1] != undefined) {
                    if (arr[i + 1][j] == 'o' && arr[i][j + 1] == 'o' && arr[i + 1][j + 1] == 'o') {
                        result.O++;
                    }
                }
                //check for a Z
                if (arr[i][j + 2] != undefined && arr[i + 1] != undefined) {
                    if (arr[i][j + 1] == 'o' && arr[i + 1][j + 1] == 'o' && arr[i + 1][j + 2] == 'o') {
                        result.Z++;
                    }
                }
                //check for an S
                if (arr[i - 1] != undefined && arr[i][j + 2] != undefined) {
                    if (arr[i][j + 1] == 'o' && arr[i - 1][j + 1] == 'o' && arr[i - 1][j + 2] == 'o') {
                        result.S++;
                    }
                }
                //check for a T
                if (arr[i + 1] != undefined && arr[i + 1][j + 1] != undefined && arr[i][j + 2] != undefined) {
                    if (arr[i + 1][j + 1] == 'o' && arr[i][j + 1] == 'o' && arr[i][j + 2] == 'o') {
                        result.T++;
                    }
                }

            }

        }

    }

    console.log(JSON.stringify(result));

}

findTetrisFigures(['--o--o-',
'--oo-oo',
'ooo-oo-',
'-ooooo-',
'---oo--']);

findTetrisFigures(['-oo',
'ooo',
'ooo']);