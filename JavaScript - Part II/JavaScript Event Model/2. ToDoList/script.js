(function () {
    var list = document.getElementById("list");
    var description = document.getElementById("description");
    var addButton = document.getElementById("add");
    var deleteButton = document.getElementById("delete");
    var showHideButton = document.getElementById("showhide");

    var todoData = [];

    var showState;

    window.addEventListener("load", function () {
        showState = 0;

        addButton.addEventListener("click", addItem, false);
        deleteButton.addEventListener("click", deleteItem, false);
        showHideButton.addEventListener("click", showHideList, false);
        renderToDoList();
    }, false);

    function renderToDoList() {
        var listToRender = localStorage.getObject("todo-list");
        for (var i in listToRender) {
            list.innerHTML += "<li>" + listToRender[i] + "</li>";
        }
    }

    function addItem(evt) {
        if (evt.preventDefault) {
            evt.preventDefault();
        }

        list.innerHTML += "<li>" + description.value + "</li>";
        todoData.push(description.value);
        localStorage.setObject("todo-list", todoData);
    }

    function deleteItem(evt) {
        if (evt.preventDefault) {
            evt.preventDefault();
        }

        var currentItems = document.querySelectorAll("#list>li");
        var itemPosition = parseInt(description.value) - 1;

        if (itemPosition >= currentItems.length || itemPosition < 0) {
            alert("The task number " + (itemPosition + 1) + " was not found. Please enter the number of the task to be removed.");
        }

        for (var i = 0; i < currentItems.length; i++) {
            if (itemPosition === i) {
                currentItems[itemPosition].parentNode.removeChild(currentItems[itemPosition]);
            }
        }
    }

    function showHideList(evt) {
        if (evt.preventDefault) {
            evt.preventDefault();
        }
        if (!showState) {
            list.style.display = "none";
        }
        else {
            list.style.display = "block"
        }
        showState = !showState;
    }

    if (!Storage.prototype.setObject) {
        Storage.prototype.setObject = function setObject(key, obj) {
            var jsonObj = JSON.stringify(obj);
            this.setItem(key, jsonObj);
        };

    }
    if (!Storage.prototype.getObject) {
        Storage.prototype.getObject = function getObject(key) {
            var jsonObj = this.getItem(key);
            var obj = JSON.parse(jsonObj);
            return obj;
        };
    }
})();