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

  
        static void Main(string[] args)
        {
            // User Story "Addieren": Als Anwender möchte ich 2 Gleitkommazahlen zwischen 0,0 und 10,0 eingeben und sie addieren

            string ersteZahlAlsString = HoleBenutzerEingabe("Bitte gib die 1. Zahl zwischen -10,0 und 100,0 ein");
            string zweiteZahlAlsString = HoleBenutzerEingabe("Bitte gib die 2. Zahl zwischen -10,0 und 100,0 ein");

            // Umwandlung der eingegebenen Variablen von Zeichenkette in Gleitkommazahl
            // TODO: Auslagern in Methode, wenn Struktur umfangreicher wird
            double ersteZahlAlsDouble = Convert.ToDouble(ersteZahlAlsString);
            double zweiteZahlAlsDouble = Convert.ToDouble(zweiteZahlAlsString);

            // Berechnung ausführen Addition
            // die Werte in ersteZahlAlsDouble und zweiteZahlAlsDouble werden an die Methode Addieren übergeben
            // nach Ausführen der Methode wird der ermittelte Wert an die Variable summe übergeben
            double summe = Addiere(ersteZahlAlsDouble, zweiteZahlAlsDouble); 

            // Ausgabe
            Console.WriteLine("Das ist die Summe aus {0} und {1}: {2}", ersteZahlAlsString, zweiteZahlAlsString, summe);

            // Programm beenden
            HoleBenutzerEingabe("zum Beenden bitte <return> drücken");
         }

        // Methode zum Einlesen von Zeichenkette
        static string HoleBenutzerEingabe(string ausgabeText)
        {
            Console.WriteLine(ausgabeText);
            string summand = Console.ReadLine();
            Console.WriteLine();

            return summand; // return muss immer die letzte Anweisung in einer Methode sein
        }

        // Methode Addiere für 2 Summanden
        static double Addiere(double ersterSummand, double zweiterSummand) // übernimmt die Werte aus ersteZahlAlsDouble und zweiteZahlAlsDouble
        {
            double summe = ersterSummand + zweiterSummand;  // summe ist nur innerhalb der Methode Addieren gültig, könnte auch anders heißen

            return summe; // summe wird als Ergebnis an summe zurückgegeben
        }

        // Methode Subtrahiere für 2 Werte
        static double Subtrahiere(double minuend, double subtrahend)
        {
            double differenz = minuend - subtrahend;

            return differenz;
        }
    }
}
