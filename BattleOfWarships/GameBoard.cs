using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleOfWarships
{
    internal class GameBoard
    {
        //tablica na której zapisują się wylosowane statki
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
        //tablica na której zapisują się wylosowane statki w opcji playerVsPlater lub PLayerVsComputer
        public static string[,] gameBoard2 = new string[11, 11] {  {" ","  A"," B"," C"," D"," E"," F"," G"," H"," I"," J"},
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
        //tablica na której gracz widzi swoje trafione i chybione strzały
        public static string[,] playerGameBoard = new string[11, 11] {  {" ","  A"," B"," C"," D"," E"," F"," G"," H"," I"," J"},
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
        //tablica na której gracz widzi swoje trafione i chybione strzaływ opcji playerVsPlater lub PLayerVsComputer
        public static string[,] player2GameBoard = new string[11, 11] {  {" ","  A"," B"," C"," D"," E"," F"," G"," H"," I"," J"},
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
        public static void PrintArray(string[,] array) // drukuje i nanosi kolory tablicy na ekranie
        {
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);

            

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    if (array[i, j] == " S")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    if (array[i, j] == " O")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write(array[i, j]);
                    Console.ResetColor();   
                }
                Console.WriteLine();
            }
        }
        public static void ClearingTheBoard(string[,] array) //czyszczenie tablicy po ukończonej grze
        {
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if(array[i, j] == " 5" || array[i, j] == " 4" || array[i, j] == " 3" || array[i, j] == " 2" || array[i, j] == " 1" || array[i, j] == " O" || array[i, j] == " S")
                    {
                        array[i, j] = " X";
                    }  
                }
            }
        }
    }
}
