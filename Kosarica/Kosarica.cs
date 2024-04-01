using System;

namespace OOP_Kosarica
{
    public class Kosarica<T>
    {
        private T objekt;

        public Kosarica(T objekt)
        {
            this.objekt = objekt;
        }

        public T Objekt
        {
            get { return objekt; }
            set { objekt = value; }
        }

        public override string ToString()
        {
            return Objekt.ToString();
        }
    }
}