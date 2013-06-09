window.requestAnimationFrame = (function () {
    return window.requestAnimationFrame ||
           window.webkitRequestAnimationFrame ||
           window.mozRequestAnimationFrame ||
           function (callback) {
               window.setTimeout(callback, 1000 / 60);
           };
})();

var canvas = document.getElementById("canvas");
var ctx = canvas.getContext("2d");

var width = canvas.width = 400;
var height = canvas.height = 300;

var radius = 10;

ctx.fillStyle = "#000000";
ctx.lineWidth = 5;
ctx.fillRect(0, 0, width, height);
ctx.strokeRect(0, 0, width, height);

function drawCircle(center) {
    ctx.clearRect(0, 0, width, height);
    ctx.beginPath();
    ctx.arc(center.x + radius, center.y + radius, radius, 0, Math.PI * 2);
    ctx.fill();
    ctx.closePath();
};

var position = new Point(0, 0);
// You can use the direction point (vector) to change the velocity of the ball
var direction = new Point(1, 1);

function moveCircle() {
    position = Point.add(position, direction);
    drawCircle(position);

    // When reaching the edge of the canvas, bounce off it
    if (0 > position.x || position.x + 2 * radius > width) {
        direction.x *= -1;
    }

    if (0 > position.y || position.y + 2 * radius >= height) {
        direction.y *= -1;
    }

    requestAnimationFrame(moveCircle);
};

moveCircle();
