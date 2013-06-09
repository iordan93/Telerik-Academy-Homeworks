function movingDivs() {

    function getDiv() {
        var div = document.createElement("div");
        div.style.width = div.style.height = "50px";
        div.style.color = getRandomColour();
        div.style.border = "1px solid " + getRandomColour();
        div.style.backgroundColor = getRandomColour();
        div.style.position = "absolute";
        // Circular shape
        div.style.borderRadius = "50%";

        function getRandomColour() {
            var letters = '0123456789ABCDEF'.split('');
            var colour = '#';
            for (var i = 0; i < 6; i++) {
                colour += letters[Math.round(Math.random() * 15)];
            }
            return colour;
        }

        return div;
    }

    function addRect() {
        var div = getDiv();
        document.body.appendChild(div);
        moveInRectangle(div);
    }

    function addCircle() {
        var div = getDiv();
        document.body.appendChild(div);
        moveInCircle(div);
    }

    function moveInRectangle(element) {
        // Set the initial position of each element
        var position = {top: 50, left: 50};

        setInterval(function () {
            // Down
            if (position.top <= 200 && position.left == 50) {
                position.top++;
            }

            // Right
            else if (position.left <= 200 && position.top >= 200) {
                position.left++;
            }

            // Up
            else if (position.left >= 200 && position.top >= 50) {
                position.top--;
            }

            // Left
            else if (position.top <= 50 && position.left >= 50) {
                position.left--;
            }

            element.style.top = position.top + "px";
            element.style.left = position.left + "px";
        }, 10);
    }

    function moveInCircle(element) {
        var position = {top: 200, left: 650, angle: 0};
        // Rotation in clockwise direction
        setInterval(function () {
            var angleInRadians = (position.angle) * (Math.PI / 180);
            var left = 150 * Math.cos(angleInRadians) + 500;
            var top = 150 * Math.sin(angleInRadians) + 200;
            element.style.left = left + "px";
            element.style.top = top + "px";
            position.angle++;
        }, 10);
    }

    function add(type) {
        switch (type) {
            case "rect":
                addRect();
                break;
            case "circle":
                addCircle();
                break;
            default:
                throw new Error("The type of movement " + type + " is not defined");
                break;
        }
    }

    return {
        add: add
    }
}   