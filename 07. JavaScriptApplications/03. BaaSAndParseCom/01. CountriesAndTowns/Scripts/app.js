$(function () {
    var PARSE_APP_ID = "lMgt8ivHZZ7gRFq59X48zLMgWk9t2njxDVuABM8z";
    var PARSE_REST_APP_KEY = "8xkrpKCYiUenpOH8ICp7ymtcTSLaeK4KpbfIxMX5";

    function emptyInputError() {
        noty({
            text: "Input cannot be empty",
            type: "error",
            layout: "topCenter",
            timeout: 5000
        });
    }

    function postTown(name, objectId) {
        var town = {
            townName: name,
            country: {
                __type: "Pointer",
                className: "Country",
                objectId: objectId
            }
        };

        $.ajax({
            method: "POST",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_APP_KEY
            },
            url: "https://api.parse.com/1/classes/Town",
            data: JSON.stringify(town),
            contentType: "application/json"
        });
    }

    function addCountry() {
        var $newCountryName = $('#countryName');
        var name = $newCountryName.val();
        $newCountryName.val('');
        if (name === "" || name === undefined) {
            emptyInputError();
        } else {
            var country = {
                countryName: name
            };

            $.ajax({
                method: "POST",
                headers: {
                    "X-Parse-Application-Id": PARSE_APP_ID,
                    "X-Parse-REST-API-Key": PARSE_REST_APP_KEY
                },
                url: "https://api.parse.com/1/classes/Country",
                data: JSON.stringify(country),
                contentType: "application/json",
                success: loadCountries,
                error: ajaxError
            }).done(function() {
                var $towns = $(".townInput");
                var townNames = [];
                $towns.val(function (_, value) {
                    if (value !== "") {
                        townNames.push(value);
                    }
                });

                function getAllCountries() {
                    return $.ajax({
                        method: "GET",
                        headers: {
                            "X-Parse-Application-Id": PARSE_APP_ID,
                            "X-Parse-REST-API-Key": PARSE_REST_APP_KEY
                        },
                        url: "https://api.parse.com/1/classes/Country",
                        success: function (data) {
                            return data;
                        },
                        error: ajaxError
                    });
                }

                var allCountries = getAllCountries();
                var countryId;
                allCountries.success(function(data) {
                    for (var c in data.results) {
                        if (data.results[c].countryName === name) {
                            countryId = data.results[c].objectId;
                            break;
                        }
                    }

                    for (var t in townNames) {
                        postTown(townNames[t], countryId);
                    }
                });

                $('#townContainer').empty();
            });
        }
    }

    function addTownField() {
        var $container = $('<div>');
        var $label = $('<label>').text("Town: ");
        var $removeButton = $('<a>').text('[X]');
        $removeButton.click(function() {
            var $parent = $(this).parent();
            $parent.remove();
        });
        $removeButton.addClass('removeInputTown');

        var input = $('<input type=text placeholder="e.g. Sofia">');
        input.addClass("townInput");
        var $inputDiv = $('#townContainer');

        $container.addClass("townContainer");
        $container.append($label);
        $container.append(input);
        $container.append($removeButton);

        $inputDiv.append($container);
    }

    function loadTownsForCountry(country) {
        return $.ajax({
            method: "GET",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_APP_KEY
            },
            url: 'https://api.parse.com/1/classes/Town?where={"country":{"__type":"Pointer","className":"Country","objectId":"' + country.objectId + '"}}&order=townName',
            success: function (data) {
                return data;
            },
            error: ajaxError
        });
    }

    function deleteTown() {
        var $parentItem = $(this).parent();
        var town = $parentItem.data('town');

        $.ajax({
            method: "DELETE",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_APP_KEY
            },
            url: 'https://api.parse.com/1/classes/Town/' + town.objectId,
            success: $parentItem.remove(),
            error: ajaxError
        });
    }

    function edit() {
        var $parent = $(this).parent();
        $(this).addClass("hide");
        var $input = $parent.find('input');
        $input.removeClass("hide");
        var $span = $parent.find("span");
        var text = $span.text();
        $span.hide();
        var $saveButton = $parent.find(".saveButton");
        $saveButton.removeClass("hide");
        var $cancelButton = $parent.find(".cancelButton");
        $cancelButton.removeClass("hide");

        $input.val(text);
    }

    function cancel() {
        var $parent = $(this).parent();
        var $input = $parent.find('input');
        $input.addClass("hide");
        var $span = $parent.find("span");
        $span.show();
        var $saveButton = $parent.find(".saveButton");
        $saveButton.addClass("hide");
        var $cancelButton = $parent.find(".cancelButton");
        $cancelButton.addClass("hide");
        var $editButton = $parent.find('.edit');
        $editButton.removeClass("hide");
    }

    function saveChangesTown() {
        var $parent = $(this).parent();
        var $input = $parent.find('input');
        var newName = $input.val();
        var townId = $parent.data('town').objectId;
        var countryId = $('#towns').find('h2').data('country').objectId;
        var town = {
            townName: newName,
            country: {
                __type: "Pointer",
                className: "Country",
                objectId: countryId
            }
        };

        $.ajax({
            method: "PUT",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_APP_KEY
            },
            url: "https://api.parse.com/1/classes/Town/" + townId,
            data: JSON.stringify(town),
            contentType: "application/json",
            error: ajaxError
        });

        var $span = $parent.find("span");
        $span.text(newName);
        $span.show();
        $input.addClass("hide");
        $parent.find(".edit").removeClass("hide");
        $parent.find(".cancelButton").addClass("hide");
        $parent.find(".saveButton").addClass("hide");
    }

    function drawLoadedTowns(data, country) {
        var $towns = $('#towns');
        var $list = $towns.find('ul');
        $list.empty();
        $towns.css('display', 'none');
        $towns.find('h2')
            .data('country', country)
            .text(country.countryName + " - Towns");

        for (var t in data.results) {
            var town = data.results[t];
            var $townListItem = $("<li>");

            var $spanTownName = $('<span>').text(town.townName);
            $spanTownName.addClass("name");

            var $deleteTownButton = $('<a>').text('[X]');
            $deleteTownButton.addClass("deleteTown");
            $deleteTownButton.click(deleteTown);

            var $editCountryButton = $('<button>').text("Edit");
            $editCountryButton.addClass("edit");
            $editCountryButton.click(edit);

            var $inputName = $("<input type=text placeholder='e.g. Sofia'>");
            $inputName.addClass("inputCountryName");
            $inputName.addClass("hide");

            var $saveButton = $("<button>").text("Save");
            $saveButton.addClass("saveButton");
            $saveButton.addClass("hide");
            $saveButton.click(saveChangesTown);

            var $cancelButton = $("<button>").text("Cancel");
            $cancelButton.addClass("cancelButton");
            $cancelButton.addClass("hide");
            $cancelButton.click(cancel);

            $townListItem.append($spanTownName);
            $townListItem.append($inputName);
            $townListItem.append($editCountryButton);
            $townListItem.append($saveButton);
            $townListItem.append($cancelButton);
            $townListItem.append($deleteTownButton);
            $townListItem.data('town', town);
            $list.append($townListItem);
        }

        $towns.css('display', 'inline-block');
    }

    function addTown() {
        var $input = $('#newTown');
        var name = $input.val();
        $input.val('');

        if (name === "") {
            emptyInputError();
        } else {
            var $heading = $("#towns").find("h2");
            var country = $heading.data('country');
            var countryId = country.objectId;
            postTown(name, countryId);

            var countryTowns = loadTownsForCountry(country);
            countryTowns.success(function (data) {
                drawLoadedTowns(data, country);
            });
        }
    }

    $('#addCountry').click(addCountry);
    $('#addTown').click(addTownField);
    $("#addToTowns").click(addTown);

    function deleteCountry() {
        var $parentItem = $(this).parent();
        var country = $parentItem.data('country');
        var dataTowns = loadTownsForCountry(country);
        dataTowns.success(function (data) {
            for (var t in data.results) {
                var town = data.results[t];
                $.ajax({
                    method: "DELETE",
                    headers: {
                        "X-Parse-Application-Id": PARSE_APP_ID,
                        "X-Parse-REST-API-Key": PARSE_REST_APP_KEY
                    },
                    url: 'https://api.parse.com/1/classes/Town/' + town.objectId
                });
            }
        });

        $.ajax({
            method: "DELETE",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_APP_KEY
            },
            url: 'https://api.parse.com/1/classes/Country/' + country.objectId,
            success: $parentItem.remove(),
            error: ajaxError
        });

        $('#towns').hide();
    }

    function clickedCountryTowns() {
        var country = $(this).parent().data('country');
        var countryTowns = loadTownsForCountry(country);
        countryTowns.success(function (data) {
            drawLoadedTowns(data, country);
        });
    }

    function saveChangesCountry() {
        var $parent = $(this).parent();
        var $input = $parent.find('input');
        var newName = $input.val();
        var countryId = $parent.data('country').objectId;
        var country = {
            countryName: newName
        };

        $.ajax({
            method: "PUT",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_APP_KEY
            },
            url: "https://api.parse.com/1/classes/Country/" + countryId,
            data: JSON.stringify(country),
            contentType: "application/json",
            error: ajaxError
        });

        var $span = $parent.find("span");
        $span.text(newName);
        $span.show();
        $input.addClass("hide");
        $parent.find(".edit").removeClass("hide");
        $parent.find(".cancelButton").addClass("hide");
        $parent.find(".saveButton").addClass("hide");
    }

    function countriesLoaded(data) {
        var $countries = $("#countries");
        $countries.empty();
        for (var c in data.results) {
            var country = data.results[c];
            var $countryListItem = $("<li>");

            var $spanCountryName = $('<span>').text(country.countryName);
            $spanCountryName.addClass("name");
            $spanCountryName.click(clickedCountryTowns);

            var $editCountryButton = $('<button>').text("Edit");
            $editCountryButton.addClass("edit");
            $editCountryButton.click(edit);

            var $deleteCountryButton = $('<a>').text('[X]');
            $deleteCountryButton.addClass("deleteCountry");
            $deleteCountryButton.click(deleteCountry);

            var $inputName = $("<input type=text placeholder='e.g. Sofia'>");
            $inputName.addClass("inputCountryName");
            $inputName.addClass("hide");

            var $saveButton = $("<button>").text("Save");
            $saveButton.addClass("saveButton");
            $saveButton.addClass("hide");
            $saveButton.click(saveChangesCountry);

            var $cancelButton = $("<button>").text("Cancel");
            $cancelButton.addClass("cancelButton");
            $cancelButton.addClass("hide");
            $cancelButton.click(cancel);

            $countryListItem.append($spanCountryName);
            $countryListItem.append($inputName);
            $countryListItem.append($saveButton);
            $countryListItem.append($cancelButton);
            $countryListItem.append($editCountryButton);
            $countryListItem.append($deleteCountryButton);
            $countryListItem.data('country', country);
            $countries.append($countryListItem);
        }
    }

    function ajaxError() {
        console.log("Error");
    }

    function loadCountries() {
        $.ajax({
            method: "GET",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key" : PARSE_REST_APP_KEY
            },
            url: "https://api.parse.com/1/classes/Country?order=countryName",
            success: countriesLoaded,
            error: ajaxError
        });
    }

    loadCountries();
});