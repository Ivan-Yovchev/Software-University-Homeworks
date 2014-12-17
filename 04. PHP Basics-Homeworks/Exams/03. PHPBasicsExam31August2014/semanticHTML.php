<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Semtantic HTML</title>
</head>
<body>

<form method="get">

<textarea name="html"></textarea><br>
<input type="submit">

</form>

</body>
</html>

<?php

if(isset($_GET['html'])){

    $html = $_GET['html'];

    $pattern1 = "/(<div ([a-zA-Z-]+\s*=\s*\"\w+[: \d\w]+\")*\s*([id|class]+\s*=\s*\"(\w+)\")\s*([a-zA-Z-]+\s*=\s*\"\w+[: \d\w]+\")*(\s*)>)/";

    function getTags($matches){

        $tag = $matches[4];

        $result = preg_replace("/([id|class]+\s*=\s*\"(\w+)\")/", '', $matches[1]);

        $result = $output = preg_replace('/\s+/', ' ',$result);

        $pos = strpos($result, '>');
        if($result[$pos - 1] == ' '){
            $result = substr($result, 0, $pos - 1) . ">";
        }

        $result = "<" . $tag . substr($result, 4, strlen($result));

        return $result;

    }

    $result = preg_replace_callback($pattern1, "getTags", $html);

    $pattern2 = "/<\/div>\s*<!--\s*(\w+)\s*-->/";

    function replaceEndTags($matches){

        return "</" . $matches[1]. ">";

    }

    $result = preg_replace_callback($pattern2, "replaceEndTags", $result);
    echo $result;
}

?>