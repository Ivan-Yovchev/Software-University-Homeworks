var CreateElements = CreateElements || {};

(function (CreateElements) {
    var number = 0;
    function Container(title) {
        number++;
        Element.call(this, title);
    }

    Container.inherits(Element);
    
    Container.prototype.addToDom = function () {
        var container = document.createElement("section");

        var header = document.createElement("h1");
        header.innerHTML = this._title + " <i>TODO</i> List";
        container.appendChild(header);

        var div = document.createElement("div");
        div.appendChild(header);
        container.appendChild(div);
        
        var emptyDiv = document.createElement("div");
        emptyDiv.id = "Container" + number;
        container.appendChild(emptyDiv);

        var input = document.createElement("input");
        input.type = "text";
        input.placeholder = 'Title';
        input.id = 'sectionTitle' + number;
        container.appendChild(input);
        
        var button = document.createElement("button");
        button.innerHTML = 'New Section';
        button.onclick = function () {
            addSection(number);
        }
        container.appendChild(button);

        document.getElementById('containerHolder').appendChild(container);
    }

    CreateElements.createContainer = function (title) {
        return new Container(title);
    }
})(CreateElements);