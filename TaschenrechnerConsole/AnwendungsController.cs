namespace TaschenrechnerConsole
{
    class AnwendungsController
    {
        #region Attribute
        /// <summary>
        /// Attribute von den Klassen ConsoleView und RechnerModel werden deklariert
        /// </summary>
        private ConsoleView view;
        private RechnerModel model;

        #endregion

        #region Konstruktoren
        /// <summary>
        /// Initialisierung der Attribute view und model im Konstruktor
        /// AnwendungsController kennt ConsoleView
        /// AnwendungsController kennt RechnerModel
        /// </summary>
        /// <param name="view"></param>
        /// <param name="model"></param>

        public AnwendungsController(ConsoleView view, RechnerModel model)
        {
            this.view = view;
            this.model = model;
        }

        #endregion

        #region Methoden
        /// <summary>
        /// Programmsteuerung mit Methode Ausfuehren()
        /// </summary>
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

        /// <summary>
        /// Methode FuehreImmerGleicheSchritteDurch() greift auf model und view zu, um Berechnungen
        /// Ein- und Ausgaben durchzuführen
        /// </summary>
        /// 
        // diese Schritte sind laufen immer ab, unabhängig von 1. oder nachfolgender Eingabe
        public void FuehreImmerGleicheSchritteDurch()
        {
            // Berechnungen durchführen
            model.Berechne();

            // Ausgabe vom Ergebnis aus der Berechnung
            view.GibResultatAus();

            // Nächsten Wert holen oder 'FERTIG' für Beenden
            view.HoleFortlaufendeEingabenVomBenutzer();
        }

        #endregion
    }
}
