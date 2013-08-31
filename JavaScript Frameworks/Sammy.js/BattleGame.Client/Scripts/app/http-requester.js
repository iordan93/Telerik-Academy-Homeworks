/// <reference path="../libs/require.js" />
/// <reference path="../libs/jquery-2.0.3.js" />
define("requester", ["jquery"], function () {
    var httpRequester = (function () {
        function getJson(url, success, error) {
            $.ajax({
                url: url,
                type: "GET",
                timeout: 5000,
                contentType: "application/json",
                success: success,
                error: error
            });
        };

        function postJson(url, data, success, error) {
            $.ajax({
                url: url,
                type: "POST",
                timeout: 5000,
                contentType: "application/json",
                data: JSON.stringify(data),
                success: success,
                error: error
            });
        };

        function putJson(url, success, error) {
            $.ajax({
                url: url,
                type: "PUT",
                timeout: 5000,
                contentType: "application/json",
                success: success,
                error: error
            });
        };

        return {
            getJson: getJson,
            postJson: postJson,
            putJson: putJson
        }
    })();

    return httpRequester;
});