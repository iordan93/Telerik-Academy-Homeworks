function specialConsole() {
    function writeLine() {
        console.log(stringFormat.apply(null, arguments));
    }

    function writeError() {
        console.error(stringFormat.apply(null, arguments));
    }

    function writeWarning() {
        console.warn(stringFormat.apply(null, arguments));
    }
        
    function stringFormat() {
        // Prepare JSON objects for printing - stringify them, remove quotes and introduce correct spacing
        for (var i = 1; i < arguments.length; i++) {
            arguments[i] = JSON.stringify(arguments[i]).replace(/\"/g, "").replace(/:/g, ": ").replace(/,/g, ", ");
        }

        var functionArguments = arguments;
        var originalString = arguments[0];

        var formattedString = originalString.replace(/{(\d+)}/g, function (match, g1) {
            return functionArguments[parseInt(g1) + 1];
        });
        return formattedString;
    }

    return {
        writeLine: writeLine,
        writeError: writeError,
        writeWarning: writeWarning
    }
}