function createRandomDivs()
{
    function getRandomIntegerInRange(min, max)
    {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    function getRandomColour() {
        var letters = '0123456789ABCDEF'.split('');
        var colour = '#';
        for (var i = 0; i < 6; i++) {
            colour += letters[Math.round(Math.random() * 15)];
        }
        return colour;
    }

    function generateSingleDiv() {
        var currDiv = document.createElement("div");
        var appendedDiv = document.body.appendChild(currDiv);

        appendedDiv.style.width = getRandomIntegerInRange(20, 100) + "px";
        appendedDiv.style.height = getRandomIntegerInRange(20, 100) + "px";
        appendedDiv.style.background = getRandomColour();
        appendedDiv.style.position = "absolute";
        appendedDiv.style.marginTop = getRandomIntegerInRange(0, window.innerHeight) + "px";
        appendedDiv.style.marginLeft = getRandomIntegerInRange(0, window.innerWidth) + "px";
        appendedDiv.style.borderWidth = getRandomIntegerInRange(10, 20) + "px";
		appendedDiv.style.borderStyle = "solid";
        appendedDiv.style.borderColor = getRandomColour();
        appendedDiv.style.borderRadius = getRandomIntegerInRange(0, 10) + "px";

        appendedDiv.innerHTML = "<strong>div</strong>";
    }

    for (var i = 0; i < 100; i++) {
        generateSingleDiv();
    }
}