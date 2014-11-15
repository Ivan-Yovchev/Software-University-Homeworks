'use strict';

function findCardFrequencies(str) {

    str = str.split(/[ ♥♣♦♠]+/).filter(Boolean);

    var cards = {};
    var printSequence = [];

    // count card frequencies
    for (var i = 0; i < str.length; i++) {

        var element = str[i];

        if ((str[i] in cards) == false) {
            
            cards[element] = 1;
            printSequence.push(element);

        }
        else {
            cards[element]++;
        }

    }


    //output
    for (var i = 0; i < printSequence.length; i++) {

        var percent = (cards[printSequence[i]] / str.length) * 100;
        console.log(printSequence[i] + ' -> ' + percent.toFixed(2) + '%');

    }
    console.log();

}

findCardFrequencies('8♥ 2♣ 4♦ 10♦ J♥ A♠ K♦ 10♥ K♠ K♦');
findCardFrequencies('J♥ 2♣ 2♦ 2♥ 2♦ 2♠ 2♦ J♥ 2♠');
findCardFrequencies('10♣ 10♥');