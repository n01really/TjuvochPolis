using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tjuv_och_polis
{
    internal class DrawMap
    {
          public static void DrawBorder(int Height, int Width)
            {
                for (int i = 0; i < Width; i++)
                {
                    for (int j = 0; j < Height; j++)
                    {
                        if (i == 0 || i == Width - 1 || j == 0 || j == Height - 1)
                        {
                            Console.SetCursorPosition(i, j);
                            Console.Write("x");
                        }
                    }
                }
            }
    }
}
