app.controller('VideoController', function($scope, $sce) {
    var data = [];
    var categoryArray = [];
    var testVideoObject3 = {
        title: '1960 What?',
        pictureUrl: 'https://www.youtube.com/v/CmDcWr1yqCc',
        length: '04:32',
        category: 'Music',
        subscribers: 8,
        date: new Date(2014, 11, 23),
        haveSubtitles: false,
        comments: [{
            username: 'Pesho Peshev',
            content: 'Congratulations Nakov',
            date: new Date(2012, 12, 15, 12, 30, 0),
            likes: 5,
            websiteUrl: 'http://pesho.com/'
        }]
    }

    var testVideoObject = {
        title: 'HTML Tables',
        pictureUrl: 'https://www.youtube.com/v/UY9V9XXNuHE',
        length: '01:01:33',
        category: 'Programming',
        subscribers: 3,
        date: new Date(2014, 11, 21),
        haveSubtitles: false,
        comments: []
    }

    var testVideoObject4 = {
        title: 'Be good',
        pictureUrl: 'https://www.youtube.com/v/9HvpIgHBSdo',
        length: '6:58',
        category: 'Music',
        subscribers: 3,
        date: new Date(2014, 11, 11),
        haveSubtitles: true,
        comments: [{
            username: 'Pesho Peshev',
            content: 'Congratulations Nakov',
            date: new Date(2015, 12, 15, 12, 30, 0),
            likes: 3,
            websiteUrl: 'http://pesho.com/'
        }, {
            username: 'a',
            content: 'Congratulations Nakov',
            date: new Date(2014, 12, 15, 12, 30, 0),
            likes: 6,
            websiteUrl: 'http://pesho.com/'
        }]
    }

    var testVideoObject2 = {
        title: "I Don't Know",
        pictureUrl: 'https://www.youtube.com/v/dEUocBDUj60',
        length: '6:58',
        category: 'Music',
        subscribers: 3,
        date: new Date(2014, 11, 11),
        haveSubtitles: false,
        comments: [{
            username: 'Pesho Peshev',
            content: 'Congratulations Nakov',
            date: new Date(2015, 12, 15, 12, 30, 0),
            likes: 3,
            websiteUrl: 'http://pesho.com/'
        }]
    }

    data.push(testVideoObject);
    data.push(testVideoObject2);
    data.push(testVideoObject3);
    data.push(testVideoObject4);
    $scope.data = data;
    makeCategoryList();



    function makeCategoryList() {
        data.forEach(function (elem) {
            if (categoryArray.indexOf(elem.category) === -1) {
                categoryArray.push(elem.category);
            };
        });
    }


    var sortFunc = function (predicate) {
        return function (item) {
            if (predicate == 'date') {
                return item.date.getTime();
            }
            if (predicate == 'title') {
                return item.title;
            }
            if (predicate == 'subscribers') {
                return item.subscribers;
            }
            if (predicate == 'length') {
                var timeString = item.length;
                var timeParts = timeString.split(/[\\:\-\/\.;\[\]\{\}_+]/g);
                switch (timeParts.length) {
                    case 1:
                        return parseInt(timeParts[0])
                        break;
                    case 2:
                        return parseInt(timeParts[0]) * 60 + parseInt(timeParts[1]);
                        break;
                    case 3:
                        return parseInt(timeParts[0]) * 60 * 60 + parseInt(timeParts[1]) * 60 + parseInt(timeParts[2]);
                        break;
                    default:
                        return;
                        break;
                }
            }
        }
    }

    $scope.addVideo = function (newVideo) {
        if (newVideo.haveSubtitles === 'true') {
            newVideo.haveSubtitles = true;
        } else {
            newVideo.haveSubtitles = false;
        }

        newVideo.date = new Date();

        data.push(newVideo);
        makeCategoryList();
    }

    $scope.makeUrl = function (url) {
        return $sce.trustAsResourceUrl(url);
    }

    $scope.sortFunc = sortFunc;
    $scope.categories = categoryArray;
});