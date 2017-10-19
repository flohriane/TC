using System;

namespace TaschenrechnerConsole
{

    class ConsoleView

    {
        #region Attribute
        // Attribut vom Typ RechnerModel - lokal
        private RechnerModel model;

        // Variable fehlereingabe wird bei allen Prüfungen auf richtige Eingabewerte gesetzt
        private bool fehlerEingabe = false;
        // Variable eingabe ist der Wert, der vom Benutzer eingegben wird
        string eingabe;
        // Variable zahl ist der Wert, der je nach Eingabe von string eingabe in double oder auf 0 gesetzt wird
        double zahl;
        // Je nach Fehler wird ein spezieller Text an die Ausgabe-Methode weitergegben
        string fehlertext;

        #endregion

        #region Eigenschaften
        /// <summary>
        /// Eigenschaft BenutzerWillBeenden für das Beenden des Programms durch den Benutzer
        /// </summary>
        public bool BenutzerWillBeenden { get; private set; }

        #endregion

        #region Konstruktoren
        /// <summary>
        /// Konstruktor verbindet die Klasse ConsoleView mit RechnerModel
        /// und initialisiert die Attribute
        /// ConsoleView kennt RechnerModel
        /// </summary>
        /// <param name="model"></param>

        // Konstruktor initialisiert das Attribut this.model mit dem Parameter model aus der Klasse RechnerModel
        // und die Properties
        public ConsoleView(RechnerModel model)
        {
            this.model = model; // this.Attribut = Parameter
            BenutzerWillBeenden = false;
        }

        #endregion

        /// <summary>
        /// Die Methode HoleErsteEingabeVomBenutzer() liest von der Konsole die 
        /// erste Eingabe der Zahlen und des Operators mittels der Methoden
        /// HoleBenutzerEingabeDouble() und HoleBenutzerEingabeOperator() ein
        /// </summary>
         public void HoleErsteEingabenVomBenutzer()
        {
            fehlertext = "Bitte gib erneut eine Zahl für die Berechnung ein: ";
            HoleBenutzerEingabeDouble("Bitte gib die 1. Zahl ein");
            // 1. Zahl wird dem RechnerModel übergeben
            model.ErsteZahlAlsDouble = zahl;
            Console.WriteLine();

            HoleBenutzerEingabeOperator("Bitte gib an, welche Operation du durchführen möchtest (+ - * /) ");
            // Eingabe wird dem RechnerModel übergeben
            model.Operation = eingabe;
            Console.WriteLine();

            HoleBenutzerEingabeDouble("Bitte gib die 2. Zahl ein");
            // 2. Zahl wird dem RechnerModel übergeben
            model.ZweiteZahlAlsDouble = zahl;
            Console.WriteLine();
        }

        /// <summary>
        /// Die Methode HoleBenutzerEingabeDouble(string text) fordert den Benutzer zur Eingabe einer Zahl auf.
        /// Es wird eine Zeichenkette -text- für die Benutzeranweisung auf der Konsole in die Methode übergeben
        /// Fehlerbehandlungen:
        /// - ungültige Eingabe string anstatt double mit Methode TryParse() 
        /// - Grenzwerte -10 und +100 mit Methode model.PruefeZahlAufGrenzwert() -> setzt fehlerEingabe true oder false
        /// - Prüfung auf Division durch 0 mit Methode model.PruefeDivisionDurchNull() -> setzt fehlerEingabe true oder false
        /// </summary>
        /// <param name="text">"Bitte gib die 1. Zahl ein" oder "Bitte gib die 2. Zahl ein"</param>
        /// <returns>zahl als double</returns>
        private void HoleBenutzerEingabeDouble(string text)
        {
            Console.WriteLine(text);
            eingabe = Console.ReadLine();

            // Ziffern
            GueltigeEingabeZahl();

            // Grenzwerte -10 bis 100
            GueltigerBereich();

            // Division durch 0 ausschließen
            GueltigOhneDivisionDurchNull();

            // Variable fehlerEingabe wird für die nächste Verwendung zurückgesetzt
            fehlerEingabe = false;
        }

        /// <summary>
        /// Die Methode HoleBenutzerEingabeOperator(string text) fordert den Benutzer zur Eingabe des Operators auf
        /// Es wird eine Zeichenkette -text- für die Benutzeranweisung auf der Konsole in die Methode übergeben
        /// Fehlerbehandlung:
        /// - Prüfung auf gültigen Operator mit Methode model.PruefeOperator(eingabe)
        /// </summary>
        /// <param name="text">"Bitte gib an, welche Operation du durchführen möchtest (+ - * /) "</param>
        /// <returns></returns>
        private void HoleBenutzerEingabeOperator(string text)
        {
            Console.WriteLine(text);
            eingabe = Console.ReadLine();

            fehlerEingabe = model.PruefeOperator(eingabe);

            while (fehlerEingabe)
            {
                GibEingabeFehlerAus(", ungültiger Operator " + eingabe);
                Console.WriteLine("Bitte gib einen gültigen Operator ein (+ - * /): ");
                eingabe = Console.ReadLine();
                fehlerEingabe = model.PruefeOperator(eingabe);
            }
            // Variable fehlerEingabe wird für die nächste Verwendung zurückgesetzt
            fehlerEingabe = false;
        }

