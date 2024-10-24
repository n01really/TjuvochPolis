namespace Tjuv_och_polis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Width = 70;
            int Height = 20;

            var rndPos = PositionsGenerate.GeneratePosition(Width, Height);
            List<Person> persons = new List<Person>();
            persons.Add(new Citizen(rndPos.X, rndPos.Y, rndPos.XDirection, rndPos.YDirection, new List<Inventory>()));

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
    }
}
