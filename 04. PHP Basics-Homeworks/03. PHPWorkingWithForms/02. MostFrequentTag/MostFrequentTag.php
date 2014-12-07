<!DOCTYPE html>
<html>
<head>
    <title>Print Tags</title>
</head>
<body>

    Enter Tags:
    <br>

<form>
    <input type="text" name="field" />
    <input type="submit" />
</form>
<br>
</body>
</html>

<?php if (isset($_GET["field"])){

    $string = htmlentities($_GET['field']);
    $string = explode(", ", $string);

    $result = array();

    foreach($string as $tag){
        if (array_key_exists($tag, $result)) {
            $result[$tag]++;
        }
        else {
            $result[$tag] = 1;
        }
    }

    arsort($result);

    foreach ($result as $key => $item) {
        echo "$key: $item "; ?>
        <br>
    <?php } ?>

    <br>
    <?php
    $mostCommon = array_keys($result)[0];

    echo "Most Frequent Tag is: $mostCommon";

} ?>