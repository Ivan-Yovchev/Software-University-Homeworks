<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>SoftUni Students</title>
</head>
<body>

<form method="get">

    <textarea name="students"></textarea><br>
    <input type="text" name="column"><br>
    <input type="text" name="order"><br>
    <input type="submit">

</form>

</body>
</html>

<?php

if(isset($_GET['students']) && isset($_GET['column']) && isset($_GET['order'])){

    $input = preg_split("/\r?\n/", $_GET['students'], -1, PREG_SPLIT_NO_EMPTY);
    $column = $_GET['column'];
    $order = $_GET['order'];

    $result = [];
    $index = 1;
    foreach ($input as $person) {
        $person = explode(", ", $person);

        $student = new stdClass();
        $student->id = $index;
        $student->username = $person[0];
        $student->email = $person[1];
        $student->type = $person[2];
        $student->result = intval($person[3]);

        switch($column){
            case "id": $student->column = $index; break;
            case "username": $student->column = $person[0]; break;
            case "result": $student->column = intval($person[3]); break;
        }

        $result[] = $student;

        $index++;

    }

    usort($result, function($person1, $person2) use ($order){

        if($person1->column != $person2->column){
            if($order == "ascending"){
                return $person1->column > $person2->column;
            }
            else {
                return $person1->column < $person2->column;
            }
        }
        else {
            if($order == "ascending"){
                return $person1->id > $person2->id;
            }
            else {
                return $person1->id < $person2->id;
            }
        }

    });

    $output = "<table><thead><tr><th>Id</th><th>Username</th><th>Email</th><th>Type</th><th>Result</th></tr></thead>";
    foreach ($result as $student) {
        $output .= "<tr>";
        $output .= "<td>" . htmlspecialchars($student->id) . "</td>";
        $output .= "<td>" . htmlspecialchars($student->username) . "</td>";
        $output .= "<td>" . htmlspecialchars($student->email) . "</td>";
        $output .= "<td>" . htmlspecialchars($student->type) . "</td>";
        $output .= "<td>" . htmlspecialchars($student->result) . "</td>";
        $output .= "</tr>";
    }

    echo $output . "</table>";

}

?>