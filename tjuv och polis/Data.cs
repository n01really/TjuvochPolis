using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tjuv_och_polis
{
    internal class Data
    {
        public static void DataWindow(List<Person>persons, bool isRunning)
        {
            isRunning = false;
            Console.Clear();
            foreach (Person person in persons)
            {
                Console.Write($"{person} {person.Name}: ");
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
                Console.WriteLine($" - Position: { person.X}:{ person.Y}. Riktning: { person.XDirection}:{ person.YDirection}");
                if (person is Robber robber)
                { Console.WriteLine(robber.PrisonTime); }
            }
            Console.WriteLine();
            Menu.Title();
            Menu.Buttons(persons);
            Console.ReadKey();
        }
    }
}
