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
            view.HoleBenutzerEingaben();

            // Division durch 0 ausschließen
            if (model.PruefeDivisionDurchNull(view.ZweiteZahlAlsDouble, view.Operation) == true)
            {
                view.DivisionDurchNullFehlerAus();
            }
            else
                {
                    // Berechnungen durchführen
                    model.Berechne(view.ErsteZahlAlsDouble, view.ZweiteZahlAlsDouble, view.Operation);

                    // Ausgabe vom Ergebnis aus der Berechnung
                    view.GebeResultatAus();
                }

            // Programm beenden
            view.BeendeProgramm();
        }
    }
}
