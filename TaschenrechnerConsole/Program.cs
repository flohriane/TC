using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaschenrechnerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // User Story "Addieren": Als Anwender möchte ich 2 Gleitkommazahlen zwischen 0,0 und 10,0 eingeben und sie addieren
            Console.WriteLine("Bitte geben Sie die 1. Zahl zwischen 0,0 und 10,0 ein: ");
            string summand1 = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Bitte geben Sie die 2. Zahl zwischen 0,0 und 10,0 ein: ");
            string summand2 = Console.ReadLine();
            Console.WriteLine();

            // Umwandlung der eingegebenen Variablen von Zeichenkette in Gleitkommazahl

            double summandDouble1 = Convert.ToDouble(summand1);
            double summandDouble2 = Convert.ToDouble(summand2);

            // Berechnung ausführen Addition

            double summe = Addiere(summandDouble1, summandDouble2);

            // Ausgabe

            Console.WriteLine("Das ist die Summe aus {0} und {1}: {2}", summand1, summand2, summe);

            // die Variable summe ist überflüssig, wenn man die Ausgabe wie folgt programmiert:
            //Console.WriteLine("Das ist die Summe aus {0} und {1}: {2}", summand1, summand2, summandDouble1 + summandDouble2); 

            WarteAufBenutzereingabe();
         }
        static void WarteAufBenutzereingabe()
        {
            Console.WriteLine();
            Console.WriteLine("zum Beenden bitte return drücken");
            Console.ReadLine();
        }
        static double Addiere(double ersterSummand, double zweiterSummand)
        {
            double summe = ersterSummand + zweiterSummand;

            return summe;
        }
    }
}
