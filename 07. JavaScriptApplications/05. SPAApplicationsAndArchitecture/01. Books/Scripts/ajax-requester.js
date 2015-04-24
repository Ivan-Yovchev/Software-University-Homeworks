var ajaxRequester = (function() {
    var makeRequest = function makeRequest(method, url, data) {
        var deferred = $.Deferred();

        $.ajax({
            method: method,
            headers: {
                "X-Parse-Application-Id": "d7d1jQCGfdgikQi5QsV8GC4gBd8Bw1iw06k7uL2y",
                "X-Parse-REST-API-Key": "NhJXRvARdsxEnj5aG6DfvEf7MCJvJ7i5TOa0d5p8"
            },
            url: url,
            contentType: "application/json",
            data: JSON.stringify(data),
            success: function(data) {
                deferred.resolve(data);
            },
            error: function(error) {
                deferred.reject(error);
            }
        });

        return deferred.promise();
    }

    function makeGetRequest(url) {
        return makeRequest("GET", url, null);
    }

    function makePostRequest(url, data) {
        return makeRequest("POST", url, data);
    }

    function makePutRequest(url, data) {
        return makeRequest("PUT", url, data);
    }

    function makeDeleteRequest(url) {
        return makeRequest("DELETE", url, null);
    }

    return {
        get: makeGetRequest,
        post: makePostRequest,
        put: makePutRequest,
        delete: makeDeleteRequest
    }
})();