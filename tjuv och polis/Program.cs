using System.Security.Cryptography.X509Certificates;

namespace Tjuv_och_polis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Width = 70;
            int Height = 20;

            List<Person> persons = new List<Person>();
            Populate(Width, Height, persons);

            DrawMap.DrawBorder(Width, Height);

            while (true)
            {
                foreach (var Person in persons)
                {
                    Person.Move(Width, Height);

                    Console.SetCursorPosition(Person.X, Person.Y);
                    Console.Write(Person.GetCharacter());
                    Console.ResetColor();
                }
                Thread.Sleep(200);
            }

            
        }

        public static void Populate(int width, int height, List<Person>persons)
        {
            

            //var rndPos = PositionsGenerate.GeneratePosition(width, height,rnd);
            for (int i = 0; i < 20; i++)
            {
                Random rnd = new Random(i);
                var rndPos = PositionsGenerate.GeneratePosition(width, height, rnd);
                
                persons.Add(new Citizen(rndPos.X, rndPos.Y, rndPos.XDirection, rndPos.YDirection, new List<Inventory>()));
                Thread.Sleep(100);
            }

            for (int i = 0; i < 10; i++)
            {
                Random rnd = new Random(i+2);
                var rndPos = PositionsGenerate.GeneratePosition(width, height, rnd);

                persons.Add(new Robber(rndPos.X, rndPos.Y, rndPos.XDirection, rndPos.YDirection, new List<Inventory>(), prison:false));
                Thread.Sleep(100);
            }

            for (int i = 0; i < 5; i++)
            {
                Random rnd = new Random(i+5);
                var rndPos = PositionsGenerate.GeneratePosition(width, height, rnd);

                persons.Add(new Cop(rndPos.X, rndPos.Y, rndPos.XDirection, rndPos.YDirection, new List<Inventory>()));
                Thread.Sleep(100);
            }
        }

    }
}
