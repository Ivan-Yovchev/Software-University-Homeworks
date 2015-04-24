var app = app || {};

app.controller = (function() {
    function Controller(dataPersister) {
        this.dataPersister = dataPersister;
    }

    Controller.prototype.load = function (selector) {
        this.selector = selector;
        this.attachEvents();
        this.loadAllBooks();
    }

    Controller.prototype.loadAllBooks = function () {
        var _this = this;
        this.dataPersister.books.getAllBooks()
            .then(function (data) {
                var $bookTemplate = $('#book-template').html();
                var $selector = $(_this.selector);

                data.results.forEach(function(book) {
                    $selector.append(Mustache.render($bookTemplate, book));
                });
            }, function(error) {
                console.log(error);
            }
        );
    }

    Controller.prototype.attachEvents = function () {
        var _this = this;
        $("#add-book").click(function() {
            var title = $("#new-book-title").val();
            $("#new-book-title").val('');
            var author = $("#new-book-author").val();
            $("#new-book-author").val('');
            var isbn = $("#new-book-isbn").val();
            $("#new-book-isbn").val('');

            var book = {
                title: title,
                author: author,
                isbn: isbn,
                tags: []
            };

            _this.dataPersister.books.addBook(book)
                .then(function (data) {
                    book.objectId = data.objectId;
                    var $bookTemplate = $('#book-template').html();
                    $(_this.selector).append(Mustache.render($bookTemplate, book));
                }, function(error) {
                    console.log(error);
                }
            );
        });

        $(_this.selector).delegate(".removeButton", 'click', function () {
            var id = $(this).parent().attr("data-bookId");
            _this.dataPersister.books.deleteBook(id);
            $(this).parent().remove();
        });

        $(_this.selector).delegate(".editButton", "click", function () {
            var $bookLi = $(this).parent();
            $bookLi.find("input.title").val($bookLi.find("span.title").html());
            $bookLi.find("input.author").val($bookLi.find("span.author").html());
            $bookLi.find("input.isbn").val($bookLi.find("span.isbn").html());
            $bookLi.addClass("edit");
        });

        $(_this.selector).delegate(".cancelEdit", "click", function () {
            $(this).parent().removeClass("edit");
        });

        $(_this.selector).delegate(".saveEdit", "click", function () {
            var $bookLi = $(this).parent();
            var title = $bookLi.find("input.title").val();
            var author = $bookLi.find("input.author").val();
            var isbn = $bookLi.find("input.isbn").val();
            var id = $bookLi.attr("data-bookId");

            var book = {
                title: title,
                author: author,
                isbn: isbn
            }

            _this.dataPersister.books.updateBook(id, book)
                .then(function (data) {
                    $bookLi.find("span.title").text(title);
                    $bookLi.find("span.author").text(author);
                    $bookLi.find("span.isbn").text(isbn);
                    $bookLi.removeClass("edit");
                }, function(error) {
                    console.log(error);
                }
            );
        });
    }

    return {
        getController: function(dataPersister) {
            return new Controller(dataPersister);
        }
    }
})();