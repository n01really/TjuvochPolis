using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace Tjuv_och_polis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Width = 80;
            int Height = 20;

            int prisonWidth = 20;
            int prisonHeight = 10;

            int newsWidth = 80;
            int newsHeight = 5;

            Collition collition = new Collition();

            List<Person> persons = new List<Person>();
            Populate(Width, Height, persons);

            Menu.Title();
            Menu.Buttons();

            DrawMap.DrawBorder(0, 2, Width, Height);

            DrawMap.DrawBorder(Width + 2, 2, prisonWidth, prisonHeight);

            DrawMap.DrawBorder(0, Height + 2, newsWidth, newsHeight);

            while (true)
            {
                foreach (var Person in persons)
                {
                    Person.Move(Width, Height+2);

                    Console.SetCursorPosition(Person.X, Person.Y);
                    Console.Write(Person.GetCharacter());
                    Console.ResetColor();
                    collition.RobberCitizenCollition(persons, 1, Height + 3);
                }
                Thread.Sleep(100);
            }
        }

        public static void Populate(int width, int height, List<Person> persons)
        {
            Random rnd = new Random();

            for (int i = 0; i < 20; i++)
            {
                var rndPos = PositionsGenerate.GeneratePosition(width, height, rnd);
                persons.Add(new Citizen(rndPos.X, rndPos.Y, rndPos.XDirection, rndPos.YDirection, new List<Inventory>()));
                //Thread.Sleep(100);
            }

            for (int i = 0; i < 10; i++)
            {
                var rndPos = PositionsGenerate.GeneratePosition(width, height, rnd);
                persons.Add(new Robber(rndPos.X, rndPos.Y, rndPos.XDirection, rndPos.YDirection, new List<Inventory>(), prison: false));
                //Thread.Sleep(100);
            }

            for (int i = 0; i < 5; i++)
            {
                var rndPos = PositionsGenerate.GeneratePosition(width, height, rnd);
                persons.Add(new Cop(rndPos.X, rndPos.Y, rndPos.XDirection, rndPos.YDirection, new List<Inventory>()));
                //Thread.Sleep(100);
            }
        }
    }
}