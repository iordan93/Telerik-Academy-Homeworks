var Folder = Class.create({
    init: function (title, urls) {
        this.title = title;
        this.urls = urls;
    },

    _render: function () {
        var container = document.createElement("div");
        var fragment = document.createDocumentFragment();

        var titleElement = document.createElement("div");
        titleElement.innerHTML = this.title;
        titleElement.style.fontSize = "16px";
        titleElement.style.fontWeight = "bold";
        fragment.appendChild(titleElement);

        for (var i = 0; i < this.urls.length; i++) {
            fragment.appendChild(this.urls[i]._render());
        }

        container.appendChild(fragment);
        document.body.appendChild(container);
    }
});

var Url = Class.create({
    init: function (title, url) {
        this.title = title;
        this.url = url;
    },

    _render: function () {
        var container = document.createElement("div");

        var urlElement = document.createElement("a");
        urlElement.setAttribute("href", this.url);
        urlElement.innerHTML = this.title;
        urlElement.target = "_blank";

        container.appendChild(urlElement);

        document.body.appendChild(container);
        return container;
    }
});

var FavouritesBar = Class.create({
    init: function (selector, title, folders, urls) {
        this.container = document.querySelector(selector);
        this.title = title;
        this.folders = folders;
        this.urls = urls;
    },

    render: function () {
        var heading = document.createElement("h2");
        heading.innerHTML = this.title;
        document.body.appendChild(heading);
        var i;
        for (i = 0; i < this.urls.length; i++) {
            this.urls[i]._render();
        }

        for (i = 0; i < this.folders.length; i++) {
            this.folders[i]._render();
        }
    }
});