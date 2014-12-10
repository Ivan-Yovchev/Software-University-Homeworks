<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Primes in Range</title>
</head>
<body>
    <form method="post">
        <label for="startIndex">Starting Index: </label>
        <input type="text" name="start" id="startIndex">
        <label for="endIndex">End: </label>
        <input type="text" name="end" id="endIndex">
        <input type="submit">
    </form>
    <?php
        if(isset($_POST['start']) && isset($_POST['end'])){
            $start = $_POST['start'];
            $end = $_POST['end'];
            for($i = $start; $i <= $end; $i++){
                if(isPrime($i) == true){ ?>
                    <b><?= $i ?></b>
                <?php }
                else { ?>
                    <?= $i ?>
                <?php }

                if($i != $end){
                    echo ", ";
                }

            }
        }
    ?>
</body>
</html>

<?php
    function isPrime($number){
        $isPrime = true;

        if($number == 0 || $number == 1){
            $isPrime = false;
        }
        else {
            for($i = 2; $i <= sqrt($number); $i++){
                if($number % $i == 0){
                    $isPrime = false;
                    break;
                }
            }
        }

        return $isPrime;
    }
?>