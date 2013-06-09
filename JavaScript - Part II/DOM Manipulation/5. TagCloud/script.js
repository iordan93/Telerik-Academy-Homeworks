function generateTagCloud(tags, minSize, maxSize) {
    var index;
    var tagsArray = [];

    // Create an associative array and count all elements
    for (var i = 0; i < tags.length; i++) {
        if (tagsArray[tags[i]] === undefined) {
            tagsArray[tags[i]] = 1;
        }
        else {
            tagsArray[tags[i]]++;
        }
    }

    // Get the maximum number of occurences
    var maxNumber = -1000000;
    for (index in tagsArray) {
        if (tagsArray[index] > maxNumber) {
            maxNumber = tagsArray[index];
        }
    }

    // Get the step using a formula - difference between the two sizes over the maximal number
    var step = (maxSize - minSize) / maxNumber;

    // Get the wrapper element and append each element from the tag cloud
    var wrapper = document.getElementById("wrapper");
    wrapper.style.width = "300px";

    for (index in tagsArray) {
        wrapper.appendChild(createElement(index, parseInt((tagsArray[index]) * step + minSize)));
    }

    function createElement(text, fontSize) {
        var element = document.createElement("span");

        element.style.margin = "10px";
        element.style.fontSize = fontSize + "px";
        element.innerHTML = text;
        return element;
    }
};