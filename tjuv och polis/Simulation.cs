using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tjuv_och_polis
{
    internal class Simulation
    {
        public static void Run(List<Person>persons)
        {
            int X = 0, Y = 2;
            int Width = 80, Height = 20;

            int prisonStartX = Width + 2;
            int prisonWidth = 20, prisonHeight = 10;

            int newsWidth = 80, newsHeight = 15;

            bool gameState = true;

            Collition collition = new Collition();

            Console.WriteLine();
            Console.WriteLine();

            //Rita staden
            DrawMap.DrawBorder(X, Y, Width, Height);
            //Rita fängelse
            DrawMap.DrawBorder(prisonStartX, Y, prisonWidth, prisonHeight);
            //Rita newsFeed
            DrawMap.DrawBorder(X, Height + Y, newsWidth, newsHeight);

            while (true)
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

                collition.CollitionManager(persons, 1, Height + 3, prisonStartX + 1, 3, prisonWidth, prisonHeight);
            }
        }
    }
}
