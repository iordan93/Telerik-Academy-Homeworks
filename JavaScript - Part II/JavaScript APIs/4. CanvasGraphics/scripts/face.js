var canvas = document.getElementById("face");
var ctx = canvas.getContext("2d");
ctx.strokeStyle = "#38899d";
ctx.fillStyle = "#90cad7";
ctx.lineWidth = "3";

// Face
ctx.beginPath();
ellipse(ctx, 86, 166, 70, 60, true);
ctx.rotate(10 * Math.PI / 180);
ellipse(ctx, 110, 185, 28, 10);
ctx.rotate(-10 * Math.PI / 180);

ctx.moveTo(75, 140);
ctx.lineTo(59, 172);
ctx.lineTo(75, 172);
ctx.stroke();

ellipse(ctx, 48, 139, 12, 7);
ellipse(ctx, 105, 139, 12, 7);

ctx.save();
ctx.fillStyle = "#38899d";
ctx.rotate(Math.PI / 2);
ellipse(ctx, 139, -45, 7, 3, true);
ellipse(ctx, 139, -102, 7, 3, true);
ctx.restore();
ctx.stroke();

// Hat
ctx.strokeStyle = "#25221f";
ctx.fillStyle = "#396693";
ellipse(ctx, 84, 106, 80, 13, true)

ctx.stroke();
ellipse(ctx, 84, 105, 43, 7, true);
ctx.fillRect(42, 8, 85, 96);
ctx.beginPath();
ctx.moveTo(41, 104);
ctx.lineTo(42, 8);
ctx.moveTo(127, 104);
ctx.lineTo(127, 8);
ctx.stroke();
ellipse(ctx, 84.5, 10, 43, 7, true);

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