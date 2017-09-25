using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaschenrechnerConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaschenrechnerConsole.Tests
{
    [TestClass()]
    public class RechnerModelTests
    {
        [TestMethod()]
        public void Berechne_DivisionDurchNull_ErgibtUnendlich() 
        {
            RechnerModel model = new RechnerModel();

            model.Operation = "/";
            model.ErsteZahlAlsDouble = 10;
            model.ZweiteZahlAlsDouble = 0;

            model.Berechne();

            Assert.AreEqual(Double.PositiveInfinity, model.Resultat);
        }
    }
}