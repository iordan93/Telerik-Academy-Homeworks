/// <reference path="jquery-2.0.2.js" />
(function ($) {
    $.fn.treeView = function () {
        var treeViewContainer = this;
        treeViewContainer.find("ul").hide();
        treeViewContainer.on("click", "li", function (ev) {
            var childrenNodes = $(this).children();

            if (childrenNodes.length > 0) {
                
                childrenNodes.toggle(500);
            }

            ev.stopPropagation();
        });

        return this;
    }
})(jQuery)