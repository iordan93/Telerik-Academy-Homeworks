/// <reference path="../_references.js" />

var persisters = (function () {
    var displayName = localStorage.getItem("displayName");
    var sessionKey = localStorage.getItem("sessionKey");

    var MainPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl;
            this.user = new UserPersister(this.rootUrl);
            this.posts = new PostsPersister(this.rootUrl);
            this.tags = new TagsPersister(this.rootUrl);
        },

        isUserLoggedIn: function () {
            return displayName != null && sessionKey != null;
        }
    });

    var UserPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl + "users/"
        },

        register: function (user, success, error) {
            var url = this.rootUrl + "register/";
            var userData = {
                username: user.username,
                displayName: user.displayName,
                authCode: CryptoJS.SHA1(user.password).toString()
            };

            httpRequester.postJson(url, {}, userData, function (response) {
                saveUserData(response);
                success(response);
            }, error);
        },

        login: function (user, success, error) {
            var url = this.rootUrl + "login/";
            var userData = {
                username: user.username,
                authCode: CryptoJS.SHA1(user.password).toString()
            };

            httpRequester.postJson(url, {}, userData, function (response) {
                saveUserData(response);
                success(response);
            }, error);
        },

        logout: function (success, error) {
            var url = this.rootUrl + "logout/";
            httpRequester.postJson(url, getSessionKeyHeader(), " ", function (response) {
                clearUserData(response);
                success(response);
            }, error);
        }
    });

    var PostsPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl + "posts/"
        },

        all: function (success, error) {
            httpRequester.getJson(this.rootUrl, getSessionKeyHeader(), success, error);
        },

        byId: function (postId, success, error) {
            var url = this.rootUrl + "" + postId;
            httpRequester.getJson(url, getSessionKeyHeader(), success, error);
        },

        byTags: function (tags, success, error) {
            var tagsString = "";
            for (var i = 0; i < tags.length; i++) {
                tagsString += tags[i] + ",";
            }

            if (tagsString[tagsString.length - 1] == ',') {
                tagsString = tagsString.substring(0, tagsString.length - 1);
            }

            var url = this.rootUrl + "?tags=" + tagsString;
            httpRequester.getJson(url, getSessionKeyHeader(), success, error);
        },

        comment: function (postId, text, success, error) {
            var url = this.rootUrl + "" + postId + "/comment";
            var comment = {
                "text": text
            };
            httpRequester.postJson(url, getSessionKeyHeader(), comment, success, error);
        },

        add: function (post, success, error) {
            var postModel = {
                title: post.title,
                tags: post.tags,
                text: post.text
            };
            httpRequester.postJson(this.rootUrl, getSessionKeyHeader(), postModel, success, error);
        }
    });

    var TagsPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl + "tags/";
        },

        all: function (success, error) {
            httpRequester.getJson(this.rootUrl, getSessionKeyHeader(), success, error);
        },
    });

    function saveUserData(response) {
        localStorage.setItem("displayName", response.displayName);
        localStorage.setItem("sessionKey", response.sessionKey);
        displayName = response.displayName;
        sessionKey = response.sessionKey;
    };

    function clearUserData() {
        localStorage.removeItem("displayName");
        localStorage.removeItem("sessionKey");
        displayName = null;
        sessionKey = null;
    };

    function getSessionKeyHeader() {
        var sessionKey = localStorage.getItem("sessionKey");
        var header = {
            "X-sessionKey": sessionKey
        };
        return header;
    }

    return {
        getPersister: function (rootUrl) {
            return new MainPersister(rootUrl);
        }
    };
})();