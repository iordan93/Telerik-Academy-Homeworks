$(function () {
    $("#FormWebPhotoAlbum").on("click", "#ImageContainer", function () {
        var imageSource = $("#ImageContainer").attr("src");

        window.open(imageSource, "Popup", "resizable=no, scrollbars=no");

    });
});