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
            // Objekte (Instanzen) anlegen
            RechnerModel model = new RechnerModel(); // Aufruf Konstruktor RechnerModel ohne Übergabe
            ConsoleView view = new ConsoleView(model); // Aufruf Konstruktor ConsoleView mit Übergabe Objekt model
            AnwendungsController controller = new AnwendungsController(view, model); // Aufruf Konstruktor AnwendungsController mit Übergabe der Objekte view und model

            controller.Ausfuehren();
        }
    }
}

