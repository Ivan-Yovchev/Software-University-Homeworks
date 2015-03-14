Object.prototype.inherits = function inherits(parent) {
    this.prototype = Object.create(parent.prototype);
    this.prototype.constructor = this;
};

var Shapes = (function createShapes() {
    var Shape = (function shapeIIFE() {
        function Shape(x, y, color) {
            if (!(this instanceof arguments.callee)) {
                return new arguments.callee(x, y, color);
            }
            
            this._x = x;
            this._y = y;
            this._color = color;
        }
        
        Shape.prototype.canvas = function canvas() {
            var canvas = document.getElementById("canvas").getContext("2d");;
            return canvas;
        };
        
        Shape.prototype.toString = function () {
            return "Shape [ (" + this._x + ", " + this._y + "), Color: " + this._color + " ]";
        };
        
        return Shape;
    })();
    
    var Circle = (function circleIIFE() {
        function Circle(x, y, color, radius) {
            if (!(this instanceof arguments.callee)) {
                return new arguments.callee(x, y, color, radius);
            }
            
            Shape.apply(this, arguments);
            this._radius = radius;
        }
        
        Circle.inherits(Shape);
        Circle.prototype.toString = function () {
            return "Circle [ O(" + this._x + ", " + this._y + "), Radius: " + this._radius + ", Color: " + this._color + " ]";
        };
        
        Circle.prototype.draw = function draw() {
            this.canvas().beginPath();
            this.canvas().arc(this._x, this._y, this._radius, 0, Math.PI * 2, true);
            this.canvas().fillStyle = this._color;
            this.canvas().fill();
        };
        
        return Circle;
    })();
    
    var Rectangle = (function rectangleIIFE() {
        function Rectangle(x, y, color, width, height) {
            if (!(this instanceof arguments.callee)) {
                return new arguments.callee(x, y, color, width, height);
            }
            
            Shape.apply(this, arguments);
            this._width = width;
            this._height = height;
        }
        
        Rectangle.inherits(Shape);
        Rectangle.prototype.toString = function () {
            return "Rectangle [ A(" + this._x + ", " + this._y + "), Width: " + this._width + ", Height: " + this._height + ", Color: " + this._color + " ]";
        };
        
        Rectangle.prototype.draw = function draw() {
            this.canvas().beginPath();
            this.canvas().fillStyle = this._color;
            this.canvas().fillRect(this._x, this._y, this._width, this._height);
        };
        
        return Rectangle;
    })();
    
    var Triangle = (function rectangleIIFE() {
        function Triangle(x, y, color, x2, y2, x3, y3) {
            if (!(this instanceof arguments.callee)) {
                return new arguments.callee(x, y, color, x2, y2, x3, y3);
            }
            
            Shape.apply(this, arguments);
            this._x2 = x2;
            this._y2 = y2;
            this._x3 = x3;
            this._y3 = y3;
        }
        
        Triangle.inherits(Shape);
        Triangle.prototype.toString = function () {
            return "Triangle [ A(" + this._x + ", " + this._y + "), B(" + this._x2 + ", " + this._y2 + "), C(" + this._x3 + ", " + this._y3 + "), Color: " + this._color + "]";
        };
        
        Triangle.prototype.draw = function draw() {
            this.canvas().beginPath();
            this.canvas().moveTo(this._x, this._y);
            this.canvas().lineTo(this._x2, this._y2);
            this.canvas().lineTo(this._x3, this._y3);
            this.canvas().fillStyle = this._color;
            this.canvas().fill();
        };

        return Triangle;
    })();
    
    var Line = (function lineIIFE() {
        function Line(x, y, color, x2, y2) {
            if (!(this instanceof arguments.callee)) {
                return new arguments.callee(x, y, color, x2, y2);
            }
            
            Shape.apply(this, arguments);
            this._x2 = x2;
            this._y2 = y2;
        }
        
        Line.inherits(Shape);
        Line.prototype.toString = function () {
            return "Line [ A(" + this._x + ", " + this._y + "), B(" + this._x2 + ", " + this._y2 + "), Color: " + this._color + "]";
        };
        
        Line.prototype.draw = function draw() {
            this.canvas().beginPath();
            this.canvas().moveTo(this._x, this._y);
            this.canvas().lineTo(this._x2, this._y2);
            this.canvas().strokeStyle = this._color;
            this.canvas().stroke();
        };

        return Line;
    })();
    
    var Segment = (function segmentIIFE() {
        function Segment(x, y, color, x2, y2) {
            if (!(this instanceof arguments.callee)) {
                return new arguments.callee(x, y, color, x2, y2);
            }
            
            Shape.apply(this, arguments);
            this._x2 = x2;
            this._y2 = y2;
        }
        
        Segment.inherits(Shape);
        Segment.prototype.toString = function () {
            return "Segment [ A(" + this._x + ", " + this._y + "), B(" + this._x2 + ", " + this._y2 + "), Color: " + this._color + "]";
        };
        
        Segment.prototype.draw = function draw() {
            this.canvas().beginPath();
            this.canvas().moveTo(this._x, this._y);
            this.canvas().lineTo(this._x2, this._y2);
            this.canvas().strokeStyle = this._color;
            this.canvas().stroke();
        };

        return Segment;
    })();
    
    return {
        Shape: Shape,
        Circle: Circle,
        Rectangle: Rectangle,
        Triangle: Triangle,
        Line: Line,
        Segment: Segment,
    };
})();
module.exports = Shapes;