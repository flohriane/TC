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

        public void Ausfuehren()
        {
                // Eingabewerte 1.Zahl, 2.Zahl, Operator holen
                view.HoleErsteEingabenVomBenutzer();

            // Division durch 0 ausschließen
            if (model.PruefeDivisionDurchNull() == true)
            {
                view.GebeDivisionDurchNullFehlerAus();
            }
            else
            {
                // Berechnungen durchführen
                model.Berechne();

                // Ausgabe vom Ergebnis aus der Berechnung
                view.GebeResultatAus();
            }

            view.HoleFortlaufendeEingabenVomBenutzer();

            while (!view.BenutzerWillBeenden)
            {
                model.Berechne();
                view.GebeResultatAus();
                view.HoleFortlaufendeEingabenVomBenutzer();
            }


            // Programm beenden
            view.BeendeProgramm();
        }
    }
}
