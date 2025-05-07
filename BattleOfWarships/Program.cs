using BattleOfWarships;
using System.Data;
using System.Data.Common;
using System.Runtime.CompilerServices;
using WarshipCombat;
using NAudio.Wave;
using static WarshipCombat.GamePlay;
using BattleOfWarships.Domain;

internal class Program
{
    private static void Main(string[] args)
    {
        //Menu.MainMenu();

        Menu.MainMenu();

        /*ShipDraw.FiveFlagships(GameBoard.gameBoard);
        ShipDraw.FourFlagships(GameBoard.gameBoard);
        ShipDraw.ThreeFlagships(GameBoard.gameBoard);
        ShipDraw.TwoFlagships(GameBoard.gameBoard);
        ShipDraw.TwoFlagshipsSecond(GameBoard.gameBoard);

        GameBoard.PrintArray(GameBoard.gameBoard);*/
    }
}