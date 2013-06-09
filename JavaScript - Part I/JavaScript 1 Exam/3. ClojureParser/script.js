function Solve(params) {
    String.prototype.fulltrim = function () { return this.replace(/(?:(?:^|\n)\s+|\s+(?:$|\n))/g, '').replace(/\s+/g, ' ').replace(/\( /g, '(').replace(/ \)/g, ')'); };
    var commands = new Array(params.length);
    var i, j;
    var functionArgs = [];
    for (i = 0; i < commands.length; i++) {
        commands[i] = params[i].fulltrim().substring(1, params[i].length - 1);
    }
    var functions = [];

    for (i = 0; i < commands.length; i++) {
        // def
        if (commands[i][0] === "d") {
            var nameAndCommands = commands[i].substring(4, commands[i].length);
            var name = (commands[i].substring(4, commands[i].length)).substr(0, nameAndCommands.indexOf(" "));
            var functionChar = nameAndCommands[+nameAndCommands.indexOf("(") + 1];
            switch (functionChar) {
                case "+":
                case "-":
                case "*":
                case "/":
                    functionArgs = nameAndCommands.substr(name.length + 1).replace(/\(|\)/g, '').split(/ /g);
                    functions[name] = functionArgs;
                    // console.log(functionArgs);
                    break;
                default:
                    functionArgs[0] = nameAndCommands.substring(name.length + 1, nameAndCommands.length);
                    functions[name] = functionArgs;
                    break;
            }
        }
        else {
            functionArgs = commands[i].split(/ /g);
            functions["global_function"] = functionArgs;
        }
    }

    for (var i in functions) {
        for (j = 0; j < functions[i].length; j++) {
            if (!functions[i][j].match(/([+|\-|\*|/]|\b\d+\b)/g)) {
                for (var fn = 0; fn < functions.length; fn++) {
                    if (functions[i][j] === functions[fn]) {
                        functions[i][j] = parseFunction(functions[i][j]);
                    }
                }
            }
        }
        functions[i] = parseFunction(functions[i]);
    }

    function parseFunction(functionToParse) {
        switch (functionToParse[0]) {
            case "+":
                var sum = 0;
                for (i = 0; i < length; i++) {
                    sum += parseInt(functionToParse[i]);
                }
                return sum;
            case "-":
                var difference = 0;
                for (i = 0; i < length; i++) {
                    difference -= parseInt(functionToParse[i]);
                }
                return difference;
            case "*":
                var product = 1;
                for (i = 0; i < length; i++) {
                    product *= parseInt(functionToParse[i]);
                }
                return product;
            case "/":
                var division = 1;
                for (i = 0; i < length; i++) {
                    division /= parseInt(functionToParse[i]);
                }
                return Math.floor(division);
        }
    }

    console.log(functions);
}


