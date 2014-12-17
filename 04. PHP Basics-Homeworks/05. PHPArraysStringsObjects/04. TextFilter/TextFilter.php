<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Text Filter</title>
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
    <input type="text" name="banlist" placeholder="Banlist"><br>
    <input type="submit">
</form>

<br>

</body>
</html>

<?php

if(isset($_POST['text']) && isset($_POST['banlist'])){

    $text = $_POST['text'];
    $banlist = explode(", ", $_POST['banlist']);

    function replaceWord($match) {
        global $banlist;

        if(in_array($match[1], $banlist)){
            return str_repeat('*', strlen($match[1]));
        }
        else {
            return $match[1];
        }

    }

    echo preg_replace_callback('/(\w+)/', "replaceWord", $text);

}

?>