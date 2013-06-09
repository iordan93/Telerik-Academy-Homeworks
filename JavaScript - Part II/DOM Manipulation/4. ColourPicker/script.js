var foreground = document.getElementById("foreground");
var background = document.getElementById("background");
var area = document.getElementById("area");

foreground.onchange = function () {
    area.style.color = foreground.value;
};

background.onchange = function () {
    area.style.backgroundColor = background.value;
};