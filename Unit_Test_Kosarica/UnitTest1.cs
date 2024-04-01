using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Kosarica;
using OOP_Vozilo;
using System;

namespace Unit_Test_Kosarica
{
    [TestClass]
    public class Podatki_testi
    {
        [TestMethod]
        public void TestMethod1()
        {
            string niz = "";
            Kosarica<string> kosarica = new Kosarica<string>(niz);
            Assert.IsTrue(kosarica.ToString().Contains(niz + ""));
        }

        [TestMethod]
        public void TestMethod2()
        {
            int stevilo = 42;
            Kosarica<int> kosarica = new Kosarica<int>(stevilo);
            Assert.IsTrue(kosarica.ToString().Contains(stevilo + ""));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Vozilo vozilo = new Vozilo(42, 4.2);
            Kosarica<Vozilo> kosarica = new Kosarica<Vozilo>(vozilo);
            Console.WriteLine(kosarica.Objekt);
            Assert.IsTrue(kosarica.ToString().Contains(vozilo + ""));
        }

        [TestMethod]
        public void TestMethod4()
        {
            double realno_st = 4.2;
            Kosarica<double> kosarica = new Kosarica<double>(realno_st);
            Assert.IsTrue(kosarica.ToString().Contains(realno_st + ""));
        }

        [TestMethod]
        public void TestMethod5()
        {
            int[] tab_celih_st = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Kosarica<int[]> kosarica = new Kosarica<int[]>(tab_celih_st);
            Assert.IsTrue(kosarica.ToString().Contains(tab_celih_st + ""));
        }
    }
}