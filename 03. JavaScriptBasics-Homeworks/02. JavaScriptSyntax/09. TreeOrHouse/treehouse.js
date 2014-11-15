'use strict';

function treeHouseCompare() {

    var houseSide = arguments[0];
    var treeSide = arguments[1];

    //calculate house area
    var houseMain = houseSide * houseSide;
    var houseRoof = (houseSide * ((houseSide / 3) * 2)) / 2;
    var houseArea = houseMain + houseRoof;

    //calculate tree area
    var treeTrunk = treeSide * (treeSide / 3);
    var radius = (treeSide / 3) * 2;
    var treeCrown = Math.PI * radius * radius;
    var treeArea = treeTrunk + treeCrown;

    //output
    if (houseArea > treeArea) {
        console.log('house/' + houseArea.toFixed(2));
    }
    if (houseArea < treeArea) {
        console.log('tree/' + treeArea.toFixed(2));
    }

}

treeHouseCompare(3, 2);
treeHouseCompare(3, 3);
treeHouseCompare(4, 5);