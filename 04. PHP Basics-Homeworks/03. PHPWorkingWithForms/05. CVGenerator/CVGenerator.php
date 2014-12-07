<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>CV Generator</title>
    <style>
        #wrapper {
            width: 600px;
            margin: 0 auto;
        }

        a {
            color: inherit;
            text-decoration: none;
        }

    </style>
</head>
<body>
<script>
    var progLangCount = 0, langCounter = 0;
    function addProgLanguage(){
        progLangCount++;
        var newDiv = document.createElement("div");
        newDiv.setAttribute("id", "progLanguage" + progLangCount);
        newDiv.innerHTML =
            "<input type='text' name='progLang[]'> " +
            "<select name='langLevel[]'>" +
            "<option selected>Beginner</option>" +
            "<option>Programmer</option>" +
            "<option>Ninja</option>" +
            "</select><br>";
        document.getElementById("computerSkills").appendChild(newDiv);
    }

    function removeProgLanguage(){
        var newDiv = document.getElementById("progLanguage" + progLangCount);
        document.getElementById("computerSkills").removeChild(newDiv);
        progLangCount--;
    }

    function addLanguage(){
        langCounter++;
        var newDiv = document.createElement("div");
        newDiv.setAttribute("id", "language" + langCounter);
        newDiv.innerHTML =
            "<input type='text' name='language[]'> " +
            "<select name='comprehension[]'>" +
            "<option selected disabled>-Comprehension-</option>" +
            "<option>Beginner</option>" +
            "<option>Intermediate</option>" +
            "<option>Advanced</option>" +
            "</select> " +
            "<select name='reading[]'>" +
            "<option selected disabled>-Reading-</option>" +
            "<option>Beginner</option>" +
            "<option>Intermediate</option>" +
            "<option>Advanced</option>" +
            "</select> " +
            "<select name='writing[]'>" +
            "<option selected disabled>-Writing-</option>" +
            "<option>Beginner</option>" +
            "<option>Intermediate</option>" +
            "<option>Advanced</option>" +
            "</select> ";
        document.getElementById("otherSkills").appendChild(newDiv);
    }

    function removeLanguage(){
        var newDiv = document.getElementById("language" + langCounter);
        document.getElementById("otherSkills").removeChild(newDiv);
        langCounter--;
    }

</script>

<script>
    function generateTables(){
        personalInfoTable();
        lastWorkTable();
        computerSkillsTable();
        otherSkillsTable();
    }

    function personalInfoTable(){
        var firstName = <?php echo json_encode($_POST['fname']); ?>;
        var lastName = <?php echo json_encode($_POST['lname']); ?>;
        var email = <?php echo json_encode($_POST['email']); ?>;
        var phone = <?php echo json_encode($_POST['phone']); ?>;
        var sex = <?php echo json_encode($_POST['sex']); ?>;
        var birthDate = <?php echo json_encode($_POST['bDate']); ?>;
        var nationallity = <?php echo json_encode($_POST['nation']); ?>;
        var newTable = document.createElement("table");
        newTable.setAttribute("border", 1);
        newTable.innerHTML =
            "<tr><th colspan='2'>Personal Information</th></tr>" +
            "<tr><td>First Name</td><td>" + firstName + "</td></tr>" +
            "<tr><td>Last Name</td><td>" + lastName + "</td></tr>" +
            "<tr><td>Email</td><td>" + email + "</td></tr>" +
            "<tr><td>Phone Number</td><td>" + phone + "</td></tr>" +
            "<tr><td>Gender</td><td>" + sex + "</td></tr>" +
            "<tr><td>Birth Date</td><td>" + birthDate + "</td></tr>" +
            "<tr><td>Nationallity</td><td>" + nationallity + "</td></tr>";
        document.getElementById("parent").appendChild(newTable);
        var newLine = document.createElement("br");
        document.getElementById("parent").appendChild(newLine);
    }

    function lastWorkTable(){
        var company = <?php echo json_encode($_POST['company']); ?>;
        var dateFrom = <?php echo json_encode($_POST['fromDate']); ?>;
        var dateTo = <?php echo json_encode($_POST['toDate']); ?>;

        var newTable = document.createElement("table");
        newTable.setAttribute("border", 1);
        newTable.innerHTML =
            "<tr><th colspan='2'>Last Work Position</th></tr>" +
            "<tr><td>Company Name</td><td>" + company + "</td></tr>" +
            "<tr><td>From</td><td>" + dateFrom + "</td></tr>" +
            "<tr><td>To</td><td>" + dateTo + "</td></tr>";
        document.getElementById("parent").appendChild(newTable);
        var newLine = document.createElement("br");
        document.getElementById("parent").appendChild(newLine);
    }

    function computerSkillsTable(){
        var newTable = document.createElement("table");
        newTable.setAttribute("border", 1);

        var innerTable = "<table border='1'><tr><th>Language</th><th>Skill Level</th></tr>";

        var languageArr = [], skillLevelArr = [];

        <?php
            foreach($_POST['progLang'] as $lang){ ?>
                languageArr.push(<?php echo json_encode($lang); ?>);
            <?php }
        ?>

        <?php
            foreach($_POST['langLevel'] as $skillLevel){ ?>
                skillLevelArr.push(<?php echo json_encode($skillLevel); ?>);
            <?php }
        ?>

        for(var i = 0; i < languageArr.length; i++){
            innerTable += "<tr><td>" + languageArr[i] +"</td><td>" + skillLevelArr[i] + "</td></tr>";
        }

        innerTable += "</table>";
        newTable.innerHTML =
            "<tr><th colspan='2'>Computer Skills</tr>" +
            "<tr><td>Programming Languages</td><td>" + innerTable + "</td></tr>";
        document.getElementById("parent").appendChild(newTable);
        var newLine = document.createElement("br");
        document.getElementById("parent").appendChild(newLine);
    }

    function otherSkillsTable(){
        var newTable = document.createElement("table");
        newTable.setAttribute("border", 1);

        var innerTable = "<table border='1'><tr>" +
            "<th>Language</th>" +
            "<th>Comprehension</th>" +
            "<th>Reading</th>" +
            "<th>Writing</th>" +
            "</tr>";

        var languageArr = [], comprehensionArr = [], readingArr = [], writingArr = [];

        <?php
            foreach($_POST['language'] as $lang){ ?>
                languageArr.push(<?php echo json_encode($lang); ?>);
            <?php }
        ?>

        <?php
            foreach($_POST['comprehension'] as $comprehension){ ?>
                comprehensionArr.push(<?php echo json_encode($comprehension); ?>);
            <?php }
        ?>

        <?php
            foreach($_POST['reading'] as $reading){ ?>
                readingArr.push(<?php echo json_encode($reading); ?>);
            <?php }
        ?>

        <?php
            foreach($_POST['writing'] as $writing){ ?>
                writingArr.push(<?php echo json_encode($writing); ?>);
            <?php }
        ?>

        for(var i = 0; i < languageArr.length; i++){
            innerTable += "<tr>" +
                "<td>" + languageArr[i] + "</td>" +
                "<td>" + comprehensionArr[i] + "</td>" +
                "<td>" + readingArr[i] + "</td>" +
                "<td>" + writingArr[i] + "</td>" +
                "</tr>"
        }

        var license = "";
        <?php
            if(isset($_POST['categoryB'])){ ?>
                license += "B ";
            <?php }

            if(isset($_POST['categoryA'])){ ?>
                license += "A ";
            <?php }

            if(isset($_POST['categoryC'])){ ?>
                license += "C ";
            <?php }
        ?>

        if(license == ""){
            license = "no license";
        }
        else if(license.length > 2){
            license.split('|');
            var str = "";
            for(var i = 0; i < license.length; i++){
                if(license[i] == "" || license[i] == " "){
                    continue;
                }
                else {
                    str += license[i] + ", ";
                }
            }
            license = str.slice(0, str.length - 2);
        }

        innerTable += "</table>";
        newTable.innerHTML =
            "<tr><th colspan='2'>Other Skills</th></tr>" +
            "<tr><td>Languages</td><td>" + innerTable + "</td></tr>" +
            "<tr><td>Driver's license</td><td>" + license + "</td></tr>";

        document.getElementById("parent").appendChild(newTable);
        var newLine = document.createElement("br");
        document.getElementById("parent").appendChild(newLine);
    }

