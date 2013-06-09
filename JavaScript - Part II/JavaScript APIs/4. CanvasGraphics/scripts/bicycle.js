var canvas = document.getElementById("bicycle");
var ctx = canvas.getContext("2d");
ctx.strokeStyle = "#38899d";
ctx.fillStyle = "#90cad7";
ctx.lineWidth = "4";

// Wheels
ctx.beginPath();
ctx.arc(61, 161, 58, 0, 2 * Math.PI);
ctx.stroke();
ctx.fill();
ctx.beginPath();
ctx.arc(290, 161, 58, 0, 2 * Math.PI);
ctx.stroke();
ctx.fill();

// Main frame
ctx.beginPath();
ctx.moveTo(129, 82);
ctx.lineTo(274, 82)
ctx.lineTo(164, 154);
ctx.lineTo(58, 157);
ctx.closePath();
ctx.moveTo(88, 54);
ctx.lineTo(137, 54);
ctx.moveTo(113, 54);
ctx.lineTo(164, 154);
ctx.stroke();

// Pedals and wheel
ctx.beginPath();
ctx.arc(164, 154, 18, 0, 2 * Math.PI);
ctx.moveTo(140, 129);
ctx.lineTo(152, 142);
ctx.moveTo(173, 167);
ctx.lineTo(183, 179);
ctx.moveTo(220, 55);
ctx.lineTo(266, 39);
ctx.lineTo(298, 2);
ctx.moveTo(266, 39);
ctx.lineTo(291, 153);
ctx.stroke();