using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    abstract class Imprimanta3D
    {
        public string ID { get; set; }
        public string Status { get; set; } = "Disponibil";

        public abstract void ProcesareComanda(Comanda comanda);
    }
}