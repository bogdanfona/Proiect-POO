using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintFarm
{
    public class ImprimantaRasina : Imprimanta
{
    public double CapacitateRasina { get; set; }
    public double RasinaCurenta { get; set; }

    public ImprimantaRasina(string nume, double capacitate) : base(nume)
    {
        CapacitateRasina = capacitate;
        RasinaCurenta = capacitate;
    }

    public void AdaugaRasina(double cantitate)
    {
        RasinaCurenta = Math.Min(RasinaCurenta + cantitate, CapacitateRasina);
    }

    public override string Descriere()
    {
        return $"Imprimanta cu rasina '{Nume}' - Rasina curenta: {RasinaCurenta}/{CapacitateRasina} ml";
    }
}

public class ImprimantaFilament : Imprimanta
{
    public string CuloareFilament { get; set; }
    public double CantitateFilament { get; set; }

    public ImprimantaFilament(string nume, string culoare, double cantitate) : base(nume)
    {
        CuloareFilament = culoare;
        CantitateFilament = cantitate;
    }

    public void SchimbaFilament(string culoareNoua, double cantitateNoua)
    {
        CuloareFilament = culoareNoua;
        CantitateFilament = cantitateNoua;
    }

    public override string Descriere()
    {
        return $"Imprimanta cu filament '{Nume}' - Culoare: {CuloareFilament}, Cantitate: {CantitateFilament} g";
    }
}
}
