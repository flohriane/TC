using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaschenrechnerConsole
{

    class ConsoleView

    {
        // Properties (Eigenschaften) zu Eingabedaten von Console
        public string Operation { get; private set; } // Kurzschreibweise
        public double ErsteZahlAlsDouble { get; private set; }
        private double zweiteZahlAlsDouble;   // Attribut ist immer private

        public double ZweiteZahlAlsDouble     // Eigenschaft ist public und kommuniziert nach außen 
        {
            get { return zweiteZahlAlsDouble; }
            set { zweiteZahlAlsDouble = value; }  // volle Schreibweise für evtl. Abfrage gewählt
        }

        // Attribut vom Typ RechnerModel - lokal
        private RechnerModel model; 

        // Konstruktor initialisiert das Attribut this.model mit dem Parameter model aus der Klasse RechnerModel
        // und die Properties
        public ConsoleView(RechnerModel model)
        {
            this.model = model;
            ErsteZahlAlsDouble = 0;
            ZweiteZahlAlsDouble = 0;
            Operation = "default";
        }

        // Methode zum Einlesen sämtlicher Eingaben von der Console
        public void HoleBenutzerEingaben ()
        {
            ErsteZahlAlsDouble = HoleBenutzerEingabeDouble("Bitte gib die 1. Zahl zwischen - 10, 0 und 100, 0 ein ");
            Console.WriteLine("");

            Operation = HoleBenutzerEingabeString("Bitte gib an, welche Operation du durchführen möchtest (+ - * /) ");
            Console.WriteLine();

            ZweiteZahlAlsDouble = HoleBenutzerEingabeDouble("Bitte gib die 2. Zahl zwischen - 10, 0 und 100, 0 ein ");
            Console.WriteLine("");
        }

        // Methode zum Einlesen von Zahl über Console und Rückgabe konvertiert in Double
        private double HoleBenutzerEingabeDouble(string text)
        {
            Console.WriteLine(text);
            return Convert.ToDouble(Console.ReadLine());
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
        public void GebeDivisionDurchNullFehlerAus()
        {
            Console.WriteLine("Division durch 0 ist nicht möglich");
            Console.WriteLine();
        }

        // Methode zum Ausgeben des Resultats
        public void GebeResultatAus()
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
            Console.WriteLine("Zum Beenden bitte ein Zeichen eingeben");
            Console.ReadLine();
        }
    }
}
