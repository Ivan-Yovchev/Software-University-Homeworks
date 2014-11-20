'use strict';

function pricesTrends(input) {
    var prices = input.map(Number);
    console.log("<table>");
    console.log("<tr><th>Price</th><th>Trend</th></tr>");

    var prevPrice = undefined;

    for (var i = 0; i < prices.length; i++) {

        var price = prices[i];
        var priceStr = price.toFixed(2);

        if (prevPrice == undefined || priceStr == prevPrice) {
            var trend = "fixed.png";
        }
        else if (price < prevPrice) {
            var trend = "down.png";
        }
        else {
            var trend = "up.png";
        }

        console.log("<tr><td>" + priceStr + "</td><td><img src=\"" + trend + "\"/></td></td>");
        prevPrice = priceStr;

    }
    console.log("</table>");
}

pricesTrends(['900', '1500']);

pricesTrends(['1.33', '1.35', '2.25', '13.00', '0.5', '0.51', '0.5', '0.5', '0.33', '1.05', '1.346', '20', '900', '1500.1', '1500.10', '2000']);

