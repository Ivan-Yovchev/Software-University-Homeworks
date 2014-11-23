'use strict';

function findSwordsAndDaggers(input) {

    var bladeLengths = [];

    for (var i = 0; i < input.length; i++) {

        var length = input[i];
        length = length.split('.');
        length = length[0];

        //console.log(length);;
        length = Number(length);

        if (length > 10) {
            bladeLengths.push(length);
        }
    }
    //console.log(bladeLengths);
    console.log('<table border="1">');
    console.log('<thead>');
    console.log('<tr><th colspan="3">Blades</th></tr>');
    console.log('<tr><th>Length [cm]</th><th>Type</th><th>Application</th></tr>');
    console.log('</thead>');
    console.log('<tbody>')

    for (var i = 0; i < bladeLengths.length; i++) {

        var bladeType, bladeApplication;

        //blade type
        if (bladeLengths[i] > 40) {
            bladeType = 'sword';
        }
        else {
            bladeType = 'dagger';
        }

        //blade application
        if (bladeLengths[i] % 5 == 1) {
            bladeApplication = 'blade';
        }
        else if (bladeLengths[i] % 5 == 2) {
            bladeApplication = 'quite a blade';
        }
        else if (bladeLengths[i] % 5 == 3) {
            bladeApplication = 'pants-scraper';
        }
        else if (bladeLengths[i] % 5 == 4) {
            bladeApplication = 'frog-butcher';
        }
        else if (bladeLengths[i] % 5 == 0) {
            bladeApplication = '*rap-poker';
        }

        console.log('<tr><td>' + bladeLengths[i] + '</td><td>' + bladeType + '</td><td>' + bladeApplication + '</td></tr>');

    }
    console.log('</tbody>');
    console.log('</table>');
}

findSwordsAndDaggers(['17.8',
'19.4',
'13',
'55.8',
'126.96541651',
'3']);