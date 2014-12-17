<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Text Abbreviator</title>
</head>
<body>

<form method="get">
    <textarea name="list"></textarea><br>
    <input type="text" name="maxSize"><br>
    <input type="submit">
</form>

</body>
</html>

<?php

if(isset($_GET['list']) && isset($_GET['maxSize'])){

    $list = preg_split("/\r?\n/", $_GET['list'], -1, PREG_SPLIT_NO_EMPTY);
    $maxSize = intval($_GET['maxSize']);

    $result = "<ul>";
    foreach ($list as $sentence) {

        $sentence = trim($sentence);

        if(strlen($sentence) > $maxSize){
            $sentence = substr($sentence, 0, $maxSize);
            $sentence .= "...";
        }

        $result .= "<li>" . htmlspecialchars($sentence) . "</li>";

    }

    $result .= "</ul>";

    echo $result;

}

?>
