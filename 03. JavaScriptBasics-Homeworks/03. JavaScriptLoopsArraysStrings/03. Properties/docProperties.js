function displayProperties() {

    var arr = Object.getOwnPropertyNames(document);
    arr.sort();

    var resultStr = arr.join('<br>');
    document.getElementById('result').innerHTML = resultStr;
}

displayProperties();