<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Sentence Extractor</title>
    <style>
        * {
            box-sizing: border-box;
        }
        textarea{
            width: 300px;
            height: 80px;
        }
        input[type=text] {
            width: 300px;
            height: 30px;
            margin-bottom: 5px;
        }
    </style>
</head>
<body>

<form method="post">
    <textarea name="text" placeholder="Enter text..."></textarea><br>
    <input type="text" name="word" placeholder="Word"><br>
    <input type="submit">
</form>

<br>

</body>
</html>

<?php

if(isset($_POST['text']) && isset($_POST['word'])){

    $text = $_POST['text'];
    $word = $_POST['word'];
    $pattern = '/([a-zA-Z\s’,|\\/+–()])+[.!?]/';
    preg_match_all($pattern, $text, $sentences);

    foreach ($sentences[0] as $str) {
        $words = preg_split('/[ ,.!?()\']/', $str, -1, PREG_SPLIT_NO_EMPTY);

        $containsWord = false;
        foreach ($words as $tempWord) {
            if($word == $tempWord){
                $containsWord = true;
                break;
            }
        }

        if($containsWord == true){
            echo $str . "<br>";
        }

    }


}

?>