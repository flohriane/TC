using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaschenrechnerConsole
{
    class AnwendungsController
    {
        // Attribute
        private ConsoleView view;
        private RechnerModel model;
        
        // Konstruktor zur Initialisierung der Attribute
        public AnwendungsController(ConsoleView view, RechnerModel model)
        {
            this.view = view;
            this.model = model;
        }

        // lokale Variablen anlegen
        double ersteZahlAlsDouble = 0;
        double zweiteZahlAlsDouble = 0;
        string operation = "";
        bool divisionDurchNull = false;

        public void Ausfuehren()

        {
            // Aufruf Methode zur Eingabe der Werte und des Operators zur Berechnung

            // 1. Wert
            view.HoleBenutzerEingabeDouble("1");
            ersteZahlAlsDouble = view.WertAlsDouble;

            // Operator
            view.HoleBenutzerEingabeString("2");
            operation = view.WertAlsString;

            // 2. Wert
            view.HoleBenutzerEingabeDouble("3");
            zweiteZahlAlsDouble = view.WertAlsDouble;

            // Division durch 0 ausschließen
            divisionDurchNull = model.PruefeDivisionDurchNull(operation, zweiteZahlAlsDouble);

            if ( divisionDurchNull == true)
            {
                view.DivisionDurchNullFehlerAus();
            }
            else
                {
                    // Berechnungen durchführen
                    model.Berechne(ersteZahlAlsDouble, zweiteZahlAlsDouble, operation);

                    // Ausgabe vom Ergebnis aus der Berechnung
                    view.GebeResultatAus();
                }

            // Programm beenden
            view.HoleBenutzerEingabeString("4");

        }
    }
}
