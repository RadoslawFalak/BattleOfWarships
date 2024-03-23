using BattleOfWarships;
using System.Data;
using System.Data.Common;
using System.Runtime.CompilerServices;
using WarshipCombat;

internal class Program
{
    private static void Main(string[] args)
    {
        ShipDraw.FiveFlagships();
        ShipDraw.FourFlagships();
        GameBoard.GameBoardPrint();
    }
}