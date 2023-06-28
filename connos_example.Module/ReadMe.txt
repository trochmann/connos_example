Anmerkungen

Im Code habe ich mich komplett ans Englische gehalten.

Damit entsprechende Überschriften lokalisiert auftauchen könnten, nutze ich die Attribute in den BusinessObjects.
Z.B.: [ModelDefault("Caption", "Mandant")] oder [DisplayName("Name")], 
um entsprechend die Lokalisierungsmöglichkeiten über .Net nutzen zu können, habe ich aber nicht implementiert.

Habe die AccessDB für den Import mit dem entsprechenden Treiber gewählt, der ConnectionString ist mit dem Dateispeicherort direkt im Code,
das wäre sonst natürlich ein OpenFileDialog. Der Dateispeicherort ist das bin\debug Verzeichnis.

DevExpress ist 22.1.9


