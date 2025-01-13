using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace PrintFarm
{
    public static class ServiciuPersistenta
    {
        private const string FisierDate = "print_farm_data.json";

        public static void SalveazaDate(List<Imprimanta> imprimante, List<Comanda> comenzi, StocFilament stocFilament)
        {
            var date = new
            {
                Imprimante = imprimante,
                Comenzi = comenzi,
                StocFilament = stocFilament.VizualizeazaStoc()
            };

            File.WriteAllText(FisierDate, JsonConvert.SerializeObject(date, Formatting.Indented));
        }

        public static (List<Imprimanta>, List<Comanda>, StocFilament) IncarcaDate()
        {
            if (!File.Exists(FisierDate)) return (new List<Imprimanta>(), new List<Comanda>(), new StocFilament());

            var date = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(FisierDate));

            var imprimante = JsonConvert.DeserializeObject<List<Imprimanta>>(date.Imprimante.ToString());
            var comenzi = JsonConvert.DeserializeObject<List<Comanda>>(date.Comenzi.ToString());
            var stoc = JsonConvert.DeserializeObject<Dictionary<string, double>>(date.StocFilament.ToString());

            var stocFilament = new StocFilament();
            foreach (var item in stoc) stocFilament.AdaugaFilament(item.Key, item.Value);

            return (imprimante, comenzi, stocFilament);
        }
    }
}