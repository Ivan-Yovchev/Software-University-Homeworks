'use strict';

function printNotebook(arr) {

    var obj = {};
    var colors = [];
    for (var i = 0; i < arr.length; i++) {

        var split = arr[i].split('|');

        if (typeof obj[split[0]] == 'undefined') {
            var colorObj = { 'age': 'empty', 'name': 'empty', 'opponents': [], 'wins': 0, 'loss': 0 };
            obj[split[0]] = colorObj;
            colors.push(split[0]);
        }

        if (split[1] == 'age') {
            obj[split[0]].age = Number(split[2]);
        }
        else if (split[1] == 'name') {
            obj[split[0]].name = split[2];
        }
        else if (split[1] == 'win') {
            obj[split[0]].wins++
            obj[split[0]].opponents.push(split[2]);
        }
        else if (split[1] == 'loss') {
            obj[split[0]].loss++
            obj[split[0]].opponents.push(split[2]);
        }

    }

    var result = {};
    for (var key in obj) {
        if (obj[key].name == 'empty' || obj[key].age == 'empty') {
            delete obj[key];
        }
        else {
            var temp = { 'age': 'empty', 'name': 'empty', 'opponents': [], 'rank': 0 };
            temp.age = obj[key].age.toString();
            temp.name = obj[key].name;
            temp.opponents = obj[key].opponents.sort();

            var average = ((obj[key].wins + 1) / (obj[key].loss + 1)).toFixed(2);

            temp.rank = average;
            result[key] = temp;
        }
    }
    
    colors.sort();

    var final = {};

    for (var i = 0; i < colors.length; i++) {
        final[colors[i]] = result[colors[i]];
    }

    console.log(JSON.stringify(final));
}

printNotebook(['purple|age|99',
'red|age|44',
'blue|win|pesho',
'blue|win|mariya',
'purple|loss|Kiko',
'purple|loss|Kiko',
'purple|loss|Kiko',
'purple|loss|Yana',
'purple|loss|Yana',
'purple|loss|Manov',
'purple|loss|Manov',
'red|name|gosho',
'blue|win|Vladko',
'purple|loss|Yana',
'purple|name|VladoKaramfilov',
'blue|age|21',
'blue|loss|Pesho']);