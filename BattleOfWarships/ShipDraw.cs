using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using BattleOfWarships;

namespace WarshipCombat
{
    internal class ShipDraw
    {    
        public static void FiveFlagships()
        {
            Random rdm = new Random();
            int horizontallyOrVertically = rdm.Next(1,3); //1- poziomo 2- pionowo
            int firstNumber = rdm.Next(1, 11);
            int secondNumber = rdm.Next(1, 11);

            //GameBoard.gameBoard[firstNumber, secondNumber] = " S";
            //int horizontallyOrVertically = 1;
            //int firstNumber = 1;
            //int secondNumber = 1;

            GameBoard.gameBoard[firstNumber, secondNumber] = " S";

            if (horizontallyOrVertically == 1)
            {
                if (10 - secondNumber > 3)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        GameBoard.gameBoard[firstNumber, secondNumber++] = " S";
                    }
                }

                else if (10 - secondNumber <= 3)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        GameBoard.gameBoard[firstNumber, secondNumber--] = " S";
                    }
                }
            }

            if (horizontallyOrVertically == 2)
            {
                if (10 - firstNumber > 3)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        GameBoard.gameBoard[firstNumber++, secondNumber] = " S";
                    }
                }

                else if (10 - firstNumber <= 3)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        GameBoard.gameBoard[firstNumber--, secondNumber] = " S";
                    }
                }
            }
        }
        public static void FourFlagships()
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

                    if (GameBoard.gameBoard[firstNumber, secondNumber] != " S" && secondNumber + 3 <= 10 && secondNumber - 3 >= 1)
                    {
                        GameBoard.gameBoard[firstNumber, secondNumber] = " S";
                        break;
                    }
                }
                if (GameBoard.gameBoard[firstNumber, secondNumber + 1] != " S" && GameBoard.gameBoard[firstNumber, secondNumber + 2] != " S" && GameBoard.gameBoard[firstNumber, secondNumber + 3] != " S")
                {
                    for (int i = 1; i < 4; i++)
                    {
                        GameBoard.gameBoard[firstNumber, secondNumber + i] = " S";
                    }
                }
                else if (GameBoard.gameBoard[firstNumber, secondNumber - 1] != " S" && GameBoard.gameBoard[firstNumber, secondNumber - 2] != " S" && GameBoard.gameBoard[firstNumber, secondNumber - 3] != " S")
                {
                    for (int i = 1; i < 4; i++)
                    {
                        GameBoard.gameBoard[firstNumber, secondNumber - i] = " S";
                    }
                }
            }
            else if (horizontallyOrVertically == 2)
            {
                for ( ; ; )
                {
                    firstNumber = rdm.Next(1, 11);
                    secondNumber = rdm.Next(1, 11);

                    if (GameBoard.gameBoard[firstNumber, secondNumber] != " S" && firstNumber + 3 <= 10 && firstNumber - 3 >= 1)
                    {
                        GameBoard.gameBoard[firstNumber, secondNumber] = " S";
                        break;
                    }
                }
                if (GameBoard.gameBoard[firstNumber + 1, secondNumber] != " S" && GameBoard.gameBoard[firstNumber + 2, secondNumber] != " S" && GameBoard.gameBoard[firstNumber + 3, secondNumber] != " S")
                {
                    for (int i = 1; i < 4; i++)
                    {
                        GameBoard.gameBoard[firstNumber + i, secondNumber] = " S";
                    }
                }
                else if (GameBoard.gameBoard[firstNumber - 1, secondNumber] != " S" && GameBoard.gameBoard[firstNumber - 2, secondNumber] != " S" && GameBoard.gameBoard[firstNumber -3, secondNumber] != " S")
                {
                    for (int i = 1; i < 4; i++)
                    {
                        GameBoard.gameBoard[firstNumber - i, secondNumber] = " S";
                    }
                }
            }
        }
        public static void ThreeFlagships()
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

                    if (GameBoard.gameBoard[firstNumber, secondNumber] != " S" && secondNumber + 2 <= 10 && secondNumber - 2 >= 1)
                    {
                        GameBoard.gameBoard[firstNumber, secondNumber] = " S";
                        break;
                    }
                }
                if (GameBoard.gameBoard[firstNumber, secondNumber + 1] != " S" && GameBoard.gameBoard[firstNumber, secondNumber + 2] != " S")
                {
                    for (int i = 1; i < 3; i++)
                    {
                        GameBoard.gameBoard[firstNumber, secondNumber + i] = " S";
                    }
                }
                else if (GameBoard.gameBoard[firstNumber, secondNumber - 1] != " S" && GameBoard.gameBoard[firstNumber, secondNumber - 2] != " S")
                {
                    for (int i = 1; i < 3; i++)
                    {
                        GameBoard.gameBoard[firstNumber, secondNumber - i] = " S";
                    }
                }
            }
            else if (horizontallyOrVertically == 2)
            {
                for ( ; ; )
                {
                    firstNumber = rdm.Next(1, 11);
                    secondNumber = rdm.Next(1, 11);

                    if (GameBoard.gameBoard[firstNumber, secondNumber] != " S" && firstNumber + 2 <= 10 && firstNumber - 2 >= 1)
                    {
                        GameBoard.gameBoard[firstNumber, secondNumber] = " S";
                        break;
                    }
                }
                if (GameBoard.gameBoard[firstNumber + 1, secondNumber] != " S" && GameBoard.gameBoard[firstNumber + 2, secondNumber] != " S")
                {
                    for (int i = 1; i < 3; i++)
                    {
                        GameBoard.gameBoard[firstNumber + i, secondNumber] = " S";
                    }
                }
                else if (GameBoard.gameBoard[firstNumber - 1, secondNumber] != " S" && GameBoard.gameBoard[firstNumber - 2, secondNumber] != " S")
                {
                    for (int i = 1; i < 3; i++)
                    {
                        GameBoard.gameBoard[firstNumber - i, secondNumber] = " S";
                    }
                }
            }
        }
        public static void TwoFlagships()
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

                    if (GameBoard.gameBoard[firstNumber, secondNumber] != " S" && secondNumber + 1 <= 10 && secondNumber - 1 >= 1)
                    {
                        GameBoard.gameBoard[firstNumber, secondNumber] = " S";
                        break;
                    }
                }
                if (GameBoard.gameBoard[firstNumber, secondNumber + 1] != " S")
                {
                    GameBoard.gameBoard[firstNumber, secondNumber + 1] = " S";     
                }
                else if (GameBoard.gameBoard[firstNumber, secondNumber - 1] != " S")
                {
                    GameBoard.gameBoard[firstNumber, secondNumber - 1] = " S";
                }
            }
            else if (horizontallyOrVertically == 2)
            {
                for (; ; )
                {
                    firstNumber = rdm.Next(1, 11);
                    secondNumber = rdm.Next(1, 11);

                    if (GameBoard.gameBoard[firstNumber, secondNumber] != " S" && firstNumber + 1 <= 10 && firstNumber - 1 >= 1)
                    {
                        GameBoard.gameBoard[firstNumber, secondNumber] = " S";
                        break;
                    }
                }
                if (GameBoard.gameBoard[firstNumber + 1, secondNumber] != " S" && GameBoard.gameBoard[firstNumber + 1, secondNumber] != " S")
                {
                    GameBoard.gameBoard[firstNumber + 1, secondNumber] = " S";
                }
                else if (GameBoard.gameBoard[firstNumber - 1, secondNumber] != " S" && GameBoard.gameBoard[firstNumber - 1, secondNumber] != " S")
                {
                    GameBoard.gameBoard[firstNumber - 1, secondNumber] = " S";
                }
            } 
        }
    }
}
