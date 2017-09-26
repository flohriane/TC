using System;

namespace TaschenrechnerConsole
{

    class ConsoleView

    {
        // Attribut vom Typ RechnerModel - lokal
        private RechnerModel model;

        // Variablen zur Verwendung für alle Methoden
        private string eingabe ="";
        private double zahl = 0;
        // Variable für Eingabefehler, die in den Methoden behandelt werden
        private bool fehlerEingabe = false;

        public bool BenutzerWillBeenden { get; private set; }

        // Konstruktor initialisiert das Attribut this.model mit dem Parameter model aus der Klasse RechnerModel
        // und die Properties
        public ConsoleView(RechnerModel model)
        {
            this.model = model; // this.Attribut = Parameter
            BenutzerWillBeenden = false;
        }

        // Methode zum Einlesen der ersten Eingaben von der Console
        public void HoleErsteEingabenVomBenutzer()
        {
            model.ErsteZahlAlsDouble = HoleBenutzerEingabeDouble("Bitte gib die 1. Zahl ein");
            Console.WriteLine("");

            model.Operation = HoleBenutzerEingabeOperator("Bitte gib an, welche Operation du durchführen möchtest (+ - * /) ");
            Console.WriteLine();

            model.ZweiteZahlAlsDouble = HoleBenutzerEingabeDouble("Bitte gib die 2. Zahl ein");
            Console.WriteLine("");
        }
        // Methode zum Einlesen der fortlaufenden Eingaben von der Console
        public void HoleFortlaufendeEingabenVomBenutzer ()
        {
            eingabe = HoleBenutzerEingabeString("Bitte gib eine weitere Zahl zur Berechnung ein oder 'FERTIG' zum Beenden");

            if (eingabe.ToUpper() == "FERTIG")
            {
                BenutzerWillBeenden = true;
            }
            else
            {
                // Prüfung auf sonstige Eingabefehler
                while (!Double.TryParse(eingabe, out zahl)) // andere Methode, um string in double umzuwandeln
                {
                    Console.WriteLine("Du musst eine gültige Gleitkommazahl eingeben");
                    Console.WriteLine("Neben den Ziffern 0-9 sind lediglich die folgenden Sonderzeichen erlaubt: ,.-");
                    Console.WriteLine("Dabei muss das - als erstes Zeichen vor einer Ziffer gesetzt werden");
                    Console.WriteLine("Der . fungiert nur als Trennzeichen an Tausenderstellen");
                    Console.WriteLine("Das , ist das Trennzeichen für die Tausenderstellen");
                    Console.WriteLine("Alle drei Sonderzeichen sind optional");
                    Console.WriteLine();
                    wiederholeEingabe();
                }

                zahl = Convert.ToDouble(eingabe);

                // Prüfung auf Grenzwertverletzung    
                fehlerEingabe = model.PruefeZahlAufGrenzwerte(zahl);
                while (fehlerEingabe)
                {
                    GibEingabeFehlerAus(eingabe, "Grenzwerte -10 und 100 beachten!");
                    wiederholeEingabe();
                    fehlerEingabe = model.PruefeZahlAufGrenzwerte(zahl);
                }

                // Prüfung auf Division durch 0
                fehlerEingabe = model.PruefeDivisionDurchNull(zahl);
                while (fehlerEingabe)
                {
                    GibEingabeFehlerAus("Division durch 0 ist nicht möglich!", eingabe);
                    wiederholeEingabe();
                    fehlerEingabe = model.PruefeDivisionDurchNull(zahl);
                }
                fehlerEingabe = false;

                model.ErsteZahlAlsDouble = model.Resultat;
                model.ZweiteZahlAlsDouble = zahl;
            }
        }

        // Methode zum Einlesen von Zahl über Console und Rückgabe konvertiert in double
        private double HoleBenutzerEingabeDouble(string text)
        {
            fehlerEingabe = false;

            Console.WriteLine(text);
            eingabe = Console.ReadLine();

            // Ausnahmen werden sofort bei der Wandlung behandelt
            // Prüfung auf sonstige Eingabefehler
            while (!Double.TryParse(eingabe, out zahl)) // andere Methode, um string in double umzuwandeln
            {
                Console.WriteLine("Du musst eine gültige Gleitkommazahl eingeben");
                Console.WriteLine("Neben den Ziffern 0-9 sind lediglich die folgenden Sonderzeichen erlaubt: ,.-");
                Console.WriteLine("Dabei muss das - als erstes Zeichen vor einer Ziffer gesetzt werden");
                Console.WriteLine("Der . fungiert nur als Trennzeichen an Tausenderstellen");
                Console.WriteLine("Das , ist das Trennzeichen für die Tausenderstellen");
                Console.WriteLine("Alle drei Sonderzeichen sind optional");
                Console.WriteLine();
                wiederholeEingabe();
            }
            // Konvertierung der eingegebenen Zahl vom string Format in double Format
            zahl = Convert.ToDouble(eingabe);

            // Prüfung auf Grenzwerte -10 bis 100
            fehlerEingabe = model.PruefeZahlAufGrenzwerte(zahl);
            while (fehlerEingabe)
            {
                GibEingabeFehlerAus(eingabe, "Grenzwerte -10 und 100 beachten!");
                wiederholeEingabe();
                fehlerEingabe = model.PruefeZahlAufGrenzwerte(zahl);
            }

            // Prüfung auf Division durch 0
            fehlerEingabe = model.PruefeDivisionDurchNull(zahl);
            while (fehlerEingabe)
            {
                GibEingabeFehlerAus("Division durch 0 ist nicht möglich!", eingabe);
                wiederholeEingabe();
                fehlerEingabe = model.PruefeDivisionDurchNull(zahl);
            }
            fehlerEingabe = false;

            return zahl;
        }

        // Methode zum Einlesen von einem Operator über Console
        private string HoleBenutzerEingabeOperator(string text)
        {
            Console.WriteLine(text);
            eingabe = Console.ReadLine();
            fehlerEingabe = model.PruefeOperator(eingabe);

            while (fehlerEingabe)
            {
                Console.WriteLine("Bitte gib erneut einen gültigen Operator ein: ");
                eingabe = Console.ReadLine();
                fehlerEingabe = model.PruefeOperator(eingabe);
            }
            fehlerEingabe = false;
            return eingabe;
        }

        // Methode zum Einlesen von einer Zeichenkette über Console
        private string HoleBenutzerEingabeString(string text)
        {
            Console.WriteLine(text);
            eingabe = Console.ReadLine();
            return eingabe;
        }

        // Methode, um die Eingabe zu wiederholen und die Umwandlung von string in double zu erledigen
        public void wiederholeEingabe()
        {
            Console.WriteLine("Bitte gib erneut eine Zahl für die Berechnung ein: ");
            eingabe = Console.ReadLine();
            zahl = Convert.ToDouble(eingabe);
        }

        // Methoden zum Ausgeben einer Fehlermeldung
        public void GibEingabeFehlerAus(string fehlerquelle, string falscheEingabe)
        {
            Console.WriteLine("Dies ist eine falsche Eingabe {0}: {1}", fehlerquelle, falscheEingabe);
            Console.WriteLine();
        }

        // Methode zum Ausgeben des Resultats
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
                    GibEingabeFehlerAus("für Operator", model.Operation);
                    break;
            }
            Console.WriteLine();
        }

        // Methode zum Beenden des Programms
        public void BeendeProgramm()
        {
            Console.WriteLine("Zum Beenden bitte return drücken");
            Console.ReadKey();
        }
    }
}
