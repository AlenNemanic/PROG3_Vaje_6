using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OOP_Racun;

namespace Unit_Test_Racun
{
    [TestClass]
    public class Napacni_parametri
    {
        [DataTestMethod]
        [DataRow("EUR", 0)]
        [DataRow("", 1)]
        public void TestMethod1(string valuta, double tecaj)
        {
            try
            {
                Racun racun = new Racun(valuta, tecaj);
                Assert.Fail("Nisi se sprožila izjema");
            }
            catch (Exception)
            {
                Assert.IsTrue(true);
            }
        }
    }

    [TestClass]
    public class Stanje_polog_in_dvig
    {
        [TestMethod]
        public void TestMethod1()
        {
            Racun racun = new Racun("Dolar", 0.93);
            Assert.AreEqual(racun.Stanje_EUR, 0);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Racun racun = new Racun("Dolar", 0.93);
            racun.Polog(1234);
            Assert.AreEqual(racun.Stanje_EUR, 1234);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Racun racun = new Racun("Dolar", 0.93);
            racun.Polog(1234);
            racun.Dvig(234);
            Assert.AreEqual(racun.Stanje_EUR, 1000);
        }

        [TestMethod]
        public void TestMethod4()
        {
            try
            {
                Racun racun = new Racun("Dolar", 0.93);
                racun.Polog(234);
                racun.Dvig(1234);
                Assert.Fail("Nisi se sprožila izjema");
            }
            catch (Exception)
            {
                Assert.IsTrue(true);
            }
        }
    }
}