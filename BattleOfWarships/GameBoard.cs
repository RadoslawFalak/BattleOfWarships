using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleOfWarships
{
    internal class GameBoard
    {
        public static string[,] gameBoard = new string[11, 11] {  {" ","  A"," B"," C"," D"," E"," F"," G"," H"," I"," J"},
                                                    {"1 "," X"," X"," X"," X"," X"," X"," X"," X"," X"," X"},
                                                    {"2 "," X"," X"," X"," X"," X"," X"," X"," X"," X"," X"},
                                                    {"3 "," X"," X"," X"," X"," X"," X"," X"," X"," X"," X"},
                                                    {"4 "," X"," X"," X"," X"," X"," X"," X"," X"," X"," X"},
                                                    {"5 "," X"," X"," X"," X"," X"," X"," X"," X"," X"," X"},
                                                    {"6 "," X"," X"," X"," X"," X"," X"," X"," X"," X"," X"},
                                                    {"7 "," X"," X"," X"," X"," X"," X"," X"," X"," X"," X"},
                                                    {"8 "," X"," X"," X"," X"," X"," X"," X"," X"," X"," X"},
                                                    {"9 "," X"," X"," X"," X"," X"," X"," X"," X"," X"," X"},
                                                    {"10"," X"," X"," X"," X"," X"," X"," X"," X"," X"," X"} };
        public static void PrintArray(string[,] array)
        {
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(array[i, j]);
                }
                Console.WriteLine();

            }
        }
    }
}
