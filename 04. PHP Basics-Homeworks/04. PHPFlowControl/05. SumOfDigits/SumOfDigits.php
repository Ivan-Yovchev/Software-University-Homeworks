<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Sum of Digits</title>
</head>
<body>
    <form method="post">
        <label for="field">Input string: </label>
        <input type="text" name="input" id="field">
        <input type="submit">
    </form>
    <br>

    <?php
        if(isset($_POST['input'])){
            $values = explode(", ", $_POST['input']); ?>
            <table border="1"> <?php
            for($i = 0; $i < sizeof($values); $i++){
                if(is_numeric($values[$i])){
                    $temp = intval($values[$i]);
                    $sum = 0;
                    while($temp > 0){
                        $sum += $temp % 10;
                        $temp /= 10;
                    } ?>
                <tr>
                    <td><?= $values[$i] ?></td>
                    <td><?= $sum ?></td>
                </tr>
                <?php }
                else { ?>
                    <tr>
                        <td><?= $values[$i] ?></td>
                        <td>I cannot sum that</td>
                    </tr>
               <?php }

            } ?>

            </table> <?php
        }
    ?>
</body>
</html>