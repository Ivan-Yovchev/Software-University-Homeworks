function processTrainingCenterCommands(commands) {
    
    'use strict';
    
    var trainingcenter = (function () {
        
        Object.prototype.inherits = function (parent) {
            this.prototype = Object.create(parent.prototype);
            this.prototype.constructor = this;
        }
        
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

        var Trainer = (function() {
            function Trainer(username, firstName, lastName, email) {
                this.setUsername(username);
                this.setFirstName(firstName);
                this.setLastName(lastName);
                this.setEmail(email);
            }
            
            Trainer.prototype.setUsername = function(username) {
                if (username == null || username === "" || typeof(username) != 'string') {
                    throw new Error("Username cannot be null or empty");
                } else {
                    this._username = username;
                }
            }
            
            Trainer.prototype.getUsername = function () {
                return this._username;
            }
            
            Trainer.prototype.setFirstName = function(firstName) {
                if (firstName == null) {
                    delete this._firstName;
                } else {
                    if (typeof firstName != "string" || firstName === "") {
                        throw new Error("First Name cannot be empty");
                    } else {
                        this._firstName = firstName;
                    }
                }
            }
            
            Trainer.prototype.getFirstName = function() {
                return this._firstName;
            }
            
            Trainer.prototype.setLastName = function (lastName) {
                if (lastName == null || lastName === "" || typeof(lastName) != 'string') {
                    throw new Error("Last name cannot be null or empty");
                } else {
                    this._lastName = lastName;
                }
            }
            
            Trainer.prototype.getLastName = function () {
                return this._lastName;
            }
            
            Trainer.prototype.setEmail = function(email) {
                if (email == null) {
                    delete this._email;
                } else {
                    if (email.indexOf("@") < 0) {
                        throw new Error("Email must contain '@'");
                    } else {
                        this._email = email;
                    }
                }
            }
            
            Trainer.prototype.getEmail = function() {
                return this._email;
            }
            
            Trainer.prototype.toString = function() {
                var firstName = this.getFirstName() ? ";first-name=" + this._firstName : "";
                var email = this.getEmail() ? ";email=" + this._email : "";

                return "Trainer[username=" + this._username + firstName + ";last-name=" + this._lastName + email + "]";
            }

            return Trainer;
        })();
        
        var Training = (function () {

            var BOTTOM_RANGE_DATE = new Date(2000, 0, 1);
            var TOP_RANGE_DATE = new Date(2020, 11, 31);

            var MIN_DURATION = 1;
            var MAX_DURATION = 99;

            function Training(name, description, trainer, startDate, duration) {
                if (this.constructor === Training) {
                    throw new Error("Cannot create instance of class Training");
                }
                this.setName(name);
                this.setDescription(description);
                this.setTrainer(trainer);
                this.setStartDate(startDate);
                this.setDuration(duration);
            }
            
            Training.prototype.setName = function(name) {
                if (name == null || name === "" || typeof name != "string") {
                    throw new Error("Name cannot be null or empty");
                } else {
                    this._name = name;
                }
            }
            
            Training.prototype.getName = function() {
                return this._name;
            }
            
            Training.prototype.setDescription = function(description) {
                if (description == null) {
                    delete this._description;
                } else {
                    if (description === "" || typeof description != "string") {
                        throw new Error("Description cannot be empty");
                    } else {
                        this._description = description;
                    }
                }
            }
            
            Training.prototype.getDescription = function() {
                return this._description;
            }
            
            Training.prototype.setTrainer = function(trainer) {
                if (trainer == null) {
                    delete this._trainer;
                } else {
                    if (Object.keys(trainer).length <= 0) {
                        throw new Error("Trainer cannot be empty");
                    } else {
                        this._trainer = trainer;
                    }
                }
            }
            
            Training.prototype.getTrainer = function() {
                return this._trainer;
            }
            
            Training.prototype.setStartDate = function (startDate) {
                if (startDate == null || startDate == "undefined") {
                    throw new Error("Start Date cannot be empty");
                } else if (Date.parse(startDate) < BOTTOM_RANGE_DATE || Date.parse(startDate) > TOP_RANGE_DATE) {
                    throw new Error("Start date is not in the correct range");
                } else {
                    var month = startDate.toString().split(' ')[1];
                    this._startDate = startDate.getDate() + "-" + month + "-" + startDate.getFullYear();
                }
            }
            
            Training.prototype.getStartDate = function() {
                return Date.parse(this._startDate);
            }
            
            Training.prototype.setDuration = function(duration) {
                if (duration == null) {
                    delete this._duration;
                } else {
                    if (duration < MIN_DURATION || duration > MAX_DURATION || typeof duration !== "number" || duration != parseInt(duration)) {
                        throw new Error("Duration must be int the range [1...99]");
                    } else {
                        this._duration = parseInt(duration);
                    }
                }
            }
            
            Training.prototype.getDuration = function() {
                return this._duration;
            }
            
            Training.prototype.toString = function() {
                var description = this.getDescription() ? ";description=" + this._description : "";
                var trainer = '';
                if (this._trainer !== undefined) {
                    trainer = ";trainer=" + this._trainer.toString();
                }
                var duration = this.getDuration() ? ";duration=" + this._duration : "";

                return "name=" + this._name + description + trainer + ";start-date=" + this._startDate + duration;
            }

            return Training;
        })();

        var Course = (function () {
            function Course(name, description, trainer, startDate, duration) {
                Training.call(this, name, description, trainer, startDate, duration);
            }
            
            Course.inherits(Training);
            
            Course.prototype.toString = function () {
                var duration = this.getDuration() ? ";duration=" + this._duration : "";
                return "Course["+ Training.prototype.toString.call(this, this._name, this._description, this._trainer, this._startDate, this._duration) + "]";
            }
            
            return Course;
        })();
        
        var Seminar = (function () {

            var DEFAULT_DURATION = 1;

            function Seminar(name, description, trainer, startDate) {
                Training.call(this, name, description, trainer, startDate, DEFAULT_DURATION);
            }
            
            Seminar.inherits(Training);
            
            Seminar.prototype.toString = function () {
                var description = this.getDescription() ? ";description=" + this._description : "";
                var trainer = '';
                if (this._trainer !== undefined) {
                    trainer = ";trainer=" + this._trainer.toString();
                }
                
                return "Seminar[name=" + this._name + description + trainer + ";date=" + this._startDate + "]";
            }
            
            return Seminar;
        })();

        var RemoteCourse = (function () {
            function RemoteCourse(name, description, trainer, startDate, duration, location) {
                Training.call(this, name, description, trainer, startDate, duration);
                this.setLocation(location);
            }
            
            RemoteCourse.inherits(Course);
            
            RemoteCourse.prototype.setLocation = function (location) {
                if (location == null || location === "") {
                    throw new Error("Location cannot be empty");
                } else {
                    this._location = location;
                }
            }
            
            RemoteCourse.prototype.getLocation = function () {
                return this._location;
            }
            
            RemoteCourse.prototype.toString = function () {
                var duration = this.getDuration() ? ";duration=" + this._duration : "";
                return "RemoteCourse[" 
                        + Training.prototype.toString.call(this, this._name, this._description, this._trainer, this._startDate, this._duration)
                        + ";location=" 
                        + this._location 
                        + "]";
            }
            
            return RemoteCourse;
        })();
        
        var TrainingCenterEngine = (function () {
            var _trainers;
            var _uniqueTrainerUsernames;
            var _trainings;
            
            function initialize() {
                _trainers = [];
                _uniqueTrainerUsernames = {};
                _trainings = [];
            }
            
            function executeCommand(command) {
                var cmdParts = command.split(' ');
                var cmdName = cmdParts[0];
                var cmdArgs = cmdParts.splice(1);
                switch (cmdName) {
                    case 'create':
                        return executeCreateCommand(cmdArgs);
                    case 'list':
                        return executeListCommand();
                    case 'delete':
                        return executeDeleteCommand(cmdArgs);
                    default:
                        throw new Error('Unknown command: ' + cmdName);
                }
            }
            
            function executeCreateCommand(cmdArgs) {
                var objectType = cmdArgs[0];
                var createArgs = cmdArgs.splice(1).join(' ');
                var objectData = JSON.parse(createArgs);
                var trainer;
                switch (objectType) {
                    case 'Trainer':
                        trainer = new trainingcenter.Trainer(objectData.username, objectData.firstName, 
                            objectData.lastName, objectData.email);
                        addTrainer(trainer);
                        break;
                    case 'Course':
                        trainer = findTrainerByUsername(objectData.trainer);
                        var course = new trainingcenter.Course(objectData.name, objectData.description, trainer,
                            parseDate(objectData.startDate), objectData.duration);
                        addTraining(course);
                        break;
                    case 'Seminar':
                        trainer = findTrainerByUsername(objectData.trainer);
                        var seminar = new trainingcenter.Seminar(objectData.name, objectData.description, 
                            trainer, parseDate(objectData.date));
                        addTraining(seminar);
                        break;
                    case 'RemoteCourse':
                        trainer = findTrainerByUsername(objectData.trainer);
                        var remoteCourse = new trainingcenter.RemoteCourse(objectData.name, objectData.description,
                            trainer, parseDate(objectData.startDate), objectData.duration, objectData.location);
                        addTraining(remoteCourse);
                        break;
                    default:
                        throw new Error('Unknown object to create: ' + objectType);
                }
                return objectType + ' created.';
            }
            
            function findTrainerByUsername(username) {
                if (!username) {
                    return undefined;
                }
                for (var i = 0; i < _trainers.length; i++) {
                    if (_trainers[i].getUsername() == username) {
                        return _trainers[i];
                    }
                }
                throw new Error("Trainer not found: " + username);
            }
            
            function addTrainer(trainer) {
                if (_uniqueTrainerUsernames[trainer.getUsername()]) {
                    throw new Error('Duplicated trainer: ' + trainer.getUsername());
                }
                _uniqueTrainerUsernames[trainer.getUsername()] = true;
                _trainers.push(trainer);
            }
            
            function addTraining(training) {
                _trainings.push(training);
            }
            
            function executeListCommand() {
                var result = '';
                if (_trainers.length > 0) {
                    result += 'Trainers:\n' + ' * ' + _trainers.join('\n * ') + '\n';
                } else {
                    result += 'No trainers\n';
                }
                
                if (_trainings.length > 0) {
                    result += 'Trainings:\n' + ' * ' + _trainings.join('\n * ') + '\n';
                } else {
                    result += 'No trainings\n';
                }
                
                return result.trim();
            }
            
            function executeDeleteCommand(cmdArgs) {
                var objectType = cmdArgs[0];
                var deleteArgs = cmdArgs.splice(1).join(' ');
                switch (objectType) {
                    case 'Trainer':
                        removeTrainerFromCourses(deleteArgs);
                        removeTrainer(deleteArgs);
                        break;
                    default:
                        throw new Error('Unknown object to delete: ' + objectType);
                }
                return objectType + ' deleted.';
            }

            function removeTrainerFromCourses(username) {
                for (var i = 0; i < _trainings.length; i++) {
                    if (_trainings[i]._trainer !== undefined && _trainings[i]._trainer._username === username) {
                        delete _trainings[i]._trainer;
                    }
                }
            }

            function removeTrainer(username) {
                if (_trainers.length <= 0) {
                    throw new Error("no trainers");
                } else {
                    var index;
                    for (var i = 0; i < _trainers.length; i++) {
                        if (_trainers[i]._username === username) {
                            index = i;
                            break;
                        }
                    }

                    if (index !== undefined) {
                        _trainers.splice(index, 1);
                        delete _uniqueTrainerUsernames[username];
                    } else {
                        throw new Error("No such trainer");
                    }
                }
            }

            var trainingCenterEngine = {
                initialize: initialize,
                executeCommand: executeCommand
            };
            return trainingCenterEngine;
        }());

        var trainingcenter = {
            Trainer: Trainer,
            Course: Course,
            Seminar: Seminar,
            RemoteCourse: RemoteCourse,
            engine: {
                TrainingCenterEngine: TrainingCenterEngine
            }
        };
        
        return trainingcenter;
    })();
    
    // Process the input commands and return the results
    var results = '';
    trainingcenter.engine.TrainingCenterEngine.initialize();
    commands.forEach(function (cmd) {
        if (cmd != '') {
            try {
                var cmdResult = trainingcenter.engine.TrainingCenterEngine.executeCommand(cmd);
                results += cmdResult + '\n';
            } catch (err) {
                results += 'Invalid command.\n';
            }
        }
    });
    return results.trim();
}