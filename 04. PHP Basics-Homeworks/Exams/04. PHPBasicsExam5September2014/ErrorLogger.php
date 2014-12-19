<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Error Logger</title>
</head>
<body>

<form method="get">
    <textarea name="errorLog"></textarea>
    <input type="submit">
</form>

</body>
</html>

<?php

if(isset($_GET['errorLog'])){

    $text = $_GET['errorLog'];

    $patternForException = "/Exception in thread \"\w+\" java\.(\w+\.)*(\w+): [a-zA-Z\d]+[\r?\n]+\s*at [a-zA-Z_-]+.([a-zA-Z_-]+)\(([a-zA-Z_.-]+):(\d+)\)/";

    $result = preg_match_all($patternForException, $text, $exception);

    $result = "<ul>";
    for($i = 0; $i < count($exception[0]); $i++){
        $result .= "<li>line <strong>" . htmlspecialchars($exception[5][$i]) . "</strong> - ";
        $result .= "<strong>" . htmlspecialchars($exception[2][$i]) . "</strong> in ";
        $result .= "<em>" . htmlspecialchars($exception[4][$i]) . ":" . htmlspecialchars($exception[3][$i]) . "</em>";
        $result .= "</li>";
    }

    echo $result . "</ul>";

}

?>