</script>

<div id="wrapper">
    <form method="post">
        <fieldset>
            <legend>Personal Information</legend>
            <input type="text" name="fname" placeholder="First Name"><br>
            <input type="text" name="lname" placeholder="Last Name"><br>
            <input type="text" name="email" placeholder="Email"><br>
            <input type="text" name="phone" placeholder="Phone Number"><br>
            <label for="female">Female </label>
            <input type="radio" name="sex" value="Female" id="female">
            <label for="male">Male </label>
            <input type="radio" name="sex" value="Male" id="male"><br>
            <label for="Date">Birth Date</label><br>
            <input type="date" name="bDate" id="Date"><br>
            <label for="nationallity">Nationallity</label><br>
            <select name="nation" id="nationallity">
                <option selected>Bulgarian</option>
                <option>American</option>
                <option>British</option>
            </select><br>
        </fieldset>

        <fieldset>
            <legend>Last Work Position</legend>
            <label for="companyName">Company Name</label>
            <input type="text" name="company" id="companyName"><br>
            <label for="dateFrom">From</label>
            <input type="date" name="fromDate" id="dateFrom"><br>
            <label for="dateTo">To</label>
            <input type="date" name="toDate" id="dateTo"><br>
        </fieldset>

        <fieldset>
            <legend>Computer Skills</legend>
            <label>Programming Languages</label><br>
            <div id="computerSkills">
            </div>
            <button><a href='javascript:removeProgLanguage()'>Remove Language</a></button>
            <button><a href='javascript:addProgLanguage()'>Add Language</a></button>
        </fieldset>

        <fieldset>
            <legend>Other Skills</legend>
            <label>Languages</label><br>
            <div id="otherSkills">
            </div>
            <button><a href='javascript:removeLanguage()'>Remove Language</a></button>
            <button><a href='javascript:addLanguage()'>Add Language</a></button><br>
            <label>Driver's License</label><br>
            <label for="b">B </label>
            <input type="checkbox" name="categoryB" value="B" id="b">
            <label for="a">A </label>
            <input type="checkbox" name="categoryA" value="A" id="a">
            <label for="c">C </label>
            <input type="checkbox" name="categoryC" value="C" id="c">
        </fieldset>

        <input type="submit" value="Generate CV">
    </form>

    <br>

    <div id="parent">
    </div>
</div>

<script>
    addProgLanguage();
    addLanguage();
</script>

<?php
if(isset($_POST['fname']) && isset($_POST['lname'])
&& isset($_POST['email']) && isset($_POST['phone'])
&& isset($_POST['sex']) && isset($_POST['bDate'])
&& isset($_POST['nation']) && isset($_POST['company'])
&& isset($_POST['fromDate']) && isset($_POST['toDate'])
&& isset($_POST['progLang']) && isset($_POST['langLevel'])
&& isset($_POST['language']) && isset($_POST['comprehension'])
&& isset($_POST['reading']) && isset($_POST['writing'])){
    echo "<script>generateTables();</script>";
}
?>

</body>
</html>