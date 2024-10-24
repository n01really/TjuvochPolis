namespace Tjuv_och_polis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Width = 70;
            int Height = 20;
            List<Citizen> citizens = GetList.Get_List(Width, Height);
            DrawMap.DrawBorder(Width, Height);

            while (true)
            {
                foreach (var Citizen in citizens)
                {
                    Console.SetCursorPosition(Citizen.X, Citizen.Y);
                    Console.Write(" ");

                    Citizen.X += Citizen.XDirection;
                    Citizen.Y += Citizen.YDirection;

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
                    Console.Write("M");
                }
                Thread.Sleep(200);
            }
        }
    }
}
