using BattleOfWarships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace WarshipCombat
{
    internal class GamePlay
    {
        public enum FirstCoordinate
        {
            A = 1,
            a = 1,
            B, b = 2,
            C, c = 3,
            D, d = 4,
            E, e = 5,
            F, f = 6,
            G, g = 7,
            H, h = 8,
            I, i = 9,
            J, j = 10,
        }
        public static void OnePlayerGame()
        {
            int firstCoordinate;
            int secondCoordinate;
            int score = 0;
            int moves = 0;
            string[] lettersTest = new string[10] {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J"};
            Console.Clear();
            ShipDraw.FiveFlagships();
            ShipDraw.FourFlagships();
            ShipDraw.ThreeFlagships();
            ShipDraw.TwoFlagships();
            ShipDraw.TwoFlagships();
            while (score != 16)
            {
                string soundFilePath = "cannon-shot-14799.mp3";
                using (var audioFile = new Mp3FileReader(soundFilePath))
                using (var outputDevice = new WaveOutEvent())
                {
                    GameBoard.PrintArray(GameBoard.playerGameBoard);
                    Console.WriteLine("Enter the attack coordinate");
                    Console.Write("Enter the first coordinate from A to J: ");
                    string input = Console.ReadLine().ToUpper();
                    int stop = 2;
                    while (stop != 1)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            if (input == lettersTest[i])
                            {
                                stop = 1;
                            }
                        }
                        if (stop != 1)
                        {
                            Console.WriteLine("Incorrect coordinate! \r\nEnter the first coordinate from A to J:");
                            input = Console.ReadLine().ToUpper();
                        }
                    }
                    char character = input[0];
                    Enum.TryParse(character.ToString(), out FirstCoordinate letter);
                    firstCoordinate = (int)letter;
                    Console.Write("Enter the second coordinate from 1 to 10: ");
                    string input2 = Console.ReadLine();

                    for (; ; )
                    {
                        if (int.TryParse(input2, out secondCoordinate))
                        {
                            if (secondCoordinate >= 1 && secondCoordinate <= 10)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Incorrect coordinate! \r\nEnter the second coordinate from 1 to 10:");
                                input2 = Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Incorrect coordinate! \r\nEnter the second coordinate from 1 to 10:");
                            input2 = Console.ReadLine();
                        }
                    }
                    if (GameBoard.gameBoard[secondCoordinate, firstCoordinate] == " S")
                    {
                        GameBoard.playerGameBoard[secondCoordinate, firstCoordinate] = " S";
                        outputDevice.Init(audioFile);
                        outputDevice.Play();
                        Console.WriteLine("You hit the ship!");
                        score += 1;
                        moves += 1;
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        GameBoard.playerGameBoard[secondCoordinate, firstCoordinate] = " O";
                        outputDevice.Init(audioFile);
                        outputDevice.Play();
                        Console.WriteLine("You missed!");
                        moves += 1;
                        Thread.Sleep(1000);
                    }
                    Console.Clear();
                }
            }
            Console.WriteLine($"Congratulations on destroying all the ships, you win in {moves} moves.");
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
            Menu.MenuPrint();
        }
    }
}
