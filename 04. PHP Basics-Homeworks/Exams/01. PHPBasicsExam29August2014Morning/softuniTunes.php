<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>SoftUni Tunes</title>
</head>
<body>

<form method="get">
    <textarea name="text"></textarea><br>
    <input type="text" name="artist"><br>
    <select name="property">
        <option>name</option>
        <option>genre</option>
        <option>downloads</option>
        <option>rating</option>
    </select>
    <select name="order">
        <option>ascending</option>
        <option>descending</option>
    </select>
    <input type="submit">
</form>

</body>
</html>

<?php

if(isset($_GET['text']) && isset($_GET['artist'])
&& isset($_GET['property']) && isset($_GET['order'])){

    $text = preg_split("/\r\n/", $_GET['text'], -1, PREG_SPLIT_NO_EMPTY);
    $artist = explode(", ", $_GET['artist']);
    $property = $_GET['property'];
    $order = $_GET['order'];

    $newTable = [];
    foreach ($text as $inputLine) {
        $inputLine = preg_split("/\s*\|\s*/", $inputLine, -1, PREG_SPLIT_NO_EMPTY);

        $names = explode(', ', trim($inputLine[2]));
        sort($names);

        for($i = 0; $i < count($artist); $i++){
            if(in_array($artist[$i], $names)){

                $name = trim($inputLine[0]);
                $genre = trim($inputLine[1]);
                $downloads = intval($inputLine[3]);
                $rating = floatval($inputLine[4]);

                $newSong = new stdClass();

                $newSong->name = $name;
                $newSong->ganre = $genre;
                $newSong->names = $names;
                $newSong->download = $downloads;
                $newSong->rating = $rating;

                switch($property){
                    case "name": $newSong->property = $name; break;
                    case "genre": $newSong->property = $genre; break;
                    case "downloads": $newSong->property = $downloads; break;
                    case "rating": $newSong->property = $rating; break;
                }

                $newTable[] = $newSong;

            }
        }

    }

    usort($newTable, function($value1, $value2) use ($order, $property){

        if($value1->property != $value2->property){
            if($order == "ascending"){
                return $value1->property > $value2->property;
            }
            else {
                return $value1->property < $value2->property;
            }
        }
        else {
            if($order == "ascending"){
                return $value1->name > $value2->name;
            }
            else {
                return $value1->name < $value2->name;
            }
        }

    });

    $output = "<table>\n" . "<tr><th>Name</th><th>Genre</th><th>Artists</th><th>Downloads</th><th>Rating</th></tr>\n";
    foreach ($newTable as $song) {

        $output .= "<tr>";

        $output .= "<td>" . htmlspecialchars($song->name) . "</td>";
        $output .= "<td>" . htmlspecialchars($song->ganre) . "</td>";
        $output .= "<td>" . htmlspecialchars(implode(', ', $song->names)) . "</td>";
        $output .= "<td>" . htmlspecialchars($song->download) . "</td>";
        $output .= "<td>" . htmlspecialchars($song->rating) . "</td>";

        $output .= "</tr>\n";

    }

    $output .= "</table>";

    echo $output;

}

?>