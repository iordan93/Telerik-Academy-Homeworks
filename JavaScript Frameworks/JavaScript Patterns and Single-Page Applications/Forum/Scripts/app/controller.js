var controllers = (function () {
    var rootUrl = "http://localhost:4464/api/";
    var Controller = Class.create({
        init: function (selector) {
            this.selector = selector;
            this.persister = persisters.getPersister(rootUrl);
        },

        loadHomePage: function () {
            if (this.persister.isUserLoggedIn()) {
                document.location.href = "#/posts";
            }
            else {
                controls.getTemplate("login", this.selector);
            }

            this.attachLoginHandlers(this.selector);
        },

        loadPosts: function () {
            var self = this;
            this.persister.posts.all(function (posts) {
                controls.getTemplate("posts", self.selector, posts);
                self.attachLogoutHandler(self.selector);
            }, function (response) {
                $("#error-messages").html(JSON.parse(response.responseText).Message);
            });
        },

        loadPostsByTags: function (tags) {
            var tagsArray = tags.split(",");
            var self = this;
            this.persister.posts.byTags(tagsArray, function (posts) {
                controls.getTemplate("posts-by-tags", self.selector, posts);
                self.attachLogoutHandler(self.selector);
            }, function (response) {
                $("#error-messages").html(JSON.parse(response.responseText).Message);
            });
        },

        loadSinglePost: function (postId) {
            var self = this;
            this.persister.posts.byId(postId, function (post) {
                controls.getTemplate("single-post", self.selector, post);
                self.attachLogoutHandler(self.selector);
            }, function (response) {
                $("#error-messages").html(JSON.parse(response.responseText).Message);
            });
        },

        loadTags: function () {
            var self = this;
            this.persister.tags.all(function (tags) {
                controls.getTemplate("tags", self.selector, tags);
            }, function (response) {
                $("#error-messages").html(JSON.parse(response.responseText).Message);
            });
        },

        addComment: function (postId) {
            var self = this;
            controls.getTemplate("add-comment", self.selector);
            self.attachCommentHandler(self.selector, postId);
            self.attachLogoutHandler(self.selector);
        },

        attachLoginHandlers: function (selector) {
            var wrapper = $(selector);
            var self = this;

            wrapper.on("click", "#open-reg-form", function () {
                wrapper.find("#login-form").hide();
                wrapper.find("#register-form").show();
            });

            wrapper.on("click", "#open-login-form", function () {
                wrapper.find("#register-form").hide();
                wrapper.find("#login-form").show();
            });

            wrapper.on("click", "#login", function () {
                var user = {
                    username: $(selector + " #login-username").val(),
                    password: $(selector + " #login-password").val()
                };

                self.persister.user.login(user, function (response) {
                    document.location.href = "#/posts";
                }, function (response) {
                    $("#error-messages").html(JSON.parse(response.responseText).Message);
                });
            });

            wrapper.on("click", "#register", function () {
                var user = {
                    username: $(selector + " #register-username").val(),
                    displayName: $(selector + " #register-displayName").val(),
                    password: $(selector + " #register-password").val(),
                };

                self.persister.user.register(user, function (response) {
                    document.location.href = "#/posts";
                }, function (response) {
                    $("#error-messages").html(JSON.parse(response.responseText).Message);
                });
            });
        },

        attachLogoutHandler: function (selector) {
            var wrapper = $(selector);
            var self = this;

            wrapper.on("click", "#logout", function (e) {
                e.preventDefault();
                self.persister.user.logout(function () {
                    document.location.href = "#/";
                    self.loadHomePage();
                }, function (response) {
                    $("#error-messages").html(JSON.parse(response.responseText).Message);
                });
            });
        },

        attachCommentHandler: function (selector, postId) {
            var wrapper = $(selector);
            var self = this;

            wrapper.on("click", "#add-comment", function () {
                var text = $(selector + " #comment-text").val();
                self.persister.posts.comment(postId, text, function (response) {
                    alert("Comment added successfully.");
                    document.location.href = "#/post/" + postId;
                }, function (response) {
                    $("#error-messages").html(JSON.parse(response.responseText).Message);
                });
            });

            wrapper.on("click", "#register", function () {
                var user = {
                    username: $(selector + " #register-username").val(),
                    displayName: $(selector + " #register-displayName").val(),
                    password: $(selector + " #register-password").val(),
                };

                self.persister.user.register(user, function (response) {
                    document.location.href = "#/posts";
                }, function (response) {
                    $("#error-messages").html(JSON.parse(response.responseText).Message);
                });
            });
        },
    });

    return {
        get: function (selector) {
            return new Controller(selector);
        }
    }
})();