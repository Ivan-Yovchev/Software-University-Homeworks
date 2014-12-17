<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Word Mapping</title>
    <style>
        textarea {
            width: 300px;
            height: 70px;
        }
    </style>
</head>
<body>

<form method="post">
    <textarea name="text"></textarea><br>
    <input type="submit" value="Count words">
</form>

<br>

</body>
</html>

<?php

if(isset($_POST['text'])){

    $input = $_POST['text'];

    $array = preg_split("/[,.!\/ ]/", $input, -1, PREG_SPLIT_NO_EMPTY);

    $result = array();

    foreach($array as $word){

        $word = strtolower($word);

        if(isset($result[$word])){
            $result[$word]++;
        }
        else{
            $result[$word] = 1;
        }
    } ?>

    <table border="1">

    <?php foreach($result as $key => $value){ ?>

        <tr>
            <td><?= $key ?></td>
            <td><?= $value ?></td>
        </tr>

    <?php } ?>

    </table>

<?php }

?>