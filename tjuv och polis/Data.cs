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
                Console.WriteLine($"{person.GetType()}:");
                if (person.Items != null && person.Items.Count > 0)
                {
                    foreach (var item in person.Items)
                    {
                        Console.Write($"{item}, ");
                    }
                }
                else
                {
                    Console.Write("No items found.");
                }
                Console.Write($"-Position: { person.X}:{ person.Y}, in the direction of: { person.XDirection}:{ person.YDirection}");
            }
            Console.WriteLine();
            Menu.Title();
            Menu.Buttons(persons);
            Console.ReadKey();
        }
    }
}
