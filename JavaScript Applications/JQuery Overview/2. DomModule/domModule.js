var DomModule = (function () {
    var insertBefore= function (element, content) {
        $(element).prepend(content);
    };
    var insertAfter= function (element, content) {
        $(element).append(content);
    }

    return {
        insertBefore: insertBefore,
        insertAfter: insertAfter
    }
})();