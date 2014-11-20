'use strict';

//function sortTable(arr) {

//    var result = {};

//    for (var i = 2; i < arr.length - 1; i++) {

//        var line = arr[i].slice(8, arr[i].length);

//        var productName = line.slice(0, line.indexOf('<'));
//        //console.log(productName);

//        line = line.slice(productName.length + 9, line.length);

//        var price = line.slice(0, line.indexOf('<'));
//        //console.log(price);

//        line = line.slice(price.length + 9, line.length);
//        price = Number(price);

//        var votes = line.slice(0, line.indexOf('<'));
//        //console.log(votes);

//        if (typeof (result[price]) == 'undefined') {

//            var products = [productName];
//            var nameAndVotes = [products, votes];
//            result[price] = nameAndVotes;

//        }
//        else {

//            var nameAndVotes = result[price];
//            var products = nameAndVotes[0];
//            products.push(productName);
//            nameAndVotes[0] = products;
//            result[price] = nameAndVotes;

//        }

//    }

//    var keys = [], min, index;
//    for (var key in result) {
//        keys.push(Number(key));
//    }

//    keys.sort(function (a, b) { return a - b });

//    console.log('<table>');
//    console.log('<tr><th>Product</th><th>Price</th><th>Votes</th></tr>');
//    for (var i = 0; i < keys.length; i++) {

//        var array = result[keys[i].toString()];

//        if (array[0].length > 1) {

//            array[0].sort();
//            for (var j = 0; j < array[0].length; j++) {
//                var string = '<tr><td>' + array[0][j] + '</td><td>' + keys[i] + '</td><td>' + array[1] + '</td></tr>';
//                console.log(string);
//            }

//        }
//        else {
//            var string = '<tr><td>' + array[0][0] + '</td><td>' + keys[i] + '</td><td>' + array[1] + '</td></tr>';
//            console.log(string);
//        }

//    }
//    console.log('</table>');
    
//}

function sortTable(input) {
    var rows = [];
    for (var i = 2; i < input.length - 1; i++) {
        var rowData = input[i];
        var regex = /<td>.*?<\/td><td>(.*?)<\/td>/g;
        var match = regex.exec(rowData);
        var price = Number(match[1]);
        var row = { price: price, data: rowData };
        rows.push(row);
    }
    rows.sort(function (a, b) {
        if (a.price != b.price) {
            return a.price - b.price;
        } else {
            return a.data == b.data ? 0 : a.data < b.data ? -1 : 1;
        }
    });
    console.log(input[0]);
    console.log(input[1]);
    for (var i = 0; i < rows.length; i++) {
        console.log(rows[i].data);
    }
    console.log(input[input.length - 1]);
}

sortTable(['<table>',
'<tr><th>Product</th><th>Price</th><th>Votes</th></tr>',
'<tr><td>Vodka Finlandia 1 l</td><td>19.35</td><td>+12</td></tr>',
'<tr><td>Ariana Radler 0.5 l</td><td>1.19</td><td>+33</td></tr>',
'<tr><td>Laptop HP 250 G2</td><td>629</td><td>+1</td></tr>',
'<tr><td>Kamenitza Grapefruit 1 l</td><td>1.85</td><td>+7</td></tr>',
'<tr><td>Ariana Grapefruit 1.5 l</td><td>1.85</td><td>+7</td></tr>',
'<tr><td>Coffee Davidoff 250 gr.</td><td>11.99</td><td>+11</td></tr>',
'</table>']);