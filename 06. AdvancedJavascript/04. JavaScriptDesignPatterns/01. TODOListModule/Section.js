var CreateElements = CreateElements || {};

(function (CreateElements) {
    var number = 0;
    function Section(title) {
        number++;
        Element.call(this, title);
    }
    
    Section.inherits(Element);
    
    Section.prototype.addToDom = function (id) {
        var header = document.createElement("h2");
        header.innerHTML = this._title;
        
        var itemDiv = document.createElement("div");
        itemDiv.appendChild(header);
        
        var emptyDiv = document.createElement("span");
        emptyDiv.id = "Section" + number;
        itemDiv.appendChild(emptyDiv);

        var input = document.createElement("input");
        input.type = "text";
        input.placeholder = 'Add item...';
        input.id = 'itemTitle' + number;
        
        var button = document.createElement("button");
        button.innerHTML = '+';
        button.onclick = function () {
            addItem(number);
        }
        
        var buttonDiv = document.createElement("div");
        buttonDiv.appendChild(input);
        buttonDiv.appendChild(button);
        
        var section = document.createElement("article");
        
        //section.id = "Section" + number;
        
        section.appendChild(itemDiv);
        section.appendChild(buttonDiv);

        document.getElementById('Container' + id).appendChild(section);
    }
    
    CreateElements.createSection = function (title) {
        return new Section(title);
    }
})(CreateElements);