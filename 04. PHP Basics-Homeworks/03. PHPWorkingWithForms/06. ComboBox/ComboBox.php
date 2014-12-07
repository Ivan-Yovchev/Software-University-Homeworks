<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>ComboBox</title>
    <style>
        select {
            width: 150px;
            height: 25px;
        }
    </style>
</head>
<body>

<?php
    session_start();
    $europe = array("Albania", "Armenia", "Austria", "Belarus", "Belgium", "Bulgaria",
    "Czech Republic", "France", "Germany", "Greece", "Hungary", "Italy", "Latvia",
    "Macedonia");
    $asia = array("Afghanistan", "Bahrain", "Bangladesh", "Cambodia", "China", "India", "Indonesia", "Iran",
    "Iraq", "Israel", "Japan", "North Korea", "South Korea",);
    $northAmerica = array("USA", "Mexico", "Canada", "Cuba", "Haiti", "Salvador", "Costa Rica");
    $southAmerica = array("Brazil", "Colombia", "Argentina", "Peru", "Venezuela", "Chile", "Ecuador");
    $australia = array("Australia");
    $africa = array("Nigeria", "Ethiopia", "Egypt", "South Africa", "Tanzania", "Kenya", "Algeria", "Sudan", "Ghana");
?>

<script>
    function submitForm(){
        document.getElementsByTagName('form')[0].submit();
    }

    function selectOptions(){
        document.getElementById("countrySelect").selectedIndex = "1";
    }

</script>

    <form method="post">
        <select name="continent" onchange="document.getElementsByTagName('form')[0].submit()">
            <option selected disabled hidden value=""></option>
            <option value="Europe" id="europe">Europe</option>
            <option value="Asia" id="asia">Asia</option>
            <option value="NorthAmerica" id="nAmerica">North America</option>
            <option value="SouthAmerica" id="sAmerica">South America</option>
            <option value="Australia" id="australia">Australia</option>
            <option value="Africa" id="africa">Africa</option>
        </select>

        <select onchange="submitForm()" id="countrySelect">
            <option selected disabled hidden value=""></option>
            <?php
                if(isset($_POST['continent']) && !empty($_POST)){
                    $_SESSION['continents'] = $_POST['continent'];
                    $countries = 0;
                    switch($_SESSION['continents']){
                        case "Europe": $countries = $europe; break;
                        case "Asia": $countries = $asia; break;
                        case "NorthAmerica": $countries = $northAmerica; break;
                        case "SouthAmerica": $countries = $southAmerica; break;
                        case "Australia": $countries = $australia; break;
                        case "Africa": $countries = $africa; break;
                    }

                    foreach ($countries as $country){
                        echo "<option>$country</option>";
                    }
                }
            ?>
        </select>
        <div id="parent"></div>
        <?php
            echo "<script>selectOptions();</script>";
        ?>
    </form>
</body>
</html>