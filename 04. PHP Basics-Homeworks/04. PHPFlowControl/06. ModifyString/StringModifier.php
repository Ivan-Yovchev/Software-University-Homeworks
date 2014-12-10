<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>String Modifier</title>
</head>
<body>
    <form method="post">
        <input type="text" name="text">
        <input type="radio" id="palindromeCheck" name="input" value="palindrome">
        <label for="palindromeCheck"> Check Palindrome</label>
        <input type="radio" id="reverseString" name="input" value="reverse">
        <label for="reverseString"> Reverse String</label>
        <input type="radio" id="splitString" name="input" value="split">
        <label for="splitString"> Split</label>
        <input type="radio" id="hashString" name="input" value="hash">
        <label for="hashString"> Hash String</label>
        <input type="radio" id="shuffleString" name="input" value="shuffle">
        <label for="shuffleString"> Shuffle String </label>
        <input type="submit">
    </form>
</body>
</html>

<?php
    if(isset($_POST['input']) && isset($_POST['text'])){
        $text = htmlentities($_POST['text']);
        $option = htmlentities($_POST['input']);

        if($option == 'palindrome'){
            $check = checkPalindrome($text);
            if($check == true){
                echo $text . " is a palindrome";
            }
            else {
                echo $text . " is not a palindrome!";
            }
        }
        else if($option == 'reverse'){
            echo reverseString($text);
        }
        else if($option == 'split'){
            $result = splitString($text);
            echo $result;
        }
        else if($option == 'hash'){
            echo hashString($text);
        }
        else if($option == 'shuffle'){
            echo stringShuffle($text);
        }

    }

    function checkPalindrome($string){
        if($string == strrev($string)){
            return true;
        }
        else {
            return false;
        }
    }

    function reverseString($string){
        return strrev($string);
    }

    function splitString($string){
        $string = preg_replace("/[^a-zA-Z]+/", "", $string);
        $result = '';
        for($i = 0; $i < strlen($string); $i++){
            $result = $result . $string[$i] . " ";
        }
        return $result;
    }

    function hashString($string){
        return crypt($string, '$1$rasmusle$');
    }

    function stringShuffle($string){
        return str_shuffle($string);
    }

?>