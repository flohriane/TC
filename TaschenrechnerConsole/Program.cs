﻿using System;
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
            string operation = HoleBenutzerEingabe("Bitte gib an, welche Operation du durchführen möchtest: +  -  *  /  sind möglich");

            if (operation != "+" && operation != "-" && operation != "*" && operation != "/")
            {
                // Eingabefehler bei Operator wird abgefangen
                Console.WriteLine("falsche Eingabe bei Operator");
                Console.WriteLine("");
            }
            else
            {
                // Berechnungen durchführen
                resultat = Berechne(operation);

                // Ausgabe vom Ergebnis aus der Berechnung
                Console.WriteLine("Das ist das Resultat {0}", resultat);
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

        // Methode Multipliziere für 2 Werte
        static double Multipliziere(double ersterfaktor, double zweiterfaktor)
        {
            double produkt = ersterfaktor * zweiterfaktor;
            return produkt;
        }

        // Methode Dividiere für 2 Werte
        static double Dividiere(double dividend, double divisor)
        {
            double quotient = dividend / divisor;
            return quotient;
        }

        // Methode Berechnungen je nach Operator
        static double Berechne(string operation)
        {
            double resultat = 0;
            double ersteZahlAlsDouble = 0;
            double zweiteZahlAlsDouble = 0;

            // Eingabe der zwei Zahlen, die verarbeitet werden sollen
            string ersteZahlAlsString = HoleBenutzerEingabe("Bitte gib die 1. Zahl zwischen -10,0 und 100,0 ein");
            string zweiteZahlAlsString = HoleBenutzerEingabe("Bitte gib die 2. Zahl zwischen -10,0 und 100,0 ein");

            // Umwandlung der eingegebenen Variablen von Zeichenkette in Gleitkommazahl
            // TODO: Auslagern in Methode, wenn Struktur umfangreicher wird
            ersteZahlAlsDouble = Convert.ToDouble(ersteZahlAlsString);
            zweiteZahlAlsDouble = Convert.ToDouble(zweiteZahlAlsString);

            switch (operation)
            {
                // Berechnung ausführen Addition
                // die Werte in ersteZahlAlsDouble und zweiteZahlAlsDouble werden an die Methode Addieren übergeben
                // nach Ausführen der Methode wird der ermittelte Wert an die Variable resultat übergeben
                case "+":
                    resultat = Addiere(ersteZahlAlsDouble, zweiteZahlAlsDouble);
                    break;

                // Berechnung ausführen Subtraktion
                case "-":
                    resultat = Subtrahiere(ersteZahlAlsDouble, zweiteZahlAlsDouble);
                    break;

                // Berechnung ausführen Multiplikation
                case "*":
                    resultat = Multipliziere(ersteZahlAlsDouble, zweiteZahlAlsDouble);
                    break;

                // Berechnung ausführen Division
                case "/":
                    if (zweiteZahlAlsDouble == 0)
                    {
                        Console.WriteLine("Division durch 0 nicht möglich");
                        resultat = 0;
                    }
                    else
                    {
                        resultat = Dividiere(ersteZahlAlsDouble, zweiteZahlAlsDouble);
                    }
                    break;

                default:
                    // zur Sicherheit wird ein unerwarteter Fehler abgefangen
                    Console.WriteLine("unerwarteter Fehler bei Eingabe Operator");
                    break;
            }
            return resultat;
        }
    }
}
