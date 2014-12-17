<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Email Encyption</title>
</head>
<body>

<form method="get">
    <input type="text" name="recipient"><br>
    <input type="text" name="subject"><br>
    <input type="text" name="body"><br>
    <input type="text" name="key"><br>

    <input type="submit">

</form>

</body>
</html>

<?php

if(isset($_GET['recipient']) && isset($_GET['subject']) &&
isset($_GET['body']) && isset($_GET['key'])){

    $recipient = $_GET['recipient'];
    $subject = $_GET['subject'];
    $body = $_GET['body'];
    $key = $_GET['key'];

    $formattedMessage = "<p class='recipient'>" . htmlspecialchars($recipient) . "</p>" .
        "<p class='subject'>" . htmlspecialchars($subject) . "</p>" .
        "<p class='message'>" . htmlspecialchars($body) . "</p>";

    $index = 0;
    $output = "|";
    for($i = 0; $i < strlen($formattedMessage); $i++){
        $number = ord($formattedMessage[$i]) * ord($key[$index]);
        $hex = dechex($number);

        $output .= $hex . "|";

        $index++;
        if($index == strlen($key)){
            $index = 0;
        }
    }

    echo $output;


}

?>