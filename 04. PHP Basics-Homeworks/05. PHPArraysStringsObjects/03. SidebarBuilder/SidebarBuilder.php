<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Sidebar Builder</title>
    <style>
        * {
            box-sizing: border-box;
        }
        body {
            font-family: arial, helvetica, sans-serif;
        }
        aside {
            width: 140px;
            float: left;
        }
        section {
            margin-bottom: 10px;
            border-radius: 15px;
            border: 1px solid black;
            background-color: lightblue;
            padding: 10px 10px 15px 10px;
        }
        h3 {
            margin: 0;
            border-bottom: 1px solid black;
        }
        ul {
            margin: 0;
            padding-left: 30px;
        }
        a {
            color: inherit;
        }
        label {
            display: inline-block;
            width: 85px;
            margin-bottom: 5px;
        }
    </style>
</head>
<body>

<form method="post">
    <label for="categoriesID">Categories: </label>
    <input id="categoriesID" name="categories" type="text" /><br>
    <label for="tagsID">Tags: </label>
    <input id="tagsID" name="tags" type="text" /><br>
    <label for="monthsID">Months: </label>
    <input id="monthsID" name="months" type="text" /><br>
    <input type="submit" value="Generate">
</form>

<br>

<?php

if(isset($_POST['categories']) && isset($_POST['tags']) && isset($_POST['months'])){
    $categories = explode(", ", $_POST['categories']);
    $tags = explode(", ", $_POST['tags']);
    $months = explode(", ", $_POST['months']); ?>

    <aside>
        <section>
            <h3>Categories</h3>
            <br>
            <ul>
                <?php
                for($i = 0; $i < sizeof($categories); $i++){ ?>

                    <li><a href=""><?= $categories[$i] ?></a></li>

                <?php }
                ?>
            </ul>
        </section>
        <section>
            <h3>Tags</h3>
            <br>
            <ul>
                <?php
                for($i = 0; $i < sizeof($tags); $i++){ ?>

                    <li><a href=""><?= $tags[$i] ?></a></li>

                <?php }
                ?>
            </ul>
        </section>
        <section>
            <h3>Months</h3>
            <br>
            <ul>
                <?php
                for($i = 0; $i < sizeof($months); $i++){ ?>

                    <li><a href=""><?= $months[$i] ?></a></li>

                <?php }
                ?>
            </ul>
        </section>
    </aside>

<?php }
?>
</body>
</html>


