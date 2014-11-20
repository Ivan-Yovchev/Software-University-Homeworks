'use strict';

function doubleRakiyaNumbers(input) {

    var start = Number(input[0]);
    var end = Number(input[1]);

    console.log('<ul>');

    for (var i = start; i <= end; i++) {

        var num = '' + i;

        var isRakiyanNumber = false;

        for (var j = 0; j < num.length; j++) {

            if (j != num.length - 1) {

                var digitCouple = num.charAt(j) + num.charAt(j + 1);

                var tempNum;

                if (j == 0) {
                    tempNum = 'XX' + num.slice(2, num.length);
                }
                else if (j < num.length - 2) {
                    tempNum = num.slice(0, j).concat('XX').concat(num.slice(j + 2, num.length));
                }
                else if (j == num.length - 2) {
                    tempNum = num.slice(0, num.length - 2).concat('XX');
                }

                if (tempNum.indexOf(digitCouple) > -1) {
                    isRakiyanNumber = true;
                    break;
                }

            }

            

        }

        if (isRakiyanNumber == true) {
            console.log("<li><span class='rakiya'>" + i + '</span><a href="view.php?id=' + i + '>View</a></li>');
        }
        else {
            console.log("<li><span class='num'>" + i + '</span></li>');
        }

    }

    console.log('</ul>');
}

doubleRakiyaNumbers(['30000', '30030']);