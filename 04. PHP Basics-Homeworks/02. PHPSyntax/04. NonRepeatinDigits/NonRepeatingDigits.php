<?php
$start = 1234;
$isOutput = false;
$result = "";

for($i = 0; $i <= $start; $i++){

    if($i <= $start && $i < 1000 && $i >= 100){
        $a = $i % 10;
        $b = ($i / 10) % 10;
        $c = ($i / 100) % 10;

        if($a != $b && $a != $c && $b != $c){
            $result = $result . (string)$i . ", " ;

        }

    }

}

if($result != ""){

    $result = substr($result, 0 , strlen($result) - 2);
    $spaceCount = 0;

    for($i = 0; $i < strlen($result); $i++){
        echo $result[$i];

        if($result[$i] = " "){
            $spaceCount++;
        }

        if($spaceCount % 75 == 0){
            echo "\n";
        }

    }
}
else {
    echo "no";
}

?>