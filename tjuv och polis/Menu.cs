using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tjuv_och_polis
{
    internal class Menu
    {
        public static void Title()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Tjuv ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("& ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Polis");
        }

        public static void Buttons()
        {
            Console.WriteLine();
            Console.ForegroundColor= ConsoleColor.White;
            Console.Write("[S] Start\t[P] Pause\t[R] Reset\t[Q] Exit");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\t\t\t  Fängelse");
        }
    }
}
