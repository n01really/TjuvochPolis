namespace Tjuv_och_polis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Width = 70;
            int Height = 20;

            var rndPos = PositionsGenerate.GeneratePosition(Width, Height);
            List<Citizen> citizens = new List<Citizen>();
            Citizen citizen = new Citizen(rndPos.X, rndPos.Y, rndPos.XDirection, rndPos.YDirection, new List<Inventory>());

            citizens.Add(citizen);
            DrawMap.DrawBorder(Width, Height);

            while (true)
            {
                foreach (var Citizen in citizens)
                {
                    Console.SetCursorPosition(Citizen.X, Citizen.Y);
                    Console.Write(" ");

                    Citizen.X += Citizen.XDirection;
                    Citizen.Y += Citizen.YDirection;

                    Citizen.X = Math.Clamp(Citizen.X, 1, Width - 2);
                    Citizen.Y = Math.Clamp(Citizen.Y, 1, Height - 2);


                    if (Citizen.X == Width - 2 || Citizen.X == 1)
                    {
                        Citizen.XDirection = -Citizen.XDirection;
                    }
                    if (Citizen.Y == Height - 2 || Citizen.Y == 1)
                    {
                        Citizen.YDirection = -Citizen.YDirection;
                    }
                }

                foreach (var Citizen in citizens)
                {
                    Console.SetCursorPosition(Citizen.X, Citizen.Y);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("M");
                    Console.ResetColor();
                }
                Thread.Sleep(200);
            }
        }
    }
}
