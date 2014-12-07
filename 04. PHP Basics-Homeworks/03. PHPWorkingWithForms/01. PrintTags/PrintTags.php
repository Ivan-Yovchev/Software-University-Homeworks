<!DOCTYPE html>
<html>
<head>
    <title>Print Tags</title>
</head>
<body>
    <form>
        Enter Tags: <br>
        <input type="text" name="field" />
        <input type="submit" />
    </form>
    <br>
</body>
</html>

<?php if (isset($_GET["field"])){

    $string = htmlentities($_GET['field']);
    $string = explode(", ", $string);

    for($i = 0; $i < sizeof($string); $i++){
        echo "$i: $string[$i]" ?>
        <br>
    <?php }

} ?>