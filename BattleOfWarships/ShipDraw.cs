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
            int horizontallyOrVertically = rdm.Next(1,3);
            int firstNumber = rdm.Next(1, 11);
            int secondNumber = rdm.Next(1, 11);

            //GameBoard.gameBoard[firstNumber, secondNumber] = " S";
            //int horizontallyOrVertically = 2;
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

            int horizontallyOrVertically = rdm.Next(1, 3);
            int firstNumber = 1;
            int secondNumber = 1;

            for ( ; ; )
            {
                firstNumber = rdm.Next(1, 11);
                secondNumber = rdm.Next(1, 11);

                if (GameBoard.gameBoard[firstNumber, secondNumber] != " S")
                {
                    GameBoard.gameBoard[firstNumber, secondNumber] = " S";
                    break;
                }
            }

            if (horizontallyOrVertically == 1)
            {
                if (10 - secondNumber > 3)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        GameBoard.gameBoard[firstNumber, secondNumber++] = " S";
                    }
                }

                else if (10 - secondNumber <= 3)
                {
                    for (int i = 0; i < 4; i++)
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
    }
}
