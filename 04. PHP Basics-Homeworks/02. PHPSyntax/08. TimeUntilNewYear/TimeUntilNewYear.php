<?php
$today = getdate();

$year = intval($today['year']);

$day = intval($today['mday']);
$month = intval($today['mon']);
$hour = intval($today['hours']);
if($month > 10 || ($month == 10 && $day > 25) || ($month == 10 && $day == 25)){
    $hour++;
}

$minutes = intval($today['minutes']);
$seconds = intval($today['seconds']);

$seconds = 60 - $seconds;
$minutes++;
if($seconds == 60){
    $minutes++;
    $seconds = 0;
}

$minutes = 60 - $minutes;
$hour++;
if($minutes == 60){
    $hour++;
    $minutes = 0;
}

$hour = 24 - $hour;
if($hour == 24){
    $hour= 23;
}

$nextYear = (string)($year + 1) . "-1-1";
$newYear = new DateTime($nextYear);

$now = (string)$year . (string)$month . (string)$day;
$currentDate = new DateTime($now);

$daysLeft = ($newYear->diff($currentDate)->days) - 1;

echo "Hours until new year : " . (($daysLeft * 24) + $hour) . "\n";
echo "Minutes until new year : " . ((($daysLeft * 24) + $hour)*60 + $minutes) . "\n";
echo "Seconds until new year : " . (((($daysLeft * 24) + $hour)*60 + $minutes)*60 + $seconds) . "\n";
echo "Days:Hours:Minutes:Seconds {$daysLeft}:{$hour}:{$minutes}:{$seconds}";
?>