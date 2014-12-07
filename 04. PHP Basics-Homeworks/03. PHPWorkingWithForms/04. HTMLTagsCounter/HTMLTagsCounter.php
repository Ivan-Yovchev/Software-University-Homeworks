<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>HTML Tags Counter</title>
    <style>
        h2 {
            margin: 0;
        }
    </style>
</head>
<body>
    <form>
        <label for="field">Enter HTML Tags:</label>
        <br>
        <br>
        <input type="text" id="field" name="text">
        <input type="submit">
    </form>
    <br>
</body>
</html>

<?php

session_start();

$htmlTags = array("DOCTYPE", "a", "abbr", "address", "area", "article",
"aside", "audio", "b", "base", "bdi", "bdo", "blockquote", "body", "br",
"br", "button", "canvas", "caption", "cite", "code", "col", "colgroup",
"datalist", "dd", "del", "details", "dfn", "dialog", "div", "dl", "dt","dt","em",
"embed", "fieldset", "figcaption", "figure", "footer", "form",
"h1", "h2", "h3", "h4", "h5", "h6", "head", "header", "hgroup", "hr",
"html", "i", "iframe", "img", "img", "input", "ins", "kbd", "keygen",
"label", "legend", "li", "link", "main", "map", "mark", "menu", "menuitem",
"meta", "meter", "nav", "noscript", "object", "ol", "optgroup", "option",
"output", "p", "param", "pre", "progress", "q", "rp", "rt", "ruby", "s",
"samp", "script", "section", "select", "small", "source", "span", "strong",
"style", "sub", "summary", "sup", "table", "tbody", "td", "textarea", "tfoot",
"th", "thead", "time", "title", "tr", "track", "u", "ul", "var", "video", "wbr");

if(!isset($_SESSION['count'])){
    $_SESSION['count'] = 0;
}

if(isset($_GET['text'])){

    $string = htmlentities($_GET['text']);

    if(in_array($string, $htmlTags)){
        $_SESSION['count']++; ?>
        <h2>Valid HTML Tag!</h2>
        <h2>Score: <?php echo $_SESSION['count']; ?></h2>
    <?php
    }
    else { ?>
        <h2>Invalid HTML Tag!</h2>
        <h2>Score: <?php echo $_SESSION['count']; ?></h2>
    <?php
    }


}

?>