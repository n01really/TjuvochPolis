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
        }

        static bool isRunning = false;
        public static void Buttons()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[S] Start\t[P] Pause\t[R] Reset\t[Q] Exit");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\t\t\t  Fängelse");
            bool exit = false;
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.S:
                    StartSimulation();
                    break;
                case ConsoleKey.P:
                    PauseSimulation();
                    break;
                case ConsoleKey.Q:
                    exit = true;
                    Console.WriteLine("Exiting the simulation...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
                    break;
            }


            
        }
        static void StartSimulation()
        {
            if (isRunning)
            {
                Console.WriteLine("Simulation is already running.");
            }
            else
            {
                isRunning = true;
                Console.WriteLine("Starting the Cops and Robbers simulation...");
                // Simulation logic would go here.
            }
        }

        static void PauseSimulation()
        {
            if (isRunning)
            {
                isRunning = false;
                Console.WriteLine("Simulation is paused.");
                // Additional logic to handle the pause can go here.
            }
            else
            {
                Console.WriteLine("Simulation is not running.");
            }
        }

    }
}


