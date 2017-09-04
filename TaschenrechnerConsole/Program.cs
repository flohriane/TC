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
            double resultat = 0;
            double ersteZahlAlsDouble = 0;
            double zweiteZahlAlsDouble = 0;

            // Eingabe der zwei Zahlen, die verarbeitet werden sollen
            string ersteZahlAlsString = HoleBenutzerEingabe("Bitte gib die 1. Zahl zwischen -10,0 und 100,0 ein");
            string zweiteZahlAlsString = HoleBenutzerEingabe("Bitte gib die 2. Zahl zwischen -10,0 und 100,0 ein");

            // Eingabe des Operators
            string operation = HoleBenutzerEingabe("Bitte gib an, welche Operation du durchführen möchtest: +  -  *  /  sind möglich");

            // Umwandlung der eingegebenen Variablen von Zeichenkette in Gleitkommazahl
            // TODO: Auslagern in Methode, wenn Struktur umfangreicher wird
            ersteZahlAlsDouble = Convert.ToDouble(ersteZahlAlsString);
            zweiteZahlAlsDouble = Convert.ToDouble(zweiteZahlAlsString);

            // Division durch 0 ausschließen
            if (operation == "/" && zweiteZahlAlsDouble == 0)
            {
                // Fehlermeldung ausgeben
                GebeEingabeFehlerAus("für 2. Zahl", "Division durch 0 ist nicht möglich");
            }
            else
            {
                // Berechnungen durchführen
                RechnerModel model = new RechnerModel();
                resultat = model.Berechne(ersteZahlAlsDouble, zweiteZahlAlsDouble, operation);

                // Ausgabe vom Ergebnis aus der Berechnung
                //Console.WriteLine("Das ist das Resultat {0}", resultat);
                GebeResultatAus(operation, resultat);
            }
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
 
        // Methode Ausgabe Resultat
        static void GebeResultatAus(string operation, double resultat)
        {
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
                    // Eingabefehler wird abgefangen
                    GebeEingabeFehlerAus("für Operator", operation);
                    break;
            }
            Console.WriteLine();
        }

        // Methode Ausgabe Eingabefehler
        static void GebeEingabeFehlerAus(string fehlerquelle, string eingabe)
        {
            Console.WriteLine("Dies ist eine falsche Eingabe {0}: {1}", fehlerquelle, eingabe);
            Console.WriteLine();
        }
    }
}

