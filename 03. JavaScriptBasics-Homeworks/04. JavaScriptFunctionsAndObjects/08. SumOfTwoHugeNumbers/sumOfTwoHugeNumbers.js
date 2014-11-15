'use strict';

function sumTwoHugeNumbers(value) {

    var firstStr = value[0], secondStr = value[1];

    var length = firstStr.length;

    if (secondStr.length > firstStr.length) {
        length = secondStr.length;
        var temp = firstStr;
        firstStr = secondStr;
        secondStr = temp;
    }

    //first number
    var firstNumber = new Array(length);
    var index = firstStr.length - 1;
    for (var i = firstNumber.length - 1; i >= 0; i--) {
        firstNumber[i] = firstStr.charAt(index);
        index--;
    }

    //second number
    var secondNumber = new Array(length);
    index = secondStr.length - 1;
    for (var i = secondNumber.length - 1; i >= 0; i--) {
        secondNumber[i] = secondStr.charAt(index);
        index--;
    }

    var result = [];

    //sum digits
    for (var i = firstNumber.length - 1; i >= 0; i--) {

        var digit;

        if (i < firstNumber.length - secondNumber.length) {

            digit = Number(firstNumber[i]);
            result.unshift(digit);
        }
        else {
            digit = Number(firstNumber[i]) + Number(secondNumber[i]);
            result.unshift(digit);
        }

    }

    //transfer digit if sum > 9
    for (var i = result.length - 1; i >= 0; i--) {

        if (i != 0) {

            if (result[i] > 9) {
                result[i - 1] += Math.floor(result[i] / 10);
                result[i] = result[i] % 10;
            }
            else {
                continue;
            }

        }

    }

    return result.join('');

}

console.log(sumTwoHugeNumbers(['155', '65']));
console.log(sumTwoHugeNumbers(['123456789', '123456789']));
console.log(sumTwoHugeNumbers(['887987345974539', '4582796427862587']));
console.log(sumTwoHugeNumbers(['347135713985789531798031509832579382573195807','817651358763158761358796358971685973163314321']));