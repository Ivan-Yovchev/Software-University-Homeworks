function hideOddRows() {

    var tableRows = document.getElementsByTagName('tr');

    for (var i = 0; i < tableRows.length; i++) {

        if (i % 2 == 0) {
            tableRows[i].style.display = 'none';
        }

    }

}