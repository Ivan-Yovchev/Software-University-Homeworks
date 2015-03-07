var Vector = (function () {
    function Vector() {
        if (arguments.length == 0) {
            throw new Error("Vectror cannot be empty");
        }
        else if (arguments[0].length == 0) {
            throw new Error("Vectror cannot be empty");
        }
        else if (!(this instanceof arguments.callee)) {
            return new arguments.callee();
        }
        
        this.dimension = arguments[0];
    }
    
    Vector.prototype.toString = function () {
        return "(" + this.dimension.join(', ') + ")";
    }
    
    Vector.prototype.add = function add(other) {
        if (this.dimension.length != other.dimension.length) {
            throw new Error("The two vectors must be of the same dimension");
        }

        var newVectorDimension = [];
        for (var i = 0; i < this.dimension.length; i++) {
            newVectorDimension.push(this.dimension[i] + other.dimension[i]);
        }

        return new Vector(newVectorDimension);
    }
    
    Vector.prototype.subtract = function subtract(other) {
        if (this.dimension.length != other.dimension.length) {
            throw new Error("The two vectors must be of the same dimension");
        }
        
        var newVectorDimension = [];
        for (var i = 0; i < this.dimension.length; i++) {
            newVectorDimension.push(this.dimension[i] - other.dimension[i]);
        }
        
        return new Vector(newVectorDimension);
    }
    
    Vector.prototype.dot = function dot(other) {
        if (this.dimension.length != other.dimension.length) {
            throw new Error("The two vectors must be of the same dimension");
        }
        
        var dot = 0;
        for (var i = 0; i < this.dimension.length; i++) {
            dot += (this.dimension[i] * other.dimension[i]);
        }
        
        return dot;
    }
    
    Vector.prototype.norm = function norm() {
        var norm = 0;
        for (var i = 0; i < this.dimension.length; i++) {
            norm += this.dimension[i] * this.dimension[i];
        }
        
        return Math.sqrt(norm);
    }

    return Vector;
})();

var a = new Vector([1, 2, 3]);
var b = new Vector([4, 5, 6]);
var c = new Vector([1, 1, 1, 1, 1, 1, 1, 1, 1, 1]);
//console.log(a.toString());
//console.log(c.toString());

// The following throw errors
//var wrong = new Vector();
//var anotherWrong = new Vector([]);

//var result = a.add(b);
//console.log(result.toString());
//a.add(c); // Error

//var result = a.subtract(b);
//console.log(result.toString());

//a.subtract(c); // Error

//var result = a.dot(b);
//console.log(result.toString());

//a.dot(c); // Error

//console.log(a.norm());
//console.log(b.norm());
//console.log(c.norm());
//console.log(a.add(b).norm());


