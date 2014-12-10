<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Square Root Sum</title>
</head>
<body>
    <table border="1">
        <tr><th>Number</th><th>Square</th></tr>
        <?php
            $sum = 0;
            for($i = 0; $i <= 100; $i+=2){
                $sum += sqrt($i);
                $squareRoot = round(sqrt($i), 2);
                ?>
                <tr><td><?= $i ?></td><td><?= $squareRoot ?></td></tr>
            <?php }
        ?>
        <tr><td><b>Total: </b></td><td><?= round($sum, 2) ?></td></tr>
    </table>
</body>
</html>