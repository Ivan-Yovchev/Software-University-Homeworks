<?php
$days = date("t");
$month = date("m");
$year = date("Y");

//echo $today->format('jS F, Y');

for($i = 1; $i <= $days; $i++){

    $date = "" . (string)$year . "-" . (string)$month . "-" . (string)$i;

    $day = new DateTime($date);
    if($day->format('D') == "Sun"){
        echo $day->format('jS F Y');
        echo "\n";
    }
}

?>