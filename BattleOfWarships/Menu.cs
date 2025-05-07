using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarshipCombat;
using NAudio.Wave;
using BattleOfWarships.Domain;
using System.Security.Cryptography.X509Certificates;

namespace BattleOfWarships
{
    internal class Menu
    {
        public static void MainMenu()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("XXXXXXXXXXXXXXXXXX\r\n" +
                          "X WARSHIP COMBAT X\r\n" +
                          "XXXXXXXXXXXXXXXXXX\r\n" +
                          "X_-_-_-_-_-_-_-_-X\r\n" +
                          "X------MENU------X\r\n" +
                          "X 1. GAME RULES  X\r\n" +
                          "X 2. GAME START  X\r\n" +
                          "X 3. Top 10      X\r\n" +
                          "X 4. EXIT        X\r\n" +
                          "X-_-_-_-_-_-_-_-_X\r\n" +
                          "XXXXXXXXXXXXXXXXXX");
            Console.ResetColor();
            string soundFilePath = "epic-battle-sound-9414.mp3";
            int choice = 0;
            using (var audioFile = new Mp3FileReader(soundFilePath))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();
                string input = Console.ReadLine();
                for (; ;)
                {
                    if (int.TryParse(input, out choice) && choice < 5 && choice > 0)
                    {
                            break;                      
                    } 
                    else
                    {
                            Console.Write("Select a number from 1 to 4: ");
                            input = Console.ReadLine();                   
                    }                   
                }                
                switch (choice)
                {
                    case 1:
                        {                      
                            GameRules.GameRulesGPT();
                            break;
                        }
                    case 2:
                        {
                            Menu.GameMenu();
                            break;
                            
                        }
                    case 3:
                        {
                            Console.Clear();
                            TopTenList.ReadTopTenList();
                            TopTenList.PrintTopTenlist();
                            Console.WriteLine();
                            Console.WriteLine("Press any key to return to the menu.");
                            Console.ReadKey();
                            Menu.MainMenu();

                            break;
                        }
                    case 4:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }
            }
        }
        public static void GameMenu()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXX\r\n" +
                          "X     WARSHIP COMBAT     X\r\n" +
                          "XXXXXXXXXXXXXXXXXXXXXXXXXX\r\n" +
                          "X_-_-_-_-_-_-_-_-_-_-_-_-X\r\n" +
                          "X---------GAMES----------X\r\n" +
                          "X 1. One Player          X\r\n" +
                          "X 2. Player vs Player    X\r\n" +
                          "X 3. Player vs Computer  X\r\n" +
                          "X 4. Back to menu        X\r\n" +
                          "X-_-_-_-_-_-_-_-_-_-_-_-_X\r\n" +
                          "XXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.ResetColor();
            string soundFilePath = "epic-battle-sound-9414.mp3";
            int choice = 0;
            using (var audioFile = new Mp3FileReader(soundFilePath))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();
                string input = Console.ReadLine();
                for (; ; )
                {
                    if (int.TryParse(input, out choice) && choice < 5 && choice > 0)
                    {
                        if (choice > 0 && choice < 5)
                        {
                            break;
                        }
                    }
                    else
                    {
                        Console.Write("Select a number from 1 to 4: ");
                        input = Console.ReadLine();
                    }
                }
                switch (choice)
                {
                    case 1:
                        {
                            GamePlay.OnePlayerGame();
                            break;
                        }
                    case 2:
                        {
                            GamePlay.PlayerVSPlayer();
                            break;
                        }
                    case 3:
                        {
                            Menu.SelectingTheDifficultyLevel();
                            break;
                        }
                    case 4: 
                        { 
                            Menu.MainMenu();
                            break;
                        }
                }
            }
        }
        public static void SelectingTheDifficultyLevel()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXX\r\n" +
                          "X Choose difficulty level  X\r\n" +
                          "XXXXXXXXXXXXXXXXXXXXXXXXXXXX\r\n" +
                          "X_-_-_-_-_-_-_-_-_-_-_-_-_-X\r\n" +
                          "X----------GAMES-----------X\r\n" +
                          "X 1. Steady as she goes    X\r\n" +
                          "X 2. A fine kettle of fish X\r\n" +
                          "X 3. All hands on deck     X\r\n" +
                          "X 4. Back to menu          X\r\n" +
                          "X-_-_-_-_-_-_-_-_-_-_-_-_-_X\r\n" +
                          "XXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.ResetColor();
            string soundFilePath = "epic-battle-sound-9414.mp3";
            int choice = 0;
            using (var audioFile = new Mp3FileReader(soundFilePath))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();
                string input = Console.ReadLine();
                for (; ; )
                {
                    if (int.TryParse(input, out choice) && choice < 5 && choice > 0)
                    {
                        if (choice > 0 && choice < 5)
                        {
                            break;
                        }
                    }
                    else
                    {
                        Console.Write("Select a number from 1 to 4: ");
                        input = Console.ReadLine();
                    }
                }
                switch (choice)
                {
                    case 1:
                        {
                            DifficultyLevel.difficultyLevel = 1;
                            GamePlay.PlayerVSComputer();
                            break;
                        }
                    case 2:
                        {
                            DifficultyLevel.difficultyLevel = 2;
                            GamePlay.PlayerVSComputer();
                            break;
                        }
                    case 3:
                        {
                            DifficultyLevel.difficultyLevel = 3;
                            GamePlay.PlayerVSComputer();
                            break;
                        }
                    case 4:
                        {
                            Menu.MainMenu();
                            break;
                        }
                }
            }
        }
    }
}
    