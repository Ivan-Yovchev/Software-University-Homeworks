Object.prototype.inherit = function (properties){
    function f() {};
    f.prototype = Object.create(this);
    for (var prop in properties) {
        f.prototype[prop] = properties[prop];
    }
    f.prototype._super = this;
    return new f();
}

var Shape = {
    init: function init(x, y, color){
        this._x = x;
        this._y = y;
        this._color = color;
    },
    toString: function() {
        return "Shape [ (" + this._x + ", " + this._y + "), Color: " + this._color + " ]";
    }
}

var Circle = Shape.inherit({
    init: function init(x, y, color, radius) {
        this._super.init.call(this, x, y, color);
        this._radius = radius;

        return this;
    },
    toString: function () {
        return "Circle [ O(" + this._x + ", " + this._y + "), Radius: " + this._radius + ", Color: " + this._color + " ]";
    }
});

var Rectangle = Shape.inherit({
    init: function init(x, y, color, width, height) {
        this._super.init.call(this, x, y, color);
        this._width = width;
        this._height = height;
        
        return this;
    },
    toString: function () {
        return "Rectangle [ A(" + this._x + ", " + this._y + "), Width: " + this._width + ", Height: " + this._height + ", Color: " + this._color + " ]";
    }
});

var Triangle = Shape.inherit({
    init: function init(x, y, color, x2, y2, x3, y3) {
        this._super.init.call(this, x, y, color);
        this._x2 = x2;
        this._y2 = y2;
        this._x3 = x3;
        this._y3 = y3;
        
        return this;
    },
    toString: function () {
        return "Triangle [ A(" + this._x + ", " + this._y + "), B(" + this._x2 + ", " + this._y2 + "), C(" + this._x3 + ", " + this._y3 + "), Color: " + this._color + "]";
    }
});

var Line = Shape.inherit({
    init: function init(x, y, color, x2, y2) {
        this._super.init.call(this, x, y, color);
        this._x2 = x2;
        this._y2 = y2;
        
        return this;
    },
    toString: function () {
        return "Line [ A(" + this._x + ", " + this._y + "), B(" + this._x2 + ", " + this._y2 + "), Color: " + this._color + "]";
    }
});

var Segment = Shape.inherit({
    init: function init(x, y, color, x2, y2) {
        this._super.init.call(this, x, y, color);
        this._x2 = x2;
        this._y2 = y2;
        
        return this;
    },
    toString: function () {
        return "Segment [ A(" + this._x + ", " + this._y + "), B(" + this._x2 + ", " + this._y2 + "), Color: " + this._color + "]";
    }
});

var circle = Object.create(Circle).init(2, 5, "red", 8.4);
console.log(circle.toString());

var rectangle = Object.create(Rectangle).init(2, 5, "red", 6, 9);
console.log(rectangle.toString());

var triangle = Object.create(Triangle).init(2, 5, "red", 6, 9, 6, 8);
console.log(triangle.toString());

var line = Object.create(Line).init(2, 5, "red", 12, 5.78);
console.log(line.toString());

var segment = Object.create(Segment).init(2, 5, "red", 12, 5.78);
console.log(segment.toString());