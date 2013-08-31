/// <reference path="../libs/require.js" />
/// <reference path="../libs/mustache.js" />
define("ui", ["mustache", "jquery"], function (Mustache, $) {
    var ui = (function () {
        function menu(selector) {
            $.get("../ui-templates.html", function (templates) {
                var menuHtml = $(templates).filter("#menu").html();
                $(selector).html(Mustache.render(menuHtml));
            });
        };


        function loginFormUI(selector) {
            $.get("../ui-templates.html", function (templates) {
                var loginFormHtml = $(templates).filter("#login-form").html();
                $(selector).html(Mustache.render(loginFormHtml));
            });
        };

        function dashboardUI(nickname, selector) {
            $.get("../ui-templates.html", function (templates) {
                var dashboardHtml = $(templates).filter("#dashboard").html();
                $(selector).html(Mustache.render(dashboardHtml, nickname));
            });
        };

        function openGamesList(games, selector) {
            $.get("../ui-templates.html", function (templates) {
                var openGames = $(templates).filter("#open-games-list").html();
                $(selector + " #open-games").html(Mustache.render(openGames, games));
            });
        };

        function activeGamesList(games, selector) {
            var gamesList = sortGamesList(games);

            for (var i = 0; i < gamesList.length; i++) {
                var game = gamesList[i];
                game.start = game.status == "full" && game.creator == localStorage["nickname"] ? true : false;
                game.play = game.status == "in-progress" ? true : false;
            }

            $.get("../ui-templates.html", function (templates) {
                var activeGames = $(templates).filter("#active-games-list").html();
                $(selector).html(Mustache.render(activeGames, gamesList));
            });
        };

        function messagesList(messages, selector) {
            $.get("../ui-templates.html", function (templates) {
                var messagesHtml = $(templates).filter("#messages-list").html();
                $(selector + " #messages").html(Mustache.render(messagesHtml, messages));
            });
        };

        function scoresList(scores, selector) {
            var scoresList = sortScoresList(scores);

            $.get("../ui-templates.html", function (templates) {
                var scoresHtml = $(templates).filter("#scores").html();
                $(selector + " #scores").html(Mustache.render(scoresHtml, scoresList));
            });
        };

        function gameUI(selector) {
            $.get("../ui-templates.html", function (templates) {
                var gameHtml = $(templates).filter("#game").html();
                $(selector).html(Mustache.render(gameHtml));
            });
        }

        function sortGamesList(games) {
            var gamesList = Array.prototype.slice.call(games, 0);

            gamesList.sort(function (g1, g2) {
                if (g1.status == g2.status) {
                    return g1.title > g2.title;
                }
                else {
                    if (g1.status == "in-progress") {
                        return -1;
                    }
                }
                return 1;
            });

            return gamesList;
        };

        function sortScoresList(scores) {
            var scoresList = [];

            for (var i = 0; i < scores.length; i++) {
                if (scores[i].score != 0) {
                    scoresList.push(scores[i]);
                }
            }

            scoresList.sort(function (s1, s2) {
                return s1.score < s2.score;
            });

            return scoresList;
        };

        function gameField(response, selector) {
            for (var i = 0; i < response.blue.units.length; i++) {
                $(selector).find("#players").html(
                    '<span class="bluePlayer">' + response.blue.nickname + '</span>' + ' vs ' +
                    '<span class="redPlayer">' + response.red.nickname + '</span>');
                var currentUnit = response.blue.units[i];
                var currentPosition = "" + currentUnit.position.y + currentUnit.position.x;
                var content = currentUnit.type[0];
                $(selector).find("#" + currentPosition).css({
                    "background-color": "blue",
                    "width": "30px",
                    "height": "30px",
                    "color": "white",
                    "font-weight": "bold",
                    "text-align": "center",
                    "vertical-align": "middle"
                }).html(content);
            }

            for (i = 0; i < response.red.units.length; i++) {
                currentUnit = response.red.units[i];
                currentPosition = "" + currentUnit.position.y + currentUnit.position.x;
                content = currentUnit.type[0];
                $(selector).find("#" + currentPosition).css({
                    "background-color": "red",
                    "width": "30px",
                    "height": "30px",
                    "color": "white",
                    "font-weight": "bold",
                    "text-align": "center",
                    "vertical-align": "middle"
                }).html(content);
            }

            $(selector).find(".selected").css({
                "background-color": "darkgreen"
            });
        }

        return {
            loginFormUI: loginFormUI,
            dashboardUI: dashboardUI,
            openGamesList: openGamesList,
            activeGamesList: activeGamesList,
            messagesList: messagesList,
            scoresList: scoresList,
            gameUI: gameUI,
            gameField: gameField,
            menu: menu
        }
    })();

    return ui;
});