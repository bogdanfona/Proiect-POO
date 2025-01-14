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
        static void MeniuUtilizator(List<Imprimanta> imprimante, List<Comanda> comenzi)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Meniu Utilizator ===");
                Console.WriteLine("1. Vizualizează costurile pe gram");
                Console.WriteLine("2. Calculează costul unui obiect");
                Console.WriteLine("3. Comandă un obiect");
                Console.WriteLine("4. Inapoi");

                Console.Write("Alegerea ta: ");
                string alegere = Console.ReadLine();

                if (alegere == "1")
                {
                    Console.WriteLine("Costuri pe gram:");
                    Console.WriteLine("- Răsină: 0.5 RON/g");
                    Console.WriteLine("- Filament: 0.2 RON/g");
                }
                else if (alegere == "2")
                {
                    Console.Write("Greutatea obiectului (g): ");
                    double greutate = double.Parse(Console.ReadLine());
                    Console.Write("Tipul printării (rasina/filament): ");
                    string tip = Console.ReadLine().ToLower();

                    double cost = tip == "rasina" ? 0.5 * greutate : 0.2 * greutate;
                    Console.WriteLine($"Costul obiectului: {cost} RON");
                }
                else if (alegere == "3")
                {
                    Console.Write("Nume obiect: ");
                    string nume = Console.ReadLine();
                    Console.Write("Greutate (g): ");
                    double greutate = double.Parse(Console.ReadLine());
                    Console.Write("Culoare: ");
                    string culoare = Console.ReadLine();
                    Console.Write("Adresa livrare: ");
                    string adresa = Console.ReadLine();

                    var comanda = new Comanda
                    {
                        NumeObiect = nume,
                        Greutate = greutate,
                        Culoare = culoare,
                        AdresaLivrare = adresa
                    };
                    comenzi.Add(comanda);

                    Console.WriteLine("Comanda a fost adăugată!");
                }
                else if (alegere == "4")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Alegere invalidă.");
                }

                Console.WriteLine("Apasă Enter pentru a continua...");
                Console.ReadLine();
            }
        }
        static void MeniuAdministrator(List<Imprimanta> imprimante, List<Comanda> comenzi, StocFilament stocFilament)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Meniu Administrator ===");
                Console.WriteLine("1. Vizualizează imprimante");
                Console.WriteLine("2. Vizualizează detalii imprimantă");
                Console.WriteLine("3. Adaugă răsină");
                Console.WriteLine("4. Schimbă filament");
                Console.WriteLine("5. Vizualizează stoc filament");
                Console.WriteLine("6. Adaugă filament în stoc");
                Console.WriteLine("7. Aruncă role cu filament putin");
                Console.WriteLine("8. Vizualizează comenzi");
                Console.WriteLine("9. Procesează comandă");
                Console.WriteLine("10. Înapoi");

                Console.Write("Alegerea ta: ");
                string alegere = Console.ReadLine();

                if (alegere == "1")
                {
                    Console.WriteLine("Lista imprimantelor:");
                    foreach (var imprimanta in imprimante)
                        Console.WriteLine(imprimanta.Descriere());
                }
                else if (alegere == "2")
                {
                    Console.Write("Introdu numele imprimantei: ");
                    string nume = Console.ReadLine();
                    var imprimanta = imprimante.Find(i => i.Nume == nume);
                    Console.WriteLine(imprimanta != null ? imprimanta.Descriere() : "Imprimanta nu a fost găsită.");
                }
                else if (alegere == "3")
                {
                    Console.Write("Nume imprimantă cu răsină: ");
                    string nume = Console.ReadLine();
                    var imprimanta = imprimante.Find(i => i is ImprimantaRasina && i.Nume == nume) as ImprimantaRasina;

                    if (imprimanta != null)
                    {
                        imprimanta.AdaugaRasina(50); 
                        Console.WriteLine("Răsina a fost adăugată.");
                    }
                    else
                    {
                        Console.WriteLine("Imprimanta nu a fost găsită.");
                    }
                }
                else if (alegere == "4")
                {
                    Console.Write("Nume imprimantă cu filament: ");
                    string nume = Console.ReadLine();
                    var imprimanta = imprimante.Find(i => i is ImprimantaFilament && i.Nume == nume) as ImprimantaFilament;

                    if (imprimanta != null)
                    {
                        Console.Write("Culoare nouă: ");
                        string culoare = Console.ReadLine();
                        Console.Write("Cantitate nouă (g): ");
                        double cantitate = double.Parse(Console.ReadLine());

                        imprimanta.SchimbaFilament(culoare, cantitate);
                        Console.WriteLine("Filamentul a fost schimbat.");
                    }
                    else
                    {
                        Console.WriteLine("Imprimanta nu a fost găsită.");
                    }
                }
                else if (alegere == "5")
                {
                    Console.WriteLine("Stoc filament:");
                    foreach (var item in stocFilament.VizualizeazaStoc())
                    {
                        Console.WriteLine($"- Culoare: {item.Key}, Cantitate: {item.Value} g");
                    }
                }
                else if (alegere == "6")
                {
                    Console.Write("Culoare filament: ");
                    string culoare = Console.ReadLine();
                    Console.Write("Cantitate (g): ");
                    double cantitate = double.Parse(Console.ReadLine());

                    stocFilament.AdaugaFilament(culoare, cantitate);
                    Console.WriteLine("Filamentul a fost adăugat în stoc.");
                }
                else if (alegere == "7")
                {
                    Console.WriteLine("Se vor arunca rolele cu filament sub 10 g...");
                }
                else if (alegere == "8")
                {
                    Console.WriteLine("Lista comenzilor:");
                    foreach (var comanda in comenzi)
                        Console.WriteLine(comanda);
                }
                else if (alegere == "9")
                {
                    Console.Write("ID comandă: ");
                    string idComanda = Console.ReadLine();
                    var comanda = comenzi.Find(c => c.IdComanda.ToString() == idComanda);

                    if (comanda != null && !comanda.EsteProcesata)
                    {
                        comanda.EsteProcesata = true;
                        Console.WriteLine("Comanda a fost procesată.");
                    }
                    else
                    {
                        Console.WriteLine("Comanda nu a fost găsită sau este deja procesată.");
                    }
                }
                else if (alegere == "10")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Alegere invalidă.");
                }

                Console.WriteLine("Apasă Enter pentru a continua...");
                Console.ReadLine();
            }
        }
    }
}