        // Methode zum Einlesen einer Zeichenkette über die Konsole
        private void HoleBenutzerEingabeString(string text)
        {
            Console.WriteLine(text);
            eingabe = Console.ReadLine();
        }

        /// <summary>
        /// die Methode HoleFortlaufendeEingabenVomBenutzer() liest die weiteren Eingaben von
        /// Zahlen bis zum Beenden durch den Benutzer (Eingabe "FERTIG") von der Konsole ein
        /// Fehlerbehandlungen:
        /// - ungültige Eingabe string anstatt double mit Methode TryParse() 
        /// - Grenzwerte -10 und +100 mit Methode model.PruefeZahlAufGrenzwert() -> setzt fehlerEingabe true oder false
        /// - Prüfung auf Division durch 0 mit Methode model.PruefeDivisionDurchNull() -> setzt fehlerEingabe true oder false
        /// </summary>
        public void HoleFortlaufendeEingabenVomBenutzer()
        {
            fehlertext = "Bitte gib eine weitere Zahl zur Berechnung ein oder <FERTIG> zum Beenden";

            HoleBenutzerEingabeString(fehlertext);

            GueltigeEingabeZahlOderFERTIG();

            GueltigerBereichOderFERTIG();

            GueltigOhneDivisionDurchNullOderFERTIG();

            // Variable fehlerEingabe wird für die nächste Verwendung zurückgesetzt
            fehlerEingabe = false;

            model.ErsteZahlAlsDouble = model.Resultat;
            model.ZweiteZahlAlsDouble = zahl;
        }

        /// <summary>
        /// Methode zum Einlesen der weiteren Zahlen für die Berechnung
        /// die Umwandlung von string eingabe in double zahl
        /// </summary>
        public void WiederholeEingabeZahl()
        {
            Console.WriteLine(fehlertext);
            eingabe = Console.ReadLine();
        }
 
        #region Methoden zur Überprüfung der Eingaben durch Benutzer

        private void GueltigeEingabeZahl()
        {
            // Prüfung auf Eingabefehler keine gültige Zahl
            fehlerEingabe = PruefeAufGueltigeEingabeZahl();

            while (fehlerEingabe)
            {
                // Fehlermeldung mit Angabe, welche Eingaben möglich sind
                GibSonstigeEingabeFehlerAus();

                WiederholeEingabeZahl();
                fehlerEingabe = PruefeAufGueltigeEingabeZahl();
            }
            // erst nach Prüfung wird string eingabe in double zahl umgewandelt 
            zahl = Convert.ToDouble(eingabe);
        }
        private void GueltigeEingabeZahlOderFERTIG()
        {
            if (eingabe.ToUpper() == "FERTIG")
            {
                BenutzerWillBeenden = true;
                zahl = 0;
            }
            else
            {
                // Prüfung auf Eingabefehler keine gültige Zahl
                fehlerEingabe = PruefeAufGueltigeEingabeZahlOderFERTIG();

                while (fehlerEingabe)
                {
                    // Fehlermeldung mit Angabe, welche Eingaben möglich sind
                    GibSonstigeEingabeFehlerAus();

                    WiederholeEingabeZahl();
                    fehlerEingabe = PruefeAufGueltigeEingabeZahlOderFERTIG();
                }

                //erst nach erneuter Prüfung wird string eingabe in double zahl umgewandelt
                if (BenutzerWillBeenden == false)
                {
                    zahl = Convert.ToDouble(eingabe);
                }
                else
                {
                    zahl = 0;
                }
            }
        }

        private void GueltigerBereich()
        {
            // Prüfung auf Grenzwerte -10 bis 100
            fehlerEingabe = model.PruefeZahlAufGrenzwerte(zahl);
            while (fehlerEingabe)
            {
                GibGrenzwertFehlerAus();
                WiederholeEingabeZahl();

                //erneute Prüfung auf gültige Eingabe nötig
                GueltigeEingabeZahl();

                fehlerEingabe = model.PruefeZahlAufGrenzwerte(zahl);
            }
        }
        private void GueltigerBereichOderFERTIG()
        {
            if (eingabe.ToUpper() == "FERTIG")
            {
                BenutzerWillBeenden = true;
                zahl = 0;
            }
            else
            {
                // Prüfung auf Grenzwerte -10 bis 100
                fehlerEingabe = model.PruefeZahlAufGrenzwerte(zahl);
                while (fehlerEingabe)
                {
                    GibGrenzwertFehlerAus();
                    WiederholeEingabeZahl();

                    //erneute Prüfung auf gültige Eingabe nötig
                    GueltigeEingabeZahlOderFERTIG();

                    fehlerEingabe = model.PruefeZahlAufGrenzwerte(zahl);
                }
            }
        }

