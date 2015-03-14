Object.prototype.inherits = function (parent) {
    this.prototype = Object.create(parent.prototype);
    this.prototype.constructor = this;
}

var Element = (function () {
    function Element(title) {
        this._setTitle(title);
    }

    Element.prototype._setTitle = function (title){
        if (!title) {
            throw new Error("Title cannot be empty");
        }

        this._title = title;
    }

    return Element;
})();