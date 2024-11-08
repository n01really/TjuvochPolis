using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tjuv_och_polis
{
    internal class PositionsGenerate
    {
        //  Position and direction generator
        public static (int X, int Y, int XDirection, int YDirection) GeneratePosition(int Width, int Height, Random rnd)
        {
            int x = rnd.Next(2, Width - 2);
            int y = rnd.Next(4, Height - 2);
            int xDirection = rnd.Next(0, 2) == 0 ? -1 : 1;
            int yDirection = rnd.Next(0, 2) == 0 ? -1 : 1;
            return (x, y, xDirection, yDirection);
        }
    }
}
