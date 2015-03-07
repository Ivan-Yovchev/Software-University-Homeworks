"use strict";

function printArgsInfo() {
    for (var i = 0; i < arguments.length; i++) {
        var variableType = typeof arguments[i];
        if ((variableType == "object" || variableType == "string") && arguments[i] == "") {
            if (arguments[i] instanceof Array) {
                console.log("(array)");
            }
            else {
                console.log("(" + typeof arguments[i] + ")");
            }
        }
        else {
            if (arguments[i] instanceof Array) {
                console.log(arguments[i] + " (array)");
            }
            else {
                console.log(arguments[i] + " (" + typeof arguments[i] + ")");
            }
        }
    }
}

printArgsInfo(2, 3, 2.5, -110.5564, false);
console.log();
printArgsInfo(null, undefined, "", 0, [], {});
console.log();
printArgsInfo([1, 2], ["string", "array"], ["single value"]);
console.log();
printArgsInfo("some string", [1, 2], ["string", "array"], ["mixed", 2, false, "array"], { name: "Peter", age: 20 });
console.log();
printArgsInfo([[1, [2, [3, [4, 5]]]], ["string", "array"]]);
console.log();

printArgsInfo.call();
printArgsInfo.call(null, 2, 6.4, true);
printArgsInfo.apply();
printArgsInfo.apply(null, [2, 6.4, [], {}]);