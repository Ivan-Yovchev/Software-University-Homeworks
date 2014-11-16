'use strict';

function concerts(input) {

    var concertsSorted = {};

    for (var i = 0; i < input.length; i++) {

        var temp = input[i].split('|');
        //console.log(temp);

        var band = temp[0].slice(0, temp[0].length - 1);
        var city = temp[1].slice(1, temp[1].length - 1);
        var stadium = temp[3].slice(1, temp[3].length);

        if (concertsSorted[city] !== undefined) {

            var tempObj = concertsSorted[city];

            if (tempObj[stadium] !== undefined) {

                var tempArray = tempObj[stadium];

                if (tempArray.indexOf(band) > -1) {
                    continue;
                }
                else {
                    tempArray.push(band);
                    tempObj[stadium] = tempArray;
                    concertsSorted[city] = tempObj;
                }


            }
            else {
                tempObj[stadium] = [band];
                concertsSorted[city] = tempObj;
            }

        }
        else {
            var obj = {};
            obj[stadium] = [band];
            concertsSorted[city] = obj;

        }

    }

    //sorting
    for (var town in concertsSorted) {

        var obj = concertsSorted[town]
        var objKeys = [];

        //sort bands
        for (var place in obj) {

            var array = obj[place];
            array.sort();
            obj[place] = array;

        }

        //sort stadiums
        for (var key in obj) {
            objKeys.push(key);
        }

        objKeys.sort();
        var newObj = {};
        for (var i = 0; i < objKeys.length; i++) {

            newObj[objKeys[i]] = obj[objKeys[i]];

        }

        concertsSorted[town] = newObj;

    }

    //sort cities
    var cityKeys = [];
    for (var city in concertsSorted) {
        cityKeys.push(city);
    }
    cityKeys.sort();

    var newCity = {};
    for (var i = 0; i < cityKeys.length; i++) {

        newCity[cityKeys[i]] = concertsSorted[cityKeys[i]];

    }

    concertsSorted = newCity;

    console.log(JSON.stringify(concertsSorted));

}

concerts(['ZZ Top | London | 2-Aug-2014 | Wembley Stadium',
'Iron Maiden | London | 28-Jul-2014 | Wembley Stadium',
'Metallica | Sofia | 11-Aug-2014 | Lokomotiv Stadium',
'Helloween | Sofia | 1-Nov-2014 | Vassil Levski Stadium',
'Iron Maiden | Sofia | 20-June-2015 | Vassil Levski Stadium',
'Helloween | Sofia | 30-July-2015 | Vassil Levski Stadium',
'Iron Maiden | Sofia | 26-Sep-2014 | Lokomotiv Stadium',
'Helloween | London | 28-Jul-2014 | Wembley Stadium',
'Twisted Sister | London | 30-Sep-2014 | Wembley Stadium',
'Metallica | London | 03-Oct-2014 | Olympic Stadium',
'Iron Maiden | Sofia | 11-Apr-2016 | Lokomotiv Stadium',
'Iron Maiden | Buenos Aires | 03-Mar-2014 | River Plate Stadium'])