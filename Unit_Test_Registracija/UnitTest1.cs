using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OOP_Regristracija;
using System.Collections.Generic;

namespace Unit_Test_Registracija
{
    [TestClass]
    public class Napacni_parametri
    {
        [DataTestMethod]
        [DataRow("", "12345")]
        [DataRow("L", "12345")]
        [DataRow("Ljubljana", "12345")]
        [DataRow("LĐ", "12345")]
        [DataRow("LJ", "123456")]
        [DataRow("LJ", "1234")]
        [DataRow("LJ", "1234Đ")]
        [DataRow("LJ", "")]
        public void TestMethod1(string obmocje, string reg_stevilka)
        {
            try
            {
                Registracija registrska = new Registracija(obmocje, reg_stevilka);
                Assert.Fail("Nisi se sprožila izjema");
            }
            catch (Exception)
            {
                Assert.IsTrue(true);
            }
        }
    }

    [TestClass]
    public class Obmocja
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                Registracija registrska1 = new Registracija("LJ", "12345");
                Registracija.Odstrani_obmocje("LJ");
                Registracija registrska2 = new Registracija("LJ", "12345");
                Assert.Fail("Nisi se sprožila izjema");
            }
            catch (Exception)
            {
                Assert.IsTrue(true);
            }
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow("LJ")]
        [DataRow("Ljubljana")]
        public void TestMethod2(string obmocje)
        {
            Registracija.Ponastavi_obmocja();
            try
            {
                Registracija.Dodaj_obmocje(obmocje);
                Assert.Fail("Nisi se sprožila izjema");
            }
            catch (Exception)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void TestMethod3()
        {
            Registracija.Ponastavi_obmocja();
            try
            {
                Registracija.Odstrani_obmocje("LJ");
                Registracija.Odstrani_obmocje("LJ");
                Assert.Fail("Nisi se sprožila izjema");
            }
            catch (Exception)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void TestMethod4()
        {
            Registracija.Ponastavi_obmocja();
            int ind = 0;
            Registracija[] tabela_registrskih = new Registracija[9 + Registracija.Veljavna_obmocja.Count];
            for (ind = 0; ind < 10;)
            {
                tabela_registrskih[ind++] = new Registracija("LJ", "12345");
            }
            for (int i = 0; i < Registracija.Veljavna_obmocja.Count - 1; i++)
            {
                tabela_registrskih[ind++] = new Registracija(Registracija.Veljavna_obmocja[i], "12345");
            }
            Registracija.Izloci_obmocji(tabela_registrskih);
            CollectionAssert.AreEqual(Registracija.Veljavna_obmocja.ToArray(), new List<string> {"KR", "KK", "MB", "MS", "KP", "GO", "CE", "SG", "NM" }.ToArray());
        }
    }
}