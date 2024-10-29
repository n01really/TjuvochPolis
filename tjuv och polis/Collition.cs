using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tjuv_och_polis
{
    internal class Collition
    {
        public void RobberCitizenCollition(List<Person> persons, int x, int y, int width, int height)
        {
            var robbers = persons.OfType<Robber>().ToList();
            var citizens = persons.OfType<Citizen>().ToList();

            bool robbery = false;

            foreach(var robber in robbers)
            {
                foreach(var citizen in citizens)
                {
                    if (robber.X == citizen.X && robber.Y == citizen.Y)
                    {
                        robbery = true; 
                    }
                }    
            }
            if (robbery)
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine("Medborgare blev rånad!");
            }
        }
    }
}
