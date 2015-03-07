String.prototype.startsWith = function startsWith(substring){
    var startString = "";
    for (var i = 0; i < substring.length; i++) {
        startString += this[i];
    }

    if (startString === substring) {
        return true;
    }
    else {
        return false;
    }
}

//var example = "This is an example string used only for demonstration purposes.";
//console.log(example.startsWith("This"));
//console.log(example.startsWith("this"));
//console.log(example.startsWith("other"));

String.prototype.endsWith = function endsWith(substring) {
    var endString = "";
    for (var i = this.length - substring.length; i < this.length; i++) {
        endString += this[i];
    }

    if (endString === substring) {
        return true;
    }
    else {
        return false;
    }
}

//var example = "This is an example string used only for demonstration purposes.";
//console.log(example.endsWith("poses."));
//console.log(example.endsWith("example"));
//console.log(example.startsWith("something else"));

String.prototype.left = function left(count) {
    var result = "";
    if (count > this.length) {
        result = this.toString();
    }
    else {
        for (var i = 0; i < count; i++) {
            result += this[i];
        }
    }

    return result;
}

//var example = "This is an example string used only for demonstration purposes.";
//console.log(example.left(9));
//console.log(example.left(90));

String.prototype.right = function right(count) {
    var result = "";
    if (count > this.length) {
        result = this.toString();
    }
    else {
        for (var i = this.length - count; i < this.length; i++) {
            result += this[i];
        }
    }
    
    return result;
}

//var example = "This is an example string used only for demonstration purposes.";
//console.log(example.right(9));
//console.log(example.right(90));
//var example = "abcdefgh";
//console.log(example.left(5).right(2));


String.prototype.padLeft = function padLeft() {
    var result = "";
    if (arguments.length == 2) {
        for (var i = 0; i < parseInt(arguments[0]); i++) {
            result += arguments[1];
        }
    }
    else {
        for (var i = 0; i < parseInt(arguments[0]); i++) {
            result += " ";
        }
    }

    return result + this.toString();
}

//var hello = "hello";
//console.log(hello.padLeft(5));
//console.log(hello.padLeft(10));
//console.log(hello.padLeft(5, "."));
//console.log(hello.padLeft(10, "."));
//console.log(hello.padLeft(2, "."));

String.prototype.padRight = function padRight() {
    var result = "";
    if (arguments.length == 2) {
        for (var i = 0; i < parseInt(arguments[0]); i++) {
            result += arguments[1];
        }
    }
    else {
        for (var i = 0; i < parseInt(arguments[0]); i++) {
            result += " ";
        }
    }
    
    return this.toString() + result;
}

//var hello = "hello";
//console.log(hello.padRight(5));
//console.log(hello.padRight(10));
//console.log(hello.padRight(5, "."));
//console.log(hello.padRight(10, "."));
//console.log(hello.padRight(2, "."));

String.prototype.repeat = function repeat(count) {
    var result = "";
    for (var i = 0; i < parseInt(count); i++) {
        result += this;
    }
    
    return result;
}

//var character = "*";
//console.log(character.repeat(5));
//console.log("~".repeat(3));

//console.log("*".repeat(5).padLeft(10, "-").padRight(15, "+"));
