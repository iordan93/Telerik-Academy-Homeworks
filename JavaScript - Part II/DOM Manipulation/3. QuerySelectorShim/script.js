window.onload = function () {
    var elementToSelect = document.querySelectorAll('#outerId>#innerId')[0];
    console.log(elementToSelect);
    var inner = document.createElement("h1");
    var test = elementToSelect.appendChild(inner);

    elementToSelect.style.width = "200px";
    elementToSelect.style.height = "200px";
    elementToSelect.style.color = "#FFFFFF";
    elementToSelect.style.backgroundColor = "#000000";
}