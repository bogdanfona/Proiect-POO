using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class ImprimantaCuRasina : Imprimanta3D
    {
        public double CapacitateRasina { get; set; } = 1000.0; // ml

        public override void ProcesareComanda(Comanda comanda)
        {
            double consum = comanda.Masa * 2; // Exemplu: 2 ml/g
            if (CapacitateRasina >= consum)
            {
                CapacitateRasina -= consum;
                Status = "Imprimare în curs";
                Console.WriteLine($"Comanda {comanda.NumeObiect} procesată cu rășină. Consum: {consum} ml.");
            }
            else
            {
                Console.WriteLine("Rășină insuficientă pentru a procesa comanda!");
            }
        }

        public void AdaugaRasina(double cantitate)
        {
            CapacitateRasina += cantitate;
            Console.WriteLine($"S-a adăugat {cantitate} ml de rășină. Capacitate actuală: {CapacitateRasina} ml.");
        }
    }
}
