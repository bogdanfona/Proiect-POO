using System;

namespace PrintFarm
{
    public class Comanda
    {
        public Guid IdComanda { get; private set; }
        public string NumeObiect { get; set; }
        public double Greutate { get; set; }
        public string Culoare { get; set; }
        public string AdresaLivrare { get; set; }
        public bool EsteProcesata { get; set; }

        public Comanda()
        {
            IdComanda = Guid.NewGuid();
            EsteProcesata = false;
        }

        public override string ToString()
        {
            return $"Comanda ID: {IdComanda}, Obiect: {NumeObiect}, Greutate: {Greutate} g, Culoare: {Culoare}, Procesata: {EsteProcesata}";
        }
    }
}
