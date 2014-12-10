<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Rich People's Problems</title>
</head>
<body>
    <form method="post">
        <label for="carsField">Enter cars</label>
        <input type="text" name="cars" id="carsField">
        <input type="submit" value="Show result">
    </form>
    <br>

    <?php
        if(isset($_POST['cars'])){ ?>
            <table border="1">
                <tr><th>Car</th><th>Color</th><th>Count</th></tr>
            <?php

            $cars = explode(", ", htmlentities($_POST['cars']));
            for($i = 0; $i < sizeof($cars); $i++){
                $color = rand(0, 10);
                $quantity = rand(1, 5);

                switch($color){
                    case 0: $carColor = "black"; break;
                    case 1: $carColor = "blue"; break;
                    case 2: $carColor = "brown"; break;
                    case 3: $carColor = "gray"; break;
                    case 4: $carColor = "green"; break;
                    case 5: $carColor = "orange"; break;
                    case 6: $carColor = "pink"; break;
                    case 7: $carColor = "purple"; break;
                    case 8: $carColor = "red"; break;
                    case 9: $carColor = "white"; break;
                    case 10: $carColor = "yellow"; break;
                } ?>

                <tr>
                    <td><?= $cars[$i] ?></td>
                    <td><?= $carColor ?></td>
                    <td><?= $quantity ?></td>
                </tr>

            <?php } ?>
            </table> <?php
        }
    ?>

</body>
</html>