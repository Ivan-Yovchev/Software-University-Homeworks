var input = '[{"manufacturer":"BMW","model":"E92 320i","year":2011,"price":50000,"class":"Family"},{"manufacturer":"Porsche","model":"Panamera","year":2012,"price":100000,"class":"Sport"},{"manufacturer":"Peugeot","model":"305","year":1978,"price":1000,"class":"Family"}]';

var table = $('<table border=1>');

var carJson = $.parseJSON(input);
for (var i = 0; i < carJson.length; i++) {
    var row = $('<tr>');
    row.append($('<td>').text(carJson[i].manufacturer));
    row.append($('<td>').text(carJson[i].model));
    row.append($('<td>').text(carJson[i].year));
    row.append($('<td>').text(carJson[i].price));
    row.append($('<td>').text(carJson[i].class));
    table.append(row);
}

var tableHead = $('<thead>');
for (var carInfo in carJson[0]) {
    tableHead.append($('<th>').text(carInfo));
}

table.prepend(tableHead);
table.appendTo(document.body);
table.css('border-collapse', 'collapse');
$('table th').css('background-color', 'coral');
$('table td').css('padding', '10px 5px 10px 5px');
$('table td').css('width', '100px');