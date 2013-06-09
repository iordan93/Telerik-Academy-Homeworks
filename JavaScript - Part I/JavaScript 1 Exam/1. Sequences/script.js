function Solve(params) {
    var N = parseInt(params[0]);
    var answer = 1;
    var sequence = new Array(N);
    var i, index;
    for (i = 0; i < N; i++) {
        sequence[i] = parseInt(params[+i + 1]);
    }
    //console.log(sequence);

    var currentStart = 0;
    var currentLength = 1;

    for (index = 1; index < sequence.length; index++) {
        if (sequence[index] > sequence[index - 1]) {
            currentLength++;
        }
        else if (sequence[index] < sequence[index - 1]) {
            {
                currentLength = 1;
                currentStart = index;
                answer++;
            }
        }

        else if (sequence[index] === sequence[index - 1]) {

            if ((+index+1<N)&&(sequence[+index + 1] === sequence[index])) {
                currentLength++;
            }
        }
    }
    return answer.toString();
}