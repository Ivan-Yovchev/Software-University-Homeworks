<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Largest Rectangle</title>
</head>
<body>

<form method="get">
    <input type="text" name="jsonTable">
    <input type="submit">
</form>

</body>
</html>

<?php

if(isset($_GET['jsonTable'])){

    $jsonTable = json_decode($_GET['jsonTable']);

    for($i = 0; $i < sizeof($jsonTable); $i++){

        $tempArray = $jsonTable[$i];
        for($j = 0; $j < sizeof($tempArray); $j++){

            if($j + 1 != sizeof($tempArray) && $i + 1 != sizeof($jsonTable)){
                $topSide = checkTopSide($i, $j, sizeof($tempArray) - $j);
                if($topSide == true){
                }
            }

        }

    }
}

function checkTopSide($row, $col, $width){

    global $jsonTable;

    $side = true;
    $char = $jsonTable[$row][$col];

    for($i = $col + 1; $i < $width; $i++){
        if($jsonTable[$row][$i] != $char){
            $side = false;
            break;
        }
    }

    return $side;

}

function checkBottomSide($row, $col, $width){

}

?>