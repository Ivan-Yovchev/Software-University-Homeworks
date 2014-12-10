<?php

class Person
{
    public $firstName;
    public $lastName;
    public $email;
    public $score;

    function __construct($fname, $lname, $email, $score){
        $this->firstName = $fname;
        $this->lastName = $lname;
        $this->email = $email;
        $this->score = $score;
    }
}

?>

<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Students</title>
    <link rel="stylesheet" href="style.css" />
</head>
<body>

<script>

    var count = 0;

    function addStudent(){
        count++;
        var newDiv = document.createElement("tr");
        newDiv.setAttribute("id", count);

        newDiv.innerHTML =
            "<td><input type='text' name='fnames[]'></td>" +
            "<td><input type='text' name='lnames[]'></td>" +
            "<td><input type='email' name='emails[]'></td>" +
            "<td><input type='number' id='examScore' min='0' max='400' name='scores[]'>" +
            "<button type='button' class='minusButton' onclick='removeStudent(" + count + ")'>-</button></td>";

        document.getElementById("parent").appendChild(newDiv);
    }

    function removeStudent(number){
        var oldDiv = document.getElementById(number);
        document.getElementById("parent").removeChild(oldDiv);

    }

</script>

<form method="post">
    <table id="parent" border="1">
        <thead>
        <tr>
            <td>First name:</td>
            <td>Last name:</td>
            <td>Email:</td>
            <td>Exam Score:</td>
        </tr>
        </thead>
    </table>
    <button class="minusButton" type="button" onclick="addStudent()">+</button>
    <label for="sort">Sort by:</label>
    <select name="sort" id="sort">
        <option>First name</option>
        <option>Last name</option>
        <option>Email</option>
        <option selected>Exam score</option>
    </select>
    <label for="orderTable">Order:</label>
    <select name="order" id="orderTable">
        <option selected>Descending</option>
        <option>Ascending</option>
    </select>
    <input type="submit">
</form>

<br>

<script>
    addStudent();
</script>

</body>
</html>

<?php

if(isset($_POST['fnames']) && isset($_POST['lnames'])
&& isset($_POST['emails']) && isset($_POST['scores'])
    && isset($_POST['sort']) && isset($_POST['order'])){
    $fnames = array();
    $lnames = array();
    $emails = array();
    $scores = array();

    foreach($_POST['fnames'] as $fname){
        array_push($fnames, $fname);
    }

    foreach($_POST['lnames'] as $lname){
        array_push($lnames, $lname);
    }

    foreach($_POST['emails'] as $email){
        array_push($emails, $email);
    }

    foreach($_POST['scores'] as $score){
        array_push($scores, intval($score));
    }

    $students = array();
    for($i = 0; $i < sizeof($fnames); $i++){
        $temp = new Person($fnames[$i], $lnames[$i], $emails[$i], $scores[$i]);
        array_push($students, $temp);
    }

    usort($students, function($student1, $student2){
        $sort = htmlentities($_POST['sort']);
        $order = htmlentities($_POST['order']);

        if($sort == "First name"){
            if($order == "Ascending"){
                return $student1->firstName > $student2->firstName;
            }
            else{
                return $student1->firstName < $student2->firstName;
            }
        }
        else if($sort == "Last name"){
            if($order == "Ascending"){
                return $student1->lastName > $student2->lastName;
            }
            else{
                return $student1->lastName < $student2->lastName;
            }
        }
        else if($sort == "Email"){
            if($order == "Ascending"){
                return $student1->email > $student2->email;
            }
            else{
                return $student1->email < $student2->email;
            }
        }
        else if($sort == "Exam score"){
            if($order == "Ascending"){
                return $student1->score > $student2->score;
            }
            else{
                return $student1->score < $student2->score;
            }
        }

    });
    ?>

    <table border="1" id="result">
        <tr>
            <th>First Name</th>
            <th>Last Name</th>
            <th>Email</th>
            <th>Exam score</th>
        </tr>

    <?php
    $sum = 0;
    for($i = 0; $i < sizeof($students); $i++){ ?>

        <tr>
            <td><?= $students[$i]->firstName ?></td>
            <td><?= $students[$i]->lastName ?></td>
            <td><?= $students[$i]->email ?></td>
            <td class="score"><?= $students[$i]->score ?></td>
        </tr>
    <?php
        $sum = $sum + $students[$i]->score;
    } ?>

    <tr>
        <td colspan="3"><b>Average Score</b></td>
        <td class="score"><b><?= intval($sum/sizeof($students)) ?></b></td>
    </tr>
    </table>

<?php }

?>