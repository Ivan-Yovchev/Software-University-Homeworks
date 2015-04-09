$(function () {
    var X_PARSE_APPLICATION_ID = "d7d1jQCGfdgikQi5QsV8GC4gBd8Bw1iw06k7uL2y";
    var X_PARSE_REST_API_KEY = "NhJXRvARdsxEnj5aG6DfvEf7MCJvJ7i5TOa0d5p8";

    $("#addBook").click(addNewBook);

    function ajaxError() {
        noty({
            text: "An error occured. Data cannot be reached.",
            type: "error",
            layout: "topCenter",
            timeout: 5000
        });
    }

    function deleteBook() {
        var $parent = $(this).parent();
        var book = $parent.data('book');

        $.ajax({
            method: "DELETE",
            headers: {
                "X-Parse-Application-Id": X_PARSE_APPLICATION_ID,
                "X-Parse-REST-API-Key": X_PARSE_REST_API_KEY
            },
            url: "https://api.parse.com/1/classes/Book/" + book.objectId,
            success: function (_) {
                noty({
                    text: "Book Successfully deleted",
                    type: "success",
                    layout: "topCenter",
                    timeout: 2000
                });
            },
            error: ajaxError
        });

        $parent.remove();
    }

    function saveChanges() {
        var $parent = $(this).parent();
        var title = $parent.find('input:eq(0)').val();
        var author = $parent.find('input:eq(1)').val();
        var isbn = $parent.find('input:eq(2)').val();
        var tags = $parent.find('input:eq(3)').val();
        var book = $parent.data('book');

        if (title === "" || author === "") {
            console.log("Error");
        } else {
            var editBook = {
                title: title,
                author: author
            }
            if (isbn !== undefined) {
                editBook.isbn = isbn;
            }
            if (tags !== undefined && tags !== "") {
                tags = tags.split(",");
                editBook.tags = tags;
            } else {
                editBook.tags = [];
            }

            $.ajax({
                method: "PUT",
                headers: {
                    "X-Parse-Application-Id": X_PARSE_APPLICATION_ID,
                    "X-Parse-REST-API-Key": X_PARSE_REST_API_KEY
                },
                url: "https://api.parse.com/1/classes/Book/" + book.objectId,
                data: JSON.stringify(editBook),
                success: function (_) {
                    loadBooks();
                    noty({
                        text: "Book successfully updated",
                        type: "success",
                        layout: "topCenter",
                        timeout: 2000
                    });
                },
                error: ajaxError
            });
        }
    }

    function editBook() {
        var $parent = $(this).parent();
        $parent.find('p').addClass("hide");
        $parent.find('input').removeClass("hide");
        var $editButton = $parent.find(".editButton");
        $editButton.addClass("hide");
        var $deleteButton = $parent.find(".deleteButton");
        $deleteButton.addClass("hide");
        var $saveButton = $parent.find(".saveButton");
        $saveButton.removeClass("hide");
        var $cancelButton = $parent.find(".cancelButton");
        $cancelButton.removeClass("hide");

        var title = $parent.find("p:eq(0)").text();
        var author = $parent.find("p:eq(1)").text();
        author = author.substr(8, author.length);
        var isbn = $parent.find("p:eq(2)").text();
        var tags = $parent.find("p:eq(3)").text();
        

        $parent.find("input:eq(0)").val(title);
        $parent.find("input:eq(1)").val(author);
        if (isbn !== "") {
            $parent.find("input:eq(2)").val(isbn.substr(6, isbn.length));
        }
        if (tags !== undefined && tags !== "") {
            tags = tags.substr(6, tags.length).split(", ");
            $parent.find("input:eq(3)").val(tags);
        }
    }

    function removeEditMode(currentElement) {
        var $parent = $(currentElement).parent();
        $parent.find('p').removeClass("hide");
        $parent.find('input').addClass("hide");
        var $editButton = $parent.find(".editButton");
        $editButton.removeClass("hide");
        var $deleteButton = $parent.find(".deleteButton");
        $deleteButton.removeClass("hide");
        var $saveButton = $parent.find(".saveButton");
        $saveButton.addClass("hide");
        var $cancelButton = $parent.find(".cancelButton");
        $cancelButton.addClass("hide");
    }

    function cancelEditBook() {
        removeEditMode(this);
    }

    function addNewBook() {
        var title = $("#newBookTitle").val();
        $("#newBookTitle").val('');
        var author = $("#newBookAuthor").val();
        $("#newBookAuthor").val('');
        var isbn = $("#newBookIsbn").val();
        $("#newBookIsbn").val('');
        var tags = $("#newBookTags").val();
        $("#newBookTags").val('');

        if (title === "" || author === "") {
            console.log("Error");
        } else {
            var book = {
                title: title,
                author: author
            };

            if (isbn !== "") {
                book.isbn = isbn;
            }

            if (tags !== "") {
                tags = tags.split(",");
                book.tags = tags;
            } else {
                book.tags = [];
            }

            $.ajax({
                method: "POST",
                headers: {
                    "X-Parse-Application-Id": X_PARSE_APPLICATION_ID,
                    "X-Parse-REST-API-Key": X_PARSE_REST_API_KEY
                },
                url: "https://api.parse.com/1/classes/Book",
                data: JSON.stringify(book),
                success: function(data) {
                    loadBooks(data);
                    noty({
                        text: "Book successfully added",
                        type: "success",
                        layout: "topCenter",
                        timeout: 2000
                    });
                },
                error: ajaxError
            });
        }
    }

    function listLoadedBooks(data) {
        var $booksUl = $("#books");
        $booksUl.empty();
        for (var index in data.results) {
            var book = data.results[index];
            var bookTitle = book.title || "Book Title",
                bookAuthor = book.author || "Book Author",
                bookIsbn = book.isbn || "",
                bookTags = book.tags || [];

            var $bookLi = $("<li>");

            var $paragraphTitle = $('<p>').text(bookTitle);
            $bookLi.append($paragraphTitle);

            var $editTitleInput = $("<input type=text placeholder='e.g. The Hunger Games'>");
            $editTitleInput.addClass("hide");
            $bookLi.append($editTitleInput);

            var $paragraphAuthor = $('<p>').text("Author: " + bookAuthor);
            $bookLi.append($paragraphAuthor);

            var $editAuthorInput = $("<input type=text placeholder='e.g. Suzann Collins'>");
            $editAuthorInput.addClass("hide");
            $bookLi.append($editAuthorInput);

            var $paragraphIsbn;
            if (bookIsbn !== "") {
                $paragraphIsbn = $('<p>').text("Isbn: " + bookIsbn);
                $bookLi.append($paragraphIsbn);
            } else {
                $paragraphIsbn = $('<p>');
                $bookLi.append($paragraphIsbn);
            }

            var $editIsbnInput = $("<input type=text placeholder='e.g. 12313213123'>");
            $editIsbnInput.addClass("hide");
            $bookLi.append($editIsbnInput);

            var $paragraphTags;
            if (bookTags.length > 0) {
                var tags = bookTags.join(", ");
                $paragraphTags = $('<p>').text("Tags: " + tags);
                $bookLi.append($paragraphTags);
            } else {
                $paragraphTags = $('<p>');
                $bookLi.append($paragraphTags);
            }
            var $editTagsInput = $("<input type=text placeholder='e.g. sci-fi,computers...'>");
            $editTagsInput.addClass("hide");
            $bookLi.append($editTagsInput);

            var $editButton = $("<button>").text("Edit");
            $editButton.click(editBook);
            $editButton.addClass("editButton");
            $bookLi.append($editButton);

            var $saveButton = $("<button>").text("Save");
            $saveButton.addClass("saveButton");
            $saveButton.addClass("hide");
            $saveButton.click(saveChanges);
            $bookLi.append($saveButton);

            var $cancelButton = $("<button>").text("Cancel");
            $cancelButton.addClass("cancelButton");
            $cancelButton.addClass("hide");
            $cancelButton.click(cancelEditBook);
            $bookLi.append($cancelButton);

            var $deleteButton = $("<button>").text("Delete");
            $deleteButton.click(deleteBook);
            $deleteButton.addClass("deleteButton");
            $bookLi.append($deleteButton);

            $bookLi.data('book', book);
            $booksUl.append($bookLi);
        }
    }

    function loadBooks() {
        $.ajax({
            method: "GET",
            headers: {
                "X-Parse-Application-Id": X_PARSE_APPLICATION_ID,
                "X-Parse-REST-API-Key": X_PARSE_REST_API_KEY
            },
            url: "https://api.parse.com/1/classes/Book?order=title",
            success: listLoadedBooks,
            error: function(error) {
                console.log(error);
            }
        });
    }

    loadBooks();
});