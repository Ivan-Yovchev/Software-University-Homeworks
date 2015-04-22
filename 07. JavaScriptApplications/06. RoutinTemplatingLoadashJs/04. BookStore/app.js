$(function() {
    var books = [
        { "book": "The Grapes of Wrath", "author": "John Steinbeck", "price": "34,24", "language": "French" },
        { "book": "The Great Gatsby", "author": "F. Scott Fitzgerald", "price": "39,26", "language": "English" },
        { "book": "Nineteen Eighty-Four", "author": "George Orwell", "price": "15,39", "language": "English" },
        { "book": "Ulysses", "author": "James Joyce", "price": "23,26", "language": "German" },
        { "book": "Lolita", "author": "Vladimir Nabokov", "price": "14,19", "language": "German" },
        { "book": "Catch-22", "author": "Joseph Heller", "price": "47,89", "language": "German" },
        { "book": "The Catcher in the Rye", "author": "J. D. Salinger", "price": "25,16", "language": "English" },
        { "book": "Beloved", "author": "Toni Morrison", "price": "48,61", "language": "French" },
        { "book": "Of Mice and Men", "author": "John Steinbeck", "price": "29,81", "language": "Bulgarian" },
        { "book": "Animal Farm", "author": "George Orwell", "price": "38,42", "language": "English" },
        { "book": "Finnegans Wake", "author": "James Joyce", "price": "29,59", "language": "English" },
        { "book": "The Grapes of Wrath", "author": "John Steinbeck", "price": "42,94", "language": "English" }
    ];

    var groupedByLanguage = _.groupBy(books, "language");
    _.each(groupedByLanguage, function(group) {
        group.sort(function(book1, book2) {
            if (book1.author === book2.author) {
                if (parseInt(book1.price) > parseInt(book2.price)) {
                    return book1;
                } else {
                    return book2;
                }
            } else {
                if (book1.author.localeCompare(book2.author) < 0) {
                    return book1;
                } else {
                    return book2;
                }
            }
        });
    });
    _.each(groupedByLanguage, function(group, key) {
        var booksGroup = {
            caption: key,
            data: group
        }

        $.get("language-template.html", function(template) {
            var result = Mustache.render(template, booksGroup);
            $("#author-price-sort").append(result);
        });
    });

    var groupedByAuthor = _.groupBy(books, "author");
    var avaregePrice = {};
    _.map(groupedByAuthor, function(group, key) {
        var sum = 0;
        _.each(group, function(book) {
            sum += parseInt(book.price);
        });

        return avaregePrice[key] = (sum / group.length);
    });
    _.each(avaregePrice, function (value, key) {
        $("#author-price-average").append($("<li>").text(key + " -> " + value + "$"));
    });

    var filterBooks = _.filter(books, function(book) {
        return (book.language === "German" || book.language === "English") && (parseInt(book.price) <= 30);
    });
    var booksByAuthor = _.groupBy(filterBooks, "author");
    _.each(booksByAuthor, function(value, key) {
        var booksGroup = {
            caption: key,
            data: value
        }

        $.get("language-template.html", function (template) {
            var result = Mustache.render(template, booksGroup);
            $("#german-english-books").append(result);
        });
    });
});