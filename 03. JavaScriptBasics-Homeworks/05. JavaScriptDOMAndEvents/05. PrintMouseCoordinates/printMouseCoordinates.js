'use strict';

function printMouseCoordinates(event) {
    document.body.innerHTML += 'X: ' + event.pageX + '; Y: ' + event.pageY + '; Time: ' + new Date() + '</br>';
}

document.addEventListener('mousemove', printMouseCoordinates, false);