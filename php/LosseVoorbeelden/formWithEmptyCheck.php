<!DOCTYPE html>
<html>
<head>
    <title>Formulier met contole leeg</title>
</head>
<body>
<h1>Formulier met controle leeg</h1>
<form method="POST">
    <table>
        <tr>
            <th><label for="selSalutation">Aanhef</label></th>
            <td>
                <select name="selSalutation" id="selSalutation">
                    <option value="dhr">Dhr.</option>
                    <option value="mvr">Mvr.</option>
                </select>
            </td>
        </tr>
        <tr>
            <th><label for="rbGender">Geslacht</label></th>
            <td>
                <!-- Automatisch 1 van de 2 keuzes omdat name hetzelfde is -->
                <input type="radio" name="rbGender" id="rbGender" value="man">Man
                <input type="radio" name="rbGender" id="rbGender" value="vrouw">Vrouw
            </td>
        </tr>
        <tr>
            <th><label for="txtFirstname">Voornaam</label></th>
            <td><input type="text" name="txtFirstname" id="txtFirstname"/></td>
        </tr>
        <tr>
            <th><label for="txtLastname">Achternaam</label></th>
            <td><input type="text" name="txtLastname" id="txtLastname"/></td>
        </tr>
        <tr>
            <td>&nbsp;</td><!-- &nbsp; om zeker te weten dat het td element gevuld is. -->
            <td>
                <input type="submit" name="btnSave" value="Inschrijven">
            </td>
        </tr>
    </table>
</form>
<?php
// Controle of er op de knop geklikt is
if(isset($_POST["btnSave"])){
    /*
     * Controle of er iets is ingevoerd in de velden
     * ALS niet ingevoerd:  Melding tonen
     * ANDERS               Input in array zetten
     */
    // Lege array aanmaken
    $lijst = array();
    // Controle of er een item in de select geselecteerd is. (standaard eerste item geselecteerd)
    if(empty($_POST["selSalutation"])){
        echo "Selecteer een aanhef<br/>";
    } else {
        $lijst["aanhef"] = $_POST["selSalutation"];
    }
    // Controle of er een keuze is gemaakt tussen de radiobuttons, isset want als er geen keuze is, bestaat de variable niet
    // ! voor de isset want controle of hij NIET bestaat 
    if(!isset($_POST["rbGender"])){
        echo "Selecteer een geslacht<br/>";
    } else {
        $lijst["geslacht"] = $_POST["rbGender"];
    }
    // Controle of er iets is ingevoerd in de textbox (firstname + lastname)
    if(empty($_POST["txtFirstname"])){
        echo "Voer een voornaam in<br/>";
    } else {
        $lijst["voornaam"] = $_POST["txtFirstname"];
    }
    if(empty($_POST["txtLastname"])){
        echo "Voer een achternaam in<br/>";
    } else {
        $lijst["achternaam"] = $_POST["txtLastname"];
    }

    // Door de array loopen en de data op het scherm tonen
    // $key wordt wat er tussen de blokhaken staat (dus: gender, firstname, lastname & choice)
    // $value wordt wat er achter de = staat (dus: wat er in de velden ingevoerd is)
    foreach($lijst as $key => $value){
        echo "Veld: $key is $value<br/>";
    }

    // Data tonen als leesbare zin
    echo $lijst["aanhef"].". ".$lijst["voornaam"]." ".$lijst["achternaam"]." is een ".$lijst["geslacht"];
}
?>
</body>
</html>