# DataGrid voorbeeld met meerdere tabellen
DataClasses.PNG bevat een foto van de LinqToSQL classes die gebruikt zijn in het voorbeeld.
- De gebruikte LinqToSQL classes heeft de naam dcSchool.dbml.

In dit voorbeeld staat zowel de .xaml als de .xaml.cs code omdat het grootste deel van de wijzigingen in de .xaml staan.
- In de DataGrid (dgStudents) staat AutoGenerateColumns="False", aangezien we zelf de kolommen specificeren met:
- DataGridTextColumn, deze gebruiken we om aan te geven welke kolommen we willen hebben, en waar deze data vandaan komt.

**(Zie ook de reader op itslearning)**