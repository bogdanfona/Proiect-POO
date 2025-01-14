using System.Collections.Generic;

namespace PrintFarm
{
    public class StocFilament
    {
        private Dictionary<string, double> stoc = new Dictionary<string, double>();

        public void AdaugaFilament(string culoare, double cantitate)
        {
            if (stoc.ContainsKey(culoare))
            {
                stoc[culoare] += cantitate;
            }
            else
            {
                stoc[culoare] = cantitate;
            }
        }

        public bool ScoateFilament(string culoare, double cantitate)
        {
            if (stoc.ContainsKey(culoare) && stoc[culoare] >= cantitate)
            {
                stoc[culoare] -= cantitate;
                return true;
            }
            return false;
        }

        public Dictionary<string, double> VizualizeazaStoc()
        {
            return new Dictionary<string, double>(stoc);
        }
    }
}
