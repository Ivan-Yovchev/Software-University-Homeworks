<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Article Parser</title>
</head>
<body>

<form method="get">
    <textarea name="text"></textarea><br>
    <input type="submit">
</form>

</body>
</html>

<?php

if(isset($_GET['text'])){

    $input = preg_split("/\r\n/", $_GET['text'], -1, PREG_SPLIT_NO_EMPTY);

    date_default_timezone_set('Europe/Sofia');

    $allSeminars = [];
    foreach ($input as $text) {
        $getSeminar = preg_match_all('/([a-zA-z\s-]+)\s*%\s*([a-zA-z\s-.]+)\s*;\s*(\d{2}-\d{2}-\d{4})\s*-\s*([^\n]+)/', $text, $result);
        if($getSeminar == true){
            $articleName = trim($result[1][0]);
            $authorName = trim($result[2][0]);
            $date = date('F', strtotime($result[3][0]));
            $summary = trim($result[4][0]);
            if(strlen($summary) > 100){
                $summary = substr($summary, 0, 100);
                $summary .= "...";
            }
            else {
                $summary .= "...";
            }

            $output = "<div>\n" .
                "<b>Topic:</b> <span>" . htmlspecialchars($articleName) . "</span>\n" .
                "<b>Author:</b> <span>" . htmlspecialchars($authorName) . "</span>\n" .
                "<b>When:</b> <span>" . htmlspecialchars($date) . "</span>\n" .
                "<b>Summary:</b> <span>" . htmlspecialchars($summary) . "</span>\n" .
                "</div>\n";

            echo $output;
        }

    }


}

?>