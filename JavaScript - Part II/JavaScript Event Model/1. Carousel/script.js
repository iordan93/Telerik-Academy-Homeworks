var carousel = (function () {
    var container = document.getElementById("carousel-container");
    var images = [];
    var index = 0;
    var addImage = function (src, alt) {
        if (src === "" || typeof (src) === undefined) {
            throw new Error("The source of the image cannot be null or undefined.");
        }
        alt = alt || "";

        images.push({ index: index, src: src, alt: alt });
        index++;
    };

    var render = function () {
        var fragment = document.createDocumentFragment();
        var length = images.length;

        for (var i = 0; i < length; i++) {
            var img = document.createElement("img");
            img.setAttribute("src", images[i].src);
            img.setAttribute("alt", images[i].alt);
            img.setAttribute("id", images[i].index);
            fragment.appendChild(img);
        }
        fragment.firstChild.classList.add("current");

        container.appendChild(fragment);
    };

    var currentImageIndex = 0;
    var showPreviousImage = function () {
        // Hide the current image and show the one before it
        var imageToHide = document.getElementById(images[currentImageIndex].index);
        imageToHide.className = "";

        // This statement allows looping of indices
        if (currentImageIndex === 0) {
            currentImageIndex = images.length - 1;
        }
        else {
            currentImageIndex--;
        }

        var currentIndex = images[currentImageIndex].index;
        var imageToShow = document.getElementById(currentIndex);
        imageToShow.className = "current";
    };

    var showNextImage = function () {
        // Hide the current image and show the one after it
        var imageToHide = document.getElementById(images[currentImageIndex].index);
        imageToHide.className = "";

        // This statement allows looping of indices
        if (currentImageIndex === images.length - 1) {
            currentImageIndex = 0;
        }
        else {
            currentImageIndex++;
        }
        var currentIndex = images[currentImageIndex].index;
        var imageToShow = document.getElementById(currentIndex);
        imageToShow.className = "current";
    };
    return {
        addImage: addImage,
        render: render,
        showPreviousImage: showPreviousImage,
        showNextImage: showNextImage
    };
})();