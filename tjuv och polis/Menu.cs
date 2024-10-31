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
        public static void Buttons(List<Person>persons)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[S] Start\t[P] Pause\t[D] Data\t[R] Reset\t [Q] Exit");
            //Console.ForegroundColor = ConsoleColor.DarkGray;
            //Console.Write("\t\t\t  Fängelse");
            Console.WriteLine();
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.S:
                    Simulation.Run(persons);
                    //StartSimulation();
                    break;
                case ConsoleKey.P:
                    PauseSimulation();
                    break;
                case ConsoleKey.D:
                    break;
                case ConsoleKey.Q:
                    Environment.Exit(0);
                    break;
                case ConsoleKey.R:
                    Console.Clear();
                    Program.Main();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select S, P, or Q.");
                    Console.Clear();
                    Program.Main();
                    break;
            }


            
        }
        //static void StartSimulation()
        //{
        //    if (isRunning)
        //    {
        //        Console.WriteLine("Simulation is already running.");
        //    }
        //    else
        //    {
        //        isRunning = true;
        //        Console.WriteLine("Starting the Cops and Robbers simulation...");
        //        // Simulation logic would go here.
        //    }
        //}

        public static void PauseSimulation()
        {
            while (!Console.KeyAvailable)
            {
                Thread.Sleep(100);
            }
        }

    }
}


