using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarshipCombat;

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
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        GameRules.GameRulesPrint();
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        GameBoard.GameBoardPrint();
                        ShipDraw.FiveFlagships();
                        GameBoard.GameBoardPrint();
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
