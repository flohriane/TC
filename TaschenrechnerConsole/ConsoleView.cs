using System;
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
                model.ErsteZahlAlsDouble = model.Resultat;
                model.ZweiteZahlAlsDouble = Convert.ToDouble(eingabe);
            }
        }

        // Methode zum Einlesen von Zahl über Console und Rückgabe konvertiert in Double
        private double HoleBenutzerEingabeDouble(string text)
        {
            Console.WriteLine(text);
            string zahl = Console.ReadLine();
            return Convert.ToDouble(zahl);
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
