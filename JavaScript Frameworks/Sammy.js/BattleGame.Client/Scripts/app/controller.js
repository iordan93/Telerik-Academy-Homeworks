/// <reference path="jquery-1.8.2.js" />
/// <reference path="class.js" />
/// <reference path="persisters.js" />
/// <reference path="../libs/require.js" />
/// <reference path="ui.js" />

define("controller", ["class", "persister", "ui", "jquery"], function (Class, persisters, ui, $) {
    var controller = (function () {
        var rootUrl = "http://localhost:22954/api/";
        var updateTimer = null;

        var Controller = Class.create({
            init: function (selector) {
                this.persister = persisters.getPersister(rootUrl);
            },

            //loadMenu: function (selector) {
            //    ui.menu(selector);
            //    this.attachHandlers(selector);
            //},

            loadLoginFormUI: function (selector) {
                var self = this;
                //if (self.persister.isUserLoggedIn()) {
                //    self.loadActiveGames(selector);
                //}
                //else {
                   ui.loginFormUI(selector);
                //}

                self.attachHandlers(selector);
            },

            loadActiveGames: function (selector) {
                var self = this;

                this.persister.game.myActive(function (games) {
                    ui.activeGamesList(games, selector);
                }, function (response) {
                    $(selector + " #error-messages").html(response);
                });
                updateTimer = setInterval(function () {
                    self.loadActiveGames(selector);
                }, 1000);
            },

            loadOpenGames: function (selector) {
                var self = this;

                this.persister.game.open(function (games) {
                    ui.openGamesList(games, selector);
                }, function (response) {
                    $(selector + " #error-messages").html(response);
                });
                updateTimer = setInterval(function () {
                    self.loadOpenGames(selector);
                }, 1000);
            },

            loadBattleUI: function (id, selector) {
                var self = this;
                self.persister.game.field(gameId, function (response) {
                    self.loadGame(selector, gameId);
                }, function (response) {
                    $(selector + " #error-messages").html(JSON.parse(response.responseText).Message);
                })
            },

            attachHandlers: function (selector) {
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
                        self.loadActiveGames(response.nickname, selector);
                    }, function (response) {
                        $(selector + " #error-messages").html(JSON.parse(response.responseText).Message);
                    });
                });

                wrapper.on("click", "#register", function () {
                    var user = {
                        username: $(selector + " #register-username").val(),
                        nickname: $(selector + " #register-nickname").val(),
                        password: $(selector + " #register-password").val(),
                    };

                    self.persister.user.register(user, function (response) {
                        self.loadActiveGames(response.nickname, selector);
                    }, function (response) {
                        $(selector + " #error-messages").html(JSON.parse(response.responseText).Message);
                    });
                });

                wrapper.on("click", "#logout", function () {
                    self.persister.user.logout(function () {
                        location.reload();
                    }, function (response) {
                        $(selector + " #error-messages").html(JSON.parse(response.responseText).Message);
                        document.location.href = "#/home";
                    });
                });

                wrapper.on("click", "#create-game", function () {
                    var title = $(selector + " #game-title").val();
                    var gameData = {
                        title: title
                    };

                    self.persister.game.create(gameData, function (resp) {
                    }, function (response) {
                        $(selector + " #error-messages").html(JSON.parse(response.responseText).Message);
                    });
                });

                wrapper.on("click", "#join", function () {
                    var gameId = $(this).parent().data("gameId");

                    self.persister.game.join({
                        id: gameId
                    }, function (response) {
                        // OK, just leave the UI to update
                    }, function (response) {
                        $(selector + " #error-messages").html(JSON.parse(response.responseText).Message);
                    });
                });

                wrapper.on("click", "#start", function () {
                    var gameId = $(this).parent().data("gameId");

                    self.persister.game.start(gameId, function (response) {
                        // OK, just leave the UI to update
                    }, function (response) {
                        $(selector + " #error-messages").html(JSON.parse(response.responseText).Message);
                    });
                });

                wrapper.on("click", "#play", function () {
                    var gameId = $(this).parent().data("gameId");
                    localStorage.setItem("gameId", gameId);
                    window.location.href = "#/battle";
                });

                wrapper.on("click", "td", function () {
                    $(this).addClass("selected");
                });
            },

            //updateUI: function (selector) {
            //    this.persister.game.open(function (games) {
            //        ui.openGamesList(games, selector);
            //    }, function (response) {
            //        $(selector + " #error-messages").html(response);
            //    });

            //    this.persister.game.myActive(function (games) {
            //        ui.activeGamesList(games, selector);
            //    }, function (response) {
            //        $(selector + " #error-messages").html(response);
            //    });

            //    this.persister.messages.all(function (messages) {
            //        ui.messagesList(messages, selector);
            //    }, function (response) {
            //        $(selector + " #error-messages").html(response);
            //    });

            //    this.persister.user.scores(function (scores) {
            //        ui.scoresList(scores, selector);
            //    }, function (response) {
            //        $(selector + " #error-messages").html(response);
            //    });
            //},

            loadGame: function (selector, gameId) {
                var self = this;
                var gameUI = ui.gameUI(selector);
                $(selector).html(gameUI);
                self.updateGameUI(selector, gameId);

                updateTimer = setInterval(function () {
                    self.updateGameUI(selector, gameId);
                }, 1000);
            },

            updateGameUI: function (selector, gameId) {
                this.persister.game.field(gameId, function (response) {
                    ui.gameField(response, selector);
                }, function (response) {
                    $(selector + " #error-messages").html(response);
                });
            },
        });

        return {
            get: function () {
                return new Controller();
            }
        }
    })();

    return controller;
});