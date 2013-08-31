var httpRequester = (function () {
    function getJson(url, headers, success, error) {
        $.ajax({
            url: url,
            type: "GET",
            timeout: 5000,
            contentType: "application/json",
            headers: headers,
            success: success,
            error: error
        });
    };

    function postJson(url, headers, data, success, error) {
        $.ajax({
            url: url,
            type: "POST",
            timeout: 5000,
            contentType: "application/json",
            headers: headers,
            data: JSON.stringify(data),
            success: success,
            error: error
        });
    };

    function putJson(url, headers, data, success, error) {
        $.ajax({
            url: url,
            type: "PUT",
            headers: headers,
            data: JSON.stringify(data),
            timeout: 5000,
            dataType: "json",
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