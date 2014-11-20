'use strict';

function printAgrigatedStudents(input) {

    //var a = 1.495;
    //a = parseFloat(a.toFixed(2));

    var result = {};
    var average = {};

    for (var i = 0; i < input.length; i++) {

        var split = input[i].split('|');
        for (var j = 0; j < split.length; j++) {
            var str = split[j];
            str = str.trim();
            split[j] = str;
        }

        if (result[split[1]] == undefined) {
            result[split[1]] = { 'avgGrade': 0, 'avgVisits': 0, 'students': [] };
            average[split[1]] = 0;
        }

        result[split[1]].avgGrade += Number(split[2]);
        result[split[1]].avgVisits += Number(split[3]);
        average[split[1]]++;

        if (result[split[1]].students.indexOf(split[0]) == -1) {
            result[split[1]].students.push(split[0]);
        }

    }

    var keys = [];
    for (var key in result) {
        keys.push(key);
        result[key].students.sort();
    }

    keys.sort();

    var newResult = {};
    for (var i = 0; i < keys.length; i++) {

        newResult[keys[i]] = result[keys[i]];

        var averageGrade = result[keys[i]].avgGrade;
        var averageVisits = result[keys[i]].avgVisits;
        var averageDel = average[keys[i]];

        var averageGradeFinal = parseFloat((averageGrade / averageDel).toFixed(2));
        var averageVisitsFinal = parseFloat((averageVisits / averageDel).toFixed(2));

        newResult[keys[i]].avgGrade = averageGradeFinal;
        newResult[keys[i]].avgVisits = averageVisitsFinal;

    }

    console.log(JSON.stringify(newResult));

}

printAgrigatedStudents(['Peter Nikolov | PHP  | 5.50 | 8',
'Maria Ivanova | Java | 5.83 | 7',
'Ivan Petrov   | PHP  | 3.00 | 2',
'Ivan Petrov   | C#   | 3.00 | 2',
'Peter Nikolov | C#   | 5.50 | 8',
'Maria Ivanova | C#   | 5.83 | 7',
'Ivan Petrov   | C#   | 4.12 | 5',
'Ivan Petrov   | PHP  | 3.10 | 2',
'Peter Nikolov | Java | 6.00 | 9',])