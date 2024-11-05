using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace Tjuv_och_polis
{
    internal class Program
    {
        public static void Main()
        {
            int Width = 80, Height = 20;
            List<Person> persons = new List<Person>();
            Populate(Width, Height, persons);

            Menu.Title();
            Menu.Buttons(persons);

        }

        public static void Populate(int width, int height, List<Person> persons)
        {
            Random rnd = new Random();

            for (int i = 0; i < 20; i++)
            {
                var rndPos = PositionsGenerate.GeneratePosition(width, height, rnd);
                persons.Add(new Citizen(rndPos.X, rndPos.Y, rndPos.XDirection, rndPos.YDirection, new List<Inventory>
                {
                new Inventory("plonkan"),
                new Inventory("klockan"),
                new Inventory("nyklarna"),
                new Inventory("telefonen")
                }));
            }

            for (int i = 0; i < 10; i++)
            {
                var rndPos = PositionsGenerate.GeneratePosition(width, height, rnd);
                persons.Add(new Robber(rndPos.X, rndPos.Y, rndPos.XDirection, rndPos.YDirection, new List<Inventory>(), prison: false));
            }

            for (int i = 0; i < 30; i++)
            {
                var rndPos = PositionsGenerate.GeneratePosition(width, height, rnd);
                persons.Add(new Cop(rndPos.X, rndPos.Y, rndPos.XDirection, rndPos.YDirection, new List<Inventory>()));
            }
        }
    }
}