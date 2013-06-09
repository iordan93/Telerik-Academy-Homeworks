(function () {
    // Static class
    var Highscores = (function () {
        var getHighscores = function () {
            return JSON.parse(localStorage.getItem("highscores") || "[]");
        };

        var setHighscores = function (highscores) {
            localStorage.setItem("highscores", JSON.stringify(highscores));
        };

        var addHighscore = function (highscore) {
            var highscores = getHighscores();
            var newScoreIndex = highscores.length;

            for (var i = 0; i < newScoreIndex; i += 1) {
                var currentScore = highscores[i].score;

                if (highscore.score < currentScore) {
                    newScoreIndex = i;
                    break;
                }
            }

            highscores.splice(newScoreIndex, 0, highscore);

            if (highscores.length > 5) {
                highscores.pop();
            }

            setHighscores(highscores);
            renderHighscores();
        };

        var renderHighscores = function () {
            var container = document.querySelector("#highscores tbody");
            var fragment = document.createDocumentFragment();
            var highscores = getHighscores();
            length = highscores.length;

            // Put the score values in their respective places
            for (var i = 0; i < length; i++) {
                var userScore = highscores[i];

                var row = document.createElement("tr");
                var position = document.createElement("td");
                position.innerHTML = i + 1;
                row.appendChild(position);

                var name = document.createElement("td");
                name.innerHTML = userScore.name;
                row.appendChild(name);

                var score = document.createElement("td");
                score.innerHTML = userScore.score;
                row.appendChild(score);

                fragment.appendChild(row);
            }

            // Clear the container before adding the scores
            container.innerHTML = "";
            container.appendChild(fragment);
        };

        return {
            getHighscores: getHighscores,
            setHighscores: setHighscores,
            renderHighscores: renderHighscores,
            addHighscore: addHighscore
        };
    })();

    // Static class
    var Timer = (function () {
        var startTime = 0;
        var endTime = 0;
        var isStarted = false;

        var start = function () {
            isStarted = true;
            startTime = new Date();
        };

        var stop = function () {
            isStarted = false;
            endTime = new Date();
        };

        var elapsed = function () {
            if (!isStarted) {
                return endTime - startTime;
            }
            return -1;
        };

        var timerIsStarted = function () {
            return isStarted;
        };

        return {
            start: start,
            stop: stop,
            elapsed: elapsed,
            isStarted: timerIsStarted
        };
    })();

    // Event listeners
    document.body.onload = function () {
        Highscores.renderHighscores();
    };

    document.addEventListener("dragstart", function (ev) {
        ev.dataTransfer.effectAllowed = "move";

        // The paper ball sends its id to be removed later
        ev.dataTransfer.setData('text/plain', ev.target.id);
        if (!Timer.isStarted()) {
            Timer.start();
        }
    }, false);

    var bin = document.getElementById("recycle-bin");

    bin.addEventListener("dragenter", function (ev) {
        ev.dropEffect = "move";
    }, false);

    bin.addEventListener("dragover", function (ev) {
        ev.target.className = "opened";
        ev.preventDefault();
    }, false);

    bin.addEventListener("dragleave", function (ev) {
        ev.target.className = "";
    }, false);

    bin.addEventListener("drop", function (ev) {
        ev.preventDefault();
        var elementToRemove = document.getElementById(ev.dataTransfer.getData("text/plain"));
        elementToRemove.parentElement.removeChild(elementToRemove);
        ev.target.className = "";

        if (document.querySelectorAll("[draggable=\"true\"]").length === 0) {
            Timer.stop();
            var name = prompt("What is your name?");
            Highscores.addHighscore({ name: name || "Unknown", score: Timer.elapsed() });
        }
    }, false);
})();