(function () {
    document.addEventListener("dragstart", function (ev) {
        ev.dataTransfer.effectAllowed = "move";

        // The paper ball sends its id to be removed later
        ev.dataTransfer.setData('text/plain', ev.target.id)
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
    }, false);
})();