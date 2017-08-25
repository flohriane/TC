using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaschenrechnerConsole
{
    class Program

    {
        // Methode definieren in 7 Schritten
        // Modifizierer definieren
        // Datentyp des Rückabewertes definieren
        // Methodennamen definieren (mit Großbuchstaben beginnen)
        // runde Klammern an den Methodennnamen anfügen
        // überlegen, welche Parameter benötigt werden (optional: diese definieren)
        // geschweifte Klammern einfügen
        // Methode implementieren (Anweisungen in den Methodenrumpf schreiben)
        // Commit in Git

        static string HoleSummanden(string ausgabeText)
        {
            Console.WriteLine(ausgabeText);
            string summand = Console.ReadLine();
            Console.WriteLine();

            return summand; // return muss immer die letzte Anweisung in einer Methode sein
        }

        static void Main(string[] args)
        {
            // User Story "Addieren": Als Anwender möchte ich 2 Gleitkommazahlen zwischen 0,0 und 10,0 eingeben und sie addieren
            string summand1 = HoleSummanden("Bitte gib die 1. Zahl zwischen -10,0 und 100,0 ein");
            string summand2 = HoleSummanden("Bitte gib die 2. Zahl zwischen -10,0 und 100,0 ein");

            // Umwandlung der eingegebenen Variablen von Zeichenkette in Gleitkommazahl
            double summandDouble1 = Convert.ToDouble(summand1);
            double summandDouble2 = Convert.ToDouble(summand2);

            // Berechnung ausführen Addition
            // die Werte in summandDouble1 und summandDouble2 werden an die Methode Addieren übergeben
            // nach Ausführen der Methode wird der ermittelte Wert an die Variable summe übergeben
            double summe = Addiere(summandDouble1, summandDouble2); 

            // Ausgabe
            Console.WriteLine("Das ist die Summe aus {0} und {1}: {2}", summand1, summand2, summe);

            WarteAufBenutzereingabe();
         }
        // Methode zum Beenden der Consolenanwendung mit <Return>
        static void WarteAufBenutzereingabe()
        {
            Console.WriteLine();
            Console.WriteLine("zum Beenden bitte <return> drücken");
            Console.ReadLine();
        }
        // Methode Addiere für 2 Summanden
        static double Addiere(double ersterSummand, double zweiterSummand) // übernimmt die Werte aus summandDouble1 und summandDouble2
        {
            double summe = ersterSummand + zweiterSummand;  // summe ist nur innerhalb der Methode Addieren gültig, könnte auch anders heißen

            return summe; // summe wird als Ergebnis an summe zurückgegeben
        }
    }
}
