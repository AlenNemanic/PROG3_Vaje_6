using System;

namespace OOP_Vozilo
{
    public class Vozilo
    {
        private double gorivo, kapaciteta, poraba;
        
        public Vozilo(double kapaciteta, double poraba)
        {
            this.Kapaciteta = kapaciteta;
            this.Poraba = poraba;
            this.Gorivo = kapaciteta;
        }

        public double Kapaciteta
        {
            get { return kapaciteta;}
            set { if (value < 0) throw new Exception("Kapaciteta ne sme biti negativna!");
            kapaciteta = value;}
        }

        public double Poraba
        {
            get { return poraba;}
            set { if (value < 0) throw new Exception("Poraba ne sme biti negativna!");
            poraba = value;}
        }

        public double Gorivo
        {
            get { return gorivo;}
            set { if (value < 0) throw new Exception("Gorivo ne sme biti negativno!");
            gorivo = value;}
        }

        public double Preostali_kilometri
        {
            get { return Gorivo * 100 / Poraba;}
        }

        public void Crpalka()
        {
            Gorivo = Kapaciteta;
        }

        public override string ToString()
        {
            return $"Vozilo ima še {Gorivo} L goriva, kapaciteto veliko {Kapaciteta} L in porabo {Poraba} L / 100 km.";
        }

        public bool Opravi_pot(double[] tabela)
        {
            double kolicina_goriva = Gorivo;
            foreach (double dolzina_poti in tabela)
            {
                if (dolzina_poti < 0) throw new Exception("Pot ne more biti negativna!");
                if (dolzina_poti == 0)
                {
                    if (kolicina_goriva == Kapaciteta) throw new Exception("Ne moremo tankati dvakrat zapored!");
                    kolicina_goriva = Kapaciteta;
                }
                kolicina_goriva -= dolzina_poti * Poraba / 100;
            }
            if (kolicina_goriva < 0)
                return false;
            Gorivo = kolicina_goriva;
            return true;
        }
    }
}