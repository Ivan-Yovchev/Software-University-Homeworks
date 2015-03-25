Object.prototype.inherits = function (parent) {
    this.prototype = Object.create(parent.prototype);
    this.prototype.constructor = this;
}

var Destination = (function () {
    function Destination(location, landmark) {
        this.setLocation(location);
        this.setLandmark(landmark);
    }
    
    Destination.prototype.getLocation = function () {
        return this._location;
    }
    
    Destination.prototype.setLocation = function (location) {
        if (location === undefined || location === "") {
            throw new Error("Location cannot be empty or undefined.");
        }
        this._location = location;
    }
    
    Destination.prototype.getLandmark = function () {
        return this._landmark;
    }
    
    Destination.prototype.setLandmark = function (landmark) {
        if (landmark === undefined || landmark == "") {
            throw new Error("Landmark cannot be empty or undefined.");
        }
        this._landmark = landmark;
    }
    
    Destination.prototype.toString = function () {
        return this.constructor.name + ": " +
                    "location=" + this.getLocation() +
                    ",landmark=" + this.getLandmark();
    }
    
    return Destination;
}());

var Travel = (function () {
    function Travel(name, startDate, endDate, price) {
        //if (this.constructor === Travel) {
        //    throw new Error("Cannot create instance of class Travel");
        //}
        this.setName(name);
        this.setStartDate(startDate);
        this.setEndDate(endDate);
        this.setPrice(price);
    }
    
    Travel.prototype.setName = function (name) {
        if (name === undefined || name === "") {
            throw new Error("Name cannot be undefined or empty");
        } else {
            this._name = name;
        }
    }
    
    Travel.prototype.getName = function () {
        return this._name;
    }
    
    Travel.prototype.setStartDate = function (startDate) {
        if (startDate === undefined || !(startDate instanceof Date)) {
            throw new Error("Start Date must be a valid Date object");
        } else {
            this._startDate = startDate;
        }
    }
    
    Travel.prototype.getStartDate = function () {
        return this._startDate;
    }
    
    Travel.prototype.setEndDate = function (endDate) {
        if (endDate === undefined || !(endDate instanceof Date)) {
            throw new Error("End Date must be a valid Date object");
        } else {
            this._endDate = endDate;
        }
    }
    
    Travel.prototype.getEndDate = function () {
        return this._endDate;
    }
    
    Travel.prototype.setPrice = function (price) {
        if (price === undefined || typeof price != "number" || price < 0) {
            throw new Error("Price cannot be negative or a non-number");
        } else {
            this._price = price;
        }
    }
    
    Travel.prototype.toString = function () {
        return "name=" + this._name + ",start-date=" + this._startDate + ",end-date=" + this._endDate + ",price=" + this._price;
    }
    
    return Travel;
})();

var Excursion = (function () {
    function Excursion(name, startDate, endDate, price, transport) {
        Travel.call(this, name, startDate, endDate, price);
        this._destinations = [];
        this.setTransport(transport);
    }
    
    Excursion.inherits(Travel);
    
    Excursion.prototype.setTransport = function (transport) {
        if (transport === undefined || transport === "") {
            throw new Error("Transport cannot be undefined or empty");
        } else {
            this._transport = transport;
        }
    }
    
    Excursion.prototype.getTransport = function () {
        return this._transport;
    }
    
    Excursion.prototype.getDestinations = function () {
        return this._destinations;
    }
    
    Excursion.prototype.addDestination = function (destination) {
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
        return "Excursion: " 
                    + Travel.prototype.toString.call(this, this._name, this._startDate, this._endDate, this._price) 
                    + ",transport=" + this._transport;
    }
    
    return Excursion;
})();

var Vacation = (function () {
    function Vacation(name, startDate, endDate, price, location, accommodation) {
        Travel.call(this, name, startDate, endDate, price);
        this.setLocation(location);
        this.setAccommodation(accommodation);
    }
    
    Vacation.inherits(Travel);
    
    Vacation.prototype.setLocation = function (location) {
        if (location === undefined || location === "") {
            throw new Error("Location cannot be undefined or empty");
        } else {
            this._location = location;
        }
    }
    
    Vacation.prototype.getLocation = function () {
        return this._location;
    }
    
    Vacation.prototype.setAccommodation = function (accommodation) {
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
    
    Vacation.prototype.getAccommodation = function () {
        return this._accommodation;
    }
    
    Vacation.prototype.toString = function () {
        var accommodation = this.getAccommodation() ? ",accommodation=" + this._accommodation : "";
        return "Vacation: " 
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
    
    Cruise.prototype.setStartDock = function (startDock) {
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
    
    Cruise.prototype.getStartDock = function () {
        return this._startDock;
    }
    
    Cruise.prototype.toString = function () {
        var startDock = this.getStartDock() ? ",start-dock=" + this._startDock : "";
        var data = Excursion.prototype.toString.call(this, this._name, this._startDate, this._endDate, this._price, this._transport) + startDock;
        return "Cruise: " + data.substring(11);
    }
    
    return Cruise;
})();

var startDate = new Date(2012, 0, 12);
var endDate = new Date(2012, 1, 12);
var pesho = new Cruise("hello", startDate, endDate, 2.5, null);
console.log(pesho.toString());

var destination = new Destination("sofia", "koti most");
console.log(destination.toString());