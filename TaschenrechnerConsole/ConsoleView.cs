using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaschenrechnerConsole
{

    class ConsoleView

    {
        private RechnerModel model; // Attribut vom Typ RechnerModel - lokal

        // Konstruktor initialisiert das Attribut this.model mit dem Parameter model aus der Klasse RechnerModel
        public ConsoleView(RechnerModel model)
        {
            this.model = model;  
        }

        // Property (Eigenschaft) zu Eingabedaten von Console

        public string WertAlsString { get; private set; }

        //public double WertAlsDouble { get; private set; }

        private double wertAlsDouble;   // Attribut ist immer private

        public double WertAlsDouble     // Eigenschaft ist public und kommuniziert nach außen 
        {
            get { return wertAlsDouble; }
            set { wertAlsDouble = value; }
        }

        // Konstruktor, der die Eigenschaften von WertAlsString und WertAlsDouble initialisiert
        public ConsoleView()
        {
            WertAlsDouble = 0;
            WertAlsString = "default";
        }

        // Methode zum Einlesen von Zeichenkette
        public void HoleBenutzerEingabeString(string fall)
        {
            switch (fall)
            {
                case "2":
                    Console.WriteLine("Bitte gib an, welche Operation du durchführen möchtest: +  -  *  /  sind möglich");
                    WertAlsString = Console.ReadLine();
                    Console.WriteLine("");
                    break;

                case "4":
                    Console.WriteLine("zum Beenden bitte <Return> drücken");
                    Console.ReadKey();
                    break;

                default:
                    WertAlsString = "";
                    GebeEingabeFehlerAus("unerwarteter Fehler ", "Modul HoleBenutzerEingabeString");
                    break;
            }
        }
        // Methode zum Einlesen von Zeichenkette und Rückgabe von Double
        public void HoleBenutzerEingabeDouble(string fall)
        {switch (fall)
            {
                case "1":
                    Console.WriteLine("Bitte gib die 1.Zahl zwischen - 10, 0 und 100, 0 ein");
                    WertAlsDouble = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("");
                    break;

                 case "3":
                    Console.WriteLine("Bitte gib die 2.Zahl zwischen - 10, 0 und 100, 0 ein");
                    WertAlsDouble = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("");
                    break;

                default:
                    WertAlsDouble = 0;
                    GebeEingabeFehlerAus("unerwarteter Fehler ", "Modul HoleBenutzerEingabeDouble");
                    break;
            }
        }

        // Methode zum Ausgeben einer Fehlermeldung
        public void GebeEingabeFehlerAus(string fehlerquelle, string eingabe)
        {
            Console.WriteLine("Dies ist eine falsche Eingabe {0}: {1}", fehlerquelle, eingabe);
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
    }
}
