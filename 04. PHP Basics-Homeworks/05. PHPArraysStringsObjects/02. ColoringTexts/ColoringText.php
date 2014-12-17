<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Coloring Text</title>
    <style>
        body {
            font-family: arial, helvetica, sans-serif;
        }
        textarea {
            width: 300px;
            height: 70px;
        }
        .red {
            color: red;
        }
        .blue{
            color: blue;
        }
    </style>
</head>
<body>

<form method="post">
    <textarea name="text"></textarea><br>
    <input type="submit" value="Color text">
</form>

<br>

</body>
</html>

<?php

if(isset($_POST['text'])) {

    $input = $_POST['text'];

    $input = preg_replace('/\s+/', '', $input);

    for($i = 0; $i < strlen($input); $i++){
        if(ord($input[$i]) % 2 == 0){
            echo "<span class='red'>" . $input[$i] ."</span> ";
        }
        else {
            echo "<span class='blue'>" . $input[$i] ."</span> ";
        }
    }


}
?>