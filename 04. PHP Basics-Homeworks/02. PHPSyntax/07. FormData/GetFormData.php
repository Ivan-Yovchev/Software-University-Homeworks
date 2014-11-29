<form>
    <input type="text" name="name" placeholder="Name..." ><br>
    <input type="text" name="age" placeholder="Age..."><br>
    <input type="radio" name="sex" value="male" >Male<br>
    <input type="radio" name="sex" value="female" >Female<br>
    <input type="submit">
</form>

<?php if (isset($_GET["name"])) { ?>
    My name is <?php echo htmlentities($_GET["name"]) ?>.
    I am <?php echo htmlentities($_GET["age"]) ?> years old.
    I am <?php echo htmlentities($_GET["sex"]) ?>.
<?php } ?>