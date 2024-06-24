using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarshipCombat;
using NAudio.Wave;

namespace BattleOfWarships
{
    internal class Menu
    {
        public static void MenuPrint()
        {
            Console.WriteLine("XXXXXXXXXXXXXXXXXX\r\n" +
                          "X WARSHIP COMBAT X\r\n" +
                          "XXXXXXXXXXXXXXXXXX\r\n" +
                          "X_-_-_-_-_-_-_-_-X\r\n" +
                          "X------MENU------X\r\n" +
                          "X 1. GAME RULES  X\r\n" +
                          "X 2. GAME START  X\r\n" +
                          "X 3. EXIT        X\r\n" +
                          "X-_-_-_-_-_-_-_-_X\r\n" +
                          "XXXXXXXXXXXXXXXXXX");
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
                    if (int.TryParse(input, out choice))
                    {
                        break;
                    } 
                    else
                    {
                            Console.Write("Select a number from 1 to 3: ");
                            input = Console.ReadLine();                   
                    }                   
                }                
                switch (choice)
                {
                    case 1:
                        {
                            GameRules.GameRulesPrint();
                            break;
                        }
                    case 2:
                        {
                            GamePlay.OnePlayerGame();
                            break;
                        }
                    case 3:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }
            }
        }
    }
}