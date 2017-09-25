using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaschenrechnerConsole
{

    class ConsoleView

    {
        // Attribut vom Typ RechnerModel - lokal
        private RechnerModel model;

        // Konstruktor initialisiert das Attribut this.model mit dem Parameter model aus der Klasse RechnerModel
        // und die Properties
        public ConsoleView(RechnerModel model)
        {
            this.model = model; // this.Attribut = Parameter
            BenutzerWillBeenden = false;
        }

        public bool BenutzerWillBeenden { get; private set; }

        // Methode zum Einlesen der ersten Eingaben von der Console
        public void HoleErsteEingabenVomBenutzer()
        {
            model.ErsteZahlAlsDouble = HoleBenutzerEingabeDouble("Bitte gib die 1. Zahl ein");
            Console.WriteLine("");

            model.Operation = HoleBenutzerEingabeString("Bitte gib an, welche Operation du durchführen möchtest (+ - * /) ");
            Console.WriteLine();

            model.ZweiteZahlAlsDouble = HoleBenutzerEingabeDouble("Bitte gib die 2. Zahl ein");
            Console.WriteLine("");
        }
        // Methode zum Einlesen der fortlaufenden Eingaben von der Console
        public void HoleFortlaufendeEingabenVomBenutzer ()
        {
            string eingabe = HoleBenutzerEingabeString("Bitte gib eine weitere Zahl zur Berechnung ein oder 'FERTIG' zum Beenden");

            if (eingabe.ToUpper() == "FERTIG")
            {
                BenutzerWillBeenden = true;
            }
            else

            {
                double zahl = Convert.ToDouble(eingabe);
                bool fehlerGrenzwert = model.PruefeZahlAufGrenzwerte(zahl);

                while (fehlerGrenzwert == true)
                {
                    GibGrenzwertFehlerAus();
                    Console.WriteLine("Bitte gib erneut eine Zahl für die Berechnung ein: ");
                    eingabe = Console.ReadLine();
                    zahl = Convert.ToDouble(eingabe);
                    fehlerGrenzwert = model.PruefeZahlAufGrenzwerte(zahl);
                }
                model.ErsteZahlAlsDouble = model.Resultat;
                model.ZweiteZahlAlsDouble = zahl;
            }
        }

        // Methode zum Einlesen von Zahl über Console und Rückgabe konvertiert in Double
        private double HoleBenutzerEingabeDouble(string text)
        {
            string eingabe;
            double zahl;
            bool fehlerGrenzwert = false;
            Console.WriteLine(text);

            eingabe = Console.ReadLine();
            // Ausnahmen werden sofort bei der Wandlung behandelt
            // Prüfung auf Grenzwerte -10 bis 100
            zahl = Convert.ToDouble(eingabe);
            fehlerGrenzwert = model.PruefeZahlAufGrenzwerte(zahl);

            while (fehlerGrenzwert)
            {
                GibGrenzwertFehlerAus();
                Console.WriteLine("Bitte gib erneut eine Zahl für die Berechnung ein: ");
                eingabe = Console.ReadLine();
                zahl = Convert.ToDouble(eingabe);
                fehlerGrenzwert = model.PruefeZahlAufGrenzwerte(zahl);
            }
            fehlerGrenzwert = false;
            while (!Double.TryParse(eingabe, out zahl))
            {
                Console.WriteLine("Du musst eine gültige Gleitkommazahl eingeben");
                Console.WriteLine("Neben den Ziffern 0-9 sind lediglich die folgenden Sonderzeichen erlaubt: ,.-");
                Console.WriteLine("Dabei muss das - als erstes Zeichen vor einer Ziffer gesetzt werden");
                Console.WriteLine("Der . fungiert nur als Trennzeichen an Tausenderstellen");
                Console.WriteLine("Das , ist das Trennzeichen für die Tausenderstellen");
                Console.WriteLine("Alle drei Sonderzeichen sind optional");
                Console.WriteLine();
                Console.WriteLine("Bitte gib erneut eine Zahl für die Berechnung ein: ");
                eingabe = Console.ReadLine();
            }
            return zahl;
        }

        // Methode zum Einlesen von Zeichenkette über Console
        private string HoleBenutzerEingabeString(string text)
        {
            Console.WriteLine(text);
            return Console.ReadLine();
        }

        // Methode zum Ausgeben einer Fehlermeldung
        public void GebeEingabeFehlerAus(string fehlerquelle, string eingabe)
        {
            Console.WriteLine("Dies ist eine falsche Eingabe {0}: {1}", fehlerquelle, eingabe);
            Console.WriteLine();
        }

        // Methode zum Ausgeben der Fehlermeldung DivisionDurchNullFehlerAus
        public void GibDivisionDurchNullFehlerAus()
        {
            Console.WriteLine("Division durch 0 ist nicht möglich");
            Console.WriteLine();
            BenutzerWillBeenden = true; // Programm nach Fehler beenden, sonst Endlosschleife
        }

        // Methode zum Ausgeben der Fehlermeldung Gib
        public void GibGrenzwertFehlerAus()
        {
            Console.WriteLine("Der Wert muss zwischen -10 und 100 liegen");
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
                    GebeEingabeFehlerAus("für Operator", model.Operation);
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
