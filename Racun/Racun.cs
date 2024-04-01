using System;

namespace OOP_Racun
{
    public class Racun
    {
        private string valuta;
        private double stanje, tecaj;

        public Racun(string valuta, double tecaj)
        {
            this.Valuta = valuta;
            this.Stanje = 0;
            this.Tecaj = tecaj;
        }

        private string Valuta
        {
            get { return this.valuta; }
            set { if (value.Length == 0)
                    throw new Exception("Valuta ne more biti prazen niz!");
                  this.valuta = value;}
        }

        private double Stanje
        {
            get { return this.stanje; }
            set { if (value < 0)
                    throw new Exception("Stanje ne more biti negativno!");
                  this.stanje = value;}
        }

        private double Tecaj
        {
            get { return this.tecaj; }
            set { if (value < 0)
                    throw new Exception("Tečaj ne more biti negativen!");
                  this.tecaj = value;}
        }

        public double Stanje_EUR
        {
            get { return Stanje * Tecaj;}
        }

        public void Polog(double znesek)
        {
            if (znesek < 0)
                throw new Exception("Znesek ne more biti negativen!");
            Stanje += znesek / Tecaj;
            Console.WriteLine("Polog je bil uspešen!");
        }

        public void Dvig(double znesek)
        {
            if (Stanje - znesek < 0)
                throw new Exception("Stanje na računu ne sme biti negativno!");
            Stanje -= znesek / Tecaj;
            Console.WriteLine("Dvig je bil uspešen!");
        }
    }
}