using System;

namespace Tjuv_och_polis
{
    internal class DrawMap
    {
        public static void DrawBorder(int startX, int startY, int width, int height)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.SetCursorPosition(startX, startY);
            Console.Write("╔");
            for (int x = startX + 1; x < startX + width - 1; x++)
            {
                Console.SetCursorPosition(x, startY);
                Console.Write("═");
            }
            Console.SetCursorPosition(startX + width - 1, startY);
            Console.Write("╗");

            Console.SetCursorPosition(startX, startY + height - 1);
            Console.Write("╚");
            for (int x = startX + 1; x < startX + width - 1; x++)
            {
                Console.SetCursorPosition(x, startY + height - 1);
                Console.Write("═");
            }
            Console.SetCursorPosition(startX + width - 1, startY + height - 1);
            Console.Write("╝");

            for (int y = startY + 1; y < startY + height - 1; y++)
            {
                Console.SetCursorPosition(startX, y);
                Console.Write("║");
                Console.SetCursorPosition(startX + width - 1, y);
                Console.Write("║");
            }
        }
    }
}

