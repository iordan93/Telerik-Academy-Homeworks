var controls = (function () {
    var Gallery = function (selector, enlargedImageSelector) {
        var galleryElement = document.querySelector(selector);
        if (enlargedImageSelector) {
            var enlargedImageElement = document.querySelector(enlargedImageSelector);

            addHandler(galleryElement, "click", function (event) {
                event.preventDefault();
                event.stopPropagation();
                while (enlargedImageElement.firstChild) {
                    enlargedImageElement.removeChild(enlargedImageElement.firstChild);
                }

                var clickedElement = event.target;

                if (clickedElement instanceof HTMLImageElement) {
                    var image = clickedElement.cloneNode(true);

                    var newWidth = parseInt(2 * clickedElement.width);
                    var newHeight = parseInt(2 * clickedElement.height);
                    image.width = newWidth;
                    image.height = newHeight;

                    enlargedImageElement.appendChild(image);
                }
            });
        }
        var gallery = document.createElement("ul");
        gallery.className = "gallery";

        var images = [];
        var albums = [];

        this.addImage = function (title, source) {
            var newImage = new Image(title, source);
            images.push(newImage);
            return newImage;
        };

        this.addAlbum = function (title) {
            var newAlbum = new Album(title);
            albums.push(newAlbum);
            return newAlbum;
        };

        this.render = function () {
            if (images.length > 0) {
                var imageNode = document.createElement("li");
                var imagesContainer = document.createElement("ul");
                var i;
                var imagesLength = images.length;
                for (i = 0; i < imagesLength; i += 1) {
                    var imageAsDomItem = images[i].render();
                    imagesContainer.appendChild(imageAsDomItem);
                }

                imageNode.appendChild(imagesContainer);
                gallery.appendChild(imageNode);
            }

            if (albums.length > 0) {
                var albumNode = document.createElement("li");
                var albumsContainer = document.createElement("ul");
                var albumsLength = albums.length;
                for (i = 0; i < albumsLength; i += 1) {
                    var albumAsDomItem = albums[i].render();
                    albumsContainer.appendChild(albumAsDomItem);
                }
                albumNode.appendChild(albumsContainer);
                gallery.appendChild(albumNode);
            }

            galleryElement.appendChild(gallery);
            if (enlargedImageElement) {
                galleryElement.appendChild(enlargedImageElement);
            }
        };

        this.getImageGalleryData = function () {
            var galleryData = {
                images: [],
                albums: []
            };
            var length = albums.length;
            for (i = 0; i < albums.length; i += 1) {
                galleryData.albums.push(albums[i].getData());
            }

            length = images.length;
            for (i = 0; i < length; i += 1) {
                galleryData.images.push(images[i].getData());
            }

            return galleryData;
        };
    };

    var Album = function (title) {
        this.title = escapeHtml(title);

        var images = [];
        var albums = [];

        this.getData = function () {
            var albumData = {
                title: this.title,
                images: [],
                albums: []
            };
            var length = albums.length;
            for (i = 0; i < albums.length; i += 1) {
                albumData.albums.push(albums[i].getData());
            }

            length = images.length;
            for (i = 0; i < length; i += 1) {
                albumData.images.push(images[i].getData());
            }

            return albumData;
        };

        this.addImage = function (title, source) {
            var newImage = new Image(title, source);
            images.push(newImage);
            return newImage;
        };

        this.addAlbum = function (title) {
            var newAlbum = new Album(title);
            albums.push(newAlbum);
            return newAlbum;
        };

        this.render = function () {
            var albumNode = document.createElement("li");
            albumNode.className = "hidden";

            addHandler(albumNode, "click",
                function (event) {
                    if (!event) {
                        event = window.event;
                    }

                    var clickedItem = event.target;

                    if (clickedItem instanceof HTMLAnchorElement) {
                        event.stopPropagation();

                        if (albumNode.className === "hidden") {
                            albumNode.className = "";
                        }

                        else {
                            albumNode.className = "hidden";
                        }
                    }
                });

            albumNode.innerHTML = "<a href=\"#\">" + this.title + "</a>";

            if (images.length > 0) {
                var imagesNode = document.createElement("ul");

                var length = images.length;
                for (i = 0; i < length; i += 1) {
                    var image = images[i].render();
                    imagesNode.appendChild(image);
                }
                albumNode.appendChild(imagesNode);
            }

            if (albums.length > 0) {
                var innerAlbumsNode = document.createElement("ul");

                var i;
                length = albums.length;
                for (i = 0; i < length; i += 1) {
                    var album = albums[i].render();
                    innerAlbumsNode.appendChild(album);
                }
                albumNode.appendChild(innerAlbumsNode);
            }

            return albumNode;
        };
    };

    var Image = function (title, source) {
        this.title = escapeHtml(title);
        this.source = source;

        this.render = function () {
            var container = document.createElement("li");
            container.innerHTML = this.title;

            var imageNode = document.createElement("img");
            imageNode.setAttribute("src", this.source);
            container.appendChild(imageNode);

            return container;
        };

        this.getData = function () {
            var imageData = {
                title: this.title,
                source: this.source
            };
            return imageData;
        };
    };

    function escapeHtml(input) {
        if (input) {
            return input.replace(/</g, "&lt;").replace(/>/g, "&gt;");
        }
    }

    function addHandler(element, eventType, eventHandler) {
        if (element.addEventListener) {
            element.addEventListener(eventType, eventHandler, false);
        }
        else {
            element.attachEvent("on" + eventType, eventHandler);
        }
    }

    function addImage(parent, image) {
        var newImage = parent.addImage(image.title, image.source);
        return newImage;
    }

    function addAlbum(parent, album) {
        var newAlbum = parent.addAlbum(album.title);
        //if (newAlbum.images.length > 0) {
        //    for (var i = 0; i < newAlbum.images.length; i += 1) {
        //        addImage(newAlbum, newAlbum.images[i]);
        //    }
        //}

        //if (newAlbum.albums.length > 0) {
        //    for (var i = 0; i < newAlbum.albums.length; i+=1) {
        //        addAlbum(newAlbum, newAlbum.albums[i]);
        //    }
        //}
    }

    return {
        getImageGallery: function (selector, enlargedImageSelector) {
            return new Gallery(selector, enlargedImageSelector);
        },

        buildImageGallery: function (selector, data) {
            console.log(data);
            var gallery = new Gallery(selector);

            if (data.images.length > 0) {
                for (var imageIndex = 0; imageIndex < data.images.length; imageIndex += 1) {
                    addImage(gallery, data.images[imageIndex]);
                }
            }

            if (data.albums.length > 0) {
                for (var albumIndex = 0; albumIndex < data.albums.length; albumIndex += 1) {
                    addAlbum(gallery, data.albums[albumIndex]);
                }
            }

            gallery.render();
        }
    };
})();