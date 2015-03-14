function addcontainer() {
    var title = document.getElementById('containerTitle').value;
    document.getElementById('containerTitle').value = null;
    var container = CreateElements.createContainer(title);
    container.addToDom();
}

function addSection(id) {
    var title = document.getElementById('sectionTitle' + id).value;
    document.getElementById('sectionTitle' + id).value = null;
    var section = CreateElements.createSection(title);
    section.addToDom(id);
}

function addItem(id) {
    var title = document.getElementById("itemTitle" + id).value;
    document.getElementById("itemTitle" + id).value = null;
    var item = CreateElements.createItem(title);
    item.addToDom(id);
    console.log(title);
}
