using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tjuv_och_polis
{
    internal class Collition
    {
        public void RobberCitizenCollition(List<Person> persons)
        {
            var robbers = persons.OfType<Robber>().ToList();
            var citizens = persons.OfType<Citizen>().ToList();

            foreach(var robber in robbers)
            {
                foreach(var citizen in citizens)
                {
                    if (robber.X == citizen.X && robber.Y == citizen.Y)
                    {

                        Console.WriteLine("Tjuv och Medborgare möttes");
                    }
                }    
            }
        }
    }
}
