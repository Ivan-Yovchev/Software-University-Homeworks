<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Rainbow Letters</title>
</head>
<body>

<form method="get">

<input type="text" name="text"><br>
<input type="text" name="red"><br>
<input type="text" name="green"><br>
<input type="text" name="blue"><br>
<input type="text" name="nth"><br>
<input type="submit">

</form>

</body>
</html>

<?php

if(isset($_GET['text']) && isset($_GET['red']) &&
    isset($_GET['green']) && isset($_GET['blue']) &&
    isset($_GET['nth'])){

    $text = $_GET['text'];
    $red = intval($_GET['red']);
    $green = intval($_GET['green']);
    $blue = intval($_GET['blue']);
    $nth = intval($_GET['nth']);

    $red = dechex($red);
    $green = dechex($green);
    $blue = dechex($blue);

    if(strlen($red) == 1){
        $red = '0' . $red;
    }
    if(strlen($green) == 1){
        $green = '0' . $green;
    }
    if(strlen($blue) == 1){
        $blue = '0' . $blue;
    }

    $color = '#' . $red . $green . $blue;

    $index = 1;
    $result = "<p>";
    for($i = 0; $i < strlen($text); $i++){
        if($index % $nth == 0){
            $result .= "<span style=\"color: " . htmlspecialchars($color) . "\">";
            $result .= htmlspecialchars($text[$i]);
            $result .= "</span>";
        }
        else {
            $result .= htmlspecialchars($text[$i]);
        }

        $index++;

    }

    echo $result . "</p>";

}

?>