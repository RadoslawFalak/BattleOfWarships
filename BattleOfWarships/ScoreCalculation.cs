using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarshipCombat
{
    internal class ScoreCalculation
    {
        public static int Calculation(int moves, int timeSeconds)
        {
            int result = 4000 - timeSeconds - moves;
            if (result < 10)
            {
                result = 10;
            }

            return result;
        }
    }
}
