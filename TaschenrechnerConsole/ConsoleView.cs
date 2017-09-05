using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaschenrechnerConsole
{

    class ConsoleView

    {
        // Property (Eigenschaft) zu Eingabedaten von Console
        public string WertAlsString { get; private set; }

        // Konstruktor, der die Eigenschaft WertAlsString initialisiert
        public ConsoleView()
        {
            WertAlsString = "default";
        }

        //Methode zum Einlesen von Zeichenkette
        public void HoleBenutzerEingabe(string ausgabeText)
        {
            Console.WriteLine(ausgabeText);
            WertAlsString = Console.ReadLine();
            Console.WriteLine();
        }

        // Methode zum Ausgeben einer Fehlermeldung
        public void GebeEingabeFehlerAus(string fehlerquelle, string eingabe)
        {
            Console.WriteLine("Dies ist eine falsche Eingabe {0}: {1}", fehlerquelle, eingabe);
            Console.WriteLine();
        }

        // Methode zum Ausgeben des Resultats
        public void GebeResultatAus(string operation, double resultat)
        {
            Console.WriteLine();
            switch (operation)
            {
                case "+":
                    Console.WriteLine("Die Summe beträgt: {0}", resultat);
                    break;

                case "-":
                    Console.WriteLine("Die Differenz beträgt: {0}", resultat);
                    break;

                case "*":
                    Console.WriteLine("Das Produkt beträgt: {0}", resultat);
                    break;

                case "/":
                    Console.WriteLine("Der Quotient beträgt: {0}", resultat);
                    break;

                default:
                    // Fehlermeldung ausgeben mit Übergabe der Fehlerquelle und der falschen Eingabe
                    GebeEingabeFehlerAus("für Operator", operation);
                    break;
            }
        }
    }
}
