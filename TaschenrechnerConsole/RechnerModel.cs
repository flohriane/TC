using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaschenrechnerConsole
{
    class RechnerModel
    {
        // Property (Eigenschaft) zur Übergabe des Resultats
        // kann von außen nicht verändert werden - private set
        public double Resultat { get; private set; }

        // Konstruktor, der die Eigenschaft Resultat initialisiert
        public RechnerModel()
        {
            Resultat = 0;
        }

        // Methode Berechne je nach Operator
        public void Berechne(double ersteZahlAlsDouble, double zweiteZahlAlsDouble, string operation)
        {
            switch (operation)
            {
                // Berechnung ausführen Addition
                // die Werte in ersteZahlAlsDouble und zweiteZahlAlsDouble werden an die Methode Addieren übergeben
                // nach Ausführen der Methode wird der ermittelte Wert an die Eigenschaft Resultat übergeben
                case "+":
                    Resultat = Addiere(ersteZahlAlsDouble, zweiteZahlAlsDouble);
                    break;

                // Berechnung ausführen Subtraktion
                case "-":
                    Resultat = Subtrahiere(ersteZahlAlsDouble, zweiteZahlAlsDouble);
                    break;

                // Berechnung ausführen Multiplikation
                case "*":
                    Resultat = Multipliziere(ersteZahlAlsDouble, zweiteZahlAlsDouble);
                    break;

                // Berechnung ausführen Division
                case "/":
                    Resultat = Dividiere(ersteZahlAlsDouble, zweiteZahlAlsDouble);
                    break;

                default:
                    Resultat = 0;
                    break;
            }
        }

        // Methode Addiere für 2 Summanden
        private double Addiere(double ersterSummand, double zweiterSummand)
        {
            double summe = ersterSummand + zweiterSummand;  // summe ist nur innerhalb der Methode Addieren gültig, könnte auch anders heißen
            return summe; // summe wird als Ergebnis an Eigenschaft Resultat zurückgegeben

            // oder kürzere Variante:
            // return ersterSummand + zweiterSummand;
        }

        // Methode Subtrahiere für 2 Werte
        private double Subtrahiere(double minuend, double subtrahend)
        {
            return minuend - subtrahend; // Differenz
        }

        // Methode Multipliziere für 2 Werte
        private double Multipliziere(double ersterfaktor, double zweiterfaktor)
        {
            return ersterfaktor * zweiterfaktor; // Produkt
        }

        // Methode Dividiere für 2 Werte
        private double Dividiere(double dividend, double divisor)
        {
            return dividend / divisor; // Quotient
        }
    }
}
