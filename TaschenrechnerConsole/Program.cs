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

            // Objekt eingabefehler anlegen
            ConsoleView eingabefehler = new ConsoleView();

            // Objekt eingabe anlegen
            ConsoleView eingabe = new ConsoleView();

            // Eingabe der Werte und des Operators zur Berechnung
            // Umwandlung der eingegebenen Variablen von Zeichenkette in Gleitkommazahl
            // TODO: Auslagern der Umwandlung String in Double in separater Methode, wenn Struktur umfangreicher wird

            // 1. Wert
            eingabe.HoleBenutzerEingabe("Bitte gib die 1. Zahl zwischen -10,0 und 100,0 ein");
            ersteZahlAlsDouble = Convert.ToDouble(eingabe.WertAlsString);

            // 2. Wert
            eingabe.HoleBenutzerEingabe("Bitte gib die 2. Zahl zwischen -10,0 und 100,0 ein");
            zweiteZahlAlsDouble = Convert.ToDouble(eingabe.WertAlsString);

            // Operator
            eingabe.HoleBenutzerEingabe("Bitte gib an, welche Operation du durchführen möchtest: +  -  *  /  sind möglich");
            operation = eingabe.WertAlsString;

            // Division durch 0 ausschließen
            if (operation == "/" && zweiteZahlAlsDouble == 0)
            {
                // Fehlermeldung ausgeben mit Übergabe der Fehlerquelle und der Fehlermeldung
                eingabefehler.GebeEingabeFehlerAus("für 2. Zahl", "Division durch 0 ist nicht möglich");
            }
            else
            {
                // Berechnungen durchführen
                RechnerModel model = new RechnerModel();
                model.Berechne(ersteZahlAlsDouble, zweiteZahlAlsDouble, operation);

                // Ausgabe vom Ergebnis aus der Berechnung
                ConsoleView ausgabe = new ConsoleView();
                ausgabe.GebeResultatAus(operation, model.Resultat);
            }       
            
            // Programm beenden
            eingabe.HoleBenutzerEingabe("zum Beenden bitte <Fertig> eingeben");
        }
    }
}

