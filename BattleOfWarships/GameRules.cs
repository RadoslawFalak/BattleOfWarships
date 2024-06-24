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
            String line;
            Console.Clear();
            StreamReader sr = new StreamReader("gameRules.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                //write the line to console window
                Console.WriteLine(line);
                //Read the next line
                line = sr.ReadLine();
            }
            //close the file
            sr.Close();
            Console.WriteLine("Press any key to return to the menu");
            Console.ReadKey();
            Console.Clear();
            Menu.MenuPrint();
        }
    }
}
