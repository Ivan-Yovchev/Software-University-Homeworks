<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Annual Expenses</title>
</head>
<body>
    <form method="post">
        <label for="textField">Enter number of years: </label>
        <input type="text" name="years" id="textField">
        <input type="submit" value="Show costs">
    </form>
    <br>

    <?php
        if(isset($_POST['years'])){
            $currentYear = date('Y');
            $years = intval(htmlentities($_POST['years'])); ?>

            <table border="1">
                <tr>
                    <th>Year</th>
                    <th>January</th>
                    <th>February</th>
                    <th>March</th>
                    <th>April</th>
                    <th>May</th>
                    <th>June</th>
                    <th>July</th>
                    <th>August</th>
                    <th>September</th>
                    <th>October</th>
                    <th>November</th>
                    <th>December</th>
                    <th>Total:</th>
                </tr>

                <?php
                    for($i = $currentYear; $i > $currentYear - $years; $i--){ ?>
                        <tr>
                            <td><?= $i ?></td>
                            <?php
                                $sum = 0;
                                for($j = 0; $j < 12; $j++){
                                    $month = rand(300, 1000);
                                    $sum += $month; ?>

                                    <td><?= $month ?></td>

                                <?php } ?>
                                <td><?= $sum ?></td> <?php
                            ?>
                        </tr>
                    <?php }
                ?>

            </table>
        <?php }
    ?>
</body>
</html>