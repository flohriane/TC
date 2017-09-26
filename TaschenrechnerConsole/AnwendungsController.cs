namespace TaschenrechnerConsole
{
    class AnwendungsController
    {
        // Attribute
        private ConsoleView view;
        private RechnerModel model;
        
        // Konstruktor zur Initialisierung der Attribute
        public AnwendungsController(ConsoleView view, RechnerModel model)
        {
            this.view = view;
            this.model = model;
        }

        public void Ausfuehren()
        {
            // anfängliche Eingabewerte 1.Zahl, 2.Zahl, Operator holen
            view.HoleErsteEingabenVomBenutzer();
            FuehreImmerGleicheSchritteDurch();

        while (!view.BenutzerWillBeenden)
            {
                FuehreImmerGleicheSchritteDurch();
            }

            // Programm beenden
            view.BeendeProgramm();
        }

        // Schritte unabhängig von 1. oder nachfolgender Eingabe
        public void FuehreImmerGleicheSchritteDurch()
        {
                // Berechnungen durchführen
                model.Berechne();

                // Ausgabe vom Ergebnis aus der Berechnung
                view.GibResultatAus();

                // Nächsten Wert holen oder 'FERTIG' für Beenden
                view.HoleFortlaufendeEingabenVomBenutzer();
        }
    }
}
