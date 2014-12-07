<!DOCTYPE html>
<html>
    <head>
        <title>Calculate Interest</title>
    </head>
    <body>
        <form>
            <label for="amountField">Enter Amount</label>
            <input type="text" name="amount" id="amountField">

            <br>

            <input type="radio" name="group" value="usd" id="usd-radio">
            <label for="usd-radio"> USD</label>
            <input type="radio" name="group" value="eur" id="eur-radio">
            <label for="eur-radio"> EUR</label>
            <input type="radio" name="group" value="bgn" id="bgn-radio">
            <label for="bgn-radio"> BGN</label>

            <br>

            <label for="interestField">Compound Interest Amount</label>
            <input type="text" name="interest" id="interestField">

            <br>

            <select name="months">
                <option value="6" selected>6 Months</option>
                <option value="12">1 Year</option>
                <option value="24">2 Years</option>
                <option value="60">5 Years</option>
            </select>

            <input type="submit" value="Calculate">

        </form>
    </body>
</html>

<?php
    if(isset ($_GET['amount'])){
        $amount = htmlentities($_GET['amount']);
        $amount = (float)$amount;
    }

    if(isset ($_GET['group'])){
        $currency = htmlentities($_GET['group']);
    }

    if(isset ($_GET['months'])){
        $months = htmlentities($_GET['months']);
        $months = (int)$months;
    }

    if(isset ($_GET['interest'])){
        $interest = htmlentities($_GET['interest']);
        $interest = (int)$interest;
        $interest = ($interest/12) + 100;

        for($i = 0; $i < $months; $i++){
            $amount = ($interest / 100) * $amount;
        }

        $amount = number_format((float)$amount, 2, '.', '');

        if($currency == 'usd'){
            echo "$ $amount";
        }
        else if($currency == "eur"){
            echo "&#8364; $amount";
        }
        else if($currency == "bgn"){
            echo "$amount leva";
        }

    }
?>