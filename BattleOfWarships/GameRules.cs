using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleOfWarships
{
    internal class GameRules
    {
        public static void GameRulesPrint() 
        {
            Console.WriteLine("Zasady gry ");
            Console.WriteLine("Press eny key to return to the menu");
            string enyKey = Console.ReadLine();
            for( ; ; )
            {
                if (enyKey != null)
                {
                    Console.Clear();
                    Menu.MenuPrint();
                    break;
                }
            }
        }
    }
}
