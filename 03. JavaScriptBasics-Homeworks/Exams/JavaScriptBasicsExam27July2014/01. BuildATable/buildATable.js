'use strict';

function buildATable(input) {

    var start = Number(input[0]);
    var end = Number(input[1]);

    console.log('<table>');
    console.log('<tr><th>Num</th><th>Square</th><th>Fib</th></tr>');

    for (var i = start; i <= end; i++) {

        var nextRow = '<tr><td>' + i + '</td><td>' + i * i + '</td><td>';

        var fibNum = 5 * (i * i);

        if (Math.sqrt(fibNum - 4) % 1 === 0 || Math.sqrt(fibNum + 4) % 1 === 0) {
            nextRow += 'yes</td></tr>';
        }
        else {
            nextRow += 'no</td></tr>';
        }

        console.log(nextRow);

    }

    console.log('</table>');

}

buildATable(2, 6);
buildATable(55, 56);