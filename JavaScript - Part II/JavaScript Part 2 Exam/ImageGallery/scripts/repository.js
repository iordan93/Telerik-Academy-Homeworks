var imageGalleryRepository = (function () {
    return {
        save: function (title, data) {
            localStorage.setObject(title, data);
        },
        load: function (title) {
            return localStorage.getObject(title);
        }
    }
})();