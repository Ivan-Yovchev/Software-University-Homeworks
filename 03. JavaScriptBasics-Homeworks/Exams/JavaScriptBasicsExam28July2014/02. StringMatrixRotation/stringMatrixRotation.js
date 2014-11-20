'use strict';

function stringMatrixRotation(input) {

    var rotationDegrees = Number(input[0].slice(7, input[0].length - 1));

    var numberOfRotations = 0
    if (rotationDegrees != 0) {
        numberOfRotations = rotationDegrees / 90;
    }

    var maxLength = 0;
    for (var i = 1; i < input.length; i++) {

        if (input[i].length > maxLength) {
            maxLength = input[i].length;
        }

    }

    var matrix = [];

    for (var i = 1; i < input.length; i++) {

        var word = input[i];
        var tempArray = [];

        for (var j = 0; j < maxLength; j++) {

            if (word.length == maxLength) {
                tempArray.push(word.charAt(j));
            }
            else {

                if (j < word.length) {
                    tempArray.push(word.charAt(j));
                }
                else {
                    tempArray.push(' ');
                }

            }

        }

        matrix.push(tempArray);

    }

    if (numberOfRotations % 4 == 0 || numberOfRotations == 0) {

        for (var j = 0; j < matrix.length; j++) {

            var row = '';

            for (var i = 0; i < matrix[j].length; i++) {
                row += matrix[j][i];
            }

            console.log(row);

        }

    }
    else if (numberOfRotations % 4 == 3) {

        // rotate 90
        var newMatrix = [];

        for (var i = 0; i < matrix[0].length; i++) {

            var temp = []

            for (var j = matrix.length - 1; j >= 0; j--) {

                temp.push(matrix[j][i]);

            }

            newMatrix.push(temp);

        }

        //move down
        for (var i = 0; i < Math.floor(newMatrix.length / 2) ; i++) {

            var temp = newMatrix[i];
            newMatrix[i] = newMatrix[newMatrix.length - 1 - i];
            newMatrix[newMatrix.length - 1 - i] = temp;

        }

        //exchange
        for (var i = 0; i < newMatrix.length; i++) {

            for (var j = 0; j < Math.floor(newMatrix[i].length / 2) ; j++) {

                var temp = newMatrix[i][j];
                newMatrix[i][j] = newMatrix[i][newMatrix[i].length - 1 - j];
                newMatrix[i][newMatrix[i].length - 1 - j] = temp;

            }

        }

        matrix = newMatrix;

        //output
        for (var j = 0; j < matrix.length; j++) {

            var row = '';

            for (var i = 0; i < matrix[j].length; i++) {
                row += matrix[j][i];
            }

            console.log(row);

        }

    }
    else if (numberOfRotations % 4 == 2) {

        //rows
        for (var i = 0; i < Math.floor(matrix.length/2) ; i++) {

            var temp = matrix[i];
            matrix[i] = matrix[matrix.length - 1 - i];
            matrix[matrix.length - 1 - i] = temp;

        }
        // cols
        for (var i = 0; i < matrix.length; i++) {

            for (var j = 0; j < Math.floor(matrix[i].length / 2); j++) {

                var temp = matrix[i][j];
                matrix[i][j] = matrix[i][matrix[i].length - 1 - j];
                matrix[i][matrix[i].length - 1 - j] = temp;

            }

        }

        //output 
        for (var j = 0; j < matrix.length; j++) {

            var row = '';

            for (var i = 0; i < matrix[j].length; i++) {
                row += matrix[j][i];
            }

            console.log(row);

        }

    }
    else if (numberOfRotations % 4 == 1) {

        var newMatrix = [];

        for (var i = 0; i < matrix[0].length; i++) {

            var temp = []

            for (var j = matrix.length - 1; j >= 0; j--) {

                temp.push(matrix[j][i]);

            }
            
            newMatrix.push(temp);

        }

        matrix = newMatrix;

        for (var j = 0; j < matrix.length; j++) {

            var row = '';

            for (var i = 0; i < matrix[j].length; i++) {
                row += matrix[j][i];
            }

            console.log(row);

        }

    }

}

stringMatrixRotation(['Rotate(0)', 'js', 'exam']);