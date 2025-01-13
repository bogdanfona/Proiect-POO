using System;
using System.Collections.Generic;

namespace PrintFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            var (imprimante, comenzi, stocFilament) = ServiciuPersistenta.IncarcaDate();
            bool ruleaza = true;

            while (ruleaza)
            {
                Console.Clear();
                Console.WriteLine("=== Meniu Principal ===");
                Console.WriteLine("1. Cont Utilizator");
                Console.WriteLine("2. Cont Administrator");
                Console.WriteLine("3. Salveaza si iesi");

                Console.Write("Alegerea ta: ");
                string alegere = Console.ReadLine();

                try
                {
                    switch (alegere)
                    {
                        case "1":
                            MeniuUtilizator(imprimante, comenzi);
                            break;
                        case "2":
                            MeniuAdministrator(imprimante, comenzi, stocFilament);
                            break;
                        case "3":
                            ServiciuPersistenta.SalveazaDate(imprimante, comenzi, stocFilament);
                            ruleaza = false;
                            break;
                        default:
                            Console.WriteLine("Alegere invalida. Incearca din nou.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Eroare: {ex.Message}");
                }

                Console.WriteLine("Apasa Enter pentru a continua...");
                Console.ReadLine();
            }
        }