using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTaschenrechner
{
    class Program
    {
        static void Main(string[] args)
        {
            // User Story "Addieren": Als Anwender möchte ich 2 Zahlen eingeben und sie addieren
            Console.WriteLine("Bitte geben Sie die 1. Zahl zwischen 0 und 10 ein: ");
            string summand1 = Console.ReadLine();
            int summandInt1 = Convert.ToInt32(summand1);
            Console.WriteLine();

            Console.WriteLine("Bitte geben Sie die 2. Zahl zwischen 0 und 10 ein: ");
            string summand2 = Console.ReadLine();
            int summandInt2 = Convert.ToInt32(summand2);
            Console.WriteLine();

            int summe = summandInt1 + summandInt2;

            Console.WriteLine("Das ist die Summe aus {0} und {1}: {2}", summand1, summand2, summe);

            // die Variable summe ist überflüssig, wenn man die Ausgabe wie folgt programmiert:
            //Console.WriteLine("Das ist die Summe aus {0} und {1}: {2}", summand1, summand2, summandInt1 + summandInt2); 

            Console.ReadKey();

         }
    }
}
