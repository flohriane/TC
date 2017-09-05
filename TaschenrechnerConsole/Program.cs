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
            // lokale Variablen anlegen
            double ersteZahlAlsDouble = 0;
            double zweiteZahlAlsDouble = 0;
            string operation = "";

            // Objekt model anlegen
            RechnerModel model = new RechnerModel(); // Aufruf Konstruktor RechnerModel ohne Übergabe

            // Objekt view anlegen und
            ConsoleView view = new ConsoleView(model); // Aufruf Konstruktor ConsoleView mit Übergabe Objekt model ???

            // Eingabe der Werte und des Operators zur Berechnung
            // Umwandlung der eingegebenen Variablen von Zeichenkette in Gleitkommazahl
            // TODO: Auslagern der Umwandlung String in Double in separater Methode, wenn Struktur umfangreicher wird

            // 1. Wert
            view.HoleBenutzerEingabe("Bitte gib die 1. Zahl zwischen -10,0 und 100,0 ein");
            ersteZahlAlsDouble = Convert.ToDouble(view.WertAlsString);

            // 2. Wert
            view.HoleBenutzerEingabe("Bitte gib die 2. Zahl zwischen -10,0 und 100,0 ein");
            zweiteZahlAlsDouble = Convert.ToDouble(view.WertAlsString);

            // Operator
            view.HoleBenutzerEingabe("Bitte gib an, welche Operation du durchführen möchtest: +  -  *  /  sind möglich");
            operation = view.WertAlsString;

            // Division durch 0 ausschließen
            if (operation == "/" && zweiteZahlAlsDouble == 0)
            {
                // Fehlermeldung ausgeben mit Übergabe der Fehlerquelle und der Fehlermeldung
                view.GebeEingabeFehlerAus("für 2. Zahl", "Division durch 0 ist nicht möglich");
            }
            else
            {
                // Berechnungen durchführen
                model.Berechne(ersteZahlAlsDouble, zweiteZahlAlsDouble, operation);

                // Ausgabe vom Ergebnis aus der Berechnung
                view.GebeResultatAus(operation);
            }       
            
            // Programm beenden
            view.HoleBenutzerEingabe("zum Beenden bitte <Return> drücken");
        }
    }
}

