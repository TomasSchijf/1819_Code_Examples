<?php
include "database.php";
?>
<!DOCTYPE html>
<html>
<head>
    <title>On the Fly</title>
</head>
<body>
    <div class="content">
        <h1>On the fly!</h1>
        <hr/>
        <form method="POST">
            <label for="txtAirplanenumber">Airplanenumber</label>
            <input type="text" name="txtAirplanenumber" id="txtAirplanenumber">
            <br/>
            <label for="txtPlanetype">Planetype</label>
            <input type="text" name="txtPlanetype" id="txtPlanetype">
            <br/>
            <label for="txtAirline">Airline</label>
            <input type="text" name="txtAirline" id="txtAirline">
            <br/>
            <label for="txtStatus">Status</label>
            <input type="text" name="txtStatus" id="txtStatus">
            <br/>
            <input type="submit" name="btnSave" value="Opslaan">
        </form>
        <?php
        // Als er op de knop btnSave geklikt is
        if(isset($_POST['btnSave'])) {

            // Tekstvelden uitlezen en opslaan in variable
            $airplanenumber = $_POST['txtAirplanenumber'];
            $planetype = $_POST['txtPlanetype'];
            $airline = $_POST['txtAirline'];
            $status = $_POST['txtStatus'];

            // Query maken om vliegtuig toe te voegen
            $query = "INSERT INTO airplanes (airplanenumber, planetype, airline, status)
                  VALUES ('$airplanenumber', '$planetype', '$airline', '$status')";

            // Query klaar zetten om uit te voeren
            $stm = $con->prepare($query);
            // Als de Query succesvol uit gevoerd wordt
            if($stm->execute()){
                echo "Airplane has been successfully added.";
            } else {
                echo "Something wrong!";
            }
        }
        ?>
        <hr/>
        <table>
            <thead>
            <tr>
                <th>airplanenumber</th>
                <th>planetype</th>
                <th>airline</th>
                <th>state</th>
            </tr>
            </thead>
            <tbody>
            <?php
            // Query om vliegtuigen op te halen
            $query = "SELECT * FROM airplanes";
            $stm = $con->prepare($query);
            if($stm->execute()){
                // Vliegtuigen uit het resultaat halen als objecten en opslaan in $airplanes
                $airplanes = $stm->fetchAll(PDO::FETCH_OBJ);
                // Loop door alle vliegtuigen heen
                foreach($airplanes as $airplane){
                    // Let op: tr in de loop omdat we 1 vliegtuig per row hebben
                    echo "<tr>";
                        echo "<td>$airplane->airplanenumber</td>";
                        echo "<td>$airplane->planetype</td>";
                        echo "<td>$airplane->airline</td>";
                        echo "<td>$airplane->status</td>";
                    echo "</tr>";
                }
            }
            ?>
            </tbody>
        </table>
    </div>
</body>
</html>