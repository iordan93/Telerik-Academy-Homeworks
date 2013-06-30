var controls = (function () {
    var Image = {
        init: function (title, url, enlargedUrl) {
            this.title = title;
            this.url = url;
            this.enlargedUrl = enlargedUrl;
        }
    };

    var Button = {
        init: function (id, title) {
            this.id = id;
            this.title = title;
        }
    };


    var Slider = {
        init: function (selector, largeImageSelector) {
            this.containerElement = document.querySelector(selector);
            this.images = [];
            this.largeImageElement = document.querySelector(largeImageSelector);
            this.currentImageId;
        },

        addImage: function (title, url, enlargedUrl) {
            var currentImage = Object.create(Image);
            currentImage.init(title, url, enlargedUrl);

            this.images.push(currentImage);
        },

        render: function () {
            var images = document.createDocumentFragment();

            for (var i = 0; i < this.images.length; i++) {
                var currentImage = document.createElement("img");
                currentImage.id = i;
                currentImage.setAttribute("title", this.images[i].title);
                currentImage.setAttribute("src", this.images[i].url);
                currentImage.setAttribute("alt", this.images[i].title);

                images.appendChild(currentImage);
            }

            this.containerElement.appendChild(images);

            var _that = this;
            this.addEventHandler(this.containerElement, "click", function (ev) {
                if (!ev) {
                    ev = window.event;
                }
                if (ev.stopPropagation) {
                    ev.stopPropagation();
                }
                if (ev.preventDefault) {
                    ev.preventDefault();
                }

                if (ev.target instanceof HTMLImageElement) {
                    _that.currentImageId = ev.target.id;
                    _that.showBigImage(_that.currentImageId);
                }
            });
        },

        showBigImage: function (id) {
            var image = document.createElement("img");
            image.id = "preview-image";
            image.setAttribute("title", this.images[id].title);
            image.setAttribute("src", this.images[id].enlargedUrl);
            image.setAttribute("alt", this.images[id].title);
            image.style.position = "absolute";
            image.style.left = "300px";

            if (document.querySelector("#preview-image")) {
                this.largeImageElement.removeChild(document.querySelector("#preview-image"));
            }
            else {
                this.addButton("left");
                this.addButton("right");

                this.setButtonBehaviours();
            }

            this.largeImageElement.appendChild(image);
        },

        setButtonBehaviours: function () {
            var _that = this;
            this.addEventHandler(this.largeImageElement, "click", function (ev) {
                if (!ev) {
                    ev = window.event;
                }
                if (ev.stopPropagation) {
                    ev.stopPropagation();
                }
                if (ev.preventDefault) {
                    ev.preventDefault();
                }

                if (ev.target instanceof HTMLButtonElement) {
                    if (ev.target.id == "leftButton" && _that.currentImageId != 0) {
                        _that.currentImageId--;
                        _that.showBigImage(_that.currentImageId);
                    }

                    if (ev.target.id == "rightButton" && _that.currentImageId != _that.images.length - 1) {
                        _that.currentImageId++;
                        _that.showBigImage(_that.currentImageId);
                    }
                }
            });
        },

        addButton: function (position) {
            var button = Object.create(Button);
            var buttonElement = document.createElement("button");
            buttonElement.className = "button";
            buttonElement.style.position = "absolute";
            buttonElement.style.top = "450px";
            if (position == "left") {
                button.init("leftButton", position);
                buttonElement.style.left = "100px"
                buttonElement.innerHTML = "Previous";
            }
            if (position == "right") {
                button.init("rightButton", position);
                buttonElement.style.left = "850px"
                buttonElement.innerHTML = "Next";
            }

            buttonElement.id = button.id;
            this.largeImageElement.appendChild(buttonElement);
        },

        addEventHandler: function (element, eventType, eventHandler) {
            if (element.addEventListener) {
                element.addEventListener(eventType, eventHandler, false);
            } else if (document.attachEvent) {
                element.attachEvent("on" + eventType, eventHandler);
            }
            else {
                element["on" + eventType] = eventHandler;
            }
        }
    }

    getSlider = function () {
        return Object.create(Slider);
    }
    return {
        getSlider: getSlider
    }
})();