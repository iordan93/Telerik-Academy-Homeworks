/// <reference path="_references.js" />
/// <reference path="libs/jquery-2.0.3.js" />

$(function () {
    var tagsController = controllers.get("#all-tags");
    tagsController.loadTags();

    var controller = controllers.get("#content");
    var app = Sammy("#content", function () {
        this.get("#/", function () {
            controller.loadHomePage();
        });

        this.get("#/home", function () {
            controller.loadHomePage();
        });

        this.get("#/posts", function () {
            controller.loadPosts();
        });

        this.get("#/posts/:tags", function () {
            controller.loadPostsByTags(this.params["tags"]);
        });

        this.get("#/post/:id", function () {
            controller.loadSinglePost(this.params["id"]);
        });

        this.get("#/post/:id/comment", function () {
            controller.addComment(this.params["id"]);
        });
    });

    app.run("#/");
});