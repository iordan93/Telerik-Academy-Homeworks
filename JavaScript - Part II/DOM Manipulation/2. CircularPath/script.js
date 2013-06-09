function createDivs() {
    var wrapper = document.getElementById("wrapper");

    // Create five divs
    for (var i = 0; i < 5; i++) {
        var div = document.createElement("div");

        var theDiv = wrapper.appendChild(div);
        theDiv.style.position = "absolute";
        theDiv.style.borderRadius = "50%";
        theDiv.style.border = "1px solid #000000";
        theDiv.style.width = "50px";
        theDiv.style.height = "50px";

        // Set the margin equal to the radius to show all the circles
        // (if it is 0, only 1/4 of them is shown)
        theDiv.style.marginTop = "100px";
        theDiv.style.marginLeft = "100px";
    }

    var allDivs = wrapper.childNodes;
    // Angle is measured in degrees
    var angle = 0;
    var radius = 100;

    function animateDivs() {
        for (j = 0; j < 5; j++) {
            // Set the rotation positions
            allDivs[j].style.left = Math.cos(angle + 2 * Math.PI / 5 * j) / radius * 10000 + "px";
            allDivs[j].style.top = Math.sin(angle + 2 * Math.PI / 5 * j) / radius * 10000 + "px";
        }
        if (angle == 360) {
            // Provide looping
            angle = 0;
        }
        angle = angle + 1;

        setTimeout(animateDivs, 100);
    }

    animateDivs();
}