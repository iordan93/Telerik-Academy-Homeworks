/// <reference path="../libs/jquery-1.8.2.js" />
var controls = (function () {
    function getTemplate(name, selector, data) {
        $.get("../Scripts/partials/" + name + ".html", function (template) {
            $(selector).html(Mustache.render(template, data));
        });
    }

    return {
        getTemplate: getTemplate
    };
})();