using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OOP_Vozilo;

namespace Unit_Test_Vozilo
{
    [TestClass]
    public class Kapaciteta_Poraba_Testi
    {
        [DataTestMethod]
        [DataRow(60, -1)]
        [DataRow(-60, 1)]
        public void TestMethod1(double kapaciteta, double poraba)
        {
            try
            {
                Vozilo vozilo = new Vozilo(kapaciteta, poraba);
                Assert.Fail($"Ni se sprožila izjema za podatke:\nKapaciteta: {kapaciteta}\nPoraba: {poraba}!");
            }
            catch (Exception)
            {
                Assert.IsTrue(true);
            }
        }
    }

    [TestClass]
    public class Pot_testi
    {
        [TestMethod]
        public void TestMethod2()
        {
            Vozilo vozilo = new Vozilo(60, 6);
            double[] pot = new double[] { 100, 200, 0, 300, 0, 0 };
            try
            {
                vozilo.Opravi_pot(pot);
                Assert.Fail("Metoda bi morala sprožiti napako!");
            }
            catch (Exception)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void TestMethod3()
        {
            Vozilo vozilo = new Vozilo(60, 10);
            double[] pot = new double[] { 100, 300, 0, 500, 100, 0, 100 };
            Assert.IsTrue(vozilo.Opravi_pot(pot));
        }
    }
}