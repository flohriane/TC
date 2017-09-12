using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaschenrechnerConsole
{
    class RechnerModel
    {
        // Prinzip "tell - don't ask" verwenden, also wenn möglich return verwenden anstatt Eigenschaften
        // Properties (Eigenschaften)
        // kann von außen nicht verändert werden, wenn private set
        public double Resultat { get; private set; } // kurze Schreibweise
        public string Operation { get; set; }
        public double ErsteZahlAlsDouble { get; set; }
        private double zweiteZahlAlsDouble;   // Attribut ist immer private

        public double ZweiteZahlAlsDouble     // Eigenschaft ist public und kommuniziert nach außen 
        {
            get { return zweiteZahlAlsDouble; }
            set { zweiteZahlAlsDouble = value; }  // volle Schreibweise für evtl. Abfrage gewählt
        }

        // Konstruktor, der die Eigenschaften initialisiert
        public RechnerModel()
        {
            Operation = "unbekannt";
            ErsteZahlAlsDouble = 0;
            ZweiteZahlAlsDouble = 0;
            Resultat = 0;
        }

        // öffetnliche Methode Berechne je nach Operator
        public void Berechne()
        {
            switch (Operation)
            {
                // Berechnung ausführen Addition
                // die Werte in ersteZahlAlsDouble und zweiteZahlAlsDouble werden an die Methode Addieren übergeben
                // nach Ausführen der Methode wird der ermittelte Wert an die Eigenschaft Resultat übergeben
                case "+":
                    Resultat = Addiere(ErsteZahlAlsDouble, ZweiteZahlAlsDouble);
                    break;

                // Berechnung ausführen Subtraktion
                case "-":
                    Resultat = Subtrahiere(ErsteZahlAlsDouble, ZweiteZahlAlsDouble);
                    break;

                // Berechnung ausführen Multiplikation
                case "*":
                    Resultat = Multipliziere(ErsteZahlAlsDouble, ZweiteZahlAlsDouble);
                    break;

                // Berechnung ausführen Division
                case "/":
                    Resultat = Dividiere(ErsteZahlAlsDouble, ZweiteZahlAlsDouble);
                    break;

                default:
                    Resultat = 0;
                    break;
            }
        }

        // private Klassen-Methoden für die Rechenarten
        // Addieren
        private double Addiere(double ersterSummand, double zweiterSummand)
        {
            double summe = ersterSummand + zweiterSummand;  // summe ist nur innerhalb der Methode Addieren gültig, könnte auch anders heißen
            return summe; // summe wird als Ergebnis an Eigenschaft Resultat zurückgegeben

            // oder kürzere Variante:
            // return ersterSummand + zweiterSummand;
        }

        // Subtrahieren
        private double Subtrahiere(double minuend, double subtrahend)
        {
            return minuend - subtrahend; // Differenz
        }

        // Multiplizieren
        private double Multipliziere(double ersterfaktor, double zweiterfaktor)
        {
            return ersterfaktor * zweiterfaktor; // Produkt
        }

        // Dividieren
        private double Dividiere(double dividend, double divisor)
        {
            return dividend / divisor; // Quotient
        }

        // öffentliche Methode PruefeDivisionDurchNull
        public bool PruefeDivisionDurchNull()
        {
            if (Operation == "/" && ZweiteZahlAlsDouble == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
