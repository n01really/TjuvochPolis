using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tjuv_och_polis
{
    internal class Data
    {
        public static void DataWindow(List<Person>persons)
        {
            Console.Clear();
            
            foreach (Person person in persons)
            {
                if (person is Citizen) { Console.ForegroundColor = ConsoleColor.Green; }
                if (person is Robber) { Console.ForegroundColor = ConsoleColor.Red; }
                if (person is Cop) { Console.ForegroundColor = ConsoleColor.Blue; }
                Console.Write($"{person} {person.Name}: ");
                Console.ForegroundColor = ConsoleColor.White;
                if (person.Items != null && person.Items.Count > 0)
                {
                    Console.Write("Innehav: ");
                    foreach (var item in person.Items)
                    {
                        Console.Write($"{item}, ");
                    }
                }
                else
                {
                    Console.Write("Inga föremål hittade.");
                }
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($" - Position: {person.X}:{person.Y}. Riktning: {person.XDirection}:{person.YDirection}");
                if (person is Robber robber)
                {
                    Console.WriteLine("Fängelsetid: " + robber.PrisonTime);
                }
                Console.WriteLine();
            }
            Menu.Title();
            Menu.Buttons(persons);
            //Console.ReadKey();
        }
    }
}
