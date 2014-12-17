<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Chat Logger</title>
</head>
<body>

<form method="get">
    <input type="text" name="currentDate"><br>
    <textarea name="messages"></textarea><br>
    <input type="submit">
</form>

</body>
</html>

<?php

if(isset($_GET['currentDate']) && isset($_GET['messages'])){

    date_default_timezone_set('Europe/Sofia');
    $messages = $_GET['messages'];
    $time = $_GET['currentDate'];

    $messages = preg_split("/\r\n/", $messages, -1, PREG_SPLIT_NO_EMPTY);

    $result = [];
    foreach ($messages as $message) {
        $message = preg_split("/\s+\/\s+/", $message, -1, PREG_SPLIT_NO_EMPTY);
        $date = strtotime($message[1]);
        $text = trim($message[0]);

        $result[$date] = $text;

    }

    ksort($result);

    foreach ($result as $key => $value) {
        echo "<div>" . htmlspecialchars($value) . "</div>\n";
        $latestMessage = $key;
    }

    $time = strtotime($time);

    $timeSince = $time - $latestMessage;

    $currentDay = intval(date('d', $time));
    $lastDay = intval(date('d', $latestMessage));

    if($currentDay == $lastDay){
        if($timeSince < 60){
            echo "<p>Last active: <time>a few moments ago</time></p>";
        }
        else if($timeSince >= 60 && $timeSince < 3600){
            $minutes = floor($timeSince/60);
            echo "<p>Last active: <time>" . htmlspecialchars($minutes) . " minute(s) ago</time></p>";
        }
        else if($timeSince >= 3600 && $timeSince < 24*3600){
            $hours = floor($timeSince/3600);
            echo "<p>Last active: <time>" . htmlspecialchars($hours) . " hour(s) ago</time></p>";
        }
    }
    else {
        if($currentDay == $lastDay + 1){
            echo "<p>Last active: <time>yesterday</time></p>";
        }
        else {
            echo "<p>Last active: <time>" . htmlspecialchars(date("d-m-Y", $latestMessage)) . "</time></p>";
        }
    }

}

?>