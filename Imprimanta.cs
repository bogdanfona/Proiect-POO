using System;

namespace PrintFarm
{
    public abstract class Imprimanta
    {
        public string Nume { get; set; }
        public bool EsteInUz { get; set; }

        public Imprimanta(string nume)
        {
            Nume = nume;
            EsteInUz = false;
        }

        public abstract string Descriere();
    }
}
