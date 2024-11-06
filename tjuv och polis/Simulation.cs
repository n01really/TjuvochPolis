using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tjuv_och_polis
{
    internal class Simulation
    {
        private static int X = 0, Y = 2;
        private static int Width = 80, Height = 20;

        private static int prisonStartX = Width + 2;
        private static int prisonWidth = 20, prisonHeight = 10;

        private static int newsWidth = 80, newsHeight = 9;
        
        private static Collition collition = new Collition();
        public static void Run(List<Person>persons, bool isRunning)
        {
            Console.Clear();
            
            Menu.Title();

            //Rita staden
            DrawMap.DrawBorder(X, Y, Width, Height);
            //Rita fängelse
            DrawMap.DrawBorder(prisonStartX, Y, prisonWidth, prisonHeight);
            //Rita newsFeed
            DrawMap.DrawBorder(X, Height + Y, newsWidth, newsHeight);

            Console.SetCursorPosition(prisonStartX, 1);
            Console.Write("Fängelse");

            while (isRunning)
            {
                foreach (var Person in persons)
                {
                    if (Person is Robber robber && robber.Prison)
                    {
                        robber.Move(prisonStartX + 1, 3, prisonWidth, prisonHeight + 2);
                    }
                    else
                    {
                        Person.Move(1, 3, Width, Height + 2);
                    }

                    Console.SetCursorPosition(Person.X, Person.Y);
                    Console.Write(Person.GetCharacter());
                    Console.ResetColor();
                }
                Thread.Sleep(100);

                collition.CollitionManager(persons, 1, Height + 3, prisonStartX + 1, 3, prisonWidth, prisonHeight, Menu.reset);

                if (Console.KeyAvailable)
                {
                    Menu.Buttons(persons);
                }
            }
        }
    }
}
