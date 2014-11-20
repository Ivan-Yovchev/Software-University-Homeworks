'use strict';

function soccerResults(arr) {

    var result = {};

    for (var i = 0; i < arr.length; i++) {

        var split = arr[i].split(/[/:-]/);
        
        for (var j = 0; j < split.length; j++) {

            if (split[j].charAt(0) == ' ') {
                split[j] = split[j].slice(1, split[j].length);
            }
            
            if (split[j].charAt(split[j].length - 1) == ' ') {
                split[j] = split[j].slice(0, split[j].length - 1);
            }

        }

        if (typeof (result[split[0]]) == 'undefined') {

            var array = [];
            array.push(split[1]);
            result[split[0]] = { 'goalsScored': Number(split[2]), 'goalsConceded': Number(split[3]), 'matchesPlayedWith': array };

        }
        else if(result[split[0]] != 'undefined'){

            var team = result[split[0]];

            team.goalsScored += Number(split[2]);
            team.goalsConceded += Number(split[3]);
            var temp = team.matchesPlayedWith;

            if (temp.indexOf(split[1]) > -1) {
                continue;
            }
            else {
                temp.push(split[1]);
            }

            team.matchesPlayedWith = temp;
            result[split[0]] = team;

        }

        //second team
        if (typeof (result[split[1]]) == 'undefined') {

            var array = [];
            array.push(split[0]);
            result[split[1]] = { 'goalsScored': Number(split[3]), 'goalsConceded': Number(split[2]), 'matchesPlayedWith': array };

        }
        else if (result[split[1]] != 'undefined') {

            var team = result[split[1]];

            team.goalsScored += Number(split[3]);
            team.goalsConceded += Number(split[2]);
            var temp = team.matchesPlayedWith;

            if (temp.indexOf(split[1]) > -1) {
                continue;
            }
            else {
                temp.push(split[0]);
            }

            team.matchesPlayedWith = temp;
            result[split[1]] = team;

        }
    }

    var keys = [];
    for (var key in result) {

        keys.push(key)

        var obj = result[key];

        obj.matchesPlayedWith.sort();

    }

    keys.sort();

    var newResult = {};
    for (var i = 0; i < keys.length; i++) {
        newResult[keys[i]] = result[keys[i]];
    }

    result = newResult;
    console.log(result);

}

soccerResults(['Levski / CSKA: 0-2',
'Pavlikeni / Loko Gorna: 4-2',
'Loko Gorna / Levski: 1-4',
'Litex / Loko Gorna: 0-0',
'Beroe / Botev Plovdiv: 2-1',
'Loko Gorna / Beroe: 3-1',
'Pavlikeni / Ludogorets: 0-2',
'Loko Sofia / Litex: 0-2',
'Pavlikeni / Marek: 1-1',
'Litex / Levski: 0-0',
'Beroe / Litex: 3-2',
'Litex / Beroe: 1-0',
'Ludogorets / Litex: 3-0',
'Litex / Ludogorets: 1-0',
'CSKA / Beroe: 1-0',
'Botev Plovdiv / CSKA: 1-1',
'Ludogorets / Loko Sofia: 1-0',
'Litex / CSKA: 0-1',
'Marek / Haskovo: 0-1',
'Levski / Loko Gorna: 1-1']);