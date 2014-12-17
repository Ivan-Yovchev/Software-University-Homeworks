<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Drop It</title>
</head>
<body>

<form method="get">
    <textarea name="text"></textarea><br>
    <input type="text" name="minFontSize"><br>
    <input type="text" name="maxFontSize"><br>
    <input type="text" name="step"><br>
    <input type="submit">
</form>

</body>
</html>

<?php

if(isset($_GET['text']) && isset($_GET['minFontSize']) &&
isset($_GET['maxFontSize']) && isset($_GET['step'])){

    $text = $_GET['text'];
    $min = intval($_GET['minFontSize']);
    $max = intval($_GET['maxFontSize']);
    $step = intval($_GET['step']);

    $fontSize = $min;
    $goUp = true;
    $goDown = false;
    $result = "";
    for($i = 0; $i < strlen($text); $i++){

        if(ord($text[$i]) % 2 == 0){

            $result .= "<span style='font-size:$fontSize" . ";text-decoration:line-through;'>" . htmlspecialchars($text[$i]) . "</span>";

        }
        else {

            $result .= "<span style='font-size:$fontSize" . ";'>" . htmlspecialchars($text[$i]) ."</span>";

        }

        if((ord($text[$i]) >= ord('a') && ord($text[$i]) <= ord('z')) ||
            (ord($text[$i]) >= ord('A') && ord($text[$i]) <= ord('Z'))){

            if($goUp == true){
                $fontSize += $step;
                if($fontSize >= $max){
                    $goUp = false;
                    $goDown = true;
                }
            }
            else if($goDown == true){
                $fontSize -= $step;
                if($fontSize == $min){
                    $goDown = false;
                    $goUp = true;
                }
            }

        }
    }

    echo $result;

}

?>