var currentDate = new Date();
var hours = currentDate.getHours();
var minutes = currentDate.getMinutes();

if (minutes < 10) {
    minutes = "0" + minutes;
}

console.log(hours + ":" + minutes);