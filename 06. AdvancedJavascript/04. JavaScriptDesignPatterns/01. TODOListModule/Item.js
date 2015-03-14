var CreateElements = CreateElements || {};

(function (CreateElements) {
    var number = 0;
    
    function Item(title) {
        number++;
        ListElement.call(this, title);
        this._id = 'item' + number;
    }
    function Item(title) {
        Element.call(this, title);
    }
    
    Item.inherits(Element);
    
    Item.prototype.addToDom = function (id) {
        var div = document.createElement("div");
        
        var input = document.createElement("input");
        input.type = "checkbox";
        input.id = this._id;
        
        var label = document.createElement("label");
        label.innerHTML = this._title;
        label.htmlFor = this._id;
        
        div.appendChild(input);
        div.appendChild(label);

        document.getElementById('Section' + id).appendChild(div);
    };
    
    CreateElements.createItem = function (title) {
        return new Item(title);
    }
})(CreateElements);