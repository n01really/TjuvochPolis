using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace Tjuv_och_polis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int X = 0, Y = 2;
            int Width = 80, Height = 20;

            int prisonStartX = Width + 2; 
            int prisonWidth = 20, prisonHeight = 10;

            int newsWidth = 80, newsHeight = 15;

            Collition collition = new Collition();

            List<Person> persons = new List<Person>();
            Populate(Width, Height, persons);

            Menu.Title();
            Menu.Buttons();

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
                    Person.Move(1, 3, Width, Height+2);

                    Console.SetCursorPosition(Person.X, Person.Y);
                    Console.Write(Person.GetCharacter());
                    Console.ResetColor();
                    collition.CollitionManager(persons, 1, Height + 3, prisonStartX + 1, 3,  prisonWidth, prisonHeight);
                }
                Thread.Sleep(1000);
            }
        }

        public static void Populate(int width, int height, List<Person> persons)
        {
            Random rnd = new Random();

            for (int i = 0; i < 20; i++)
            {
                var rndPos = PositionsGenerate.GeneratePosition(width, height, rnd);
                persons.Add(new Citizen(rndPos.X, rndPos.Y, rndPos.XDirection, rndPos.YDirection, new List<Inventory>
                {
                new Inventory("Wallet"),
                new Inventory("Watch"),
                new Inventory("Keys"),
                new Inventory("Phone")
                }));

            }

            for (int i = 0; i < 10; i++)
            {
                var rndPos = PositionsGenerate.GeneratePosition(width, height, rnd);
                persons.Add(new Robber(rndPos.X, rndPos.Y, rndPos.XDirection, rndPos.YDirection, new List<Inventory>(), prison: false));
            }

            for (int i = 0; i < 5; i++)
            {
                var rndPos = PositionsGenerate.GeneratePosition(width, height, rnd);
                persons.Add(new Cop(rndPos.X, rndPos.Y, rndPos.XDirection, rndPos.YDirection, new List<Inventory>()));
            }
        }
    }
}