        private void GueltigOhneDivisionDurchNull()
        {
            fehlerEingabe = model.PruefeDivisionDurchNull(zahl);
            while (fehlerEingabe)
            {
                GibDivisionDurchNullFehlerAus();
                WiederholeEingabeZahl();

                // Prüfung auf gültige Eingabe nötig
                GueltigeEingabeZahl();

                // Grenzwerte -10 bis 100
                GueltigerBereich();

                fehlerEingabe = model.PruefeDivisionDurchNull(zahl);
            }
        }
        private void GueltigOhneDivisionDurchNullOderFERTIG()
        {
            if (eingabe.ToUpper() == "FERTIG")
            {
                BenutzerWillBeenden = true;
                zahl = 0;
            }
            else
            {
                fehlerEingabe = model.PruefeDivisionDurchNull(zahl);
                while (fehlerEingabe)
                {
                    GibDivisionDurchNullFehlerAus();
                    WiederholeEingabeZahl();

                    // Prüfung auf gültige Eingabe nötig
                    GueltigeEingabeZahlOderFERTIG();

                    // Grenzwerte -10 bis 100
                    GueltigerBereichOderFERTIG();

                    fehlerEingabe = model.PruefeDivisionDurchNull(zahl);
                }
            }
        }

        public bool PruefeAufGueltigeEingabeZahl()
        {
            // Prüfung auf Eingabefehler keine gültig Zahl
            if (!Double.TryParse(eingabe, out zahl))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool PruefeAufGueltigeEingabeZahlOderFERTIG()
        {
            // Prüfung auf Eingabefehler keine gültig Zahl oder FERTIG
            // nach der 1. Berechnung soll der Benutzer jederzeit aus dem Programm aussteigen können
            if (Double.TryParse(eingabe, out zahl))
            {
                return false;
            }
            else if (eingabe.ToUpper() == "FERTIG")
            {
                BenutzerWillBeenden = true;
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion
        
        #region Methoden für Ausgaben (Meldungen)
        // verschieden Methoden zum Ausgeben von Fehlermeldungen
        public void GibEingabeFehlerAus(string fehlerquelle)
        {
            Console.WriteLine("Dies ist eine falsche Eingabe {0}: {1}", fehlerquelle, eingabe);
            Console.WriteLine();
        }

        // Methode zur Ausgabe einer Fehlermeldung bei sonstigen Eingabefehlern
        public void GibSonstigeEingabeFehlerAus()
        {
            Console.WriteLine("Du musst eine gültige Gleitkommazahl eingeben");
            Console.WriteLine("Neben den Ziffern 0-9 sind lediglich die folgenden Sonderzeichen erlaubt: ,.-");
            Console.WriteLine("Dabei muss das - als erstes Zeichen vor einer Ziffer gesetzt werden");
            Console.WriteLine("Der . fungiert nur als Trennzeichen an Tausenderstellen");
            Console.WriteLine("Das , ist das Trennzeichen für die Tausenderstellen");
            Console.WriteLine("Alle drei Sonderzeichen sind optional");
            Console.WriteLine();
        }

        // Methode zur Ausgabe einer Fehlermeldung bei Grenzwertverletzung
        public void GibGrenzwertFehlerAus()
        {
            Console.WriteLine("Die eingegebene Zahl {0} liegt außerhalb des gültigen Bereichs von -10 bis 100", eingabe);
            Console.WriteLine();
        }

        // Methode zur Ausgabe einer Fehlermeldung bei Division durch 0
        public void GibDivisionDurchNullFehlerAus()
        {
            Console.WriteLine("Division durch {0} ist nicht möglich", eingabe);
            Console.WriteLine();
        }

        /// <summary>
        /// Methode zum Ausgeben des Resultats abhängig vom Operator
        /// </summary>
        public void GibResultatAus()
        {
            Console.WriteLine();
            switch (model.Operation)
            {
                case "+":
                    Console.WriteLine("Die Summe beträgt: {0}", model.Resultat);
                    break;

                case "-":
                    Console.WriteLine("Die Differenz beträgt: {0}", model.Resultat);
                    break;

                case "*":
                    Console.WriteLine("Das Produkt beträgt: {0}", model.Resultat);
                    break;

                case "/":
                    Console.WriteLine("Der Quotient beträgt: {0}", model.Resultat);
                    break;

                default:
                    // Fehlermeldung ausgeben mit Übergabe der Fehlerquelle und der falschen Eingabe
                    GibEingabeFehlerAus("für Operator "+ model.Operation);
                    break;
            }
            Console.WriteLine();
        }

        #endregion
        
        // Methode zum Beenden des Programms
        public void BeendeProgramm()
        {
            Console.WriteLine("Zum Beenden bitte return drücken");
            Console.ReadKey();
        }
    }
}

