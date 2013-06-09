function Solve(args) {
    var nmj = args[0].split(" ");
    var N = nmj[0];
    var M = nmj[1];
    var J = nmj[2];

    var rc = args[1].split(" ");
    var startRow = rc[0];
    var startCol = rc[1];

    var i, j, jump;
    var jumps = new Array(J);
    for (i = 0; i < J; i++) {
        jumps[i] = [];
        jump = args[2 + i].split(" ");
        jumps[i][0] = jump[0];
        jumps[i][1] = jump[1];
    }

    var field = new Array(N);
    var currNum = 1;
    for (i = 0; i < N; i++) {
        field[i] = new Array(M);
        for (j = 0; j < M; j++) {
            field[i][j] = currNum;
            currNum++;
        }
    }
    //var visited = new Array(N);
    //for (i = 0; i < N; i++) {
    //    visited[i] = new Array(M);
    //    for (j = 0; j < M; j++) {
    //        visited[i][j] = false;
    //    }
    //}

    var startPoint = field[startRow][startCol];
    var sum = startPoint;
    var escaped = false;
    while (!escaped) {
        for (i = 0; i < jumps.length; i++) {
            var currRow = +startRow + parseInt(jumps[i][0]);
            var currCol = +startCol + parseInt(jumps[i][1]);
            startRow = currRow;
            startCol = currCol;
            if (typeof field[currRow] == "undefined" || typeof field[currRow][currCol] == "undefined") {
                return "escaped " + sum;
            }
            var currPosition = field[currRow][currCol];
            sum += currPosition;
        }
        if (!escaped && i === jumps[jumps.length - 1]) {
            i === 0;
        }
        //var visitedCells = 0;

    }
}