'use strict';

function variablesTypes(input) {
   
    console.log('My name: ' + input[0] + ' //type is ' + typeof input[0]);
    console.log('My age: ' + input[1] + ' //type is ' + typeof input[1]);
    console.log('I am male: ' + input[2] + ' //type is ' + typeof input[2]);
    console.log('My favorite foods are: ' + input[3] + ' //type is ' + typeof input[3]);
}

variablesTypes(['Pesho', 22, true, ['fries', 'banana', 'cake']]);