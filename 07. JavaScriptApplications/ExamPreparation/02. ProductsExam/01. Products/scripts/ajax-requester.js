var ajaxRequester = (function() {
    function makeRequest(method, headers, url, data) {
        var defered = Q.defer();

        $.ajax({
            method: method,
            headers: headers,
            url: url,
            contentType: "application/json",
            data: JSON.stringify(data),
            success: function(data) {
                defered.resolve(data);
            },
            error: function(error) {
                defered.reject(error);
            }
        });

        return defered.promise;
    }

    function makeGetRequest(headers, url) {
        return makeRequest("GET", headers, url, null);
    }

    function makePostRequest(headers, url, data) {
        return makeRequest("POST", headers, url, data);
    }

    function makePutRequest(headers, url, data) {
        return makeRequest("PUT", headers, url, data);
    }

    function makeDeleteRequest(headers, url) {
        return makeRequest("DELETE", headers, url, null);
    }

    return {
        get: makeGetRequest,
        post: makePostRequest,
        put: makePutRequest,
        delete: makeDeleteRequest
    }
}());