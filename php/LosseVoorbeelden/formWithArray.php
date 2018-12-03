<!DOCTYPE html>
<html>
<head>
    <title>Formulier met array</title>
</head>
<body>
    <h1>Formulier met array</h1>
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
    // Controleren of er op de knop geklikt is
    if(isset($_POST["btnSave"])){
        // Array aanmaken (leeg)
        $lijst = array();
        // Gegevens uit formulier in array zetten
        $lijst['aanhef'] = $_POST["selSalutation"];
        $lijst['geslacht'] = $_POST["rbGender"];
        $lijst['voornaam'] = $_POST["txtFirstname"];
        $lijst['achternaam'] = $_POST["txtLastname"];
        // Later: Array uitlezen, voor nu, array op scherm 'dumpen'
        //var_dump laat een variable op het scherm zien, ALLEEN VOOR DEVELOPMENT!
        var_dump($lijst);
    }
    ?>
</body>
</html>