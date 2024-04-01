using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_Regristracija
{
    public class Registracija
    {
        private string obmocje, reg_stevilke;
        private static List<string> veljavna_obmocja = new List<string> { "LJ", "KR", "KK", "MB", "MS", "KP", "GO", "CE", "SG", "NM", "PO" };
        private static string alfanumericni_znaki = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";

        public Registracija(string obmocje, string regristracija)
        {
            this.Obmocje = obmocje;
            this.Reg_stevilke = regristracija;
        }

        public string Obmocje
        {
            get { return this.obmocje; }
            set
            {
                if (!veljavna_obmocja.Contains(value)) throw new Exception("Nisi vnesel veljavnega območja!");
                this.obmocje = value;
            }
        }

        public string Reg_stevilke
        {
            get { return this.reg_stevilke; }
            set
            {
                if ((value + "").Length != 5)
                    throw new Exception("Vnešena registracija ni veljavna!");
                foreach (char znak in value)
                {
                    if (!alfanumericni_znaki.Contains(znak + ""))
                        throw new Exception("Vnešena regristracija vsebuje neveljavne znake!");
                }
                this.reg_stevilke = value;
            }
        }

        public static List<string> Veljavna_obmocja
        {
            get { return veljavna_obmocja; }
        }

        /// <summary>
        /// Ponastavi območja na privzeta območja.
        /// Privzeta območja so določena v kodi, glejte ustrezne metode za podrobnosti.
        /// </summary>
        public static void Ponastavi_obmocja()
        {
            veljavna_obmocja = new List<string> { "LJ", "KR", "KK", "MB", "MS", "KP", "GO", "CE", "SG", "NM", "PO" };
        }

        public override string ToString()
        {
            return $"{Obmocje} {Reg_stevilke.Substring(0, 2)}-{Reg_stevilke.Substring(2, 3)}";
        }
        
        /// <summary>
        /// Dodaj območje na seznam veljavnih območji v Sloveniji.
        /// </summary>
        /// <param name="obmocje">Niz območja</param>
        public static void Dodaj_obmocje(string obmocje)
        {
            if (Veljavna_obmocja.Contains(obmocje))
                throw new Exception("Območje že obstaja!");
            if (obmocje.Length != 2)
                throw new Exception("Vneseno območje ni veljavno!");
            foreach (char znak in obmocje)
            {
                if (!alfanumericni_znaki.Contains(znak + ""))
                    throw new Exception("Vneseno območje vsebuje neveljavne znake!");
            }
            veljavna_obmocja.Add(obmocje);
        }

        /// <summary>
        /// Odstrani območje na seznam veljavnih območji v Sloveniji.
        /// </summary>
        /// <param name="obmocje">Niz območja</param>
        public static void Odstrani_obmocje(string obmocje)
        {
            if (!Veljavna_obmocja.Contains(obmocje))
                throw new Exception("Območje ne obstaja!");
            veljavna_obmocja.Remove(obmocje);
        }

        /// <summary>
        /// Izpiše vse registrske iz tabele, ki se ujemajo z podanem območju.
        /// </summary>
        /// <param name="registrske">Tabela registrskih</param>
        /// <param name="obmocje">Niz območja</param>
        public static void Izpisi_za_obmocje(Registracija[] registrske, string obmocje)
        {
            if (!Veljavna_obmocja.Contains(obmocje))
                throw new Exception("Območje ne obstaja");
            foreach (Registracija registrska in registrske)
            {
                if (registrska.Obmocje == obmocje)
                    Console.WriteLine(registrska);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Iz veljavnih območji izloči najpogosteje in najredkeje uporabljeni območji iz tabele registrkih.
        /// </summary>
        /// <param name="registrske">Tabela registrskih</param>
        public static void Izloci_obmocji(Registracija[] registrske)
        {
            if (registrske.Length == 0)
                throw new Exception("Tabela ne more biti prazna!");
            if (registrske.Length == 1)
                Odstrani_obmocje(registrske[0].Obmocje);
            else
            {
                int[] stevec_obmocji = new int[Veljavna_obmocja.Count];
                foreach (Registracija registrska in registrske)
                {
                    stevec_obmocji[Veljavna_obmocja.IndexOf(registrska.Obmocje)]++;
                }
                string najbolj_pogosto = Veljavna_obmocja[stevec_obmocji.ToList().IndexOf(stevec_obmocji.Max())];
                string najmanj_pogosto = Veljavna_obmocja[stevec_obmocji.ToList().IndexOf(stevec_obmocji.Min())];
                Odstrani_obmocje(najbolj_pogosto);
                Odstrani_obmocje(najmanj_pogosto);
            }
        }
    }
}