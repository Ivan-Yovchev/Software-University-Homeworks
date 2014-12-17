<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Uppercase Words</title>
</head>
<body>

<form method="get">
    <input type="text" name="text">
    <input type="submit">
</form>

</body>
</html>

<?php

if(isset($_GET['text'])){

    $text = htmlspecialchars($_GET['text']);

    function getWords($match){
        $word = $match[1];

        if(strtoupper($word) == $word){
            if(strrev($word) == $word){

                $result = "";
                for($i = 0; $i < strlen($word); $i++){
                    $result .= str_repeat($word[$i], 2);
                }

                $word = $result;

            }
            else {
                $word = strrev($word);
            }
        }

        return $word;

    }

    $output = preg_replace_callback('/([a-zA-Z]+)/', "getWords", $text);

    echo "<p>" . $output . "</p>";
}

?>