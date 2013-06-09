var canvas = document.getElementById("house");
var ctx = canvas.getContext("2d");

ctx.strokeStyle = "#000000";
ctx.lineWidth = "3";
ctx.fillStyle = "#975b5b";

// Base
ctx.beginPath();
ctx.fillRect(1, 162, 290, 216);
ctx.strokeRect(1, 162, 290, 216);
ctx.moveTo(1, 162);
ctx.lineTo(145, 0);
ctx.lineTo(291, 162)
ctx.closePath();
ctx.fill();
ctx.stroke();

// Door
ctx.beginPath();
ctx.moveTo(34, 377);
ctx.lineTo(34, 300);
ctx.moveTo(74, 377);
ctx.lineTo(74, 281);
ctx.moveTo(114, 377);
ctx.lineTo(114, 300);
ctx.stroke();

ctx.beginPath();
halfEllipse(ctx, 74, 300, 40, 19);
ctx.stroke();

ctx.beginPath();
ctx.arc(63, 348, 5, 0, 2 * Math.PI);
ctx.stroke();
ctx.beginPath();
ctx.arc(85, 348, 5, 0, 2 * Math.PI);
ctx.stroke();

// Chimney
ctx.fillRect(202, 43, 33, 78);
ctx.moveTo(202, 43);
ctx.lineTo(202, 121);
ctx.moveTo(235, 43);
ctx.lineTo(235, 121);
ctx.stroke();
ellipse(ctx, 218.5, 43, 17, 5, true)

// Windows
drawWindow(ctx);
ctx.translate(140, 0);
drawWindow(ctx);
ctx.translate(0, 90);
drawWindow(ctx);

function drawWindow(context) {
    context.beginPath();
    context.fillStyle = "#000000";;
    context.fillRect(25, 190, 50, 32);
    context.fillRect(78, 190, 50, 32);
    context.fillRect(25, 225, 50, 32);
    context.fillRect(78, 225, 50, 32);
}

function halfEllipse(context, centerX, centerY, semimajorAxis, semiminorAxis) {
    context.save();
    context.beginPath();
    context.translate(centerX - semimajorAxis, centerY - semiminorAxis);
    context.scale(semimajorAxis, semiminorAxis);
    context.arc(1, 1, 1, 0, Math.PI, true);
    context.restore();
    ctx.stroke();
}

function ellipse(context, centerX, centerY, semimajorAxis, semiminorAxis, fill) {
    context.save();
    context.beginPath();
    context.translate(centerX - semimajorAxis, centerY - semiminorAxis);
    context.scale(semimajorAxis, semiminorAxis);
    context.arc(1, 1, 1, 0, 2 * Math.PI, false);
    context.restore();
    if (arguments[5] == true) {
        context.fill();
    }
    ctx.stroke();
}