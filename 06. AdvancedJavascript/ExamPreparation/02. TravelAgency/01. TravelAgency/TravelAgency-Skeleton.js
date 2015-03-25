function processTravelAgencyCommands(commands) {
    'use strict';

    var Models = (function () {
        
        Object.prototype.inherits = function(parent) {
            this.prototype = Object.create(parent.prototype);
            this.prototype.constructor = this;
        }

        var Destination = (function() {
            function Destination(location, landmark) {
                this.setLocation(location);
                this.setLandmark(landmark);
            }

            Destination.prototype.getLocation = function() {
                return this._location;
            }

            Destination.prototype.setLocation = function(location) {
                if (location === undefined || location === "") {
                    throw new Error("Location cannot be empty or undefined.");
                }
                this._location = location;
            }

            Destination.prototype.getLandmark = function() {
                return this._landmark;
            }

            Destination.prototype.setLandmark = function(landmark) {
                if (landmark === undefined || landmark == "") {
                    throw new Error("Landmark cannot be empty or undefined.");
                }
                this._landmark = landmark;
            }

            Destination.prototype.toString = function() {
                return this.constructor.name + ": " +
                    "location=" + this.getLocation() +
                    ",landmark=" + this.getLandmark();
            }

            return Destination;
        }());

        var Travel = (function() {
            function Travel(name, startDate, endDate, price) {
                if (this.constructor === Travel) {
                    throw new Error("Cannot create instance of class Travel");
                }
                this.setName(name);
                this.setStartDate(startDate);
                this.setEndDate(endDate);
                this.setPrice(price);
            }
            
            Travel.prototype.setName = function(name) {
                if (name === undefined || name === "") {
                    throw new Error("Name cannot be undefined or empty");
                } else {
                    this._name = name;
                }
            }
            
            Travel.prototype.getName = function() {
                return this._name;
            }
            
            Travel.prototype.setStartDate = function(startDate) {
                if (startDate === undefined || !(startDate instanceof Date)) {
                    throw new Error("Start Date must be a valid Date object");
                } else {
                    this._startDate = startDate;
                }
            }
            
            Travel.prototype.getStartDate = function() {
                return this._startDate;
            }
            
            Travel.prototype.setEndDate = function(endDate) {
                if (endDate === undefined || !(endDate instanceof Date)) {
                    throw new Error("End Date must be a valid Date object");
                } else {
                    this._endDate = endDate;
                }
            }
            
            Travel.prototype.getEndDate = function() {
                return this._endDate;
            }
            
            Travel.prototype.setPrice = function(price) {
                if (price === undefined || isNaN(price) || price < 0) {
                    throw new Error("Price cannot be negative or a non-number");
                } else {
                    this._price = price.toFixed(2);
                }
            }
            
            Travel.prototype.getPrice = function() {
                return this._price;
            }

            Travel.prototype.toString = function() {
                return "name=" + this._name + ",start-date=" + formatDate(this._startDate) + ",end-date=" + formatDate(this._endDate) + ",price=" + this._price;
            }

            return Travel;
        })();

        var Excursion = (function() {
            function Excursion(name, startDate, endDate, price, transport) {
                Travel.call(this, name, startDate, endDate, price);
                this._destinations = [];
                this.setTransport(transport);
            }

            Excursion.inherits(Travel);

            Excursion.prototype.setTransport = function(transport) {
                if (transport === undefined || transport === "") {
                    throw new Error("Transport cannot be undefined or empty");
                } else {
                    this._transport = transport;
                }
            }
            
            Excursion.prototype.getTransport = function() {
                return this._transport;
            }
            
            Excursion.prototype.getDestinations = function() {
                return this._destinations;
            }

            Excursion.prototype.addDestination = function(destination) {
                if (this._destinations.indexOf(destination) >= 0) {
                    throw new Error("Already have this destination");
                } else {
                    this._destinations.push(destination);
                }
            }
            
            Excursion.prototype.removeDestination = function (destination) {
                var index = this._destinations.indexOf(destination);
                if (index < 0) {
                    throw new Error("No such destination");
                } else {
                    this._destinations.splice(index, 1);
                }
            }
            
            Excursion.prototype.toString = function () {
                var destinations = "\n ** Destinations: ";
                if (this._destinations.length <= 0) {
                    destinations += "-";
                } else {
                    destinations += this._destinations.join(";");
                }

                return " * Excursion: "
                    + Travel.prototype.toString.call(this, this._name, this._startDate, this._endDate, this._price)
                    + ",transport=" + this._transport
                    + destinations;
            }

            return Excursion;
        })();

        var Vacation = (function() {
            function Vacation(name, startDate, endDate, price, location, accommodation) {
                Travel.call(this, name, startDate, endDate, price);
                this.setLocation(location);
                this.setAccommodation(accommodation);
            }

            Vacation.inherits(Travel);
            
            Vacation.prototype.setLocation = function(location) {
                if (location === undefined || location === "") {
                    throw new Error("Location cannot be undefined or empty");
                } else {
                    this._location = location;
                }
            }
            
            Vacation.prototype.getLocation = function() {
                return this._location;
            }
            
            Vacation.prototype.setAccommodation = function(accommodation) {
                if (accommodation == null) {
                    delete this._accommodation;
                } else {
                    if (accommodation === undefined || accommodation === "") {
                        throw new Error("Accommodation cannot be undefined or empty");
                    } else {
                        this._accommodation = accommodation;
                    }
                }
            }
            
            Vacation.prototype.getAccommodation = function() {
                return this._accommodation;
            }
            
            Vacation.prototype.toString = function () {
                var accommodation = this.getAccommodation() ? ",accommodation=" + this._accommodation : "";
                return " * Vacation: "
                    + Travel.prototype.toString.call(this, this._name, this._startDate, this._endDate, this._price)
                    + ",location=" + this._location
                    + accommodation;
            }

            return Vacation;
        })();

        var Cruise = (function () {

            var CRUISE_DEFAULT_TRAVEL = "cruise liner";

            function Cruise(name, startDate, endDate, price, startDock) {
                Excursion.call(this, name, startDate, endDate, price, CRUISE_DEFAULT_TRAVEL);
                this.setStartDock(startDock);
            }

            Cruise.inherits(Excursion);

            Cruise.prototype.setStartDock = function(startDock) {
                if (startDock == null) {
                    delete this._startDock;
                } else {
                    if (startDock === undefined || startDock === "") {
                        throw new Error("Start Dock cannot be empty");
                    } else {
                        this._startDock = startDock;
                    }
                }
            }
            
            Cruise.prototype.getStartDock = function() {
                return this._startDock;
            }
            
            Cruise.prototype.toString = function () {
                var destinations = "\n ** Destinations: ";
                if (this._destinations.length <= 0) {
                    destinations += "-";
                } else {
                    destinations += this._destinations.join(";");
                }
                
                return " * Cruise: name=" + this._name 
                        + ",start-date=" + formatDate(this._startDate) 
                        + ",end-date=" + formatDate(this._endDate) 
                        + ",price=" + this._price
                        + ",transport=" + this._transport
                        + destinations;
            }

            return Cruise;
        })();

        return {
            Destination: Destination,
            Excursion: Excursion,
            Vacation: Vacation,
            Cruise: Cruise
        }
    }());

    var TravellingManager = (function(){
        var _travels;
        var _destinations;

        function init() {
            _travels = [];
            _destinations = [];
        }

        var CommandProcessor = (function() {

            function processInsertCommand(command) {
                var object;

                switch (command["type"]) {
                    case "excursion":
                        object = new Models.Excursion(command["name"], parseDate(command["start-date"]), parseDate(command["end-date"]),
                            parseFloat(command["price"]), command["transport"]);
                        _travels.push(object);
                        break;
                    case "vacation":
                        object = new Models.Vacation(command["name"], parseDate(command["start-date"]), parseDate(command["end-date"]),
                            parseFloat(command["price"]), command["location"], command["accommodation"]);
                        _travels.push(object);
                        break;
                    case "cruise":
                        object = new Models.Cruise(command["name"], parseDate(command["start-date"]), parseDate(command["end-date"]),
                            parseFloat(command["price"]), command["start-dock"]);
                        _travels.push(object);
                        break;
                    case "destination":
                        object = new Models.Destination(command["location"], command["landmark"]);
                        _destinations.push(object);
                        break;
                    default:
                        throw new Error("Invalid type.");
                }

                return object.constructor.name + " created.";
            }

            function processDeleteCommand(command) {
                var object,
                    index,
                    destinations;

                switch (command["type"]) {
                    case "destination":
                        object = getDestinationByLocationAndLandmark(command["location"], command["landmark"]);
                        _travels.forEach(function(t) {
                            if (t instanceof Models.Excursion && t.getDestinations().indexOf(object) !== -1) {
                                t.removeDestination(object);
                            }
                        });
                        index = _destinations.indexOf(object);
                        _destinations.splice(index, 1);
                        break;
                    case "excursion":
                    case "vacation":
                    case "cruise":
                        object = getTravelByName(command["name"]);
                        index = _travels.indexOf(object);
                        _travels.splice(index, 1);
                        break;
                    default:
                        throw new Error("Unknown type.");
                }

                return object.constructor.name + " deleted.";
            }

            function processListCommand(command) {
                return formatTravelsQuery(_travels);
            }

            function processAddDestinationCommand(command) {
                var destination = getDestinationByLocationAndLandmark(command["location"], command["landmark"]),
                    travel = getTravelByName(command["name"]);

                if (!(travel instanceof Models.Excursion)) {
                    throw new Error("Travel does not have destinations.");
                }
                travel.addDestination(destination);

                return "Added destination to " + travel.getName() + ".";
            }

            function processRemoveDestinationCommand(command) {
                var destination = getDestinationByLocationAndLandmark(command["location"], command["landmark"]),
                    travel = getTravelByName(command["name"]);

                if (!(travel instanceof Models.Excursion)) {
                    throw new Error("Travel does not have destinations.");
                }
                travel.removeDestination(destination);

                return "Removed destination from " + travel.getName() + ".";
            }

            function getTravelByName(name) {
                var i;

                for (i = 0; i < _travels.length; i++) {
                    if (_travels[i].getName() === name) {
                        return _travels[i];
                    }
                }
                throw new Error("No travel with such name exists.");
            }

            function getDestinationByLocationAndLandmark(location, landmark) {
                var i;

                for (i = 0; i < _destinations.length; i++) {
                    if (_destinations[i].getLocation() === location
                        && _destinations[i].getLandmark() === landmark) {
                        return _destinations[i];
                    }
                }
                throw new Error("No destination with such location and landmark exists.");
            }

            function formatTravelsQuery(travelsQuery) {
                var queryString = "";

                if (travelsQuery.length > 0) {
                    queryString += travelsQuery.join("\n");
                } else {
                    queryString = "No results.";
                }

                return queryString;
            }
            
            function processFilterInPriceRange(command) {
                var type = command["type"],
                    priceMin = parseFloat(command["price-min"]),
                    priceMax = parseFloat(command["price-max"]),
                    filteredByType,
                    filteredByPrice,
                    sortedByDateAsc;
                
                filteredByType = _travels
                    .filter(function (e) {
                    switch (type) {
                        case "excursion":
                            return e.constructor.name === "Excursion";
                        case "vacation":
                            return e.constructor.name === "Vacation";
                        case "cruise":
                            return e.constructor.name === "Cruise";
                        case "all":
                            return true;
                        default:
                            return false;
                    }
                });
                
                filteredByPrice = filteredByType
                    .filter(function (e) {
                    return priceMin <= e.getPrice() && e.getPrice() <= priceMax;
                });
                
                sortedByDateAsc = filteredByPrice
                    .sort(function (e1, e2) {
                    var dateOne = e1.getStartDate().valueOf(),
                        dateTwo = e2.getStartDate().valueOf();
                    
                    if (dateOne === dateTwo) {
                        return e1.getName().localeCompare(e2.getName());
                    }
                    return dateOne - dateTwo;
                });
                
                return formatTravelsQuery(sortedByDateAsc);
            }

            return {
                processInsertCommand: processInsertCommand,
                processDeleteCommand: processDeleteCommand,
                processListCommand: processListCommand,
                processFilterTravelsCommand: processFilterInPriceRange,
                processAddDestinationCommand: processAddDestinationCommand,
                processRemoveDestinationCommand: processRemoveDestinationCommand
            }
        }());

        var Command = (function() {
            function Command(cmdLine) {
                this._cmdArgs = processCommand(cmdLine);
            }

            function processCommand(cmdLine) {
                var parameters = [],
                    matches = [],
                    pattern = /(.+?)=(.+?)[;)]/g,
                    key,
                    value,
                    split;

                split = cmdLine.split("(");
                parameters["command"] = split[0];
                while ((matches = pattern.exec(split[1])) !== null) {
                    key = matches[1];
                    value = matches[2];
                    parameters[key] = value;
                }

                return parameters;
            }

            return Command;
        }());

        function executeCommands(cmds) {
            var commandArgs = new Command(cmds)._cmdArgs,
                action = commandArgs["command"],
                output;

            switch (action) {
                case "insert":
                    output = CommandProcessor.processInsertCommand(commandArgs);
                    break;
                case "delete":
                    output = CommandProcessor.processDeleteCommand(commandArgs);
                    break;
                case "add-destination":
                    output = CommandProcessor.processAddDestinationCommand(commandArgs);
                    break;
                case "remove-destination":
                    output = CommandProcessor.processRemoveDestinationCommand(commandArgs);
                    break;
                case "list":
                    output = CommandProcessor.processListCommand(commandArgs);
                    break;
                case "filter":
                    output = CommandProcessor.processFilterTravelsCommand(commandArgs);
                    break;
                default:
                    throw new Error("Unsupported command.");
            }

            return output;
        }

        return {
            init: init,
            executeCommands: executeCommands
        }
    }());

    var parseDate = function (dateStr) {
        if (!dateStr) {
            return undefined;
        }
        var date = new Date(Date.parse(dateStr.replace(/-/g, ' ')));
        var dateFormatted = formatDate(date);
        if (dateStr != dateFormatted) {
            throw new Error("Invalid date: " + dateStr);
        }
        return date;
    }

    var formatDate = function (date) {
        var day = date.getDate();
        var monthName = date.toString().split(' ')[1];
        var year = date.getFullYear();
        return day + '-' + monthName + '-' + year;
    }

    var output = "";
    TravellingManager.init();

    commands.forEach(function(cmd) {
        var result;
        if (cmd != "") {
            try {
                result = TravellingManager.executeCommands(cmd) + "\n";
            } catch (e) {
                result = "Invalid command." + "\n";
            }
            output += result;
        }
    });

    return output;
}

// ------------------------------------------------------------
// Read the input from the console as array and process it
// Remove all below code before submitting to the judge system!
// ------------------------------------------------------------

//(function() {
//    var arr = [];
//    if (typeof (require) == 'function') {
//        // We are in node.js --> read the console input and process it
//        require('readline').createInterface({
//            input: process.stdin,
//            output: process.stdout
//        }).on('line', function(line) {
//            arr.push(line);
//        }).on('close', function() {
//            console.log(processTravelAgencyCommands(arr));
//        });
//    }
//})();