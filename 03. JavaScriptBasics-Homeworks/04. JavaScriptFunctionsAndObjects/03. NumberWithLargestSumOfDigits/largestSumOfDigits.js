'use strict';

function findLargestBySumOfDigits(arr) {

    if (arr.length == 0) {
        return undefined;
    }
    else {

        var correctArguments = true;

        for (var i = 0; i < arr.length; i++) {
            if (Math.floor(arr[i]) != arr[i]) {
                correctArguments = false;
                break;
            }
        }

        if (correctArguments == false) {
            return undefined;
        }
        else {

            var maxIndex, maxSum = 0;

            for (var i = 0; i < arr.length; i++) {

                var tempNumber = arr[i], tempSum = 0, tempIndex = i;
                if (tempNumber < 0) {
                    tempNumber = 0 - tempNumber;
                }

                while (tempNumber != 0) {
                    tempSum += tempNumber % 10;
                    tempNumber = Math.floor(tempNumber / 10);
                }

                if (maxSum < tempSum) {
                    maxSum = tempSum;
                    maxIndex = tempIndex;
                }

            }

            return arr[maxIndex];

        }

    }

}

console.log(findLargestBySumOfDigits([5, 10, 15, 111]));
console.log(findLargestBySumOfDigits([33, 44, -99, 0, 20]));
console.log(findLargestBySumOfDigits(['hello']));
console.log(findLargestBySumOfDigits([5, 3.3]));
