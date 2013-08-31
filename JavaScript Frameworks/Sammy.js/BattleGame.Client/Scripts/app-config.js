/// <reference path="libs/require.js" />
/// <reference path="libs/sammy-0.7.4.js" />

require.config({
    paths: {
        jquery: "libs/jquery-2.0.3",
        mustache: "libs/mustache",
        sammy: "libs/sammy-0.7.4",
        underscore: "libs/underscore",
        "class": "app/class",
        requester: "app/http-requester",
        persister: "app/persisters",
        controller: "app/controller",
        sha1: "app/sha1",
        ui: "app/ui"
    }
});

require(["controller", "sammy", "jquery"], function (controllers, sammy, $) {
    var controller = controllers.get();
    var app = sammy("#wrapper", function () {
        // Register / Login
        this.get("#/user", function () {
            controller.loadLoginFormUI("#wrapper");
            if (isUserLoggedIn()) {
                document.location.href = "#/all-games";
            }
        });

        // All games (open games)
        this.get("#/all-games", function () {
            if (isUserLoggedIn()) {
                controller.loadOpenGames("#wrapper");
            }
            else {
                $("#wrapper").html("There is no user logged in.");
            }
        });

        // Join game (active games)
        this.get("#/join-game", function () {
            if (isUserLoggedIn()) {
                controller.loadActiveGames("#wrapper");
            }
            else {
                $("#wrapper").html("There is no user logged in.");
            }
        });

        // Battle
        this.get("#/battle", function () {
            if (isUserLoggedIn()) {
                controller.loadBattleUI(localStorage["gameId"], "#wrapper");
            }
            else {
                $("#wrapper").html("There is no user logged in.");
            }
        });
    });

    function isUserLoggedIn() {
        return localStorage["username"] != null && localStorage["sessionKey"] != null;
    }

    app.run("#/user");
});