var app = app || {};

app.dataPersister = (function() {
    function Persister(rootUrl) {
        this.rootUrl = rootUrl;
        this.books = new Books(rootUrl);
    }

    var Books = (function () {
        function Books(rootUrl) {
            this.serviceUrl = rootUrl + 'Book/';
        }

        Books.prototype.getAllBooks = function() {
            return ajaxRequester.get(this.serviceUrl);
        }

        Books.prototype.addBook = function (book) {
            return ajaxRequester.post(this.serviceUrl, book);
        }

        Books.prototype.updateBook = function (id, book) {
            return ajaxRequester.put(this.serviceUrl + id, book);
        }

        Books.prototype.deleteBook = function (id) {
            return ajaxRequester.delete(this.serviceUrl + id);
        }

        return Books;
    })();

    return {
        getPersister: function(rootUrl) {
            return new Persister(rootUrl);
        }
    }
})();