<?php
$name = "Gosho";
$phone = "0882-321-432";
$age = 24;
$address = "Hadji Dimitar";
?>

<!DOCTYPE html>
<html>
    <head>
        <style>
            table {
                font-family: Arial, sans-serif;
                font-size: 2em;
                border-collapse: collapse;
                margin: 0 auto;
            }

            table, tr, td {
                border: 1px solid black;
            }

            table tr td.head {
                text-align: left;
                font-weight: bold;
                padding: 10px 15px;
                width: 300px;
                background-color: #FF9C00;
            }

            table tr td.info {
                text-align: right;
                padding: 10px 15px;
                width: 250px;
                background-color: white;
            }

        </style>
    </head>
<body>

<table border="1">
    <tr>
        <td class="head">
            Name
        </td>
        <td class="info">
            <?php echo $name ?>
        </td>
    </tr>
    <tr>
        <td class="head">
            Phone Number
        </td>
        <td class="info">
            <?php echo $phone ?>
        </td>
    </tr>
    <tr>
        <td class="head">
            Age
        </td>
        <td class="info">
            <?php echo $age ?>
        </td>
    </tr>
    <tr>
        <td class="head">
            Address
        </td>
        <td class="info">
            <?php echo $address ?>
        </td>
    </tr>
</table>
</body>
</html>