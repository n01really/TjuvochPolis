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
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        if (i == 0 || i == Height - 1 || j == 0 || j == Width - 1)
                        {
                            Console.SetCursorPosition(i, j);
                            Console.Write("x");
                        }
                    }
                }
            }
    }
}
