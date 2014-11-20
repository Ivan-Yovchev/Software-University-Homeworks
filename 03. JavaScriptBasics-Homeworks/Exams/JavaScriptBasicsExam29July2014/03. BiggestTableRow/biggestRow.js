'use strict';

function findBiggestTableRow(input) {

    var maxSum = Number.MIN_VALUE;
    var numbers;

    for (var i = 2; i < input.length - 1; i++) {

        var row = input[i].slice(8, input[i].length);

        var city = row.slice(0, row.indexOf('<'));
        row = row.slice(city.length + 9, row.length);

        var numStr1 = row.slice(0, row.indexOf('<'));
        row = row.slice(numStr1.length + 9, row.length);

        var numStr2 = row.slice(0, row.indexOf('<'));
        row = row.slice(numStr2.length + 9, row.length);

        var numStr3 = row.slice(0, row.indexOf('<'));
        row = row.slice(numStr3.length + 9, row.length);

        //console.log(city + ' ' + numStr1 + ' ' + numStr2 + ' ' + numStr3);

        var tempArray = [];
        if (numStr1 != '-') {
            tempArray.push(numStr1);
        }
        if (numStr2 != '-') {
            tempArray.push(numStr2);
        }
        if (numStr3 != '-') {
            tempArray.push(numStr3);
        }

        console.log(tempArray);

        if (tempArray.length == 0) {
            continue;
        }
        else {
            var sum = 0;
            for (var j = 0; j < tempArray.length; j++) {
                sum += Number(tempArray[j]);
            }

            if (sum >= 0 && maxSum >= 0) {
                if (sum > maxSum) {
                    maxSum = sum;
                    numbers = tempArray;
                }
            }
            else if (sum < 0 && maxSum < 0) {

                if (Math.abs(sum) < Math.abs(maxSum)) {
                    maxSum = sum;
                    numbers = tempArray;
                }
            }
        }

    }

    if (maxSum == Number.MIN_VALUE) {
        console.log('no data');
    }
    else {

        var str = '' + maxSum + ' = ';

        for (var i = 0; i < numbers.length; i++) {

            if (i != 0) {
                str += ' + ';
            }

            str += numbers[i];

        }

        console.log(str);

    }
}

//findBiggestTableRow(['<table>',
//'<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>',
//'<tr><td>Sofia</td><td>26.2</td><td>8.20</td><td>-</td></tr>',
//'<tr><td>Varna</td><td>11.2</td><td>18.00</td><td>36.10</td></tr>',
//'<tr><td>Plovdiv</td><td>17.2</td><td>12.3</td><td>6.4</td></tr>',
//'<tr><td>Bourgas</td><td>-</td><td>24.3</td><td>-</td></tr>',
//'</table>']);

//findBiggestTableRow(['<table>',
//'<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>',
//'<tr><td>Sofia</td><td>-</td><td>-</td><td>-</td></tr>',
//'</table>']);

//findBiggestTableRow(['<table>',
//'<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>',
//'<tr><td>Sofia</td><td>12850</td><td>-560</td><td>20833</td></tr>',
//'<tr><td>Rousse</td><td>-</td><td>50000.0</td><td>-</td></tr>',
//'<tr><td>Bourgas</td><td>25000</td><td>25000</td><td>-</td></tr>',
//'</table>']);

findBiggestTableRow(['<table>',
'<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>',
'<tr><td>Pleven</td><td>-100</td><td>-200</td><td>-</td></tr>',
'<tr><td>Varna</td><td>-100</td><td>-</td><td>-300</td></tr>',
'<tr><td>Rousse</td><td>-</td><td>-200</td><td>-100</td></tr>',
'</table>']);