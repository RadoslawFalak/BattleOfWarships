using BattleOfWarships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarshipCombat
{
    internal class ShipDraw          
    {
        public static void FiveFlagships(string[,] array)
        {
            Random rdm = new Random();
            int horizontallyOrVertically = rdm.Next(1, 3); //1- poziomo 2- pionowo
            int firstNumber = rdm.Next(1, 11);
            int secondNumber = rdm.Next(1, 11);

            array[firstNumber, secondNumber] = " 5";

            if (horizontallyOrVertically == 1)
            {
                if (10 - secondNumber > 3)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        array[firstNumber, secondNumber++] = " 5";
                    }
                }

                else if (10 - secondNumber <= 3)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        array[firstNumber, secondNumber--] = " 5";
                    }
                }
            }

            if (horizontallyOrVertically == 2)
            {
                if (10 - firstNumber > 3)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        array[firstNumber++, secondNumber] = " 5";
                    }
                }

                else if (10 - firstNumber <= 3)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        array[firstNumber--, secondNumber] = " 5";
                    }
                }
            }
        }
        public static void FourFlagships(string[,] array)
        {
            Random rdm = new Random();
            int horizontallyOrVertically = rdm.Next(1, 3); //1- poziomo 2- pionowo
            int firstNumber = 1;
            int secondNumber = 1;
 
            if (horizontallyOrVertically == 1)
            {
                for (; ; )
                {
                    firstNumber = rdm.Next(1, 11);
                    secondNumber = rdm.Next(1, 11);

                    if (array[firstNumber, secondNumber] != " 5" && secondNumber + 3 <= 10 && secondNumber - 3 >= 1)
                    {
                        array[firstNumber, secondNumber] = " 4";
                        break;
                    }
                }
                if (array[firstNumber, secondNumber + 1] != " 5" && array[firstNumber, secondNumber + 2] != " 5" && array[firstNumber, secondNumber + 3] != " 5")
                {
                    for (int i = 1; i < 4; i++)
                    {
                        array[firstNumber, secondNumber + i] = " 4";
                    }
                }
                else if (array[firstNumber, secondNumber - 1] != " 5" && array[firstNumber, secondNumber - 2] != " 5" && array[firstNumber, secondNumber - 3] != " 5")
                {
                    for (int i = 1; i < 4; i++)
                    {
                        array[firstNumber, secondNumber - i] = " 4";
                    }
                }
                horizontallyOrVertically = 2;
            }
            else if (horizontallyOrVertically == 2)
            {
                for (; ; )
                {
                    firstNumber = rdm.Next(1, 11);
                    secondNumber = rdm.Next(1, 11);

                    if (array[firstNumber, secondNumber] != " 5" && firstNumber + 3 <= 10 && firstNumber - 3 >= 1)
                    {
                        array[firstNumber, secondNumber] = " 4";
                        break;
                    }
                }
                if (array[firstNumber + 1, secondNumber] != " 5" && array[firstNumber + 2, secondNumber] != " 5" && array[firstNumber + 3, secondNumber] != " 5")
                {
                    for (int i = 1; i < 4; i++)
                    {
                        array[firstNumber + i, secondNumber] = " 4";
                    }
                }
                else if (array[firstNumber - 1, secondNumber] != " 5" && array[firstNumber - 2, secondNumber] != " 5" && array[firstNumber - 3, secondNumber] != " 5")
                {
                    for (int i = 1; i < 4; i++)
                    {
                        array[firstNumber - i, secondNumber] = " 4";
                    }
                }
                horizontallyOrVertically = 1;
            }
        }
        public static void ThreeFlagships(string[,] array)
        {
            Random rdm = new Random();
            int horizontallyOrVertically = rdm.Next(1, 3); //1- poziomo 2- pionowo
            int firstNumber = 1;
            int secondNumber = 1;

            if (horizontallyOrVertically == 1)
            {
                for ( ; ; )
                {
                    firstNumber = rdm.Next(1, 11);
                    secondNumber = rdm.Next(1, 11);

                    if (array[firstNumber, secondNumber] != " 4" && array[firstNumber, secondNumber] != " 5" 
                        && secondNumber + 2 <= 10 && secondNumber - 2 >= 1 && firstNumber + 2 <= 10 && firstNumber - 2 >= 1)
                    {
                        array[firstNumber, secondNumber] = " 3";
                        break;
                    }
                }
                if (array[firstNumber, secondNumber + 1] != " 4" && array[firstNumber, secondNumber + 1] != " 5" && array[firstNumber, secondNumber + 2] != " 4" && array[firstNumber, secondNumber + 2] != " 5")
                {
                    for (int i = 1; i < 3; i++)
                    {
                        array[firstNumber, secondNumber + i] = " 3";
                    }
                }
                else if (array[firstNumber, secondNumber - 1] != " 5" && array[firstNumber, secondNumber - 1] != " 4" && array[firstNumber, secondNumber - 2] != " 5" && array[firstNumber, secondNumber - 2] != " 4")
                {
                    for (int i = 1; i < 3; i++)
                    {
                        array[firstNumber, secondNumber - i] = " 3";
                    }
                }
                else if (array[firstNumber + 1, secondNumber] != " 4" && array[firstNumber + 1, secondNumber] != " 5" && array[firstNumber + 2, secondNumber] != " 4" && array[firstNumber + 2, secondNumber] != " 5" && firstNumber + 2 <= 10 && firstNumber - 2 >= 1)
                {
                    for (int i = 1; i < 3; i++)
                    {
                        array[firstNumber + i, secondNumber] = " 3";
                    }
                }
                else if (array[firstNumber - 1, secondNumber] != " 4" && array[firstNumber - 1, secondNumber] != " 5" && array[firstNumber - 2, secondNumber] != " 4" && array [firstNumber - 2, secondNumber] != " 5" && firstNumber + 2 <= 10 && firstNumber - 2 >= 1)
                {
                    for (int i = 1; i < 3; i++)
                    {
                        array[firstNumber - i, secondNumber] = " 3";
                    }
                }
            }
            else if (horizontallyOrVertically == 2)
            {
                for (; ; )
                {
                    firstNumber = rdm.Next(1, 11);
                    secondNumber = rdm.Next(1, 11);

                    if (array[firstNumber, secondNumber] != " 4" && array[firstNumber, secondNumber] != " 5" 
                        && firstNumber + 2 <= 10 && firstNumber - 2 >= 1 && secondNumber + 2 <= 10 && secondNumber - 2 >= 1)
                    {
                        array[firstNumber, secondNumber] = " 3";
                        break;
                    }
                }
                if (array[firstNumber + 1, secondNumber] != " 4" && array[firstNumber + 1, secondNumber] != " 5" && array[firstNumber + 2, secondNumber] != " 4" && array[firstNumber + 2, secondNumber] != " 5")
                {
                    for (int i = 1; i < 3; i++)
                    {
                        array[firstNumber + i, secondNumber] = " 3";
                    }
                }
                else if (array[firstNumber - 1, secondNumber] != " 4" && array[firstNumber - 1, secondNumber] != " 5" && array[firstNumber - 2, secondNumber] != " 4" && array[firstNumber - 2, secondNumber] != " 5")
                {
                    for (int i = 1; i < 3; i++)
                    {
                        array[firstNumber - i, secondNumber] = " 3";
                    }
                }
                else if (array[firstNumber, secondNumber + 1] != " 4" && array[firstNumber, secondNumber + 1] != " 5" && array[firstNumber, secondNumber + 2] != " 4" && array[firstNumber, secondNumber + 2] != " 5" )
                {
                    for (int i = 1; i < 3; i++)
                    {
                        array[firstNumber, secondNumber + i] = " 3";
                    }
                }
                else if (array[firstNumber, secondNumber - 1] != " 5" && array[firstNumber, secondNumber - 1] != " 4" && array[firstNumber, secondNumber - 2] != " 5" && array[firstNumber, secondNumber - 2] != " 4" )
                {
                    for (int i = 1; i < 3; i++)
                    {
                        array [firstNumber, secondNumber - i] = " 3";
                    }
                }
            }
        }
        public static void TwoFlagships(string[,] array)
        {
            Random rdm = new Random();
            int horizontallyOrVertically = rdm.Next(1, 3); //1- poziomo 2- pionowo
            int firstNumber = 1;
            int secondNumber = 1;

            if (horizontallyOrVertically == 1)
            {
                for (; ; )
                {
                    firstNumber = rdm.Next(1, 11);
                    secondNumber = rdm.Next(1, 11);

                    if (array[firstNumber, secondNumber] != " 5" && array[firstNumber, secondNumber] != " 4" 
                        && array[firstNumber, secondNumber] != " 3" && array[firstNumber, secondNumber] != " 2" 
                        && secondNumber + 1 <= 10 && secondNumber - 1 >= 1 && firstNumber + 1 <= 10 && firstNumber - 1 >= 1)
                    {
                        array[firstNumber, secondNumber] = " 2";
                        break;
                    }
                }
                if (array[firstNumber, secondNumber + 1] != " 5" && array[firstNumber, secondNumber + 1] != " 4" && array[firstNumber, secondNumber + 1] != " 3" && array[firstNumber, secondNumber + 1] != " 2")
                {
                    array[firstNumber, secondNumber + 1] = " 2";
                }
                else if (array[firstNumber, secondNumber - 1] != " 5" && array[firstNumber, secondNumber - 1] != " 4" && array[firstNumber, secondNumber - 1] != " 3" && array[firstNumber, secondNumber - 1] != " 2")
                {
                    array[firstNumber, secondNumber - 1] = " 2";
                }
                else if (array[firstNumber + 1, secondNumber] != " 5" && array[firstNumber + 1, secondNumber] != " 4" && array[firstNumber + 1, secondNumber] != " 3" && array[firstNumber + 1, secondNumber] != " 2")
                {
                    array[firstNumber + 1, secondNumber] = " 2";
                }
                else if (array[firstNumber - 1, secondNumber] != " 5" && array[firstNumber - 1, secondNumber] != " 4" && array[firstNumber - 1, secondNumber] != " 3" && array[firstNumber - 1, secondNumber] != " 2")
                {
                    array[firstNumber - 1, secondNumber] = " 2";
                }
            }
            else if (horizontallyOrVertically == 2)
            {
                for (; ; )
                {
                    firstNumber = rdm.Next(1, 11);
                    secondNumber = rdm.Next(1, 11);

                    if (array[firstNumber, secondNumber] != " 5" && array[firstNumber, secondNumber] != " 4" 
                        && array[firstNumber, secondNumber] != " 3" && array[firstNumber, secondNumber] != " 2" 
                        && firstNumber + 1 <= 10 && firstNumber - 1 >= 1 && secondNumber + 1 <= 10 && secondNumber - 1 >= 1)
                    {
                        array[firstNumber, secondNumber] = " 2";
                        break;
                    }
                }
                if (array[firstNumber + 1, secondNumber] != " 5" && array[firstNumber + 1, secondNumber] != " 4"
                   && array[firstNumber + 1, secondNumber] != " 3" && array[firstNumber + 1, secondNumber] != " 2")
                {
                    array[firstNumber + 1, secondNumber] = " 2";
                }
                else if (array[firstNumber - 1, secondNumber] != " 5" && array[firstNumber - 1, secondNumber] != " 4" && array[firstNumber - 1, secondNumber] != " 3" && array[firstNumber - 1, secondNumber] != " 2")
                {
                    array[firstNumber - 1, secondNumber] = " 2";
                }
                else if (array[firstNumber, secondNumber + 1] != " 5" && array[firstNumber, secondNumber + 1] != " 4" && array[firstNumber, secondNumber + 1] != " 3" && array[firstNumber, secondNumber + 1] != " 2")
                {
                    array[firstNumber, secondNumber + 1] = " 2";
                }
                else if (array[firstNumber, secondNumber - 1] != " 5" && array[firstNumber, secondNumber - 1] != " 4" && array[firstNumber, secondNumber - 1] != " 3" && array[firstNumber, secondNumber - 1] != " 2")
                {
                    array[firstNumber, secondNumber - 1] = " 2";
                }
            }
        }
        public static void TwoFlagshipsSecond(string[,] array)
        {
            Random rdm = new Random();
            int horizontallyOrVertically = rdm.Next(1, 3); //1- poziomo 2- pionowo
            int firstNumber = 1;
            int secondNumber = 1;

            if (horizontallyOrVertically == 1)
            {
                for (; ; )
                {
                    firstNumber = rdm.Next(1, 10);
                    secondNumber = rdm.Next(1, 10);

                    if (array[firstNumber, secondNumber] == " X" && array[firstNumber + 1, secondNumber] != " 5"
                        && array[firstNumber + 1, secondNumber] != " 4" && array[firstNumber + 1, secondNumber] != " 3"
                        && array[firstNumber + 1, secondNumber] != " 2" && firstNumber + 1 <= 10 )
                    {
                        array[firstNumber, secondNumber] = " 1";
                        array[firstNumber + 1, secondNumber] = " 1";
                        break;
                    }
                }

            }
            else if (horizontallyOrVertically == 2)
            {
                for (; ; )
                {
                    firstNumber = rdm.Next(1, 10);
                    secondNumber = rdm.Next(1, 10);
                 
                    if (array[firstNumber, secondNumber] == " X" && array[firstNumber, secondNumber + 1] != " 5"
                        && array[firstNumber, secondNumber + 1] != " 4" && array[firstNumber, secondNumber + 1] != " 3"
                        && array[firstNumber, secondNumber + 1] != " 2" && secondNumber + 1 <= 10)
                    {
                        array[firstNumber, secondNumber] = " 1";
                        array[firstNumber, secondNumber + 1] = " 1";
                        break;
                    }
                }
            }
        }
    }
}
