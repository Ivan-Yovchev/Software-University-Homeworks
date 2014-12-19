<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Facebook Posts</title>
</head>
<body>

<form method="get">
    <textarea name="text"></textarea>
    <input type="submit">
</form>

</body>
</html>

<?php

if(isset($_GET['text'])){

    date_default_timezone_set('Europe/Sofia');

    $text = preg_split("/\r?\n/", $_GET['text'], -1, PREG_SPLIT_NO_EMPTY);

    $allPosts = [];
    foreach ($text as $currentPost) {

        $currentPost = explode(';', $currentPost);

        $key = strtotime(trim($currentPost[1]));

        $name = trim($currentPost[0]);
        $date = date("j F Y", $key);
        $message = trim($currentPost[2]);
        $likes = trim($currentPost[3]);

        if(sizeof($currentPost) > 4 && $currentPost[4] != ""){
            $comments = explode("/", $currentPost[4]);
            $allPosts[$key] = [$name, $date, $message, $likes, $comments];
        }
        else {
            $allPosts[$key] = [$name, $date, $message, $likes];
        }

    }

    krsort($allPosts);

    foreach ($allPosts as $temp) {
        echo "<article><header><span>". htmlspecialchars($temp[0]) ."</span><time>". htmlspecialchars($temp[1]) ."</time></header>";
        echo "<main><p>". htmlspecialchars($temp[2]) ."</p></main>";
        echo "<footer><div class=\"likes\">". htmlspecialchars($temp[3]) ." people like this</div>";

        if(sizeof($temp) > 4){

            echo "<div class=\"comments\">";

            for($i = 0; $i < sizeof($temp[4]); $i++){

                echo "<p>". htmlspecialchars(trim($temp[4][$i])) ."</p>";

            }

            echo "</div>";

        }

        echo "</footer></article>";

    }


}

?>

