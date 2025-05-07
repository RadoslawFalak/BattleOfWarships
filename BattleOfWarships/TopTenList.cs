using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarshipCombat
{
    internal class TopTenList
    {
        public static string srcTopTenList = "topTenList.txt";
        public static List<(string Name, int Result)> topTenList = new List<(string, int)>(); // Lista wyników jako krotki

        public static void ReadTopTenList()
        {
            if (File.Exists("topTenList.txt"))
            {
                string[] lines = File.ReadAllLines(srcTopTenList);
                topTenList.Clear();

                foreach (string line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        try
                        {
                            // Odczytaj linie w formacie "1. Imie - Wynik"
                            string[] parts = line.Split(new[] { '.', '-' }, StringSplitOptions.RemoveEmptyEntries);
                            string imie = parts[1].Trim();
                            int wynik = int.Parse(parts[2].Trim());
                            topTenList.Add((imie, wynik));
                        }
                        catch
                        {
                            Console.WriteLine($"Błąd w odczycie linii: {line}");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Plik z wynikami nie istnieje. Utworzono pustą listę.");
            }
        }

        // Funkcja do wyświetlania aktualnej listy wyników
        public static void PrintTopTenlist()
        {
            if (topTenList.Count == 0)
            {
                Console.WriteLine("Top ten list is empty.");
            }
            else
            {
                int number = 1;
                foreach (var result in topTenList)
                {
                    Console.WriteLine($"{number}. {result.Name} - {result.Result}");
                    number++;
                    if (number == 11)
                    {
                        break;
                    }
                }
            }
        }

        // Funkcja do dodawania nowego wyniku do listy i zapisu do pliku
        public static void AddResultToTopTenList(string name, int points)
        {
                topTenList.Add((name, points));
                SaveTopTenList();
        }

        // Funkcja do sortowania listy według punktacji (malejąco)
        public static void SortTopTenList()
        {
            topTenList = topTenList.OrderByDescending(x => x.Result).ToList();
            SaveTopTenList();
        }

        // Funkcja do zapisywania listy wyników do pliku
        public static void SaveTopTenList()
        {
            using (StreamWriter writer = new StreamWriter(srcTopTenList))
            {
                int number = 1;
                foreach (var result in topTenList)
                {
                    writer.WriteLine($"{number}. {result.Name} - {result.Result}");
                    number++;
                }
            }
        }
    }
}
