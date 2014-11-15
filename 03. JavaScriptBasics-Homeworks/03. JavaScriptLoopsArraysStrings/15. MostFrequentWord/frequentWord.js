'use strict';

function findMostFreqWord(str) {

    str = str.toLowerCase();

    str = str.split(/\W+/).filter(Boolean);

    var result = [];
    var maxFrequency = 0;

    for (var i = 0; i < str.length; i++) {

        var element = str[i];
        var frequency = 1;

        for (var j = i + 1; j < str.length; j++) {

            if (element === str[j]) {
                frequency++;
            }

        }

        if (frequency > maxFrequency) {
            maxFrequency = frequency;
            result = new Array();
            result.push(element);
        }
        else if (frequency == maxFrequency) {
            result.push(element);
        }

    }

    result = result.sort();
    for (var i = 0; i < result.length; i++) {

        console.log(result[i] + ' -> ' + maxFrequency + ' times');

    }

    console.log();
}

findMostFreqWord('in the middle of the night');
findMostFreqWord('Welcome to SoftUni. Welcome to Java. Welcome everyone.');
findMostFreqWord('Hello my friend, hello my darling. Come on, come here. Welcome, welcome darling.');