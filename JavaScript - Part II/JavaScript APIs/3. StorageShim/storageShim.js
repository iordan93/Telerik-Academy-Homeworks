if (!window.Storage) {
    window.Storage = storage;
}

var storage = (function () {
    // Using cookies to emulate local and session storage.
    // Cookies with no expiry date are removed at the end of the session
    function createCookie(key, value, expires, path) {
        key = key || "";
        value = value || "";
        expires = expires || "31 Dec 2100 23:59:59 UTC";
        path = path || "/";

        document.cookie = key + "=" + value + "; expires=" + expires + "; path=" + path;
    }

    function readCookie(name) {
        var allCookies = document.cookie.split(";");

        for (var cookieIndex = 0; cookieIndex < allCookies.length; cookieIndex++) {
            var cookie = allCookies[cookieIndex];
            for (var j = 0; j < cookie.length; j++) {
                if (cookie[j] !== " ") {
                    break;
                }
            }
            cookie = cookie.substring(j);

            if (cookie.startsWith(name + "=")) {
                return cookie;
            }
        }
    }

    var localStorage = (function () {
        var getItem = function (key) {
            var cookie = readCookie(key);
            var data = cookie.substring(cookie.indexOf("=") + 1).toString();
            data = JSON.parse(data);
            return data;
        };

        var setItem = function (key, data) {
            data = JSON.stringify(data);
            createCookie(key, data);
        };

        var removeItem = function (key) {
            document.cookie = key + "=; expires=01 Jan 1970 00:00:01 GMT; path=/";
        };

        var clear = function () {
            var cookies = document.cookie.split(";");
            for (var i = 0; i < cookies.length; i++) {
                var currentCookie = cookies[i];
                var currentCookieName = currentCookie.substring(0, currentCookie.indexOf("="));
                removeItem(currentCookieName);
            }
        };

        var length = function () {
            if (document.cookie === "") {
                return 0;
            }
            var length = document.cookie.split(";").length;
            return length;
        };

        return {
            getItem: getItem,
            setItem: setItem,
            removeItem: removeItem,
            clear: clear,
            length: length
        };
    })();

    var sessionStorage = (function () {
        var getItem = function (key) {
            var cookie = readCookie(key);
            var data = cookie.substring(cookie.indexOf("=") + 1).toString();
            data = JSON.parse(data);
            return data;
        };

        var setItem = function (key, data) {
            data = JSON.stringify(data);
            // Cookie with no "expires" will expire at the end of the current session
            createCookie(key, data, "");
        };

        var removeItem = function (key) {
            document.cookie = key + "=; expires=01 Jan 1970 00:00:01 GMT; path=/;";
        };

        var clear = function () {
            var cookies = document.cookie.split(";");
            for (var i = 0; i < cookies.length; i++) {
                var currentCookie = cookies[i];
                var currentCookieName = currentCookie.substring(0, currentCookie.indexOf("="));
                removeItem(currentCookieName);
            }
        };

        var length = function () {
            if (document.cookie === "") {
                return 0;
            }
            var length = document.cookie.split(";").length;
            return length;
        };

        return {
            getItem: getItem,
            setItem: setItem,
            removeItem: removeItem,
            clear: clear,
            length: length
        };
    })();

    return {
        localStorage: localStorage,
        sesssionStorage: sessionStorage
    }
})();