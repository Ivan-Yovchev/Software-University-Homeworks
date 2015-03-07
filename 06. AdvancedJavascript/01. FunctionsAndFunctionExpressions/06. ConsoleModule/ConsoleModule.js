var specialConsole = (function specialConsole() {
    
    function writeLine() {
        if (arguments.length > 2) {
            console.log(writeLineWithArguments(arguments));
        }
        else {
            console.log(writeLineWithoutArguments(arguments));
        }
    }
    
    function writeError() {
        if (arguments.length > 2) {
            console.error(writeLineWithArguments(arguments));
        }
        else {
            console.error(writeLineWithoutArguments(arguments));
        }
    }
    
    function writeWarning() {
        if (arguments.length > 2) {
            console.warn(writeLineWithArguments(arguments));
        }
        else {
            console.warn(writeLineWithoutArguments(arguments));
        }
    }
    
    function writeLineWithoutArguments(args) {
        var strResult = args[0].toString();
        return strResult;
    }
    
    function writeLineWithArguments(args) {
        var pattern = args[0];
        var isThereAPlaceHolder = pattern.match(/{{1}[0-9]}{1}/g);
        var arrReplacement = [];
        arrReplacement[0] = pattern.replace(isThereAPlaceHolder[0], args[1]);
        if (isThereAPlaceHolder.length > 1) {
            for (var i = 1; i < isThereAPlaceHolder.length; i++) {
                arrReplacement[i] = arrReplacement[i - 1].replace(isThereAPlaceHolder[i], args[i + 1]);
            }
        }
        var strResult = arrReplacement[arrReplacement.length - 1].toString();
        return strResult;
    }
    
    return {
        writeLine: writeLine,
        writeError: writeError,
        writeWarning: writeWarning
    };

})();

specialConsole.writeLine("Message: hello");
specialConsole.writeLine("Message: {0}", "hello");
specialConsole.writeError("Error: {0}", "A fatal error has occurred.");
specialConsole.writeWarning("Warning: {0}", "You are not allowed to do that!");
specialConsole.writeInfo("Info: {0}", "Hi there! Here is some info for you.");
