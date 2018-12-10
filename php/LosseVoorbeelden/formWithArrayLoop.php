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
                <th><label for="rbGender">Geslacht</label></th>
                <td>
                    <input type="radio" id="rbGender" name="rbGender" value="Man" required>Man
                    <input type="radio" id="rbGender" name="rbGender" value="Vrouw" required>Vrouw
                </td>
            </tr>
            <tr>
                <th><label for="txtFirstname">Voornaam</label></th>
                <td><input type="text" id="txtFirstname" name="txtFirstname" required></td>
            </tr>
            <tr>
                <th><label for="txtLastname">Achternaam</label></th>
                <td><input type="text" id="txtLastname" name="txtLastname" required></td>
            </tr>
            <tr>
                <th><label for="selChoice">Keuze</label></th>
                <td>
                    <select name="selChoice" id="selChoice" required>
                        <option value="Optie">Optie</option>
                        <option value="NogEenOptie">Nog een optie</option>
                        <option value="TeveelKeuzes">Teveel keuzes</option>
                    </select>
                </td>
            </tr>
            <tr>
                <th></th>
                <td><input type="submit" name="btnSave" value="Opslaan"></td>
            </tr>
        </table>
    </form>
    <?php
    // Als er op de knop 'btnSave' geklikt is
    if(isset($_POST["btnSave"])){
        // Array maken
        $aData = array();

        // Velden uit formulier uitlezen en opslaan in een array
        $aData["gender"] = $_POST["rbGender"];
        $aData["firstname"] = $_POST["txtFirstname"];
        $aData["lastname"] = $_POST["txtLastname"];
        $aData["choice"] = $_POST["selChoice"];

        // Door de array loopen en de data op het scherm tonen
        // $key wordt wat er tussen de blokhaken staat (dus: gender, firstname, lastname & choice)
        // $value wordt wat er achter de = staat (dus: wat er in de velden ingevoerd is)
        foreach($aData as $key => $value){
            echo "Veld: $key is $value<br/>";
        }
    }
    ?>
</body>
</html>