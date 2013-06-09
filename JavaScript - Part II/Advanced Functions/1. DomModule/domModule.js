var domModule = function () {
    // A buffer (associative array) to hold all elements which should be appended
    // Every index of the buffer corresponds to a different selector
    var buffer = [];
    var bufferSize = 100;

    function appendChild(childElement, selector) {
        document.querySelector(selector).appendChild(childElement.cloneNode(true));
    }

    function removeChild(parentElement, childSelector) {
        var elementsToRemove = document.querySelectorAll(parentElement + ">" + childSelector);

        for (var i = 0; i < elementsToRemove.length; i++) {
            elementsToRemove[i].parentNode.removeChild(elementsToRemove[i]);
        }
    }

    function addHandler(selector, eventType, eventHandler) {
        var element = document.querySelector(selector);

        // Feature detection - attachEvent for IE, and addEventListener for other browsers
        if (element.addEventListener) {
            element.addEventListener(eventType, eventHandler, false);
        }
        else {
            element.attachEvent("on" + eventType, eventHandler);
        }
    }

    function appendToBuffer(parentSelector, element) {
        // If there is no fragment for the current selector, create one and append the element
        if (!buffer[parentSelector]) {
            buffer[parentSelector] = document.createDocumentFragment();
        }

        buffer[parentSelector].appendChild(element);

        // If the buffer is full, flush it to the DOM and empty it
        if (buffer[parentSelector].childNodes.length === bufferSize) {
            var parent = document.querySelector(parentSelector);
            parent.appendChild(buffer[parentSelector]);

            buffer[parentSelector] = null;
        }
    }

    function getElement(selector) {
        return document.querySelector(selector);
    }

    function getAllElements(selector) {
        return document.querySelectorAll(selector);
    }

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        appendToBuffer: appendToBuffer,
        getElement: getElement,
        getAllElements: getAllElements
    };
};