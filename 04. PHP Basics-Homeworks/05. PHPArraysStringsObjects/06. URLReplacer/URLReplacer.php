<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>URL Replacer</title>
    <style>
        * {
            box-sizing: border-box;
        }
        body {
            font-family: Arial, Helvetica, sans-serif;
        }
        textarea{
            width: 300px;
            height: 80px;
        }
    </style>
</head>
<body>

<form method="post">
    <textarea name="text" placeholder="Enter text..."></textarea><br>
    <input type="submit">
</form>

<br>

</body>
</html>

<?php

if(isset($_POST['text'])){

    $text = $_POST['text'];
    $pattern = '/<a href\s*=\s*[\'|"]((http:\/\/|https:\/\/|www\.[a-z0-9-]+)+([a-z0-9-]+)\.+([a-z]{2,4})(\/|\.)*(([a-zA-Z0-9-_.\/?=&#%]*)))[\'|"]>/';

    $text = preg_replace('/<\/a>/', "[/URL]", $text);

    function changeLink($match){
        return "[URL=" . $match[1] . "]";
    }

    $text = preg_replace_callback($pattern, "changeLink", $text);

    echo htmlentities($text);

}

?>