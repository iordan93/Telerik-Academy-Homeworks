/// <reference path="jquery-1.8.2.js" />
/// <reference path="class.js" />
/// <reference path="http-requester.js" />
/// <reference path="sha1.js" />
define("persister", ["class", "requester", "sha1"], function (Class, httpRequester) {
    var persisters = (function () {
        var nickname = localStorage.getItem("nickname");
        var sessionKey = localStorage.getItem("sessionKey");

        var MainPersister = Class.create({
            init: function (rootUrl) {
                this.rootUrl = rootUrl;
                this.game = new GamePersister(this.rootUrl);
                this.battle = new BattlePersister(this.rootUrl);
                this.messages = new MessagesPersister(this.rootUrl);
                this.user = new UserPersister(this.rootUrl);
            },

            isUserLoggedIn: function () {
                return nickname != null && sessionKey != null;
            }
        });
        
        var GamePersister = Class.create({
            init: function (rootUrl) {
                this.rootUrl = rootUrl + "game/"
            },

            create: function (game, success, error) {
                var url = this.rootUrl + "create/" + sessionKey;
                var gameData = {
                    title: game.title,
                    // password: CryptoJS.SHA1("")
                };

                httpRequester.postJson(url, gameData, success, error);
            },

            join: function (game, success, error) {
                var url = this.rootUrl + "join/" + sessionKey;
                var gameData = {
                    id: game.id,
                    // password: CryptoJS.SHA1("")
                };

                httpRequester.postJson(url, gameData, success, error);
            },

            start: function (gameId, success, error) {
                var url = this.rootUrl + gameId + "/start/" + sessionKey;

                httpRequester.putJson(url, success, error);
            },

            field: function (gameId, success, error) {
                var url = this.rootUrl + gameId + "/field/" + sessionKey;

                httpRequester.getJson(url, success, error);
            },

            open: function (success, error) {
                var url = this.rootUrl + "open/" + sessionKey;

                httpRequester.getJson(url, success, error);
            },

            myActive: function (success, error) {
                var url = this.rootUrl + "my-active/" + sessionKey;

                httpRequester.getJson(url, success, error);
            }
        });

        var BattlePersister = Class.create({
            init: function (rootUrl) {
                this.rootUrl = rootUrl + "battle/"
            },

            move: function (move, success, error) {
                var url = this.rootUrl + gameId + "/move/" + sessionKey;

                var moveData = {
                    unitId: move.unitId,
                    position: {
                        x: move.position.x,
                        y: move.position.y
                    }
                };

                httpRequester.postJson(url, moveData, success, error);
            },

            attack: function (attack, success, error) {
                var url = this.rootUrl + gameId + "/attack/" + sessionKey;

                var attackData = {
                    unitId: attack.unitId,
                    position: {
                        x: attack.position.x,
                        y: attack.position.y
                    }
                };

                httpRequester.postJson(url, attackData, success, error);
            },

            defend: function (unitId, success, error) {
                var url = this.rootUrl + gameId + "/defend/" + sessionKey;

                httpRequester.postJson(url, unitId, success, error);
            },
        });

        var MessagesPersister = Class.create({
            init: function (rootUrl) {
                this.rootUrl = rootUrl + "messages/"
            },

            all: function (success, error) {
                var url = this.rootUrl + "all/" + sessionKey;

                httpRequester.getJson(url, success, error);
            },

            unread: function (success, error) {
                var url = this.rootUrl + "unread/" + sessionKey;

                httpRequester.getJson(url, success, error);
            }
        });

        var UserPersister = Class.create({
            init: function (rootUrl) {
                this.rootUrl = rootUrl + "user/"
            },

            register: function (user, success, error) {
                var url = this.rootUrl + "register/";
                var userData = {
                    username: user.username,
                    nickname: user.nickname,
                    authCode: CryptoJS.SHA1(user.username + user.password).toString()
                };

                httpRequester.postJson(url, userData, function (response) {
                    saveUserData(response);
                    success(response);
                }, error);
            },

            login: function (user, success, error) {
                var url = this.rootUrl + "login/";
                var userData = {
                    username: user.username,
                    authCode: CryptoJS.SHA1(user.username + user.password).toString()
                };

                httpRequester.postJson(url, userData, function (response) {
                    saveUserData(response);
                    success(response);
                }, error);
            },

            logout: function (success, error) {
                var url = this.rootUrl + "logout/" + sessionKey;
                console.log(httpRequester);
                httpRequester.putJson(url, function (response) {
                    clearUserData(response);
                    success(response);
                }, error);
            },

            scores: function (success, error) {
                var url = this.rootUrl + "scores/" + sessionKey;

                httpRequester.getJson(url, success, error);
            }
        });

        function saveUserData(response) {
            localStorage.setItem("nickname", response.nickname);
            localStorage.setItem("sessionKey", response.sessionKey);
            nickname = response.nickname;
            sessionKey = response.sessionKey;
        };

        function clearUserData() {
            localStorage.removeItem("nickname");
            localStorage.removeItem("sessionKey");
            nickname = "";
            sessionKey = "";
        };

        return {
            getPersister: function (rootUrl) {
                return new MainPersister(rootUrl);
            }
        };
    })();

    return persisters;
});