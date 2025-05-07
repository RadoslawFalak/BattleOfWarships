using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BattleOfWarships
{
    internal class GameRules
    {
        public static void GameRulesGPT()
        {
                try
                {
                    Console.Clear();
                    // Ścieżka do pliku tekstowego
                    string filePath = "GameRules.txt";

                    // Wczytanie tekstu z pliku
                    string text = File.ReadAllText(filePath);

                    // Szerokość linii w konsoli
                    int lineWidth = 50;

                    // Wyjustowanie tekstu
                    List<string> justifiedLines = JustifyText(text, lineWidth);

                    // Wyświetlenie wyjustowanego tekstu
                    foreach (string line in justifiedLines)
                    {
                        Console.WriteLine(line);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Press any key to return to the menu");
                    Console.ReadKey();
                    Console.Clear();
                    Menu.MainMenu();
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Plik nie został znaleziony. Upewnij się, że plik istnieje i podano poprawną ścieżkę.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Wystąpił błąd: {ex.Message}");
                }
            }

            static List<string> JustifyText(string text, int lineWidth)
            {
                var words = text.Split(' '); // Podział tekstu na słowa
                var lines = new List<string>();
                var currentLine = new List<string>();
                int currentLineLength = 0;

                foreach (var word in words)
                {
                    // Sprawdzenie, czy słowo zmieści się w bieżącej linii
                    if (currentLineLength + word.Length + currentLine.Count <= lineWidth)
                    {
                        currentLine.Add(word);
                        currentLineLength += word.Length;
                    }
                    else
                    {
                        // Dodanie wyjustowanej linii
                        lines.Add(JustifyLine(currentLine, lineWidth));
                        currentLine.Clear();
                        currentLine.Add(word);
                        currentLineLength = word.Length;
                    }
                }

                // Dodanie ostatniej linii (bez justowania, wyrównana do lewej)
                if (currentLine.Count > 0)
                {
                    lines.Add(string.Join(" ", currentLine));
                }

                return lines;
            }

            static string JustifyLine(List<string> words, int lineWidth)
            {
                if (words.Count == 1)
                {
                    // Jeśli linia ma jedno słowo, po prostu wyrównaj do lewej
                    return words[0].PadRight(lineWidth);
                }

                int totalSpaces = lineWidth - words.Sum(word => word.Length); // Ilość spacji do wstawienia
                int spacesBetweenWords = totalSpaces / (words.Count - 1); // Podstawowa liczba spacji
                int extraSpaces = totalSpaces % (words.Count - 1); // Pozostałe spacje

                var justifiedLine = new List<string>();
                for (int i = 0; i < words.Count - 1; i++)
                {
                    justifiedLine.Add(words[i]);
                    justifiedLine.Add(new string(' ', spacesBetweenWords + (i < extraSpaces ? 1 : 0)));
                }
                justifiedLine.Add(words[^1]); // Dodanie ostatniego słowa

                return string.Join("", justifiedLine);
            }
    }
}
