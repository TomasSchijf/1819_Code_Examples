<?php
include "database.php";
?>
<!DOCTYPE html>
<html>
<head>
    <title>Voorbeeld form</title>
</head>
<body>
<h1>Voorbeeld form</h1>
<h2>Met verschillende elementen</h2>

<form method="POST">
    <table>
        <tr>
            <th><label for="txtFirstname">Voornaam</label></th>
            <td><input type="text" id="txtFirstname" name="txtFirstname" required></td>
        </tr>
        <tr>
            <th><label for="txtLastname">Achternaam</label></th>
            <td><input type="text" id="txtLastname" name="txtLastname" required></td>
        </tr>
        <tr>
            <th><label for="txtCity">Woonplaats</label></th>
            <td><input type="text" id="txtCity" name="txtCity" required></td>
        </tr>
        <tr>
            <th><label for="txtEmail">Email</label></th>
            <td><input type="text" id="txtEmail" name="txtEmail" required></td>
        </tr>
        <tr>
            <th><label for="txtPhonenumber">Telefoonnummer</label></th>
            <td><input type="text" id="txtPhonenumber" name="txtPhonenumber" required></td>
        </tr>
        <tr>
            <th></th>
            <td><input type="submit" name="btnSave" value="Opslaan"></td>
        </tr>
    </table>
</form>
<?php
// Controleren of er op de knop geklikt is
if(isset($_POST["btnSave"])){
    // Formulier data ophalen en opslaan in variable
    $firstname = $_POST["txtFirstname"];
    $lastname = $_POST["txtLastname"];
    $city = $_POST["txtCity"];
    $email = $_POST["txtEmail"];
    $phonenumber = $_POST["txtPhonenumber"];

    // Opbouwen van query
    $query = "INSERT INTO submissions (firstname, lastname, city, email, phonenumber) ".
             "VALUES ('$firstname', '$lastname', '$city', '$email', '$phonenumber')";
    // Query op het scherm tonen (voor development only!) NIET VERPLICHT!!
//    var_dump($query);
    // Query klaarzetten om uit te gaan voeren
    $stm = $con->prepare($query);
    // Query uitvoeren en als dat lukt -> if, als dat niet lukt (fout) -> else
    if($stm->execute()){
        echo "De inschrijving is succesvol opgeslagen!";
    } else {
        echo "Er is helaas iets misgegaan!";
    }
}
?>
</body>
</html>