/// <reference path="../libs/class.js" />
/// <reference path="../libs/jquery-2.0.3.js" />

define(["libs/class", "jquery"], function (Class, $) {
    var controls = controls || {};
    var ComboBox = Class.create({
        init: function (itemsSource) {
            if (!(itemsSource instanceof Array)) {
                throw "The itemsSource of a ListView must be an array!";
            }
            this.itemsSource = itemsSource;
        },
        render: function (template) {
            var list = document.createElement("ul");
            list.setAttribute("class", "person-list");
            for (var i = 0; i < this.itemsSource.length; i++) {
                var listItem = document.createElement("li");
                listItem.setAttribute("id", this.itemsSource[i].id);
                var item = this.itemsSource[i];
                listItem.innerHTML = template(item);
                list.appendChild(listItem);
            }
            $(list).children().hide();
            var firstItem = $(list).children().first();
            firstItem.addClass("selected");
            firstItem.show();
            return list.outerHTML;
        }
    });

    controls.ComboBox = function (itemsSource) {
        return new ComboBox(itemsSource);
    }

    return controls;
});