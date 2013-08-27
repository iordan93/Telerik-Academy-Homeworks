/// <reference path="jquery-2.0.3.js" />
/// <reference path="class.js" />
var controls = controls || {};
(function (c) {
    var TableView = Class.create({
        init: function (itemSource, columns) {
            if (!(itemSource instanceof Array)) {
                throw "The itemSource of a TreeView must be an array!";
            }
            this.itemSource = itemSource;
            this.columns = columns;
        },
        render: function (template) {
            var table = document.createElement("table");
            table.setAttribute("border", 1);
            table.style.borderCollapse = "collapse";

            var row = document.createElement("tr");
            table.appendChild(row);

            var currentColumn = 0;
            for (var i = 0; i < this.itemSource.length; i++) {
                if (currentColumn == this.columns) {
                    currentColumn = 0;
                    table.appendChild(row);
                    row = document.createElement("tr");
                }

                var cell = document.createElement("td");
                var item = this.itemSource[i];
                cell.innerHTML = template(item);
                row.appendChild(cell);
                currentColumn++;
            }

            table.appendChild(row);
            return table.outerHTML;
        }
    });

    c.getTableView = function (itemsSource, cols) {
        return new TableView(itemsSource, cols);
    }
}(controls || {}));