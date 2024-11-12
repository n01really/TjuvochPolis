using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[S] Start\t[P] Pause\t[D] Data\t[R] Reset\t [Q] Exit ");
            Console.WriteLine();
        }

        private static string state;
        private static bool isRunning = false;
        public static bool reset = false;
        public static void Buttons(List<Person>persons)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.S:
                    state = "simulation";
                    Console.Clear();
                    isRunning = true;
                    Simulation.Run(persons,  isRunning);
                    break;
                case ConsoleKey.P:
                    if (state == "simulation")
                    {
                        PauseSimulation();
                    }
                    else if (state == "data")
                    {
                        Console.Clear();
                        Data.DataWindow(persons);
                    }
                    break;
                case ConsoleKey.D:
                    state = "data";
                    isRunning = false;
                    Data.DataWindow(persons);
                    break;
                case ConsoleKey.Q:
                    Environment.Exit(0);
                    break;
                case ConsoleKey.R:
                    reset = true;
                    Console.Clear();
                    Program.Main();
                    break;
                default:
                    if (state == "simulation")
                    {
                        Console.SetCursorPosition(20, 0);
                        Console.WriteLine("Fel knappval. Välj ett val i menyn!");
                        break;
                    }
                    if (state == "data")
                    {
                        Console.WriteLine("Fel knappval. Välj ett val i menyn!");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Data.DataWindow(persons);
                    }
                    break;
            } 
        }

        public static void PauseSimulation()
        {
            while (!Console.KeyAvailable)
            {
                Thread.Sleep(100);
            }
        }
    }
}


